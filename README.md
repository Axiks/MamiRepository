<img src="https://github.com/Axiks/MamiRepository/blob/main/Icon.png" alt="drawing" width="200" style="display:block; margin: 0 auto;"/>
<center>
    <h1>Mami</h1>
    <i>anime offline database library</i>
</center>
<p> </p>

This is a unofficial C# library for Manami [anime offline database](https://github.com/manami-project/anime-offline-database/blob/master/anime-offline-database.json). It allows you to download a database from a remote repository and interact with it locally without the need to connect to the Internet.

## Apabilities
- Download database from [remote repository]()
- Automatic update of the local database
- Selection of all anime
- Search anime by ID

### Technologies used
- C# .Net Core
- Newtonsoft.Json

## Installation
Copy repository to local project

## Configuration
```
var manamiAnimeRepository = new ManamiAnimeRepository(pathToDatabaseFolder, autoUpdateLocalDatabase);
```

- ```pathToDatabaseFolder``` - The path to the folder where the necessary files will be stored when working with the library
- ```autoUpdateLocalDatabase``` - Updates the database, if a newer version is available

## How To Use

This method returns all anime from the database
```
List<ManamiAnime> manamiAnimes = manamiAnimeRepository.GetAllAnime();
```

This method returns searches for anime by ID from any available service
```
List<ManamiAnime> manamiAnimes = manamiAnimeRepository.GetAnimeById("4224");
```
This is how you can get information about anime
```
ManamiAnime anime = manamiAnimes.First();
string title = anime.title;
string posterLink = anime.picture;
List<string> tags = anime.tags;
string animeType = anime.type.ToString();
```

All available methods and fields are similar to those posted in the documentation to [anime offline database](https://github.com/manami-project/anime-offline-database/blob/master/anime-offline-database.json).
## Sources
This library is based on the [manami-project](https://github.com/manami-project)
