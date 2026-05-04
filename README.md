**1. Opis Aplikacji: Diabets App**

    Diabets App to asystent zdrowia zaprojektowany do monitorowania parametrów zdrowotnych i wspierania użytkowników w codziennej kontroli zdrowia (w tym przypadków diabetyków ale z możliwościa dodania innych parametwów w przyszłosci). Aplikacja pozwala na         systematyczne gromadzenie danych, analizę trendów oraz budowanie społeczności wspierającej się w dążeniu do lepszego samopoczucia.
    
    Główne Funkcjonalności:
    Monitorowanie Pomiarów: Możliwość dodawania różnorodnych typów danych (np. waga, glukoza, ciśnienie) z automatycznym zapisem czasu.
    
    Analiza Statystyczna: Dynamiczne wyliczanie średniej z ostatnich 30 pomiarów dla każdego parametru, co pozwala na szybką ocenę trendów zdrowotnych.
    
    Panel Społecznościowy: System znajomości pozwalający na dodawanie innych użytkowników i wzajemne śledzenie postępów.
    
    Dynamiczny Dashboard: Tabela wyników, która automatycznie dostosowuje kolumny do rodzajów pomiarów istniejących w bazie danych.
    
    Bezpieczeństwo danych: Pełna autoryzacja użytkowników oraz zabezpieczenia przeciwko atakom CSRF (Antiforgery).

**2. Opis Techniczny**

    Projekt został zbudowany w nowoczesnej architekturze opartej na ekosystemie .NET, z naciskiem na separację logiki i wysoką wydajność.
    
    Użyte Technologie:
    Backend: ASP.NET Core 10.0 (Razor Pages) – zapewniający szybkość działania i skalowalność.
    
    Database & ORM: Entity Framework Core z silnikiem SQLite. Wybór SQLite zapewnia lekkość i brak konieczności konfigurowania ciężkich serwerów bazodanowych przy starcie.
    
    Frontend: Bootstrap 5.3 + JavaScript (Vanilla) – responsywny interfejs użytkownika z dynamicznymi oknami Modal.
    
    Architektura: Wzorzec Repository Pattern oraz Service Layer, oddzielające dostęp do bazy danych od logiki biznesowej widoków.
    
    Ciekawe Rozwiązania:
    Schemeful Same-Site Cookies: Zastosowanie zaawansowanej konfiguracji ciasteczek Antiforgery, zapewniającej bezpieczną komunikację HTTPS nawet w środowisku deweloperskim.
    
    Dynamiczna Agregacja LINQ: Użycie zaawansowanych zapytań LINQ do jednoczesnego pobierania ostatnich wyników i obliczania średnich kroczących bezpośrednio na silniku bazy danych.
    
    Join-Table Relationships: Implementacja relacji wiele-do-wielu dla systemu znajomości z asynchroniczną weryfikacją istnienia użytkownika.

**3. Instrukcja uruchomienia lokalnie**

    Aby uruchomić projekt na własnym komputerze, upewnij się, że masz zainstalowane .NET 10 SDK.
    
    Krok 1: Klonowanie i Przygotowanie
    Pobierz repozytorium na dysk.
    
    Otwórz terminal w folderze głównym projektu.
    
    Krok 2: Konfiguracja Bazy Danych
    Aplikacja korzysta z EF Core Migrations. Aby stworzyć bazę danych i tabele, wykonaj:
    
    Bash
    dotnet tool install --global dotnet-ef
    dotnet ef database update
    
    Krok 3: Uruchomienie Projektu
    Aplikacja jest projektem monolitycznym (Razor Pages), więc API i Frontend startują jednocześnie:
    
    Bash
    dotnet run
    Po uruchomieniu otworzy się przeglądarka w przypadku wpisanej opcji true dla startowania apliakci lub skopiuj i przejdź pod adres wskazany w terminalu (zazwyczaj https://localhost:7021).
    
    Uwaga: Przy pierwszym uruchomieniu zostaniesz poproszony o zaakceptowanie certyfikatu deweloperskiego HTTPS.

**4. Wsparcie Narzędzi AI**

    W procesie wytwórczym wykorzystano asystentów AI w celu optymalizacji pracy i zapewnienia najwyższej jakości kodu:
    
    Gemini 3 Flash: Posłużył jako główny architekt rozwiązań technicznych. Pomógł w zaprojektowaniu relacji między tabelami User i UserFriend oraz wdrożył bezpieczną konfigurację Antiforgery dla ciasteczek HTTPS.
    
    Analiza Błędów: AI wspierało proces debugowania, pomagając m.in. w rozwiązaniu problemów z asynchronicznością (Task<T> vs T) oraz identyfikacji brakujących tabel w SQLite.
    
    Frontend Refactoring: Użyto AI do wygenerowania responsywnej tabeli w Bootstrapie oraz logiki JavaScript przekazującej dane do okien Modal bez konieczności przeładowania całej strony.
