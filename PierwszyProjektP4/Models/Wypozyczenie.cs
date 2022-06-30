using System;
using System.Collections.Generic;

namespace PierwszyProjektP4.Models
{
    public partial class Wypozyczenie
    {
        public int IdWypozyczenie { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime? DataOddania { get; set; }
        public int IdPlyta { get; set; }
        public int IdWypozyczajacy { get; set; }

        public virtual Plytum IdPlytaNavigation { get; set; } = null!;
        public virtual Wypozyczajacy IdWypozyczajacyNavigation { get; set; } = null!;
    }
}
