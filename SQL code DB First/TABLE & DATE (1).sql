--CREATE DATABASE KolekcjaPlyt;

USE KolekcjaPlyt
GO

--TABLE / PK,FK / CONSTRAINT

CREATE TABLE Nabycie (
IdNabycie INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
DataNabycia DATE,
Cena MONEY
);

CREATE TABLE Plyta (
IdPlyta INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
Nazwa VARCHAR(80) NOT NULL,
Komentarz VARCHAR(255),
RodzajPlyty VARCHAR(20) NOT NULL,
StatusPosiadania VARCHAR(20) NOT NULL
);

CREATE TABLE Czlonek (
IdCzlonek INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
Czlonek VARCHAR(80) NOT NULL,
Rola VARCHAR(40)
);

CREATE TABLE Wypozyczenie (
IdWypozyczenie INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
DataWypozyczenia DATE NOT NULL CONSTRAINT dataWypozyczeniaCheck 
CHECK (DataWypozyczenia <= getdate()),
DataOddania DATE CONSTRAINT dataOddaniaCheck 
CHECK (DataOddania <= getdate()),
);

CREATE TABLE Utwor (
IdUtwor INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
Tytul VARCHAR(80) NOT NULL,
Komentarz VARCHAR(255),
GatunekMuzyczny VARCHAR(20)
);

