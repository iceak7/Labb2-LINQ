using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        public string KursNamn { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public ICollection<LärareKurs> LärareKurs { get; set; }
        public ICollection<ElevKurs> ElevKurs { get; set; }
        public ICollection<ÄmneKurs> ÄmneKurs { get; set; }

    }
}
