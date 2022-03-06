using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class ÄmneKurs
    {
        [Key]
        public int ÄmneKursId { get; set; }
        public Ämne Ämne { get; set; }
        public Kurs Kurs { get; set; }

    }
}
