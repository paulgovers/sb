# Surebusiness Phone Notes API
RESTful API voor het bijhouden van telefoonnotities
Notitie kan worden opgeslagen, notitie bestaat uit de volgende velden: Naam, notitie, telefoonnummer, status(nieuw | inbehandeling | afgehandeld), toegewezen medewerker

Het is tevens mogelijk:
* Notitie toe te voegen
* Status aanpassen
* Toegewezen medewerker aanpassen
* Lijst van alle notities ophalen

# Requirements
* .NET Core 3.1
* Visual Studio 2019
* SqlServer

# Installatie
De volgende stappen moeten doorlopen worden om de API te draaien lokaal op je pc
* git clone https://github.com/paulgovers/sb.git
* Solution openen met Visual studio 2019 en Rechter muis klik op de solution en vervolgens "Restore NuGet packages" selecteren
* connection string aanpassen in config bestand: appsettings.Development.json, gebruiker heeft privileges nodig om Tabellen aan te mogen maken
* SqlServer Database aanmaken 
* Start Debugging (F5) 

# Api Documentatie
Er is Api Swagger documentatie beschikbaar en tevens de mogelijkheid om de deze interface de API endpoint aan te roepen
<br/>Swagger endpoint: https://localhost:44330/swagger

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