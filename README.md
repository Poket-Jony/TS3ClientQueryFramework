# TS3ClientQueryFramework
Teamspeak 3 framework for C#

*Version: 0.2*

## German
Dieses Framework ist eine sehr einfache Möglichkeit eine externe Anwendung zu schreiben, welche sich wie ein TS3-Client-Plugin verhält.

Anwendungsmöglichkeiten:
- Client-Interface
- Received-Poke Nachricht an den Absender schicken
- Client Namen vorlesen
- ...

Das Framework ist in **C#** geschrieben und verbindet sich über **TCP** mit der **ClientQuery**-Schnittstelle vom Teamspeak 3 Client.
Die aktuelle Version ist bisher nur eine Demo und beinhaltet noch nicht alle Funktionen, sollten Sie an dem Framework weiterarbeiten bitte ich Sie mich zu Informieren, damit das Projekt auch aktuell gehalten wird.

*Bitte beachten Sie die beigefügte Lizenz zur Nutzung des Frameworks.*

## English
This framework is a very easy way to write an external application, which behaves like a TS3 client plugin.

Example applications:
- Client Interface
- Send "Received Poke message" to the sender
- Speak client name
- ...

The framework is written in **C#** and connects via **TCP** with the **Client-Query**-Interface from the TeamSpeak 3 client. The current version is so far only a demo and not yet includes all the features. If you continue work on the framework inform me, so that the project will also be kept up to date.

*Please note the enclosed license for the use of the framework.*

# Documentation
## Starting
**Initialize the connection**
```C#
TS3Client ts3Client = new TS3Client();
if(ts3Client.Connect())
{
  Console.WriteLine("Connected!");
  Console.WriteLine(ts3Client.GetHelp());
}
```

**Get my current client nickname**
```C#
TS3Models.Client currentClient = ts3Client.GetMyClient();
Console.WriteLine(currentClient.ClientNickname);
```

## Methods
- GetHelp()
- GetWhoami()
- GetClientList()
- GetChannelList()
- Use()
- ServerConnectionHandlerList()
- SendTextMessage()
- ClientPoke()
- ClientMove()
- ClientKick()
- BanClient()
- ClientUpdate()
- ClientVariable()
- GetMyClient()
- GetAnyClient()
- ChannelCreate()
- ChannelDelete()
- ChannelEdit()
- ChannelMove()
- ChannelVariable()
- ServerVariable()
- ClientNotifyRegister()
- ClientNotifyUnregister()
- ...

## Events
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
- OnServerGroupList()
- ...
