using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class Result
    {
        public int ErrorId { get; set; }
        private string errorMsg = null;
        public string ErrorMsg
        {
            get
            {
                return errorMsg;
            }
            set
            {
                errorMsg = TS3Helper.UnescapeString(value);
            }
        }
        public List<Dictionary<string, string>> ResultsList = new List<Dictionary<string, string>>();
        public string ResultString { get; set; }

        public string GetFirstResult(string key)
        {
            if (ResultsList.Count != 0)
                return GetResultByList(ResultsList.First(), key);
            return null;
        }

        public string GetResultByList(Dictionary<string, string> list, string key)
        {
            if (ResultsList.Count != 0)
            {
                string val;
                if (list.TryGetValue(key, out val))
                    return val;
            }
            return null;
        }
    }
}
