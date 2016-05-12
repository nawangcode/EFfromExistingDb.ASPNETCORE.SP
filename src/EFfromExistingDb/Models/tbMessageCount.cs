using System;
using System.Collections.Generic;

namespace EFfromExistingDb.Models
{
    public partial class tbMessageCount
    {
        public int idMessageCount { get; set; }
        public DateTime dLogged { get; set; }
        public int iCount { get; set; }
        public short idLevel { get; set; }
        public int idMessageTag { get; set; }
        public byte idOrigin { get; set; }
    }
}
