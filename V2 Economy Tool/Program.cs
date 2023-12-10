using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace V2_Economy_Tool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_form());
        }

        public static bool Process_filepath(string filepath, out string goodspath, out string POPspath, out string production_typespath)
        {
            goodspath = POPspath = production_typespath = string.Empty;
            if (!Directory.Exists(filepath))
                return false;
            string goodslocation = @"\common\goods.txt", POPslocation = @"\poptypes", production_typeslocation = @"\common\production_types.txt", modtext = @"\mod\";
            if (File.Exists(filepath + goodslocation))
                goodspath = filepath + goodslocation;
            else if (filepath.Contains(modtext) && File.Exists(filepath.Substring(0, filepath.IndexOf(modtext)) + goodslocation))
                goodspath = filepath.Substring(0, filepath.IndexOf(modtext)) + goodslocation;
            else return false;
            if (Directory.Exists(filepath + POPslocation))
                POPspath = filepath + POPslocation;
            else if (filepath.Contains(modtext) && Directory.Exists(filepath.Substring(0, filepath.IndexOf(modtext)) + POPslocation))
                POPspath = filepath.Substring(0, filepath.IndexOf(modtext)) + POPslocation;
            else return false;
            if (File.Exists(filepath + production_typeslocation))
                production_typespath = filepath + production_typeslocation;
            else if (filepath.Contains(modtext) && File.Exists(filepath.Substring(0, filepath.IndexOf(modtext)) + production_typeslocation))
                production_typespath = filepath.Substring(0, filepath.IndexOf(modtext)) + production_typeslocation;
            else return false;
            return true;
        }

        public static List<Good> LoadGoods(string goodspath)
        {
            List<Good> goods = new List<Good>();
            using (StreamReader reader = new StreamReader(goodspath))
            {
                char[] ignore = { '=', '{', '}'};
                string currentline, temp = string.Empty, goodname = string.Empty;
                bool scopestart = false, costscope = false;
                int scope = 0;
                // scopes
                // 0 - general
                // 1 - good group
                // 2 - good
                // 3 - colors

                while (!reader.EndOfStream)
                {
                    currentline = reader.ReadLine();
                    if (!costscope) temp = string.Empty;
                    for (int i = 0; i < currentline.Length; i++)
                    {
                        switch (currentline[i])
                        {
                            case '#':
                                i = currentline.Length;
                                break;
                            case '\t':
                                break;
                            case ' ':
                                break;
                            case '=':
                                if (scope < 2)
                                {
                                    scopestart = true;
                                    if (scope == 1)
                                    {
                                        goodname = Trim(temp, ignore);
                                        temp = string.Empty;
                                    }
                                }
                                else if (scope == 2 && Trim(temp, ignore) == "cost")
                                {
                                    costscope = true;
                                    temp = string.Empty;
                                }
                                break;
                            case '{':
                                if (scope < 2)
                                {
                                    if (scopestart)
                                        scopestart = false;
                                    else throw new FileLoadException();
                                }
                                scope++;
                                goto default;
                            case '}':
                                scope--;
                                temp = string.Empty;
                                if (scope < 0) throw new FileLoadException();
                                goto default;
                            default:
                                if (scopestart) throw new FileLoadException();
                                if (scope > 0)
                                {
                                    if (costscope)
                                    {
                                        if (!char.IsNumber(currentline[i]))
                                        {
                                            if (currentline[i] != '.' || temp.Contains('.'))
                                            {
                                                costscope = false;
                                                goods.Add(new Good(goodname, decimal.Parse(temp)));
                                                temp = string.Empty;
                                            }
                                        }
                                    }
                                    temp += currentline[i];
                                }
                                break;
                        }
                    }
                }
            }
            return goods;
        }

        public static List<POP> LoadPOPs(string POPspath, List<Good> goods)
        {
            List<POP> pops = new List<POP>();
            string[] pop_files = Directory.GetFiles(POPspath);
            foreach (string pop_file_path in pop_files)
            {
                using (StreamReader reader = new StreamReader(pop_file_path))
                {
                    Dictionary<Good, decimal> life_needs = new Dictionary<Good, decimal>(), everyday_needs = new Dictionary<Good, decimal>(), luxury_needs = new Dictionary<Good, decimal>();
                    char[] ignore = { '=', '{', '}' };
                    string currentline, temp = string.Empty, goodname = string.Empty, name = pop_file_path.Split('\\').Last().Replace(".txt", "");
                    bool scopestart = false, amountscope = false, outputscope = false, outputamountscope = false, life_needs_done = false, everyday_needs_done = false, luxury_needs_done = false, life_needs_scope = false, everyday_needs_scope = false, luxury_needs_scope = false;
                    int scope = 0;
                    // scopes
                    // 0 - general
                    // 1 - rebel units, needs, migration mechanics, ideology, issues
                    //     anything higher than 1 should be either within migration mechanics, ideology or issues

                    while (!reader.EndOfStream && (!life_needs_done || !everyday_needs_done || !luxury_needs_done))
                    {
                        currentline = reader.ReadLine();
                        if (!amountscope && !outputamountscope && !outputscope) temp = string.Empty;
                        for (int i = 0; i < currentline.Length; i++)
                        {
                            switch (currentline[i])
                            {
                                case '#':
                                    i = currentline.Length;
                                    break;
                                case '\t':
                                    break;
                                case ' ':
                                    break;
                                case '=':
                                    if (scope == 0)
                                    {
                                        scopestart = true;
                                        string trimmed = Trim(temp, ignore);
                                        if (trimmed == "life_needs")
                                        {
                                            life_needs_scope = true;
                                            temp = string.Empty;
                                        }
                                        else if (trimmed == "everyday_needs")
                                        {
                                            everyday_needs_scope = true;
                                            temp = string.Empty;
                                        }
                                        else if (trimmed == "luxury_needs")
                                        {
                                            luxury_needs_scope = true;
                                            temp = string.Empty;
                                        }
                                    }
                                    else if (scope == 1 && (life_needs_scope || everyday_needs_scope || luxury_needs_scope))
                                    {
                                        amountscope = true;
                                        goodname = Trim(temp, ignore);
                                        temp = string.Empty;
                                    }
                                    break;
                                case '{':
                                    if (scope == 0)
                                    {
                                        if (scopestart) scopestart = false;
                                        else throw new FileLoadException();
                                    }
                                    scope++;
                                    goto default;
                                case '}':
                                    scope--;
                                    if (amountscope)
                                    {
                                        amountscope = false;
                                        if (life_needs_scope)
                                        {
                                            if (!life_needs.Keys.Contains(goods.Find(x => x.Name == goodname)))
                                                life_needs.Add(goods.Find(x => x.Name == goodname), decimal.Parse(temp));
                                            else
                                                life_needs[goods.Find(x => x.Name == goodname)] += decimal.Parse(temp);
                                            life_needs_scope = false;
                                            life_needs_done = true;
                                        }
                                        else if (everyday_needs_scope)
                                        {
                                            if (!everyday_needs.Keys.Contains(goods.Find(x => x.Name == goodname)))
                                                everyday_needs.Add(goods.Find(x => x.Name == goodname), decimal.Parse(temp));
                                            else
                                                everyday_needs[goods.Find(x => x.Name == goodname)] += decimal.Parse(temp);
                                            everyday_needs_scope = false;
                                            everyday_needs_done = true;
                                        }
                                        else if (luxury_needs_scope)
                                        {
                                            if (!luxury_needs.Keys.Contains(goods.Find(x => x.Name == goodname)))
                                                luxury_needs.Add(goods.Find(x => x.Name == goodname), decimal.Parse(temp));
                                            else
                                                luxury_needs[goods.Find(x => x.Name == goodname)] += decimal.Parse(temp);
                                            luxury_needs_scope = false;
                                            luxury_needs_done = true;
                                        }
                                    }
                                    else {
                                        if (life_needs_scope) {
                                            life_needs_scope = false;
                                            life_needs_done = true;
                                        }
                                        else if (everyday_needs_scope) {
                                            everyday_needs_scope = false;
                                            everyday_needs_done = true;
                                        }
                                        else if (luxury_needs_scope) {
                                            luxury_needs_scope = false;
                                            luxury_needs_done = true;
                                        }
                                    }

                                    temp = string.Empty;
                                    if (scope < 0) throw new FileLoadException();
                                    goto default;
                                default:
                                    //if (scopestart) throw new FileLoadException();
                                    if (amountscope)
                                    {
                                        if (!char.IsNumber(currentline[i]))
                                        {
                                            if (currentline[i] != '.' || temp.Contains('.'))
                                            {
                                                amountscope = false;
                                                if (life_needs_scope)
                                                {
                                                    if (!life_needs.Keys.Contains(goods.Find(x => x.Name == goodname)))
                                                        life_needs.Add(goods.Find(x => x.Name == goodname), decimal.Parse(temp));
                                                    else
                                                        life_needs[goods.Find(x => x.Name == goodname)] += decimal.Parse(temp);
                                                }
                                                else if (everyday_needs_scope)
                                                {
                                                    if (!everyday_needs.Keys.Contains(goods.Find(x => x.Name == goodname)))
                                                        everyday_needs.Add(goods.Find(x => x.Name == goodname), decimal.Parse(temp));
                                                    else
                                                        everyday_needs[goods.Find(x => x.Name == goodname)] += decimal.Parse(temp);
                                                }
                                                else if (luxury_needs_scope)
                                                {
                                                    if (!luxury_needs.Keys.Contains(goods.Find(x => x.Name == goodname)))
                                                        luxury_needs.Add(goods.Find(x => x.Name == goodname), decimal.Parse(temp));
                                                    else
                                                        luxury_needs[goods.Find(x => x.Name == goodname)] += decimal.Parse(temp);
                                                }
                                                temp = string.Empty;
                                            }
                                        }
                                    }
                                    temp += currentline[i];
                                    break;
                            }
                        }
                    }
                    pops.Add(new POP(name, life_needs, everyday_needs, luxury_needs));
                }
            }
            return pops;
        }

        public static List<Production_type> LoadProduction_types(string production_typespath, List<Good> goods)
        {
            List<Production_type> production_types = new List<Production_type>();
            List<Factory_template> templates = new List<Factory_template>();
            using (StreamReader reader = new StreamReader(production_typespath))
            {
                Dictionary<Good, decimal> inputs = new Dictionary<Good, decimal>();
                KeyValuePair<Good, decimal> output = new KeyValuePair<Good,decimal>();
                char[] ignore = { '=', '{', '}' };
                string currentline, temp = string.Empty, production_typename = string.Empty, template = string.Empty, goodname = string.Empty;
                bool scopestart = false, templatescope = false, inputscope = false, amountscope = false, outputscope = false, outputamountscope = false;
                int scope = 0;

                // scopes
                // 0 - general
                // 1 - production type
                // 2 - effiency, owner, employees, input_goods, output_goods, bonus
                // 3 - employee type, bonus trigger
                //     anything higher than 3 should be within a bonus trigger

                templates.Add(new Factory_template("artisans", new Dictionary<Good,decimal>()));

                while (!reader.EndOfStream)
                {
                    if (templatescope)
                    {
                        template = Trim(temp, ignore);
                        templatescope = false;
                    }
                    currentline = reader.ReadLine();
                    if (!amountscope && !outputamountscope && !outputscope) temp = string.Empty;
                    for (int i = 0; i < currentline.Length; i++)
                    {
                        switch (currentline[i])
                        {
                            case '#':
                                i = currentline.Length;
                                break;
                            case '\t':
                                break;
                            case ' ':
                                break;
                            case '=':
                                if (scope < 2)
                                {
                                    scopestart = true;
                                    if (scope == 0)
                                    {
                                        production_typename = Trim(temp, ignore);
                                        temp = string.Empty;
                                    }
                                    else if (scope == 1 && Trim(temp, ignore) == "template")
                                    {
                                        templatescope = true;
                                        temp = string.Empty;
                                    }
                                    else if ((scope == 1 && Trim(temp, ignore) == "input_goods") || (scope == 1 && Trim(temp, ignore) == "efficiency"))
                                    {
                                        inputscope = true;
                                        temp = string.Empty;
                                    }
                                    else if (scope == 1 && Trim(temp, ignore) == "output_goods")
                                    {
                                        outputscope = true;
                                        temp = string.Empty;
                                    }
                                    else if (scope == 1 && Trim(temp, ignore) == "value")
                                    {
                                        outputamountscope = true;
                                        temp = string.Empty;
                                    }
                                }
                                else if (scope == 2 && inputscope)
                                {
                                    amountscope = true;
                                    goodname = Trim(temp, ignore);
                                    temp = string.Empty;
                                }
                                break;
                            case '{':
                                if (scope < 2)
                                {
                                    if (scopestart) scopestart = false;
                                    else throw new FileLoadException();
                                }
                                scope++;
                                goto default;
                            case '}':
                                scope--;
                                if (amountscope)
                                {
                                    amountscope = false;
                                    inputs.Add(goods.Find(x => x.Name == goodname), decimal.Parse(temp));
                                }
                                temp = string.Empty;
                                if (inputscope) inputscope = false;
                                if (scope == 0)
                                {
                                    if (!template.StartsWith("RGO_template_"))
                                    {
                                        if (template == string.Empty)
                                        {
                                            if (production_typename.StartsWith("artisan_"))
                                                production_types.Add(new Production_type(production_typename, templates.First(x => x.Name == "artisans"), inputs, output));
                                            else templates.Add(new Factory_template(production_typename, inputs));
                                        }
                                        else production_types.Add(new Production_type(production_typename, templates.First(x => x.Name == template), inputs, output));
                                    }
                                    inputs = new Dictionary<Good, decimal>();
                                    template = string.Empty;
                                }
                                else if (scope < 0) throw new FileLoadException();
                                goto default;
                            default:
                                //if (scopestart) throw new FileLoadException();
                                if (amountscope)
                                {
                                    if (!char.IsNumber(currentline[i]))
                                    {
                                        if (currentline[i] != '.' || temp.Contains('.'))
                                        {
                                            amountscope = false;
                                            inputs.Add(goods.Find(x => x.Name == goodname), decimal.Parse(temp));
                                            temp = string.Empty;
                                        }
                                    }
                                }
                                else if (outputamountscope)
                                {
                                    if (!char.IsNumber(currentline[i]))
                                    {
                                        if (currentline[i] != '.' || temp.Contains('.'))
                                        {
                                            outputamountscope = false;
                                            output = new KeyValuePair<Good, decimal>(goods.Find(x => x.Name == goodname), decimal.Parse(temp));
                                            temp = string.Empty;
                                        }
                                    }
                                }
                                temp += currentline[i];
                                break;
                        }
                        if (outputscope)
                        {
                            if (!char.IsLetter(currentline[i]) && currentline[i] != '_' && temp != string.Empty)
                            {
                                goodname = Trim(temp, ignore);
                                outputscope = false;
                                temp = string.Empty;
                            }
                        }
                    }
                }
            }
            return production_types;
        }

        private static string Trim(string temp, char[] remove)
        {
            foreach (char item in remove)
            {
                temp = temp.Replace(item.ToString(), string.Empty);
            }
            return temp;
        }

        public static decimal Normalize(this decimal value)
        {
            return value / 1.000000000000000000000000000000000m;
        }
    }
}
