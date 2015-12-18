# TS3ClientQueryFramework
Teamspeak 3 framework for C#

## German
Dieses Framework ist eine sehr einfache Möglichkeit eine externe Anwendung zu schreiben, welche sich wie ein TS3-Client-Plugin verhält.

Anwendungsmöglichkeiten:
- Client-Interface
- Received-Poke Nachricht an den Absender schicken
- Client Namen vorlesen

Das Framework ist in **C#** geschrieben und verbindet sich über **TCP** mit der **ClientQuery**-Schnittstelle vom Teamspeak 3 Client.
Die aktuelle Version ist bisher nur eine Demo und beinhaltet noch nicht alle Funktionen, sollten Sie an dem Framework weiterarbeiten bitte ich Sie mich zu Informieren, damit das Projekt auch aktuell gehalten wird.

*Bitte beachten Sie die beigefügte Lizenz zur Nutzung des Frameworks.*

#Documentation
##Starting
**Initialize the connection**
```C#
TS3Client ts3Client = new TS3Client();
if(ts3Client.Connect())
{
  Console.WriteLine("Connected!");
  Console.WriteLine(ts3Client.GetHelp());
}
```

**Get my current client id**
```C#
TS3Models.Client currentClient = ts3Client.GetWhoami();
Console.WriteLine(currentClient.ClId);
```

##Methods
- GetHelp()
- GetWhoami()
- GetClientList()
- GetChannelList()
- Use()
- SendTextMessage()
- ClientPoke()
- ClientMove()
- ClientKick()
- BanClient()
- ClientNotifyRegister()
- ClientNotifyUnregister()
- ...

##Events
- OnNotification()
- OnTextMessage()
- OnClientPoke()
- OnClientEnterView()
- OnClientLeftView()
- OnClientMoved()
- OnChannelMoved()
- OnChannelEdited()
- OnChannelCreated()
- OnChannelDeleted()
- OnServerEdited()
- ...
