# BankProject

Rekreace maturitního projektu Banka kompletně přepsaného z `WinForms` do `WPF` a s využitím `ADO.NET Disconnected Modelu` a local `MS SQL`.

Mým hlavním cílem je pochopení vývoje aplikací ve WPF a bezpečná práce s databází bez použití ORM frameworků.



## Architektura

Projekt je rozdělený do 3 vrstev
- **BankProject (WPF):** Jedno hlavní okno
- **BankLibrary (Class Library):** Logika celého systému
- **BankConsole (Console Application)** Izolované testování



## Features

### WPF & UI Logika
- **Data Binding:** využití `ObservableCollection<Account>` pro automatickou synchronizaci dat mezi pamětí a ListBoxama
- **Validace:** Ošetření uživatelských vstupů v reálném čase (parsování finančních částek, hlídání prázdných hodnot apod.)

### SQL & ADO.NET Disconnected Model
- **DISCONNECTED MODEL** Data jsou z DB stahována jednorázově do paměti (`DataTable`) pomocí `SqlDataAdapter.Fill()`
- **Connection String:** `|DataDirectory|` odkazuje na databázi, která je přímo v projektu. SQL soubory se nachází ve slozce `Database_Setup`
- **Bezpečnost (SQL Injection):** Veškeré SQL dotazy jsou parametrizované



## TODO
- [ ] Implementace úročení zůstatků na `SavingsAccount`.
- [ ] Implementace limitu pro výběr (`withdrawalLimit`) na základě typu účtu.
- [ ] Možnost odstranění vybraného účtu z databáze v UI
- [ ] Logování transakcí



## Uživatelské Rozhraní
![screenshot](UI_Showcase.png)
