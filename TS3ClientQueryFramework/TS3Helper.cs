using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TS3ClientQueryFramework
{
    public class TS3Helper
    {
        private static Regex errorRegex = new Regex(@"error id=(\d) msg=(.+)");
        private static Regex paramRegex = new Regex(@"(.+)=(.+)");

        public static TS3Models.Result ParseResult(string resultString, bool isMany)
        {
            if (!string.IsNullOrEmpty(resultString))
            {
                TS3Models.Result result = new TS3Models.Result();
                result.ResultString = resultString;

                Match errorMatch = errorRegex.Match(resultString);
                if (errorMatch.Success)
                {
                    result.ErrorId = Convert.ToInt32(errorMatch.Groups[1].Value);
                    result.ErrorMsg = errorMatch.Groups[2].Value;
                    resultString = errorRegex.Replace(resultString, "");
                }

                string[] manyResults;
                if (isMany)
                    manyResults = resultString.Split('|');
                else
                {
                    if (resultString.Contains('|'))
                        throw new Exception("Illegal separation found");
                    manyResults = new string[] { resultString };
                }

                foreach (string mr in manyResults)
                {
                    Dictionary<string, string> resl = new Dictionary<string, string>();
                    string[] paramSplit = mr.Split(' ');
                    foreach (string pa in paramSplit)
                    {
                        Match paramMatch = paramRegex.Match(pa);
                        if (paramMatch.Success)
                        {
                            resl.Add(paramMatch.Groups[1].Value, paramMatch.Groups[2].Value);
                        }
                    }
                    result.ResultsList.Add(resl);
                }

                return result;
            }
            return null;
        }

        public static string UnescapeString(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text.Replace(@"\s", " ").Replace(@"\p", "|").Replace(@"\\", @"\").Replace(@"\/", "/");
            }
            return null;
        }

        public static string EscapeString(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text.Replace(@"\", @"\\").Replace("/", @"\/").Replace(" ", @"\s").Replace("|", @"\p");
            }
            return null;
        }

        public static string StringSeperatedList(string key, List<object> list)
        {
            if(!string.IsNullOrEmpty(key) && list != null)
            {
                string output = string.Empty;
                foreach (object obj in list)
                {
                    output += string.Format("{0}={1}|", key, obj.ToString());
                }
                return output.Remove(output.Length - 1);
            }
            return null;
        }
    }
}
