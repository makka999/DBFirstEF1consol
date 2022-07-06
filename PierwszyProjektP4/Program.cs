
using Microsoft.EntityFrameworkCore;
using PierwszyProjektP4;
using PierwszyProjektP4.Models;

Console.WriteLine("Wszystko wyświatla się dobrze po zwiększniu termminala");

var context = new KolekcjaPlytContext();
FunctionWypozyczajacy FunctionWypozyczajacy = new FunctionWypozyczajacy();

Menu:

Console.Clear();
Console.WriteLine("#################-MENU-#################");
Console.WriteLine("1) Wyswielt wszystkich wypozyczakacych");
Console.WriteLine("2) Znajdz wypozyczajacego po ID");
Console.WriteLine("3) Znajdz wypozyczajacego po imieniu i nazwisku");
Console.Write("\nPodaj numer z menu: ");

switch (Console.ReadLine())
{
    case "1":
        Console.Clear();
        FunctionWypozyczajacy.DysplayAll(context);
        Console.WriteLine("Nacisnij klawisz aby wrocic do Menu");
        Console.ReadKey();
        goto Menu;
    case "2":
        Console.Clear();
        FunctionWypozyczajacy.LookForId(context);
        Console.WriteLine("Nacisnij klawisz aby wrocic do Menu");
        Console.ReadKey();
        goto Menu;
    case "3":
        Console.Clear();
        FunctionWypozyczajacy.LookForName(context);
        Console.WriteLine("Nacisnij klawisz aby wrocic do Menu");
        Console.ReadKey();
        goto Menu;
    default:
        break;
}




//DisplayAll.WypozyczajacyDis(context);
/*
var wypozyczajacyInsert = new Wypozyczajacy()
{
    Imie = "testpierwszy",
    Nazwisko = "testnazwiosko"
};

context.Wypozyczajacies.Add(wypozyczajacyInsert);
context.SaveChanges();*/
/*
var wypozyczajacyUpdate = new Wypozyczajacy()
{
    //IdWypozyczajacy = 8,
    //Imie = "zmienione",
    Nazwisko = "UpdateALALALAL"
};

//string Imie = zmienione;

//Wypozyczajacy WypUpdate = context.Wypozyczajacies.Where(x => x.Imie == Imie);

context.Entry(wypozyczajacyUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
context.SaveChanges();*/






/*
foreach (var item in context.Wypozyczajacies)
{
    Console.WriteLine($"{item.IdWypozyczajacy} {item.Nazwisko} {item.Imie}");
}*/



