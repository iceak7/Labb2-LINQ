using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class Elev
    {
        [Key]
        public int ElevId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Klass { get; set; }
        public int Ålder { get; set; }
        public ICollection<ElevKurs> ElevKurs { get; set; }

    }
}
