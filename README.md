# Load-Balancer
# **Load-Balancer**
###### Projekat rađen za predmet Elementi Razvoja Softvera na Fakultetu Tehničkih Nauka u Novom Sadu



### Saradnici:
 - PR 60/2020 Luka Đelić
 - PR 68/2020 Stefan Milovanović
 - PR 69/2020 Momčilo Micić
 - PR 76/2020 Dušan Paripović

## Opšte informacije

Load balancer u računarstvu je servis koji obezbeđuje ravnomerno raspoređivanje zadataka među radnim jedinicama. U našoj implementaciji simuliraćemo upis podataka u bazu, čiji će tok nadgledati Load Balancer.

## Princip rada

Opisan je princip rada sve 4 komponente. Detaljnije informacije o strukturama podataka kojima operišu se nalaze ispod.

## Writer

Ova komponenta simulira pristizanje korisničkih zahteva tako što na svake dve sekunde generiče nasumičan Item i šalje ga Load Balanceru.

## Load Balancer

LB raspoređuje primljeni Item u jedan od svojih Descriptiona. Jedan Description odgovara jednom datasetu, te se na osnovu CODE-a u Itemu određuje kom datasetu i Descriptionu pripada. Nakon određenog vremena, Load Balancer pošalje jedan Description sa svim svojim Itemima jednom Workeru, odre]enom po Round Robin principu.

## Worker

Po prijemu Description-a, Worker Iteme iz istog prepakuje u WorkerProperty-je, i smešta ih u listu Historical Collection, i čeka da stignu OBA CODE-a koja odgovaraju jednom dataset-u. Po pristizanju oba CODE-a se svi WorkerProperty-ji iz jednog Historical Collection-a upisuju u Bazu podataka. 
