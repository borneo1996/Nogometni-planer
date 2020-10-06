# PI20-069 Nogometni planer (mentor: Boris Tomaš) 


## Projektni tim

Ime i prezime | E-mail adresa (FOI) | JMBAG | Github korisničko ime
------------  | ------------------- | ----- | ---------------------
Borneo Culović | bculovic@foi.hr | 0246064592 | bculovic
Ivan Starčević | istarcevi@foi.hr | 0016124691 | Strla
Alen Špiljak | aspiljak@foi.hr | 0016123402 | aspiljak

## Opis domene
Problem koji rješavamo ovim projektom jest pojednostavljivanje organizacije nogometnih termina, evidencija dolazaka na termine i pregled rasporeda i lokacija termina unutar određene grupe korisnika.

## Specifikacija projekta
Aplikacija treba imati mogućnost kreiranja korisničkog računa kao i upis korisničkih podataka pri ulasku u aplikaciju. Kao temeljne funkcionalnosti smatramo kreiranje grupe, listu prijatelja na koju se mogu dodavati prijatelji pretraživanjem korisničkih imena, dopisivanje sa korisnicima sa liste prijatelja, mjenjanje postavki vlastitog računa kao što su profilna slika, nadimak i osnovni opis o sebi. Kao funkcionalnosti nižeg ranga uzimamo popis grupa i chat unutar svake od grupa sa porukama koje su poslane specifično u tu određenu grupu. Kreator grupe automatski zauzima ulogu admina te može mjenjati uloge ostalih korisnika unutar grupe koje prethodno mora pozvati da bi oni imali pristup događanjima i porukama grupe. Unutar svake zasebne grupe postoji opcija pregleda događaja na kalendaru kao i pregled predhodnih događaja, te za admina kreiranje novog događaja te u potpunosti upravljanje atributima. Uzmimo u obzir da su spomenuti događaji ustvari termini u kojima se na određenim lokacijama i u prethodno određeno vrijeme odvijaju nogometne utakmice rekreativnog tipa. Stoga pošto u stvarnosti mora za termin biti neki minimalni broj ljudi da bi se mogao termin održati tako bi i admin termina kreiranog na kalendaru mogao upravljati pozivima na termin. Odnosno ako grupa u kojoj je kreiran termin za 15 ljudi ima 30 članova grupe, tada se taj problem rješi tako što kreator termina šalje pozive ostalim članovima grupe i na taj način popunjuje termin. Unutar samog kreiranog termina na kalendaru postoji lista ljudi koja je potvrdila svoj dolazak i onih koji su pozvani a ili nisu odgovorili ili su odbili doći. Termine u kalendaru bi mogao kreirati samo admin grupe unutar koje se nalazi spomenuti kalendar. Korisnik bi mogao biti član više grupa.

Oznaka | Naziv | Kratki opis | Odgovorni član tima
------ | ----- | ----------- | -------------------
F01 | Login | Za pristup aplikaciji potrebna je autentikacija korisnika pomoću login funkcionalnosti. Korisnik se logira s podacima koje je sam zadao prilikom kreacije korisničkog računa. | Alen Špiljak
F02 | Grupe | Stvaranje grupa unutar kojih se može dodati drugi korisnik radi razmjene grupnih poruka i dogovora za termine. | Borneo Culović
F03 | Poruke u grupi | Svaka grupa ima svoj chat unutar kojeg korisnici koji su u grupi mogu razmjenjivati poruke sa preostalim članovima grupe. | Borneo Culović
F04 | Kalendar | Svaka grupa ima svoj kalendar sa vlastitim događajima koje kreira admin grupe, te kreator događaja upravlja vremenom i lokacijom održavanja termina. | Ivan Starčević
F05 | Uloge | Admin grupe ima mogućnosti kreiranja termina u kalendaru kao i dodavanje i izbacivanja članova iz grupe i termina, te može i unaprijediti ulogu nekom drugom korisniku. Npr. dati mu prava admina. | Borneo Culović
F06 | Slaganje timova | Unutar termina na kalendaru bi bila opcija podjele u 2 tima koji će igrati jedan protiv drugog na danom terminu. | Ivan Starčević
F07 | Lista prijatelja | Sustav umrežavanja preko liste prijatelja te pretrage korisnika radi dodavanja na listu. | Alen Špiljak
F08 | Privatne poruke | Sustav dopisivanja '1na1' sa korisnicima na listi prijatelja. | Alen Špiljak
F09 | Obavijesti | Sustav obavijesti novih poruka i pozivnica za grupe i termine. | Ivan Starčević

## Tehnologije i oprema
Pri implementaciji rješenja projekta koristit ćemo programski jezik C# u Visual Studio IDE, te Microsoft SQL Server za bazu podataka.
