# Surebusiness Telefoonnotities API
RESTful API voor het bijhouden van telefoonnotities.<br/>
Notitie bestaan uit de volgende velden: Naam, notitie, telefoonnummer, status(nieuw | inbehandeling | afgehandeld), toegewezen medewerker

De volgende acties worden ondersteund:
* Notitie toevoegen
* Waarde van "Status" bijwerken
* Waarde van "Toegewezen medewerker" bijwerken
* Lijst van alle notities ophalen
* Lijst van alle notities ophalen, met filter en gepagineerd resultaat

# Requirements
* .NET Core 3.1
* Visual Studio 2019
* SqlServer
* GIT

# Installatie
De volgende stappen moeten doorlopen worden om de API te draaien lokaal op je pc
* start een command prompt en voer het volgende uit: git clone https://github.com/paulgovers/sb.git
* Sla deze stap over als je met git clone de broncode hebt binnen gehaald. als je geen git hebt geinstalleerd, kan je als volgt downloaden: ga naar https://github.com/paulgovers/sb en klik op de knop "Code"
* Solution openen met Visual studio 2019, Daarna rechter muis klik op de solution en vervolgens "Restore NuGet packages" selecteren
* connection string aanpassen in config bestand: appsettings.Development.json, sql gebruiker heeft privileges nodig om Tabellen aan te mogen maken
* SqlServer Database aanmaken 
* Start Debugging (F5) 

De eerste keer nadat de applicatie start, zal er een tabel "Notes" worden aangemaakt en gevuld worden met 100 notities.

# Api Documentatie
Er is Api Swagger documentatie beschikbaar en tevens de mogelijkheid om met swagger de telefoonnotities API endpoint aan te roepen. In de swagger interface ga je naar een specifiek endpoint en klik vervolgens op de knop "Try it out" om het endpoint aan te roepen.
<br/>Swagger endpoint: https://localhost:44330/swagger
<br/>De swagger documentatie beschrijft alle endpoints, er staat ook beschreven hoe je de endpoints kunt aanroepen maar ook welke responses je kunt verwachten en met de bijbehorende Http response code.

>Om een kickstart te geven, is de API ook online beschikbaar, de swagger documentatie is te vinden op de volgende locatie:
> https://surebusiness.paulgovers.nl/swagger

> Base URL van de online telefoonnotities API:
> https://surebusiness.paulgovers.nl/api <br/>
> voorbeeld: https://surebusiness.paulgovers.nl/api/v1/phonenotes

## Notitie aanmaken
```code
POST /api/v1/phonenotes
{
  "name": "string",
  "notes": "string",
  "phoneNumber": "string",
  "status": "string",
  "assignedTo": "string"
}
```

## Lijst opvragen
```code
GET /api/v1/phonenotes
```


## Notitie patchen
Patch endpoint maakt gebruik van JsonPatchDocument (Microsoft standaard)
```code
PATCH /api/v1/phonenotes/{id}
[
  {
     "path": "/assignedTo",
      "op": "replace",
      "value": "Paul"
  },
   {
     "path": "/status",
      "op": "replace",
      "value": "nieuw"
  }
]
```

## Enkel notitie ophalen
```code
GET /api/v1/phonenotes/{id}
```

## Lijst filteren op "Status" en "AssignedTo" opvragen en gepagineerd terug krijgen
documentatie is te vinden op de volgende locatie: https://surebusiness.paulgovers.nl/swagger/index.html#/PhoneNotesV2/PhoneNotesV2_GetPagedAndFilter
```code
GET /api/v2/phonenotes?status=afgehandeld&PageNumber=2&PageSize=10

Example Response:
{
  "currentPage": 0,
  "totalPages": 0,
  "pageSize": 0,
  "totalCount": 0,
  "hasPrevious": true,
  "hasNext": true,
  "data": [
    {
      "id": 0,
      "name": "string",
      "notes": "string",
      "phoneNumber": "string",
      "status": "string",
      "assignedTo": "string",
      "createDate": "2021-10-04T12:24:03.899Z"
    }
  ]
}
```
