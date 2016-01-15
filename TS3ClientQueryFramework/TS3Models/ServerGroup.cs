using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class ServerGroup
    {
        public int SgId { get; set; }
        private string name = null;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = TS3Helper.UnescapeString(value);
            }
        }
        public int Type { get; set; }
        public ulong IconId { get; set; }
        public int SaveDb { get; set; }
        public int SortId { get; set; }
        public int NameMode { get; set; }
        public int NModifyP { get; set; }
        public int NMemberAddP { get; set; }
        public int NMemberRemoveP { get; set; }

        public Result Result { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public ServerGroup FillWithResult(Result result)
        {
            return FillWithResult(result, result.ResultsList.First());
        }

        public ServerGroup FillWithResult(Result result, Dictionary<string, string> list)
        {
            if (result.GetResultByList(list, ServerGroupProperties.sgid.ToString()) != null)
                this.SgId = Convert.ToInt32(result.GetResultByList(list, ServerGroupProperties.sgid.ToString()));
            if (result.GetResultByList(list, ServerGroupProperties.name.ToString()) != null)
                this.Name = result.GetResultByList(list, ServerGroupProperties.name.ToString());
            if (result.GetResultByList(list, ServerGroupProperties.type.ToString()) != null)
                this.Type = Convert.ToInt32(result.GetResultByList(list, ServerGroupProperties.type.ToString()));
            if (result.GetResultByList(list, ServerGroupProperties.iconid.ToString()) != null)
                this.IconId = Convert.ToUInt64(result.GetResultByList(list, ServerGroupProperties.iconid.ToString()));
            if (result.GetResultByList(list, ServerGroupProperties.savedb.ToString()) != null)
                this.SaveDb = Convert.ToInt32(result.GetResultByList(list, ServerGroupProperties.savedb.ToString()));
            if (result.GetResultByList(list, ServerGroupProperties.sortid.ToString()) != null)
                this.SortId = Convert.ToInt32(result.GetResultByList(list, ServerGroupProperties.sortid.ToString()));
            if (result.GetResultByList(list, ServerGroupProperties.namemode.ToString()) != null)
                this.NameMode = Convert.ToInt32(result.GetResultByList(list, ServerGroupProperties.namemode.ToString()));
            if (result.GetResultByList(list, ServerGroupProperties.n_modifyp.ToString()) != null)
                this.NModifyP = Convert.ToInt32(result.GetResultByList(list, ServerGroupProperties.n_modifyp.ToString()));
            if (result.GetResultByList(list, ServerGroupProperties.n_member_addp.ToString()) != null)
                this.NMemberAddP = Convert.ToInt32(result.GetResultByList(list, ServerGroupProperties.n_member_addp.ToString()));
            if (result.GetResultByList(list, ServerGroupProperties.n_member_removep.ToString()) != null)
                this.NMemberRemoveP = Convert.ToInt32(result.GetResultByList(list, ServerGroupProperties.n_member_removep.ToString()));
            this.Result = result;
            return this;
        }
    }
}
