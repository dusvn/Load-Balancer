
<div allign="center">
  
# **Load-Balancer**
###### Projekat rađen za predmet Elementi Razvoja Softvera na Fakultetu Tehničkih Nauka u Novom Sadu
  
</div>

### Saradnici:

| Broj indeksa | Ime | Prezime |
|------|---------------|------|
|PR 60/2020|Luka|Đelić|
|PR 68/2020|Stefan|Milovanović|
|PR 69/2020|Momčilo|Micić|
|PR 76/2020|Dušan|Paripović|

## Opšte informacije

Load balancer u računarstvu je servis koji obezbeđuje ravnomerno raspoređivanje zadataka među radnim jedinicama. U našoj implementaciji simuliraćemo upis podataka u bazu, čiji će tok nadgledati Load Balancer.

### Korišćene tehnologije

- Projekat je pravljen uz pomoć .NET Frameworka, te će Vam biti potreban [Visual Studio 2017 ili noviji](https://visualstudio.microsoft.com/free-developer-offers/) sa instaliranim alatkama za razvoj .NET Framework aplikacija. U projektu se nalaze 3 konzolne aplikacije koje međusobno komuniciraju preko WCF Frameworka za ostvarivanje komunikacije preko lokalne mreže. 
- Za bazu je korišćen [Oracle RDBMS 11g Express Edition](https://www.oracle.com/database/technologies/xe-prior-release-downloads.html), a korišćen je i SQLDeveloper za nadgledanje podataka. 
- Baza je implementirana preko ADO_NET API za povezivanje programa napisanih na C# programskom jeziku i velikog broja sistema za upravljanje bazama podataka i drugih vrsta izvora podataka.

## Princip rada

Opisan je princip rada sve 4 komponente: Writer, Load Balancer, Worker i Reader. Workeri i Load Balancer imaju svoje interface-ove kako bi komunicirali sa svojim nadređenim komponentama preko WCF Frameworka.

Pored toga, svaka komponenta ima Logger koji prati i zapisuje događaje u toku rada programa. Load Balancer i Worker imaju svoje zasebne relacione baze podataka u koje zapisuju ili iz kojih čitaju podatke. 

### Component dijagram
![](https://cdn.discordapp.com/attachments/1051409709044871228/1068985518106349630/component_final.png)

Detaljnije informacije o glavnim komponentama i strukturama podataka kojima operišu se nalaze ispod.


<details>
  <summary> Komponente Load Balancera </summary>
  
## Writer
  
  Ova komponenta simulira pristizanje korisničkih zahteva tako što na svake dve sekunde generiče nasumičan Item i šalje ga Load Balanceru. Šematski prikaz     klase Item je dat ispod:
  
  |Item|
  |----|
  |Code|
  |Value|
  
  **Code** može imati jednu od sledećih vrednosti:
  + CODE_ANALOG
  + CODE_DIGITAL
  + CODE_CUSTOM
  + CODE_LIMITSET
  + CODE_SINGLENODE
  + CODE_MULTIPLENODE
  + CODE_CONSUMER
  + CODE_SOURCE
  
  **Value** je tipa int i može biti u opsegu 1-10000
  
## Load Balancer
  
LB raspoređuje primljeni Item u jedan od svojih Descriptiona. Jedan Description odgovara jednom datasetu, te se na osnovu CODE-a u Itemu određuje kom datasetu i Descriptionu pripada. Nakon određenog vremena, Load Balancer pošalje jedan Description sa svim svojim Itemima jednom Workeru, određenom po Round Robin principu.
  
|Description|
|-----------|
|ID|
|Lista Itema čiji CODE odgovara Datasetu|
|Dataset|
  
## Worker

Po prijemu Description-a, Worker prepakuje Iteme iz istog u WorkerProperty-je, smešta ih u listu Historical Collection, i čeka da stignu OBA CODE-a koja odgovaraju jednom dataset-u. Po pristizanju oba CODE-a, uzima se prvi par WorkerProperty-ja iz jednog Historical Collection-a i upisuje se u Bazu podataka.
  
|CollectionDescription|
|---------------------|
|ID|
|Dataset|
|HistoricalCollection (prepakovana Lista Itema iz Descriptiona)|

## Reader
  
Reader je komponenta koja služi za čitanje i ispisivanje podataka iz baze. Pomoću nje dobijamo Item-e po određenom kodu iz određenog intervala od određenog Worker-a. U projektu je implementiran u okviru menija za konzolnu aplikaciju Workera (jer sa njim i komunicira).

</details>

## Način instaliranja / korišćenja

U glavonm folderu se nalazi fajl *Common.sln* koji treba otvoriti u Visual Studiu. Konzolne aplikacije Za Client, Worker, Load Balancer mogu da se pokrenu u bilo kom redosledu jer je naša implementacija omogućila bezbedno pokretanje. Kada se postigne uspešna konekcija između aplikacija, dozvoljava se korisnička interakcija u Client aplikaciji.

U Clientu je moguće uključiti / isključiti generisanje i slanje Itema Load Balancer-u, kao i povećavanje i smanjivanje broja Workera.

U slkopu Worker apliacije se nalazi gorepomenuti Reader pomoću čijeg menija možete obaviti ispis podataka od određenog Workera, za određeni CODE u nekom vremenskom intervalu.
