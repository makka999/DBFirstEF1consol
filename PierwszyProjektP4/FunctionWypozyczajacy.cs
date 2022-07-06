using ConsoleTables;
using PierwszyProjektP4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszyProjektP4
{
    internal class FunctionWypozyczajacy
    {

        public void DysplayAll(KolekcjaPlytContext context)
        {

            Console.WriteLine("Wyświetlam całą zawartość Wypozyczających");
            var table = new ConsoleTable("Id", "Imie i Nazwisko", "NrTel", "Email", "Addres");

            foreach (var item in context.Wypozyczajacies)
            {

                table.AddRow(item.IdWypozyczajacy, item.Imie + " " + item.Nazwisko, item.NrTelefonu, item.Email,
                   item.Miasto + " " + item.KodPocztowy + " " + item.Ulica + " " + item.NumerMieszkania);

            }
            table.Write();
            Console.WriteLine();

        }

        public static void LookForId(KolekcjaPlytContext context)
        {

            Console.Write("Podaj (int)Id: ");
            var ClikResult = Console.ReadLine();
            if (ClikResult != "exit")
            {   
                var result = context.Wypozyczajacies.Where(w => w.IdWypozyczajacy.ToString() == ClikResult).ToList();
                var table = new ConsoleTable("Id", "Imie i Nazwisko", "NrTel", "Email", "Addres");
                foreach (var item in result)
                {

                    table.AddRow(item.IdWypozyczajacy, item.Imie + " " + item.Nazwisko, item.NrTelefonu, item.Email,
                       item.Miasto + " " + item.KodPocztowy + " " + item.Ulica + " " + item.NumerMieszkania);

                }
                table.Write();
                Console.WriteLine();
                LookForId(context);

            }
            if (ClikResult == "exit")
            {
                return;
            }
        }

        public static void LookForName(KolekcjaPlytContext context)
        {
       
            Console.Write("Podaj Imię: ");
            var ClikResultName = Console.ReadLine();
            Console.Write("Podaj Nazwisko: ");
            var ClikResultSur = Console.ReadLine();
            
           
            var result = context.Wypozyczajacies.Where(w => w.Imie.Contains(ClikResultName) || w.Nazwisko.Contains(ClikResultSur )).ToList();
            var table = new ConsoleTable("Id", "Imie i Nazwisko", "NrTel", "Email", "Addres");
            foreach (var item in result)
            {

                table.AddRow(item.IdWypozyczajacy, item.Imie + " " + item.Nazwisko, item.NrTelefonu, item.Email,
                   item.Miasto + " " + item.KodPocztowy + " " + item.Ulica + " " + item.NumerMieszkania);

            }
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Wpisz T - aby kontynulowac wyszukiwanie");
            var exit = Console.ReadLine();
            if (exit == "T")
            {
                LookForName(context);
            }
            if (exit == "t")
            {
                LookForName(context);
            }
            else
            {
                return;
            }
        }
    }
}

