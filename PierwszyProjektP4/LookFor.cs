using PierwszyProjektP4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PierwszyProjektP4;
using PierwszyProjektP4.Models;
using Microsoft.EntityFrameworkCore;
using ConsoleTables;

namespace PierwszyProjektP4
{
    internal class LookFor
    {
        //public KolekcjaPlytContext context = new KolekcjaPlytContext();
        
        public static void LookForId(KolekcjaPlytContext context)
        {
            Console.Write("Podaj (int)Id: ");
            var ClikResult = Console.ReadLine();
            if (true)
            {
                context.Wypozyczajacies.Where(w => w.IdWypozyczajacy.ToString() == ClikResult).Load();
                var table = new ConsoleTable("Id", "Imie i Nazwisko", "NrTel", "Email", "Addres");
                foreach (var item in context.Wypozyczajacies.Local)
                {

                    table.AddRow(item.IdWypozyczajacy, item.Imie + " " + item.Nazwisko, item.NrTelefonu, item.Email,
                       item.Miasto + " " + item.KodPocztowy + " " + item.Ulica + " " + item.NumerMieszkania);

                }
                table.Write();
                Console.WriteLine();
                LookForId(context);

            }
            else
            {
                Console.WriteLine("Coś poszło nie tak");
                LookForId(context);

            }

        }
       
        
    }
}
