using System;
using System.Collections.Generic;

namespace EFfromExistingDb.Models
{
    public partial class tbEvent
    {
        public int idEvent { get; set; }
        public DateTime dLogged { get; set; }
        public DateTime dtLocal { get; set; }
        public DateTime dtLogged { get; set; }
        public DateTime dtLoggedUtc { get; set; }
        public short idLevel { get; set; }
        public int idMachine { get; set; }
        public int idMessageTag { get; set; }
        public byte idOrigin { get; set; }
        public int idUserAcct { get; set; }
        public int iEventId { get; set; }
        public string sExtended { get; set; }
        public string sIpAddr { get; set; }
        public short siPriority { get; set; }
        public int? siWinPID { get; set; }
        public int? siWinTID { get; set; }
        public string sMessage { get; set; }
        public string sProcess { get; set; }
        public string sSource { get; set; }
        public string sThread { get; set; }
    }
}
