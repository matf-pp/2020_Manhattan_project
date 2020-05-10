# 2020_Manhattan_project

Aplikacija za nalazenje optimalnog puta od pocetne do kranje izabrane tacke. Optimalan put u smislu cene taksija, vremena potrebnog autom ili 
razdaljina u kilometrima ako korisnik odabere da ide peske.
Takodje, prikazuju se i znamenitosti pored kojih korisnik prodje.
Koriscen je algoritam Dijkstra.
Koriscen je programski jezik C#.
Koriscena je GMap biblioteka za rad sa mapama i korisnicka klasa za usmereni graf.
Uputstvo:
Korisnik odabere jednu od opcija "peske","autom" ili "taksi".
Zatim duplim klikom oznacava pocetnu poziciju, a na isti nacin i krajnju.
Nakon odabira dveju lokacija, pojavljuje se opcija dijkstra, na koju korisnik treba da klikne.
Pojavljuje se optimalan put kao i znamenitosti na koje korisnik nailazi ako se krece tim putem. U text boxu se u zavisnosti od odabira opcije ispisuje vreme(ako je izabrana opcija peske ili autom) ili cena u dolarima(ako je izabrana opcija taksi). 
Aplikacija je pravljena za Windows.
Instalacioni fajl nalazi se u 2020_Manhattan_project/ManhattanProject/Setup/Debug/ , gde nakon
par next-ova  dolazi do instalacije programa i pravljenja precice na Desktop-u.


Podaci za vreme po ulicama su preuzeti iz tabele sa sajta: https://www1.nyc.gov/html/dot/html/about/datafeeds.shtml
Formula za racunanje cene taksija: https://www.taxi-calculator.com/taxi-fare-new-york-city/259

Radili:
Miloje Joksimovic joksimovic21@gmail.com
Vladan Kovacevic vkovac01@gmail.com
Luka Djorovic luka.djorovic3010@gmail.com