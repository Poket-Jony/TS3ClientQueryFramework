using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TS3ClientQueryFramework
{
    internal class TS3Helper
    {
        private static Regex errorRegex = new Regex(@"error id=(\d+) msg=(.+)");
        private static Regex paramRegex = new Regex(@"(.+)=(.+)");

        internal static TS3Models.Result ParseResult(string resultString, bool isMany)
        {
            if (!string.IsNullOrEmpty(resultString))
            {
                TS3Models.Result result = new TS3Models.Result();
                result.ResultString = resultString;

                Match errorMatch = errorRegex.Match(resultString);
                if (errorMatch.Success)
                {
                    result.ErrorId = Convert.ToInt32(errorMatch.Groups[1].Value);
                    result.ErrorMsg = UnescapeString(errorMatch.Groups[2].Value);
                    resultString = errorRegex.Replace(resultString, "");
                }
                
                if(!string.IsNullOrEmpty(resultString))
                    result.ResultsList = GetParamList(resultString, isMany);
                return result;
            }
            return null;
        }

        private static List<Dictionary<string, string>> GetParamList(string input, bool isMany, char paramSplitter = ' ')
        {
            List<Dictionary<string, string>> resultsList = new List<Dictionary<string, string>>();

            if (!string.IsNullOrEmpty(input))
                return resultsList;

            string[] manyResults;
            if (isMany)
                manyResults = input.Split('|');
            else
            {
                if (input.Contains('|'))
                    throw new Exception("Illegal separation found");
                manyResults = new string[] { input };
            }

            foreach (string mr in manyResults)
            {
                Dictionary<string, string> resl = new Dictionary<string, string>();
                string[] paramSplit = mr.Split(paramSplitter);
                foreach (string pa in paramSplit)
                {
                    Match paramMatch = paramRegex.Match(pa);
                    if (paramMatch.Success)
                    {
                        resl.Add(paramMatch.Groups[1].Value, paramMatch.Groups[2].Value);
                    }
                }
                resultsList.Add(resl);
            }
            return resultsList;
        }

        internal static string UnescapeString(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text.Replace(@"\s", " ").Replace(@"\p", "|").Replace(@"\\", @"\").Replace(@"\/", "/");
            }
            return null;
        }

        internal static string EscapeString(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return text.Replace(@"\", @"\\").Replace("/", @"\/").Replace(" ", @"\s").Replace("|", @"\p");
            }
            return null;
        }

        internal static string GetSeperatedParamStringList(string key, List<object> list)
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

        internal static Dictionary<string, string> GetSeperatedParamList(string list)
        {
            if (!string.IsNullOrEmpty(list))
            {
                return GetParamList(list, false, '|').First();
            }
            return null;
        }

        internal static List<string> GetSeperatedList(string list, char seperator = ',')
        {
            if (!string.IsNullOrEmpty(list))
            {
                return list.Split(seperator).ToList();
            }
            return null;
        }

        internal static string GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
