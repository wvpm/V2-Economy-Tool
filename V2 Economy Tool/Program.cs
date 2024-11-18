using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace V2_Economy_Tool {
	internal static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main() {
			System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";
			System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main_form());
		}

		public static bool Process_filepath(string filePath, out string goodsPath, out string POPspath, out string productionTypesPath) {
			goodsPath = POPspath = productionTypesPath = string.Empty;
			if (!Directory.Exists(filePath)) {
				return false;
			}

			string goodslocation = @"\common\goods.txt", popsLocation = @"\poptypes", productionTypesLocation = @"\common\production_types.txt", modText = @"\mod\";
			if (File.Exists(filePath + goodslocation)) {
				goodsPath = filePath + goodslocation;
			}
			else if (filePath.Contains(modText) && File.Exists(filePath.Substring(0, filePath.IndexOf(modText)) + goodslocation)) {
				goodsPath = filePath.Substring(0, filePath.IndexOf(modText)) + goodslocation;
			}
			else {
				return false;
			}

			if (Directory.Exists(filePath + popsLocation)) {
				POPspath = filePath + popsLocation;
			}
			else if (filePath.Contains(modText) && Directory.Exists(filePath.Substring(0, filePath.IndexOf(modText)) + popsLocation)) {
				POPspath = filePath.Substring(0, filePath.IndexOf(modText)) + popsLocation;
			}
			else {
				return false;
			}

			if (File.Exists(filePath + productionTypesLocation)) {
				productionTypesPath = filePath + productionTypesLocation;
			}
			else if (filePath.Contains(modText) && File.Exists(filePath.Substring(0, filePath.IndexOf(modText)) + productionTypesLocation)) {
				productionTypesPath = filePath.Substring(0, filePath.IndexOf(modText)) + productionTypesLocation;
			}
			else {
				return false;
			}

			return true;
		}

		public static IReadOnlyCollection<Good> LoadGoods(string goodsPath) {
			List<Good> goods = new List<Good>();
			using (StreamReader reader = new StreamReader(goodsPath)) {
				char[] ignore = { '=', '{', '}' };
				string currentLine, temp = string.Empty, goodName = string.Empty;
				bool isScopeStart = false, isCostScope = false;
				int scope = 0;
				// scopes
				// 0 - general
				// 1 - good group
				// 2 - good
				// 3 - colors

				while (!reader.EndOfStream) {
					currentLine = reader.ReadLine();
					if (!isCostScope) {
						temp = string.Empty;
					}

					for (int i = 0; i < currentLine.Length; i++) {
						switch (currentLine[i]) {
							case '#':
								i = currentLine.Length;
								break;
							case '\t':
								break;
							case ' ':
								break;
							case '=':
								if (scope < 2) {
									isScopeStart = true;
									if (scope == 1) {
										goodName = Trim(temp, ignore);
										temp = string.Empty;
									}
								}
								else if (scope == 2 && Trim(temp, ignore) == "cost") {
									isCostScope = true;
									temp = string.Empty;
								}
								break;
							case '{':
								if (scope < 2) {
									if (isScopeStart) {
										isScopeStart = false;
									}
									else {
										throw new FileLoadException();
									}
								}
								scope++;
								goto default;
							case '}':
								scope--;
								temp = string.Empty;
								if (scope < 0) {
									throw new FileLoadException();
								}

								goto default;
							default:
								if (isScopeStart) {
									throw new FileLoadException();
								}

								if (scope > 0) {
									if (isCostScope) {
										if (!char.IsNumber(currentLine[i])) {
											if (currentLine[i] != '.' || temp.Contains('.')) {
												isCostScope = false;
												goods.Add(new Good(goodName, decimal.Parse(temp)));
												temp = string.Empty;
											}
										}
									}
									temp += currentLine[i];
								}
								break;
						}
					}
				}
			}
			return goods;
		}

		public static IReadOnlyCollection<PopType> LoadPOPs(string popsPath, IReadOnlyCollection<Good> goods) {
			List<PopType> pops = new List<PopType>();
			string[] popFiles = Directory.GetFiles(popsPath);
			foreach (string popFilePath in popFiles) {
				using (StreamReader reader = new StreamReader(popFilePath)) {
					Dictionary<Good, decimal> lifeNeeds = new Dictionary<Good, decimal>(), everydayNeeds = new Dictionary<Good, decimal>(), luxuryNeeds = new Dictionary<Good, decimal>();
					char[] ignore = { '=', '{', '}' };
					Good good = null;
					string currentline, temp = string.Empty, name = popFilePath.Split('\\').Last().Replace(".txt", "");
					bool isScopeStart = false, isAmountScope = false, isOutputScope = false, isOutputAmountScope = false,
					hasDoneLifeNeeds = false, hasDoneEveryDayNeeds = false, hasDoneLuxuryGoods = false,
					isLifeNeedsScope = false, isEverydayNeedsScope = false, isLuxuryNeedsScope = false;
					int scope = 0;
					// scopes
					// 0 - general
					// 1 - rebel units, needs, migration mechanics, ideology, issues
					//     anything higher than 1 should be either within migration mechanics, ideology or issues

					while (!reader.EndOfStream && (!hasDoneLifeNeeds || !hasDoneEveryDayNeeds || !hasDoneLuxuryGoods)) {
						currentline = reader.ReadLine();
						if (!isAmountScope && !isOutputAmountScope && !isOutputScope) {
							temp = string.Empty;
						}

						for (int i = 0; i < currentline.Length; i++) {
							switch (currentline[i]) {
								case '#':
									i = currentline.Length;
									break;
								case '\t':
									break;
								case ' ':
									break;
								case '=':
									if (scope == 0) {
										isScopeStart = true;
										string trimmed = Trim(temp, ignore);
										if (trimmed == "life_needs") {
											isLifeNeedsScope = true;
											temp = string.Empty;
										}
										else if (trimmed == "everyday_needs") {
											isEverydayNeedsScope = true;
											temp = string.Empty;
										}
										else if (trimmed == "luxury_needs") {
											isLuxuryNeedsScope = true;
											temp = string.Empty;
										}
									}
									else if (scope == 1 && (isLifeNeedsScope || isEverydayNeedsScope || isLuxuryNeedsScope)) {
										isAmountScope = true;
										string goodName = Trim(temp, ignore);
										good = goods.Single(x => x.Name == goodName);
										temp = string.Empty;
									}
									break;
								case '{':
									if (scope == 0) {
										if (isScopeStart) {
											isScopeStart = false;
										}
										else {
											throw new FileLoadException();
										}
									}
									scope++;
									goto default;
								case '}':
									scope--;
									if (isAmountScope) {
										isAmountScope = false;
										if (isLifeNeedsScope) {
											if (!lifeNeeds.Keys.Contains(good)) {
												lifeNeeds.Add(good, decimal.Parse(temp));
											}
											else {
												lifeNeeds[good] += decimal.Parse(temp);
											}

											isLifeNeedsScope = false;
											hasDoneLifeNeeds = true;
										}
										else if (isEverydayNeedsScope) {
											if (!everydayNeeds.Keys.Contains(good)) {
												everydayNeeds.Add(good, decimal.Parse(temp));
											}
											else {
												everydayNeeds[good] += decimal.Parse(temp);
											}

											isEverydayNeedsScope = false;
											hasDoneEveryDayNeeds = true;
										}
										else if (isLuxuryNeedsScope) {
											if (!luxuryNeeds.Keys.Contains(good)) {
												luxuryNeeds.Add(good, decimal.Parse(temp));
											}
											else {
												luxuryNeeds[good] += decimal.Parse(temp);
											}

											isLuxuryNeedsScope = false;
											hasDoneLuxuryGoods = true;
										}
									}
									else {
										if (isLifeNeedsScope) {
											isLifeNeedsScope = false;
											hasDoneLifeNeeds = true;
										}
										else if (isEverydayNeedsScope) {
											isEverydayNeedsScope = false;
											hasDoneEveryDayNeeds = true;
										}
										else if (isLuxuryNeedsScope) {
											isLuxuryNeedsScope = false;
											hasDoneLuxuryGoods = true;
										}
									}

									temp = string.Empty;
									if (scope < 0) {
										throw new FileLoadException();
									}

									goto default;
								default:
									if (isAmountScope) {
										if (!char.IsNumber(currentline[i])) {
											if (currentline[i] != '.' || temp.Contains('.')) {
												isAmountScope = false;
												if (isLifeNeedsScope) {
													if (!lifeNeeds.Keys.Contains(good)) {
														lifeNeeds.Add(good, decimal.Parse(temp));
													}
													else {
														lifeNeeds[good] += decimal.Parse(temp);
													}
												}
												else if (isEverydayNeedsScope) {
													if (!everydayNeeds.Keys.Contains(good)) {
														everydayNeeds.Add(good, decimal.Parse(temp));
													}
													else {
														everydayNeeds[good] += decimal.Parse(temp);
													}
												}
												else if (isLuxuryNeedsScope) {
													if (!luxuryNeeds.Keys.Contains(good)) {
														luxuryNeeds.Add(good, decimal.Parse(temp));
													}
													else {
														luxuryNeeds[good] += decimal.Parse(temp);
													}
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
					pops.Add(new PopType(name, lifeNeeds, everydayNeeds, luxuryNeeds));
				}
			}
			return pops;
		}

		public static IReadOnlyCollection<ProductionType> LoadProduction_types(string production_typespath, IReadOnlyCollection<Good> goods) {
			List<ProductionType> production_types = new List<ProductionType>();
			List<FactoryTemplate> templates = new List<FactoryTemplate>();
			using (StreamReader reader = new StreamReader(production_typespath)) {
				Dictionary<Good, decimal> inputs = new Dictionary<Good, decimal>();
				KeyValuePair<Good, decimal> output = new KeyValuePair<Good, decimal>();
				char[] ignore = { '=', '{', '}' };
				string currentLine, temp = string.Empty, productionTypeName = string.Empty, template = string.Empty;
				Good good = null;
				bool isScopeStart = false, isTemplateScope = false, isInputScope = false, isAmountScope = false, isOutputScope = false, isOutputAmountScope = false;
				int scope = 0;

				// scopes
				// 0 - general
				// 1 - production type
				// 2 - effiency, owner, employees, input_goods, output_goods, bonus
				// 3 - employee type, bonus trigger
				//     anything higher than 3 should be within a bonus trigger
				const string artisansTemplateName = "artisan";
				templates.Add(new FactoryTemplate(artisansTemplateName, new Dictionary<Good, decimal>()));

				while (!reader.EndOfStream) {
					if (isTemplateScope) {
						template = Trim(temp, ignore);
						isTemplateScope = false;
					}
					currentLine = reader.ReadLine();
					if (!isAmountScope && !isOutputAmountScope && !isOutputScope) {
						temp = string.Empty;
					}

					for (int i = 0; i < currentLine.Length; i++) {
						switch (currentLine[i]) {
							case '#':
								i = currentLine.Length;
								break;
							case '\t':
								break;
							case ' ':
								break;
							case '=':
								if (scope < 2) {
									isScopeStart = true;
									if (scope == 0) {
										productionTypeName = Trim(temp, ignore);
										temp = string.Empty;
									}
									else if (scope == 1 && Trim(temp, ignore) == "template") {
										isTemplateScope = true;
										temp = string.Empty;
									}
									else if ((scope == 1 && Trim(temp, ignore) == "input_goods") || (scope == 1 && Trim(temp, ignore) == "efficiency")) {
										isInputScope = true;
										temp = string.Empty;
									}
									else if (scope == 1 && Trim(temp, ignore) == "output_goods") {
										isOutputScope = true;
										temp = string.Empty;
									}
									else if (scope == 1 && Trim(temp, ignore) == "value") {
										isOutputAmountScope = true;
										temp = string.Empty;
									}
								}
								else if (scope == 2 && isInputScope) {
									isAmountScope = true;
									string goodName = Trim(temp, ignore);
									good = goods.Single(x => x.Name == goodName);
									temp = string.Empty;
								}
								break;
							case '{':
								if (scope < 2) {
									if (isScopeStart) {
										isScopeStart = false;
									}
									else {
										throw new FileLoadException();
									}
								}
								scope++;
								goto default;
							case '}':
								scope--;
								if (isAmountScope) {
									isAmountScope = false;
									inputs.Add(good, decimal.Parse(temp));
								}
								temp = string.Empty;
								if (isInputScope) {
									isInputScope = false;
								}

								if (scope == 0) {
									if (!template.StartsWith("RGO_template_")) {
										if (template == string.Empty) {
											if (productionTypeName.StartsWith(artisansTemplateName + '_')) {
												production_types.Add(new ProductionType(productionTypeName, templates.Single(x => x.Name == artisansTemplateName), inputs, output));
											}
											else {
												templates.Add(new FactoryTemplate(productionTypeName, inputs));
											}
										}
										else {
											production_types.Add(new ProductionType(productionTypeName, templates.Single(x => x.Name == template), inputs, output));
										}
									}
									inputs = new Dictionary<Good, decimal>();
									template = string.Empty;
								}
								else if (scope < 0) {
									throw new FileLoadException();
								}

								goto default;
							default:
								if (isAmountScope) {
									if (!char.IsNumber(currentLine[i])) {
										if (currentLine[i] != '.' || temp.Contains('.')) {
											isAmountScope = false;
											inputs.Add(good, decimal.Parse(temp));
											temp = string.Empty;
										}
									}
								}
								else if (isOutputAmountScope) {
									if (!char.IsNumber(currentLine[i])) {
										if (currentLine[i] != '.' || temp.Contains('.')) {
											isOutputAmountScope = false;
											output = new KeyValuePair<Good, decimal>(good, decimal.Parse(temp));
											temp = string.Empty;
										}
									}
								}
								temp += currentLine[i];
								break;
						}
						if (isOutputScope) {
							if (!char.IsLetter(currentLine[i]) && currentLine[i] != '_' && temp != string.Empty) {
								string goodName = Trim(temp, ignore);
								good = goods.Single(x => x.Name == goodName);
								isOutputScope = false;
								temp = string.Empty;
							}
						}
					}
				}
			}
			return production_types;
		}

		private static string Trim(string temp, char[] remove) {
			foreach (char item in remove) {
				temp = temp.Replace(item.ToString(), string.Empty);
			}
			return temp;
		}

		public static decimal Normalize(this decimal value) {
			return value / 1.000000000000000000000000000000000m;
		}
	}
}