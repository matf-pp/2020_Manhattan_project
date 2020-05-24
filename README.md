# 2020_Manhattan_project

Kratak opis aplikacije
-----------------

Aplikacija za nalaženje optimalnog puta od početne do kranje izabrane tačke na mapi jednog dela Menhetna.

Optimalan put u smislu vremena potrebnog autom (peške) ili cene taksija u zavisnosti od odabira korisnika.

Takođe, prikazuju se i neke znamenitosti grada pored kojih korisnik prođe.

Uputstvo za korišćenje aplikacije
-----------------

Korsnik izabere način prevoza (peške, autom ili taksijem).

Prvim duplim klikom označava se početna lokacija.

Drugim duplim klikom označava se krajnja lokacija.

Zatim se pojavljuje dugme "Put" i klikom na to dugme iscrtava se optimalna putanja

i ispisuje se vreme putovanja (cena taksija) od početne do krajnje tačke.

Na datoj putanji označeni su markeri sa znamenitostima koje predstavljaju.

Klikom na znamenitost pojaviće se link preko kojeg se može saznati nešto više o njoj.

Sa leve strane nalazi se dugme "Pomoc" pomoću kojeg korisnik dobije prethodno navedene instrukcije.

Ako korisnik želi da poništi neki odabir, to može da uradi klikom na dugme "Ponisti".

Detaljniji opis aplikacije
-----------------

Manhattan Project je Windows Forms aplikacija, napisana u programskom jeziku C#

u razvojnom okruženju Visual Studio.

Za rad sa mapama korišćena je GMap biblioteka.

Za pronaleženje najoptimalnijeg puta korišćen je algoritam Dijkstra.

Usmereni težinski graf nad kojim Dijkstra radi implementiran je kao korisnička klasa "Graph".

Za svaki način putovanja postoji poseban graf. 

Svi grafovi imaju iste čvorove, ali različite grane (zbog težina i jednosmernih ulica, kojima
na primer pešaci mogu da se kreću u oba smera a vozila ne).

Čvorovi i grane čitaju se iz datoteka. 

Duplim klikom korisnik će izabrati početnu i krajnju tačku, od kojih se traže dve najbliže tačke grafa,
i nad njima se primenjuje Dijkstra.

Jezici i tehnologije korišćene u izradi
-----------------

Programski jezik: C#

IDE: Visual Studio

GUI: Windows Forms

Dodatne biblioteke: GMap.NET

Pokretanje
-----------------

Instalacioni fajl je napravljen za Windows operativni sistem.

Da bi se program instalirao, potrebno je iz odeljka releases preuzeti ManhattanProject.exe i prisutni .msi fajl, zatim smestiti ih u isti folder.

Pokretanjem .exe fajla program se instalira i pojavljuje se shortcut "Manhattan Project" na desktopu. 

Radili
-----------------

Miloje Joksimović   joksimovic21@gmail.com

Vladan Kovačević    vkovac01@gmail.com

Luka Đorović        luka.djorovic3010@gmail.com
