using System;
using System.Collections.Generic;

namespace EFfromExistingDb.Models
{
    public partial class tb_Version
    {
        public short idVersion { get; set; }
        public string DbTag { get; set; }
        public DateTime dtCreated { get; set; }
        public DateTime dtInstalled { get; set; }
        public string sVersion { get; set; }
    }
}
