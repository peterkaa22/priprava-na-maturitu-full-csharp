# Priprava Na Maturitu Full CSharp

ASP.NET Core MVC aplikace v C# pro správu soukromych textovych poznamek.

## Pouzite technologie

- ASP.NET Core MVC (.NET 10)
- ASP.NET Core Identity (hashovana hesla)
- Entity Framework Core
- SQLite

## Funkce aplikace

- Registrace uzivatele pomoci unikatniho uzivatelskeho jmena a hesla
- Prihlaseni a odhlaseni uzivatele
- Ukladani poznamek pouze pro prihlaseneho uzivatele
- Kazda poznamka obsahuje:
	- nadpis
	- text
	- datum a cas vlozeni
	- priznak dulezitosti
- Vypis poznamek od nejnovejsich
- Mazani vlastnich poznamek
- Oznaceni poznamek jako dulezitych
- Filtrovani pouze dulezitych poznamek
- Zruseni uctu po zadani spravneho hesla
- Pri zruseni uctu se smaze uzivatel i vsechny jeho poznamky

## Spusteni projektu

1. Otevri slozku projektu v terminalu.
2. Prejdi do aplikace:

```powershell
cd NotesApp
```

3. Obnov balicky a spust aplikaci:

```powershell
dotnet restore
dotnet run
```

4. Otevri URL, kterou vypise terminal (napr. https://localhost:xxxx).

## Poznamka k databazi

- Databaze je lokalni soubor SQLite: NotesApp/notesapp.db
- Pri prvnim spusteni se databaze vytvori automaticky.

## Stav podle zadani

Vsechny pozadovane body ze zadani jsou implementovane:

- registrace + hash hesla
- prihlaseni uzivatele
- tvorba, vypis a mazani poznamek
- oznaceni dulezitych poznamek a filtr
- zruseni uctu s kontrolou hesla a smazanim vsech poznamek