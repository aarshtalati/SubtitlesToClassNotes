using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace SubtitlesToClassNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* ~~~ Application specific configurations start ~~~ */

            String basePath = @"/home/atalati/Documents/notes/1. Game Playing Subtitles"; // change path accordingly
            String outputFullFileName = basePath + "/Notes.txt";
            bool verboseLogging = false;
            bool ignoreWarnings = false;

            /* ~~~ Application specific configurations end ~~~ */

            string srtLines;
            string searchPattern = "*.srt";

            List<string> directories = new List<string>();
            List<string> srtFilesInCurrentDirectory = new List<string>();

            DirectoryInfo[] diArr = null;
            FileInfo[] files = null;
            DirectoryInfo di = null;

            StringBuilder stringBuilder = new StringBuilder();

            Regex extractTextRegularExpression1 = new Regex(@"(?<Order>\d+)(\r\n)*(?<StartTime>(\d\d:){2}\d\d,\d{3}) --> (?<EndTime>(\d\d:){2}\d\d,\d{3})(\r\n)*");
            Regex extractTextRegularExpression2 = new Regex(@"(?<Order>\d+)\n(?<StartTime>(\d\d:){2}\d\d,\d{3}) --> (?<EndTime>(\d\d:){2}\d\d,\d{3})\n(?<Sub>.+)\n");
            Regex extractTextRegularExpression3 = new Regex(@"(?<Order>\d+)\n(?<StartTime>(\d\d:){2}\d\d,\d{3}) --> (?<EndTime>(\d\d:){2}\d\d,\d{3})\n(?<Sub>.+)\n\n");
            Regex extractTextRegularExpression4 = new Regex(@"(?<StartTime>(\d\d:){2}\d\d,\d{3}),(?<EndTime>(\d\d:){2}\d\d,\d{3})\r\n(?<Sub>.+)\r\n\r");
            Regex extractTextRegularExpression5 = new Regex(@"(?<StartTime>(\d{1,2}:){2}\d\d.\d{3}),(?<EndTime>(\d{1,2}:){2}\d\d.\d{3})(?<Sub>.+)");

            // Make a reference to a directory.
            di = new DirectoryInfo(basePath);

            if (di.GetFiles("*.srt").Count() > 0)
            {
                diArr = new DirectoryInfo[] { di };
            }
            else
            {

                // Get a reference to each directory in that directory.
                diArr = di.GetDirectories();
                diArr = diArr.AsEnumerable().OrderByAlphaNumeric(x => x.Name).ToArray();
            }

            foreach (DirectoryInfo dri in diArr)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(dri.Name.ToUpper());
                stringBuilder.Append(
                    Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                    String.Join("", Enumerable.Range(0, dri.Name.Length).Select(x => "=")) +
                     Environment.NewLine +
                    dri.Name.ToUpperInvariant() + Environment.NewLine +
                    String.Join("", Enumerable.Range(0, dri.Name.Length).Select(x => "=")) +
                    Environment.NewLine + Environment.NewLine + Environment.NewLine);
                Console.ResetColor();

                files = dri.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);

                files = files.AsEnumerable().OrderByAlphaNumeric(x => x.Name).ToArray();

                string extractedContent = null;

                foreach (var file in files)
                {
                    // if you notice any offset in the speech and sub-titles, this should let you fix it
                    // int sequence = 1;
                    // double offset = 0;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t" + file.Name);
                    stringBuilder.Append(
                        Environment.NewLine + Environment.NewLine + Environment.NewLine +
                        file.Name + " (" + dri.Name + ")" + Environment.NewLine +
                        String.Join("", Enumerable.Range(0, file.Name.Length + dri.Name.Length + 4).Select(x => ".")) +
                        Environment.NewLine + Environment.NewLine + Environment.NewLine);
                    Console.ResetColor();

                    try
                    {   // Open the text file using a stream reader.
                        using (var sr = new StreamReader(file.FullName, Encoding.Default))
                        {
                            srtLines = sr.ReadToEnd();

                            if (extractTextRegularExpression1.IsMatch(srtLines))
                            {
                                if (verboseLogging)
                                {
                                    stringBuilder.Append(" ( ~~~ 1 ~~~ ) ");
                                }

                                extractedContent = extractTextRegularExpression1.Replace(srtLines, delegate (Match m)
                                {
                                    return m.Value.Replace(
                                            String.Format("{0}\r\n{1} --> {2}\r\n",
                                            m.Groups["Order"].Value,
                                            m.Groups["StartTime"].Value,
                                            m.Groups["EndTime"].Value),

                                        " ");
                                });
                            }

                            else if (extractTextRegularExpression2.IsMatch(srtLines))
                            {
                                if (verboseLogging)
                                {
                                    stringBuilder.Append(" ( ~~~ 2 ~~~ ) ");
                                }

                                extractedContent = extractTextRegularExpression2.Replace(srtLines, delegate (Match m)
                                {
                                    return m.Value.Replace(
                                            String.Format("{0}\n{1} --> {2}",
                                            m.Groups["Order"].Value,
                                            m.Groups["StartTime"].Value,
                                            m.Groups["EndTime"].Value),
                                            "");
                                });
                            }

                            else if (extractTextRegularExpression3.IsMatch(srtLines))
                            {
                                if (verboseLogging)
                                {
                                    stringBuilder.Append(" ( ~~~ 3 ~~~ ) ");
                                }

                                extractedContent = extractTextRegularExpression3.Replace(srtLines, delegate (Match m)
                                {
                                    return m.Value.Replace(
                                            String.Format("{0}\n{1} --> {2}\n",
                                            m.Groups["Order"].Value,
                                            m.Groups["StartTime"].Value,
                                            m.Groups["EndTime"].Value),
                                            " ").Replace(
                                            String.Format("{0}{1} --> {2}\n",
                                            m.Groups["Order"].Value,
                                            m.Groups["StartTime"].Value,
                                            m.Groups["EndTime"].Value),
                                            " ")
                                            .Replace(
                                            String.Format("{0}{1} --> {2}",
                                            m.Groups["Order"].Value,
                                            m.Groups["StartTime"].Value,
                                            m.Groups["EndTime"].Value),
                                            " ");
                                });
                            }

                            else if (extractTextRegularExpression4.IsMatch(srtLines))
                            {
                                if (verboseLogging)
                                {
                                    stringBuilder.Append(" ( ~~~ 4 ~~~ ) ");
                                }

                                extractedContent = extractTextRegularExpression4.Replace(srtLines, delegate (Match m)
                                {
                                    return m.Value.Replace(
                                            String.Format("{0},{1}\r\n",
                                            m.Groups["StartTime"].Value,
                                            m.Groups["EndTime"].Value),
                                            " ");
                                });
                            }

                            else if (extractTextRegularExpression5.IsMatch(srtLines))
                            {
                                if (verboseLogging)
                                {
                                    stringBuilder.Append(" ( ~~~ 5 ~~~ ) ");
                                }

                                extractedContent = extractTextRegularExpression5.Replace(srtLines, delegate (Match m)
                                {
                                    return m.Value.Replace(
                                            String.Format("{0},{1}",
                                            m.Groups["StartTime"].Value,
                                            m.Groups["EndTime"].Value),
                                            " ");
                                });
                            }

                            else
                            {
                                if (!ignoreWarnings)
                                {
                                    stringBuilder.Append(" ( ~~~ WARNING : POSSIBLE UNKNOWN PATTERN DETECTION ~~~ ) ");
                                }
                                stringBuilder.Append(srtLines);
                            }

                            extractedContent = extractedContent
                                                .Replace("\n", " ")
                                                .Replace("\r", " ")
                                                .Replace("   ", " ")
                                                .Replace("  ", " ")
                                                .Trim();

                            stringBuilder.Append(extractedContent);
                            extractedContent = "";
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

            stringBuilder = stringBuilder.Replace(">>", "").Replace("  ", " ").Replace("&gt;", "");

            File.WriteAllText(outputFullFileName, stringBuilder.ToString());
        }

    }

    public static class extensions
    {
        // courtesy: https://stopbyte.com/t/how-to-make-natural-sort-order-in-c/68
        public static IEnumerable<T> OrderByAlphaNumeric<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            int max = source.SelectMany(i => Regex.Matches(selector(i), @"\d+").Cast<Match>().Select(m => (int?)m.Value.Length)).Max() ?? 0;
            return source.OrderBy(i => Regex.Replace(selector(i), @"\d+", m => m.Value.PadLeft(max, '0')));
        }
    }
}
