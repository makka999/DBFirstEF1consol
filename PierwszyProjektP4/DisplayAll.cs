using ConsoleTables;
using PierwszyProjektP4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PierwszyProjektP4
{
    internal class DisplayAll
    {
        public void WypozyczajacyDis(KolekcjaPlytContext context)
        {

            Console.WriteLine("Wyświetlam całą zawartość Wypozyczających");
            var table = new ConsoleTable("Id", "Imie i Nazwisko", "NrTel", "Email", "Addres");

            foreach (var item in context.Wypozyczajacies)
            {

                table.AddRow(item.IdWypozyczajacy, item.Imie + " " + item.Nazwisko, item.NrTelefonu, item.Email,
                   item.Miasto + " " + item.KodPocztowy + " "  + item.Ulica + " " + item.NumerMieszkania);

            }
            table.Write();
            Console.WriteLine();

        }


    }
}
