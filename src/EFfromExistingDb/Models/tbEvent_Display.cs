using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFfromExistingDb.Models
{
    public class tbEvent_Display
    {
        public int idEvent { get; set; }
        public DateTime dtLogged { get; set; }
        public short idLevel { get; set; }
        public int idMachine { get; set; }
        public string sMessage { get; set; }
    }
}
