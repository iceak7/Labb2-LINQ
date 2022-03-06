using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class Lärare
    {
        [Key]
        public int LärareId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public ICollection<LärareKurs> LärareKurs { get; set; }

    }
}
