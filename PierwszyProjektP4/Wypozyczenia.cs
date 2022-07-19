using ConsoleTables;
using PierwszyProjektP4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszyProjektP4
{
    internal class Wypozyczenia
    {

        public void DysplayAll(KolekcjaPlytContext context)
        {
            Console.WriteLine("Wyświetlam całą zawartość Wypozyczających");
            var table = new ConsoleTable("Id", "Data Wypozyczenia", "Data Oddania", "Plyta", "Wypozycząjacy","Status plyty");
            using(var db = new KolekcjaPlytContext())
            {
             var wypozyczenieFull = (from Wpp in db.Wypozyczenies
                                     join Wyp in db.Wypozyczajacies on Wpp.IdWypozyczajacy equals Wyp.IdWypozyczajacy
                                     join Ply in db.Plyta on Wpp.IdPlyta equals Ply.IdPlyta
                                     select new
                                     {
                                         Id = Wpp.IdWypozyczenie,
                                         DataW = Wpp.DataWypozyczenia,
                                         DataO = Wpp.DataOddania,
                                         Plyta = Ply.Nazwa,
                                         ImieW = Wyp.Imie,
                                         NazwW = Wyp.Nazwisko,
                                         PlyStat = Ply.StatusPosiadania
                                     }).ToList();

                foreach (var item in wypozyczenieFull)
                {

                    table.AddRow(item.Id,item.DataW,item.DataO,item.Plyta,item.ImieW + "" + item.NazwW, item.PlyStat);

                }
                table.Write();
                Console.WriteLine();
            }
            


        }

    }
}
