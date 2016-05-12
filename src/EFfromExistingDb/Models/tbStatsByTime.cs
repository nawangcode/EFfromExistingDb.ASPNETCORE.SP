using System;
using System.Collections.Generic;

namespace EFfromExistingDb.Models
{
    public partial class tbStatsByTime
    {
        public DateTime dLogged { get; set; }
        public byte tiHH { get; set; }
        public byte tiNN { get; set; }
        public int idEvent { get; set; }
        public int lCount { get; set; }
    }
}
