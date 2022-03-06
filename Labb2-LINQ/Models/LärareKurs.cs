using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class LärareKurs
    {
        [Key]
        public int LärareKursId { get; set; }
        public Lärare Lärare { get; set; }
        public Kurs Kurs { get; set; }

    }
}
