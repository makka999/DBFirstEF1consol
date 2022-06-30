// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PierwszyProjektP4;
using PierwszyProjektP4.Models;

Console.WriteLine("Wszystko wyświatla się dobrze po zwiększniu termminala");

var context = new KolekcjaPlytContext();
DisplayAll DisplayAll = new DisplayAll();
LookFor LookFor = new LookFor();

LookFor.LookForId(context);

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



