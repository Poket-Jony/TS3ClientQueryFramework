using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ClientQueryFramework.TS3Models
{
    public class ClientMoved
    {
        public Channel Channel { get; set; }
        public int ReasonId { get; set; }
        public Client Invoker { get; set; }
        public List<Client> Clients { get; set; } = new List<Client>();

        public Result Result { get; set; }
    }
}
