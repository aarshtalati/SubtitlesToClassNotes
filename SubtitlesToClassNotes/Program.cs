using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SubtitlesToClassNotes
{
	class Program
	{
		static void Main(string[] args)
		{
			// Configurations

			string basePath = "C:\\Data\\sub";
			bool condensed = true;

			// Actual Program

			string srtLines;
			string searchPattern = "*.srt";

			List<string> directories = new List<string>();
			List<string> srtFilesInCurrentDirectory = new List<string>();

			DirectoryInfo[] diArr = null;
			FileInfo[] files = null;
			DirectoryInfo di = null;

			StringBuilder stringBuilder = new StringBuilder();

			Regex extractTextRegularExpression = new Regex(@"(?<Order>\d+)\r\n(?<StartTime>(\d\d:){2}\d\d,\d{3}) --> (?<EndTime>(\d\d:){2}\d\d,\d{3})\r\n(?<Sub>.+)(?=\r\n\r\n\d+|$)");

			// Make a reference to a directory.
			di = new DirectoryInfo(basePath);

			// Get a reference to each directory in that directory.
			diArr = di.GetDirectories();

			foreach (DirectoryInfo dri in diArr)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine(dri.Name);
				stringBuilder.Append(Environment.NewLine + Environment.NewLine + Environment.NewLine + dri.Name + Environment.NewLine + Environment.NewLine + Environment.NewLine);
				Console.ResetColor();

				files = dri.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);

				foreach (var file in files)
				{
					// if you notice any offset in the speech and sub-titles, this should let you fix it

					int sequence = 1;
					double offset = 0;

					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("\t" + file.Name);
					stringBuilder.Append(Environment.NewLine + Environment.NewLine + file.Name + Environment.NewLine + Environment.NewLine);
					Console.ResetColor();

					try
					{   // Open the text file using a stream reader.
						using (var sr = new StreamReader(file.FullName, Encoding.Default))
						{
							srtLines = sr.ReadToEnd();

							string extractedContent = extractTextRegularExpression.Replace(srtLines, delegate(Match m)
							{
								return m.Value.Replace(
									String.Format("{0}\r\n{1} --> {2}\r\n",
										m.Groups["Order"].Value,
										m.Groups["StartTime"].Value,
										m.Groups["EndTime"].Value),
									String.Format(
										" " +
										"",
										sequence++,
										DateTime.Parse(m.Groups["StartTime"].Value.Replace(",", "."))
												.AddSeconds(offset),
										DateTime.Parse(m.Groups["EndTime"].Value.Replace(",", "."))
												.AddSeconds(offset)));
							});

							if(condensed)
							{
								extractedContent = extractedContent.Replace("\n", "").Replace("\r", "");
							}

							stringBuilder.Append(extractedContent);
							
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("The file could not be read:");
						Console.WriteLine(e.Message);
					}

					Console.WriteLine("... Done");
				}
			}
			File.WriteAllText(basePath + "\\Notes.txt", stringBuilder.ToString());
		}
	}
}
