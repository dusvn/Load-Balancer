
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

## Princip rada

Opisan je princip rada sve 4 komponente. Detaljnije informacije o strukturama podataka kojima operišu se nalaze ispod.


<details>
  <summary> Komponente Load Balancera </summary>
  
## Writer
  
Ova komponenta simulira pristizanje korisničkih zahteva tako što na svake dve sekunde generiče nasumičan Item i šalje ga Load Balanceru. Šematski prikaz klase Item je dat ispod:
  
|Item|
|----|
|Code|
|Value|
  
## Load Balancer
  
LB raspoređuje primljeni Item u jedan od svojih Descriptiona. Jedan Description odgovara jednom datasetu, te se na osnovu CODE-a u Itemu određuje kom datasetu i Descriptionu pripada. Nakon određenog vremena, Load Balancer pošalje jedan Description sa svim svojim Itemima jednom Workeru, odre]enom po Round Robin principu.
  
|Description|
|-----------|
|ID|
|Lista Itema čiji CODE odgovara Datasetu|
|Dataset|
  
## Worker

Po prijemu Description-a, Worker prepakuje Iteme iz istog u WorkerProperty-je, i smešta ih u listu Historical Collection, i čeka da stignu OBA CODE-a koja odgovaraju jednom dataset-u. Po pristizanju oba CODE-a se svi WorkerProperty-ji iz jednog Historical Collection-a upisuju u Bazu podataka.
  
|CollectionDescription|
|---------------------|
|ID|
|Dataset|
|HistoricalCollection (prepakovana Lista Itema iz Descriptiona)|

## Reader
  
Reader je komponenta koja služi za čitanje i ispisivanje podataka iz baze.

</details>
