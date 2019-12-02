# ServiceExample

1. Lataa repositoryn sisältö ja avaa .sln tiedosto visual studiossa. (vs2019)
2. Importtaa ServiceExample.postman_collection.json postmaniin, tämä sisältää rajapinnan dokumentoinnin.
3. Käynnistä ServiceExample.Web projekti

Tässä vaiheessa on hyvä tarkistaa, että postmanin resurssien portti on oikea.

4. Lähetä POST pyyntö http://localhost:61515/api/factorydevices/generate valitsemalla Postmanista resurssi ServiceManual/Laitteet/Generoi laitekanta. (Laitekannan pystyy myös poistamaan lähettämällä Poista laitekanta käsky)
5. Rajapinta on nyt valmis testattavaksi Postman kutsuilla ServiceManual/Huoltotehtävät/*


Huom.
Toteutus tallentaa huoltotehtävät tietokantaan Guid tunnisteella jota käytetään tehtävien tunnuksena.
Esim: 

GET http://localhost:61515/api/v1/MaintenanceTasks/601124c6-8e58-4739-8fb3-9e054dd81b7f palauttaa yhden työtehtävän.

GET http://localhost:61515/api/v1/MaintenanceTasks Palauttaa kaikki työtehtävät.

GET http://localhost:61515/api/v1/MaintenanceTasks/Devices/126 Palauttaa kaikki työtehtävät jotka sisältävät annetun laitteen.

POST http://localhost:61515/api/v1/MaintenanceTasks lisää uuden tehtävän, bodyssa tehtävän konfiguraatio.

PUT http://localhost:61515/api/v1/MaintenanceTasks/f7b82363-ad6f-44fd-ac6a-b08a136f1b05 päivittää halutun tehtävän bodyn konfiguraatiolla.

DELETE http://localhost:61515/api/v1/MaintenanceTasks/f7b82363-ad6f-44fd-ac6a-b08a136f1b05 poistaa halutun tehtävän.
