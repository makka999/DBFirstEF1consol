using System;
using System.Collections.Generic;

namespace PierwszyProjektP4.Models
{
    public partial class Plytum
    {
        public Plytum()
        {
            Utwors = new HashSet<Utwor>();
            Wypozyczenies = new HashSet<Wypozyczenie>();
        }

        public int IdPlyta { get; set; }
        public string Nazwa { get; set; } = null!;
        public string? Komentarz { get; set; }
        public string RodzajPlyty { get; set; } = null!;
        public string StatusPosiadania { get; set; } = null!;
        public int? IdNabycie { get; set; }

        public virtual Nabycie? IdNabycieNavigation { get; set; }
        public virtual ICollection<Utwor> Utwors { get; set; }
        public virtual ICollection<Wypozyczenie> Wypozyczenies { get; set; }
    }
}
