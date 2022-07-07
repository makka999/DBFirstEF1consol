using ConsoleTables;
using PierwszyProjektP4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.RegularExpressions;

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
            if (exit == "T" || exit == "t")
            {
                LookForName(context);
            }
            else
            {
                return;
            }
        }

        public static void AddWypozyczajacy(KolekcjaPlytContext context)
        {
            int checkNumber;
            Console.WriteLine("Podaj dane wypozyczajacego ktorego chcesz dodac");
            checkImie:
            Console.Write("Podaj imie: ");
            string imieAdd = Console.ReadLine();
            if (imieAdd == null || imieAdd == String.Empty)
            {
                Console.WriteLine("Musisz podać imie");
                goto checkImie;
            }
            checkNazwisko:
            Console.Write("Podaj nazwisko: ");
            string nazwiskoAdd = Console.ReadLine();
            if (nazwiskoAdd == null || nazwiskoAdd == String.Empty)
            {
                Console.WriteLine("Musisz podać nazwisko");
                goto checkNazwisko;
            }
            checkNumer:
            Console.Write("Podaj nr telefonu: ");
            string nrTelAdd = Console.ReadLine();
            if (nrTelAdd == null || nrTelAdd == String.Empty)
            {
                nrTelAdd = null;
                goto skipCheckEmail;
            }
            if (!(int.TryParse(nrTelAdd, out checkNumber))) //https://www.arungudelli.com/tutorial/c-sharp/check-if-string-is-number/#check-if-a-string-is-a-number-or-not-in-c
            {
                Console.WriteLine("Niepoprawny numer");
                goto checkNumer;
            }
            if (checkNumber > 999999999 || checkNumber <= 99999999)
            {
                Console.WriteLine("Niepoprawny numer");
                goto checkNumer;
            }
            skipCheckEmail:
            checkEmail:
            Console.Write("Podaj e-mail: ");
            string eMailAdd = Console.ReadLine();
            if (eMailAdd == null || eMailAdd == String.Empty)
            {
                eMailAdd = null;
            }
            if (!(RegexEmailCheck(eMailAdd)))
            {
                Console.WriteLine("Podano nieprawidlowy adres email");
                goto checkEmail;
            }
            checkKod:
            Console.Write("Podaj kod pocztowy: ");
            string kodPocztowyAdd = Console.ReadLine();
            if (!(RegexCodelCheck(kodPocztowyAdd)))
            {
                Console.WriteLine("Podano nieprawidłowy kod pocztowy");
                goto checkKod;
            }
            if (kodPocztowyAdd == null || kodPocztowyAdd == String.Empty)
            {
                kodPocztowyAdd = null;
            }
            Console.Write("Podaj miasto: ");
            string miastoAdd = Console.ReadLine();
            if (miastoAdd == null || miastoAdd == String.Empty)
            {
                miastoAdd = null;
            }
            Console.Write("Podaj ulice: ");
            string ulicaAdd = Console.ReadLine();
            if (ulicaAdd == null || ulicaAdd == String.Empty)
            {
                ulicaAdd = null;
            }
            checkNumerM:
            Console.Write("Podaj numer mieszkania: ");
            string numerMieszkaniaAdd = Console.ReadLine();
            if (numerMieszkaniaAdd == null || numerMieszkaniaAdd == String.Empty)
            {
                numerMieszkaniaAdd = null;
                goto skipCheckHomeN;
            }
            if (!(int.TryParse(numerMieszkaniaAdd, out checkNumber))) 
            {
                Console.WriteLine("Niepoprawny numer");
                goto checkNumerM;
            }
            skipCheckHomeN:

            var wypozyczajacyInsert = new Wypozyczajacy()
            {
                Imie = imieAdd,
                Nazwisko = nazwiskoAdd,
                NrTelefonu = nrTelAdd,
                Email = eMailAdd,
                KodPocztowy = kodPocztowyAdd,
                Miasto = miastoAdd,
                Ulica = ulicaAdd,
                NumerMieszkania = numerMieszkaniaAdd
            };

            var table = new ConsoleTable("Imie i Nazwisko", "NrTel", "Email", "Addres");
            table.AddRow(wypozyczajacyInsert.Imie + " " + wypozyczajacyInsert.Nazwisko, wypozyczajacyInsert.NrTelefonu,
                wypozyczajacyInsert.Email,wypozyczajacyInsert.KodPocztowy + " " + wypozyczajacyInsert.Miasto + " " 
                + wypozyczajacyInsert.Ulica + " " + wypozyczajacyInsert.NumerMieszkania);
            table.Write();
            Console.WriteLine();
            Console.WriteLine("Czy chcesz dodac tego wypozyczajacego");
            Console.WriteLine("T - tak");
            var input = Console.ReadLine();

            if (input == "t" || input == "T")
            {
                context.Wypozyczajacies.Add(wypozyczajacyInsert);
                context.SaveChanges();
            }
            else
            {
                return;
            }

        }
        public static bool RegexEmailCheck(string input) //https://www.abstractapi.com/guides/validate-emails-in-c
        {
            if (input == null || input == String.Empty)
            {
                return true;
            }
            else
            {
                return Regex.IsMatch(input, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            }
        }

        public static bool RegexCodelCheck(string input)  
        {
            if (input == null || input == String.Empty)
            {
                return true;
            }
            else
            {
                return Regex.IsMatch(input, @"[0-9]{2}-[0-9]{3}"); //https://regex101.com/
            }
            
        }
    }
}

