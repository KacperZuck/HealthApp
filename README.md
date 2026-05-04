Diabets App - Dokumentacja Projektu
1. Opis Aplikacji: Diabets App
   
    Diabets App to asystent zdrowia zaprojektowany do monitorowania parametrów zdrowotnych i wspierania użytkowników w codziennej kontroli zdrowia (w tym przypadków diabetyków, z możliwością dodania innych parametrów w przyszłości). Aplikacja pozwala na systematyczne gromadzenie danych, analizę trendów oraz budowanie społeczności wspierającej się w dążeniu do lepszego samopoczucia.
    
    Główne Funkcjonalności:
    
        Monitorowanie Pomiarów: Możliwość dodawania różnorodnych typów danych (np. waga, glukoza,
       ciśnienie) z automatycznym zapisem czasu.
        
        Analiza Statystyczna: Dynamiczne wyliczanie średniej z ostatnich 30 pomiarów dla każdego
         parametru, co pozwala na szybką ocenę trendów zdrowotnych.
        
        Panel Społecznościowy: System znajomości pozwalający na dodawanie innych użytkowników i
         wzajemne śledzenie postępów.
        
        Dynamiczny Dashboard: Tabela wyników, która automatycznie dostosowuje kolumny do rodzajów
         pomiarów istniejących w bazie danych.
        
        Bezpieczeństwo danych: Pełna autoryzacja użytkowników oraz zabezpieczenia przeciwko atakom
         CSRF (Antiforgery).

3. Opis Techniczny
    Projekt został zbudowany w nowoczesnej architekturze opartej na ekosystemie .NET, z naciskiem na separację logiki i wysoką wydajność.
    
    Użyte Technologie:
    
        Backend: ASP.NET Core 10.0 (Razor Pages) – zapewniający szybkość działania i skalowalność.
        
        Database & ORM: Entity Framework Core z silnikiem SQLite. Wybór SQLite zapewnia lekkość i
         brak konieczności konfigurowania ciężkich serwerów bazodanowych przy starcie.
        
        Frontend: Bootstrap 5.3 + JavaScript (Vanilla) – responsywny interfejs użytkownika z
         dynamicznymi oknami Modal.
        
        Architektura: Wzorzec Repository Pattern oraz Service Layer, oddzielające dostęp do bazy danych
         od logiki biznesowej widoków.
    
    Ciekawe Rozwiązania:
    
        Schemeful Same-Site Cookies: Zastosowanie zaawansowanej konfiguracji ciasteczek Antiforgery,
         zapewniającej bezpieczną komunikację HTTPS nawet w środowisku deweloperskim.
        
        Dynamiczna Agregacja LINQ: Użycie zaawansowanych zapytań LINQ do jednoczesnego pobierania
         ostatnich wyników i obliczania średnich kroczących bezpośrednio na silniku bazy danych.
        
        Join-Table Relationships: Implementacja relacji wiele-do-wielu dla systemu znajomości z
        asynchroniczną weryfikacją istnienia użytkownika.

5. Instrukcja uruchomienia lokalnie
    Aby uruchomić projekt na własnym komputerze, upewnij się, że masz zainstalowane .NET 10 SDK.
    
    Krok 1: Klonowanie i Przygotowanie
    
        Pobierz repozytorium na dysk.
    
        Otwórz terminal w folderze głównym projektu.
    
    Krok 2: Konfiguracja Bazy Danych
        Aplikacja korzysta z EF Core Migrations. Aby stworzyć bazę danych i tabele, wykonaj w terminalu komendy:
    
        dotnet tool install --global dotnet-ef
    
        dotnet ef database update
    
    Krok 3: Uruchomienie Projektu
        Aplikacja startuje jako projekt monolityczny:
    
        Uruchom komendę: dotnet run
    
        Po uruchomieniu przejdź pod adres wskazany w terminalu (zazwyczaj: https://localhost:7021).
    
    Uwaga: Przy pierwszym uruchomieniu należy zaakceptować certyfikat deweloperski HTTPS.

6. Wsparcie Narzędzi AI
    W procesie wytwórczym wykorzystano asystentów AI w celu optymalizacji pracy:
    
    Gemini 3 Flash: Główny architekt rozwiązań technicznych. Pomógł w zaprojektowaniu relacji między tabelami User i UserFriend
       oraz wdrożył bezpieczną konfigurację Antiforgery.
    
    Analiza Błędów: AI wspierało proces debugowania, pomagając w rozwiązaniu problemów z asynchronicznością (Task vs T) oraz identyfikacji
       brakujących tabel w SQLite.
    
    Frontend Refactoring: Użyto AI do wygenerowania responsywnej tabeli w Bootstrapie oraz logiki JavaScript obsługującej okna Modal bez przeładowania strony.