CREATE TABLE Wykonawca (
IdWykonawca INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
Wykonawca VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE Wypozyczajacy (
IdWypozyczajacy INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
Imie VARCHAR(30) NOT NULL,
Nazwisko VARCHAR(30) NOT NULL,
NrTelefonu VARCHAR(9) CONSTRAINT numeryCheck 
CHECK (NrTelefonu LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
Email VARCHAR(40) CONSTRAINT emailCheck 
CHECK (Email LIKE '%@%.%'),
KodPocztowy VARCHAR(10)CONSTRAINT kodPocztowyCheck 
CHECK (KodPocztowy LIKE '%-%'),
Miasto VARCHAR(30),
Ulica VARCHAR(50),
NumerMieszkania VARCHAR(10)
);

ALTER TABLE Plyta 
ADD IdNabycie INT NULL UNIQUE FOREIGN KEY REFERENCES Nabycie(IdNabycie);

ALTER TABLE  Wypozyczenie
ADD IdPlyta INT NOT NULL FOREIGN KEY REFERENCES Plyta(IdPlyta);

ALTER TABLE  Wypozyczenie
ADD IdWypozyczajacy INT NOT NULL FOREIGN KEY REFERENCES Wypozyczajacy(IdWypozyczajacy);

ALTER TABLE Utwor 
ADD IdPlyta INT NOT NULL FOREIGN KEY REFERENCES Plyta(IdPlyta);

ALTER TABLE Utwor 
ADD IdWykonawca INT NOT NULL FOREIGN KEY REFERENCES Wykonawca(IdWykonawca);

ALTER TABLE Czlonek 
ADD IdWykonawca INT NOT NULL FOREIGN KEY REFERENCES Wykonawca(IdWykonawca);

--Dane do Wypozyczajacy

INSERT INTO Wypozyczajacy(
           Imie,
           Nazwisko,
           NrTelefonu,
           Email,
           KodPocztowy,
           Miasto,
           Ulica,
           NumerMieszkania)
     VALUES(
           'Tomasz',
           'Kowal', 
           999555123, 
           'eTomasz@gmail.com', 
           '00-460', 
           'Warszawa', 
           'Agrykola', 
           1);

INSERT INTO Wypozyczajacy
     VALUES(
           'Mateusz',
           'Kowalski', 
           222312163, 
           'mati123@gmail.com', 
           '03-044', 
           'Warszawa', 
           'P³ochociñska', 
           51);

INSERT INTO Wypozyczajacy
     VALUES
           ('Karolina',
           'Szpak', 
           572312133, 
           'konwalia4@wp.pl', 
           '43-300', 
           'Bielsko-Bia³a', 
           'Tadeusza Rychliñskiego', 
           21);

INSERT INTO Wypozyczajacy
     VALUES(
           'Konstanty',
           'Witkowski', 
           222312163, 
           'lovemeall@picsviral.net', 
           '03-044', 
           'Warszawa', 
           'P³ochociñska', 
           51);

INSERT INTO Wypozyczajacy
     VALUES(
           'Ludwik',
           'Mróz', 
           981345657, 
           'mauricejonesdrew32@o0i.es.eu', 
           '02-028', 
           'Warszawa', 
           'Adama Asnyka', 
           32);

INSERT INTO Wypozyczajacy
     VALUES(
           'Rafa³',
           'Chmielewski', 
           179238645, 
           'Rafa³141@gmail.com', 
           '91-710', 
           '£ódŸ', 
           'Harcerska', 
           40);

INSERT INTO Wypozyczajacy
     VALUES(
           'Alek',
           'Koz³owski', 
           615438927, 
           'Koza2113@onet.pl', 
           '90-303', 
           '£ódŸ', 
           'Lutego', 
           12);

INSERT INTO Wypozyczajacy
     VALUES(
           'Emil',
           'Górecki', 
           287431956, 
           'skak3@janurganteng.com', 
           '94-113', 
           '£ódŸ', 
           'Sieciowa', 
           70);

INSERT INTO Wypozyczajacy
     VALUES(
           'Leopold',
           'Szewczyk', 
           294517386, 
           'leo3@gmail.com', 
           '25-535', 
           'Kielce', 
           'Akacjowa', 
           95);

INSERT INTO Wypozyczajacy
     VALUES(
           'Oskar',
           'Krupa', 
           895342176, 
           'krupA@gmail.com', 
           '10-686', 
           'Olsztyn', 
           'Jana Boenigka', 
           45);

INSERT INTO Wypozyczajacy
     VALUES(
           'Franciszek',
           'Duda', 
           891543762, 
           'DudaF3@gmail.com', 
           '58-100', 
           'Œwidnica', 
           'Adama Mickiewicza', 
           32);

INSERT INTO Wypozyczajacy
     VALUES(
           'Janusz',
           'Mazowiecki', 
           179586243, 
           'JanMaz3@gmail.com', 
           '87-100', 
           'Toruñ', 
           'Agatowa', 
           67);

INSERT INTO Wypozyczajacy
     VALUES(
           'Amadeusz',
           'Jaworski', 
           267185493, 
           'AmaJaw@gmail.com', 
           '39-300', 
           'Mielec', 
           'Lotnicza', 
           41);

--Dane Wykonawca

--1
INSERT INTO Wykonawca
     VALUES ('AC/DC');
--2
INSERT INTO Wykonawca
     VALUES ('Led Zeppelin');
--3
INSERT INTO Wykonawca
     VALUES ('Nocny Kochanek');
--4
INSERT INTO Wykonawca
     VALUES ('Obywatel G.C');
--5
INSERT INTO Wykonawca
     VALUES ('Koniec Œwiata');

--Dane Nabyia

--1
INSERT INTO Nabycie(
           DataNabycia,
           Cena)
     VALUES(
           getdate(),
           0);
--2
INSERT INTO Nabycie
     VALUES(
           '2000-11-12',
           '30.2');
--3
INSERT INTO Nabycie
     VALUES(
           '2002-12-4',
           '120.2');
--4
INSERT INTO Nabycie
     VALUES(
           '2011-02-12',
           '24.66');
--5
INSERT INTO Nabycie
     VALUES(
           '2011-01-22',
           '223.99');
--6
INSERT INTO Nabycie
     VALUES(
           '2008-07-02',
           '80.40');

--Dane Czlonek

INSERT INTO Czlonek(
           Czlonek,
           Rola,
           IdWykonawca)
     VALUES(
           'Angus Young',
           'Gitara prowadz¹ca',
           1)

INSERT INTO Czlonek
     VALUES(
           'Stevie Young',
           'Gitara rytmiczna',
           1)

INSERT INTO Czlonek
     VALUES(
           'Phil Rudd',
           'Perkusja',
           1)

INSERT INTO Czlonek
     VALUES(
           'Brian Johnson',
           'Wokal',
           1)

INSERT INTO Czlonek
     VALUES(
           'Cliff Williams',
           'Gitara basowa',
           1)

INSERT INTO Czlonek
     VALUES(
           'Jimmy Page',
           'Gitara',
           2)

INSERT INTO Czlonek
     VALUES(
           'Robert Plant',
           'Wokal',
           2)

INSERT INTO Czlonek
     VALUES(
           'John Paul Jones',
           'gitara basowa, wokal wspieraj¹cy',
           2)

INSERT INTO Czlonek
     VALUES(
           'John Bonham',
           'perkusja, wokal wspieraj¹cy',
           2)

INSERT INTO Czlonek
     VALUES(
           'Krzysztof Soko³owski',
           'Wokal',
           3)

INSERT INTO Czlonek
     VALUES(
           'Arkadiusz Majstrak',
           'Gitara',
           3)

INSERT INTO Czlonek
     VALUES(
           'Robert Kazanowski',
           'Gitara',
           3)

INSERT INTO Czlonek
     VALUES(
           'Artur Pochwa³a',
           'Gitara basowa',
           3)

INSERT INTO Czlonek
     VALUES(
           'Tomasz Nachy³a',
           'Perkusja',
           3)

INSERT INTO Czlonek
     VALUES(
           'Grzegorz Ciechowski',
           'Wokal, instrumenty klawiszowe',
           4)

INSERT INTO Czlonek
     VALUES(
           'Wojciech Karolak',
           'Organy',
           4)

INSERT INTO Czlonek
     VALUES(
           'Krzysztof Œcierañski',
           'Gitara basowa',
           4)

INSERT INTO Czlonek
     VALUES(
           'José Torres',
           'Instrumenty perkusyjne',
           4)

INSERT INTO Czlonek
     VALUES(
           'Tomasz Stañko',
           'Tr¹bka',
           4)

INSERT INTO Czlonek
     VALUES(
           'Marcin Otrêbski',
           'Gitara',
           4)

INSERT INTO Czlonek
     VALUES(
           'Adam Wendt',
           'Saksofon',
           4)

INSERT INTO Czlonek
     VALUES(
           'John Porter',
           'Gitara akustyczna',
           4)

INSERT INTO Czlonek
     VALUES(
           'Marek Surzyn',
           'Perkusja',
           4)

INSERT INTO Czlonek
     VALUES(
           'Jacek Stêszewski',
           'Wokal, gitara, s³owa',
           5)

INSERT INTO Czlonek
     VALUES(
           'Jacek Czepu³kowski',
           'Gitara, wokal',
           5)

INSERT INTO Czlonek
     VALUES(
           'Szymon Cirbus',
           'Tr¹bka, wokal, instrumenty klawiszowe',
           5)

INSERT INTO Czlonek
     VALUES(
           'Wojtek Filipek',
           'Gitara basowa',
           5)

INSERT INTO Czlonek
     VALUES(
           'Micha³ Leks',
           'Perkusja',
           5)

INSERT INTO Czlonek
     VALUES(
           'Tomasz K³aptocz',
           'Wokal',
           5)

INSERT INTO Czlonek
     VALUES(
           'Konstanty Janiak',
           'Puzon',
           5)

INSERT INTO Czlonek
     VALUES(
           'Dawid G³ówczewski',
           'Saksofon',
           5)

INSERT INTO Czlonek
     VALUES(
           'Krzysztof Kurek',
           'Mandolina',
           5)

INSERT INTO Czlonek
     VALUES(
           'Katarzyna Pytel',
           'Skrzypce',
           5)

--Dane plyty

INSERT INTO Plyta(
           Nazwa,
           RodzajPlyty,
           StatusPosiadania,
           IdNabycie)
     VALUES(
           'TestWyzwalacz',
           'CD',
           'W kolekcji',
           1);

INSERT INTO Plyta(
           Nazwa,
           RodzajPlyty,
           StatusPosiadania,
           IdNabycie)
     VALUES(
           'The Razor`s Edge',
           'CD',
           'W kolekcji',
           2);

INSERT INTO Plyta(
           Nazwa,
           RodzajPlyty,
           StatusPosiadania,
           IdNabycie)
     VALUES(
           'Led Zeppelin III (Remastered)',
           'P³yta Analogowa',
           'W kolekcji',
           3);

INSERT INTO Plyta(
           Nazwa,
           RodzajPlyty,
           StatusPosiadania,
           IdNabycie)
     VALUES(
           'Zdrajcy Metalu',
           'CD',
           'W kolekcji',
           4);

INSERT INTO Plyta(
           Nazwa,
           RodzajPlyty,
           StatusPosiadania,
           IdNabycie)
     VALUES(
           'Selekcja',
           'P³yta Analogowa',
           'W kolekcji',
           5);

INSERT INTO Plyta(
           Nazwa,
           RodzajPlyty,
           StatusPosiadania,
           IdNabycie)
     VALUES(
           'Oran¿ada',
           'CD',
           'W kolekcji',
           6);

--Dane Utwur

INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Thunderstruck',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Fire Your Guns',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Moneytalks',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'The Razor`s Edge',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Mistress for Christmas',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Rock Your Heart Out',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Are You Ready',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Got You By the Balls',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Shot of Love',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Let`s Make It',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Goodbye and Good Riddance to Bad Luck',
           'Rock',
           2,
           1);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'If You Dare',
           'Rock',
           2,
           1);
		   --nowa plyta
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Immigrant Song',
           'Rock',
           3,
           2);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Friends',
           'Rock',
           3,
           2);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Celebration Day',
           'Rock',
           3,
           2);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Since I’ve Been Loving You',
           'Rock',
           3,
           2);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Out On The Tiles',
           'Rock',
           3,
           2);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Gallows Pole',
           'Rock',
           3,
           2);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Tangerine',
           'Rock',
           3,
           2);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'That’s The Way',
           'Rock',
           3,
           2);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Bron-Y-Aur Stomp',
           'Rock',
           3,
           2);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Hats Off To (Roy) Harper',
           'Rock',
           3,
           2);
		   --nowa plyta
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Poniedzia³ek',
           'heavy metal',
           4,
           3);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'D¿entelmeni Metalu',
           'heavy metal',
           4,
           3);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Dziebniêty',
           'heavy metal',
           4,
           3);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Dziewczyna z Kebabem',
           'heavy metal',
           4,
           3);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'De Pajret Bej',
           'heavy metal',
           4,
           3);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Piosenka o niczym',
           'heavy metal',
           4,
           3);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Zdrajca Metalu',
           'heavy metal',
           4,
           3);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Pierwszego nie przepijam',
           'heavy metal',
           4,
           3);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Gdzie Jesteœ?',
           'heavy metal',
           4,
           3);
		   --nowa plyta
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Pary¿-Moskwa',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Tak D³ugo Czekam',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Przyznajê siê do Winy',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Tak ... Tak ... To Ja',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Podró¿ Do Ciep³ych Krajów',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Ani Ja Ani Ty',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Nie Pytaj o Polskê',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Ja Kain Ty Abel',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Tobie Wybaczam',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Piosenka Dla Weroniki',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Powoli Spadam',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Umar³a Klasa',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Zasypiasz Sama',
           'art rock, nowa fala',
           5,
           4);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Zasypiasz Sama',
           'art rock, nowa fala',
           5,
           4);
		   -- nowa plyta
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Bankiet',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Na moœcie w Sarajewie',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Fania',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'G³uche telefony',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Jak mnie tu znalaz³aœ',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Szare',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Oran¿ada',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Pust Wsiegda',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Serce w morzu',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Pracki rum',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           '1980 II',
           'rock, ska',
           6,
           5);
INSERT INTO Utwor(
           Tytul,
           GatunekMuzyczny,
           IdPlyta,
           IdWykonawca)
     VALUES(
           'Puct Wsiegda AC',
           'rock, ska',
           6,
           5);

--- wypozyczenia

INSERT INTO [dbo].[Wypozyczenie]
           ([DataWypozyczenia]
           ,[IdPlyta]
           ,[IdWypozyczajacy])
     VALUES
           (GETDATE(),
           5,
           2);

INSERT INTO [dbo].[Wypozyczenie]
           ([DataWypozyczenia]
           ,[IdPlyta]
           ,[IdWypozyczajacy])
     VALUES
           (GETDATE(),
           1,
           1);

INSERT INTO [dbo].[Wypozyczenie]
           ([DataWypozyczenia]
           ,[IdPlyta]
           ,[IdWypozyczajacy])
     VALUES
           (GETDATE(),
           3,
           4);