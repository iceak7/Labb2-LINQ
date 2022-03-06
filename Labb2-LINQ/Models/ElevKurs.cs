using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class ElevKurs
    {
        [Key]
        public int ElevKursId { get; set; }
        public Elev Elev { get; set; }
        public Kurs Kurs { get; set; }

    }
}
