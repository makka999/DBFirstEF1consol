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
            if (!(RegexNumberCheck(nrTelAdd)))
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
                Console.WriteLine("\nDodano nowego wypozyczajacego\n");
            }
            else
            {
                Console.WriteLine("\nNie dodano\n");
                return;
            }

        }

        public static void ChangeWypozyczajacy(KolekcjaPlytContext context)
        {
     
            Console.WriteLine("\nPodaj ID wypozyczajacego do modyfikacji");
            Console.Write("\nPodaj (int)ID:");
            var IDRead = Console.ReadLine();
            var MakeSure = context.Wypozyczajacies.Where(w => w.IdWypozyczajacy.ToString() == IDRead).ToList();
            var table = new ConsoleTable("Id", "Imie i Nazwisko", "NrTel", "Email", "Addres");
            foreach(var item in MakeSure)
            {

                table.AddRow(item.IdWypozyczajacy, item.Imie + " " + item.Nazwisko, item.NrTelefonu, item.Email,
                   item.Miasto + " " + item.KodPocztowy + " " + item.Ulica + " " + item.NumerMieszkania);

            }
            table.Write();
            Console.WriteLine("\nCzy chcesz modyfikowac tego wypozyczajacego\n");
            Console.WriteLine("T - tak");
            var input = Console.ReadLine();
            if (input == "t" || input == "T")
            {
            Menu:
                var wypozyczajacyMod = new Wypozyczajacy()
                {
                    IdWypozyczajacy = MakeSure[0].IdWypozyczajacy,
                    Imie = MakeSure[0].Imie,
                    Nazwisko = MakeSure[0].Nazwisko,
                    NrTelefonu = MakeSure[0].NrTelefonu,
                    Email = MakeSure[0].Email,
                    KodPocztowy = MakeSure[0].KodPocztowy,
                    Miasto = MakeSure[0].Miasto,
                    Ulica = MakeSure[0].Ulica,
                    NumerMieszkania = MakeSure[0].NumerMieszkania
                };
                Console.Clear();
                Console.WriteLine("_-@@@@@@@@@@@@@@@@@-MENU_MOD-@@@@@@@@@@@@@@@@@-_");
                Console.WriteLine("1) Zmien imie");
                Console.WriteLine("2) Zmien nazwisko");
                Console.WriteLine("3) Zmien numer telefonu");
                Console.WriteLine("4) Zmien email");
                Console.WriteLine("5) Zmien kod pocztowy");
                Console.WriteLine("6) Zmien miasto");
                Console.WriteLine("7) Zmien ulica");
                Console.WriteLine("8) Zmien numer mieszkania");
                Console.WriteLine("9) Dokonaj zmian");

                Console.WriteLine("\nWygląd zmodyfikowanego wypozyczajacego\n");
                var tableMod = new ConsoleTable("Id", "Imie i Nazwisko", "NrTel", "Email", "Addres");
                tableMod.AddRow(wypozyczajacyMod.IdWypozyczajacy, wypozyczajacyMod.Imie + " " + wypozyczajacyMod.Nazwisko, wypozyczajacyMod.NrTelefonu, wypozyczajacyMod.Email,
                       wypozyczajacyMod.Miasto + " " + wypozyczajacyMod.KodPocztowy + " " + wypozyczajacyMod.Ulica + " " + wypozyczajacyMod.NumerMieszkania);
                tableMod.Write();

                Console.Write("\nPodaj numer z menu: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        imieMod:
                        Console.Write("Podaj nowe imie: ");
                        string imieMod = Console.ReadLine();
                        if (imieMod == null || imieMod == String.Empty)
                        {
                            Console.WriteLine("Musisz podać imie");
                            goto imieMod;
                        }
                        MakeSure[0].Imie = imieMod;
                        goto Menu;
                    case "2":
                        Console.Clear();
                        nazwiskoMod:
                        Console.Write("Podaj nowe nazwisko: ");
                        string nazwiskoMod = Console.ReadLine();
                        if (nazwiskoMod == null || nazwiskoMod == String.Empty)
                        {
                            Console.WriteLine("Musisz podać nazwisko");
                            goto nazwiskoMod;
                        }
                        MakeSure[0].Nazwisko = nazwiskoMod;
                        goto Menu;
                    case "3":
                        Console.Clear();
                        numerMod:
                        Console.Write("Podaj nowy numer telefonu: ");
                        string nrTelMod = Console.ReadLine();
                        if (nrTelMod == null || nrTelMod == String.Empty)
                        {
                            nrTelMod = null;
                            goto Menu;
                        }
                        if (!(RegexNumberCheck(nrTelMod)))
                        {
                            Console.WriteLine("Niepoprawny numer");
                            goto numerMod;
                        }
                        MakeSure[0].NrTelefonu = nrTelMod;
                        goto Menu;
                    case "4":
                        Console.Clear();
                        emailMod:
                        Console.Write("Podaj nowy e-mail: ");
                        string eMailMod = Console.ReadLine();
                        if (eMailMod == null || eMailMod == String.Empty)
                        {
                            eMailMod = null;
                        }
                        if (!(RegexEmailCheck(eMailMod)))
                        {
                            Console.WriteLine("Podano nieprawidlowy adres email");
                            goto emailMod;
                        }
                        MakeSure[0].Email = eMailMod;
                        goto Menu;
                    case "5":
                        Console.Clear();
                        kodPocztowyMod:
                        Console.Write("Podaj nowy kod pocztowy:");
                        string kodPocztowyMod = Console.ReadLine();
                        if (!(RegexCodelCheck(kodPocztowyMod)))
                        {
                            Console.WriteLine("Podano nieprawidłowy kod pocztowy");
                            goto kodPocztowyMod;
                        }
                        if (kodPocztowyMod == null || kodPocztowyMod == String.Empty)
                        {
                            kodPocztowyMod = null;
                        }
                        MakeSure[0].KodPocztowy = kodPocztowyMod;
                        goto Menu;
                    case "6":
                        Console.Clear();
                        Console.Write("Podaj nowe miasto: ");
                        string miastoMod = Console.ReadLine();
                        if (miastoMod == null || miastoMod == String.Empty)
                        {
                            miastoMod = null;
                        }
                        MakeSure[0].Miasto = miastoMod;
                        goto Menu;
                    case "7":
                        Console.Clear();
                        Console.Write("Podaj nowa ulice: ");
                        string ulicaMod = Console.ReadLine();
                        if (ulicaMod == null || ulicaMod == String.Empty)
                        {
                            ulicaMod = null;
                        }
                        MakeSure[0].Ulica = ulicaMod;
                        goto Menu;
                    case "8":
                        Console.Clear();
                        numerDomMod:
                        Console.Write("Podaj nowy numer mieszkania: ");
                        string numerMieszkaniaMod = Console.ReadLine();
                        if (numerMieszkaniaMod == null || numerMieszkaniaMod == String.Empty)
                        {
                            numerMieszkaniaMod = null;
                            goto skipCheckHomeNMod;
                        }
                        if (!(int.TryParse(numerMieszkaniaMod, out int num)))
                        {
                            Console.WriteLine("Niepoprawny numer");
                            goto numerDomMod;
                        }
                        skipCheckHomeNMod:
                        MakeSure[0].NumerMieszkania = numerMieszkaniaMod;
                        goto Menu;
                    case "9":
                        Console.Clear();
                        goto EndMod;
                    default:
                        break;
                }
            EndMod:

                context.Entry(wypozyczajacyMod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public static bool RegexNumberCheck(string input)
        {
            if (input == null || input == String.Empty)
            {
                return true;
            }
            else
            {
                return Regex.IsMatch(input, @"[0-9]{9}"); 
            }

        }
    }
}

