using System;
using System.Collections.Generic;

namespace PierwszyProjektP4.Models
{
    public partial class Utwor
    {
        public int IdUtwor { get; set; }
        public string Tytul { get; set; } = null!;
        public string? Komentarz { get; set; }
        public string? GatunekMuzyczny { get; set; }
        public int IdPlyta { get; set; }
        public int IdWykonawca { get; set; }

        public virtual Plytum IdPlytaNavigation { get; set; } = null!;
        public virtual Wykonawca IdWykonawcaNavigation { get; set; } = null!;
    }
}
