using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class Ämne
    {
        public int ÄmneId { get; set; }
        public string Namn { get; set; }
        public ICollection<ÄmneKurs> ÄmneKurs { get; set; }
    }
}
