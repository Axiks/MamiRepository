

<p align="center">
  <img width="200" height="200" src="https://github.com/Axiks/MamiRepository/blob/main/Icon.png">
</p>
<h1 align="center">Mami</h1>

<p align="center">
    <i>anime offline database library</i>
</p>

![GitHub license](https://img.shields.io/github/license/Naereen/StrapDown.js.svg) ![GitHub license](https://img.shields.io/pypi/status/ansicolortags.svg)

This is a unofficial C# library for Manami [anime offline database](https://github.com/manami-project/anime-offline-database/blob/master/anime-offline-database.json). It allows you to download a database from a remote repository and interact with it locally without the need to connect to the Internet.


## Apabilities
- Download database from [remote repository]()
- Automatic update of the local database
- Selection of all anime
- Search anime by ID

## Technologies used

<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">
<img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white">

## Installation
Copy repository to local project

## Configuration
```
var mamiAnimeDatabase = new MamiDatabase(pathToDatabaseFolder, autoUpdateLocalDatabase);
```

- ```pathToDatabaseFolder``` - The path to the folder where the necessary files will be stored when working with the library
- ```autoUpdateLocalDatabase``` - Updates the database, if a newer version is available

## How To Use

This method returns all anime from the database
```
List<ManamiAnime> mamiAnimes = mamiAnimeDatabase.GetAllAnime();
```

This method returns searches for anime by ID from any available service
```
List<ManamiAnime> mamiAnimes = mamiAnimeDatabase.GetAnimeById("4224");
```
This is how you can get information about anime
```
ManamiAnime anime = mamiAnimes.First();
string title = anime.title;
string posterLink = anime.picture;
List<string> tags = anime.tags;
string animeType = anime.type.ToString();
```

All available methods and fields are similar to those posted in the documentation to [anime offline database](https://github.com/manami-project/anime-offline-database/blob/master/anime-offline-database.json).
## Sources
This library is based on the [manami-project](https://github.com/manami-project)
Thanks for the logo [Yurii Hromko](https://t.me/yurii_hromko)