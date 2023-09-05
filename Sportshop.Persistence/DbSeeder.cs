using Microsoft.EntityFrameworkCore;
using Sportshop.Domain.Entities;
using Sportshop.Persistence.Context;

namespace Sportshop.Persistence
{
    public class DbSeeder
    {
        public async static Task Seed(SportshopDbContext context)
        {
            // context.Database.EnsureCreated() does not use migrations to create the database and therefore the database that is created cannot be later updated using migrations 
            // use context.Database.Migrate() instead
            context.Database.Migrate();

            if (context.Products.Any())
            {
                return;
            }

            // insert dummy data
            await context.AddRangeAsync(GetDefaultProducts());
            await context.SaveChangesAsync();
        }


        public static List<ProductEntity> GetDefaultProducts()
        {
            var products = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ręcznik frotte 70x140cm L Adidas",
                    Description = "This is seeded product",
                    Price = 2,
                    Quantity = 10,
                    Seller = "Dummy Seller",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Trampolina Pumpkin 374cm 12ft Outtec",
                    Description = "Stabilna i solidna konstrukcja to zasługa zaokrąglonego stelaża, który zapewnia optymalne" +
                    " napięcie siatki oraz podwójnych nóg w kształcie litery U.",
                    Price = 999.00M,
                    Quantity = 2,
                    Seller = "Outtec",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Trampolina 91cm Hypermotion",
                    Description = "Trampolina została wykonana z trwałych materiałów, które zapewniają komfort i bezpieczeństwo." +
                    " Produkt posiada 6 nóżek z antypoślizgową nasadką, chroniącą przed poślizgiem oraz zapewniającą bardzo dobrą" +
                    " stabilność.",
                    Price = 179.99M,
                    Quantity = 1,
                    Seller = "Hypermotion",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Komplet bielizny termoaktywnej dla motocyklistów BT0041 Stanteks",
                    Description = "Wygodna termoaktywna odzież dla motocyklistów, wykonana w technologii płaskich szwów ze" +
                    " specjalnie opracowanych włókien poliestrowych. Miła w dotyku, elastyczna, bardzo dobrze dopasowujące się do" +
                    " ciała, nie ograniczająca ruchów, ",
                    Price = 149.99M,
                    Quantity = 5,
                    Seller = "Stanteks",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Longsleeve męski Dry Park First Layer Nike",
                    Description = "Longsleeve męski Dry Park First Layer Nike został wykonany poliestrowej tkaniny składającej się" +
                    " ze specjalnych mikrowłókien, które wspomagają naturalny system chłodzenia ciała. Raglanowe rękawy bez szwów" +
                    " sprawiają, że longsleeve męski Dry Park First Layer Nike nie będzie ograniczał Ci ruchów.",
                    Price = 89.99M,
                    Quantity = 10,
                    Seller = "Nike",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Koszulka termoaktywna męska Rapid Spaio",
                    Description = "Elastyczny materiał i bezszwowa konstrukcja dopasuje się do ciała oraz zapewni wygodę podczas" +
                    " każdej aktywności. Ustrzeże Cię także przed zbędnymi obtarciami, a przede wszystkim nie będzie krępować" +
                    " Twoich ruchów.",
                    Price = 79.99M,
                    Quantity = 12,
                    Seller = "Spalo",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Podkoszulek termoaktywny długi rękaw męski BT0030 Stanteks",
                    Description = "Bielizna termoaktywna różnego rodzaju ma pomagać w utrzymaniu odpowiedniej temperatury ciała" +
                    " oraz odprowadzaniu wilgoci z powierzchni skóry – co także wpływa\r\nna odczuwanie temperatury otoczenia.",
                    Price = 69.99M,
                    Quantity = 14,
                    Seller = "Stanteks",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Bielizna termoaktywna męska Active Alpinus",
                    Description = "Bielizna termoaktywna męska Active Alpinus znajdzie zastosowanie przede wszystkim podczas" +
                    " treningu w chłodniejsze dni. Wiatr czy ujemne temperatury nie będą żadną przeszkodą na Twojej drodze do" +
                    " osiągnięcia sportowego celu.",
                    Price = 259.99M,
                    Quantity = 22,
                    Seller = "Alpinus",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ręcznik szybkoschnący L 60x130cm Dr.Bacty",
                    Description = "Nie jest trudno wybrać odpowiedni ręcznik? Jeśli często wyjeżdżasz, trenujesz i ogólnie jesteś" +
                    " aktywną osobą, wiesz też, że to bzdura. Wybór ręcznika jest skomplikowany, ale możesz go sobie ułatwić -" +
                    " postaw na model marki Dr. Bacty.",
                    Price = 84.99M,
                    Quantity = 43,
                    Seller = "Dr.Bacty",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rękawice bokserskie BXT-5127 Boxeur",
                    Description = "Rękawice BXT-5127 włoskiej marki Boxeur wykonane zostały z materiału skóropodobnego, a wewnątrz wypełnione amortyzującą" +
                    " pianką EVA. Strefa uderzeniowa rękawicy połączona jest z kciukiem co uniemożliwia ewentualną jego kontuzję.",
                    Price = 104.39M,
                    Quantity = 21,
                    Seller = "Boxeur",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rękawice bokserskie Wrist Protect BB4 Bushido",
                    Description = "Rękawice bokserskie BB4, to model zaprojektowany przez specjalistów marki Bushido z myślą o" +
                    " profesjonalnych zawodnikach. Ich solidna i dokładnie przemyślana konstrukcja składająca się z kilku warstw," +
                    " dba o bezpieczeństwo podczas każdego uderzenia i zapobiega prostym kontuzjom, zwłaszcza nadgarstka.",
                    Price = 207.00M,
                    Quantity = 12,
                    Seller = "Bushido",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rękawice bokserskie Classic PU Allright",
                    Description = "Klasyczne rękawice bokserskie Classic PU to propozycja marki Allright dla początkujących adeptów boksu.",
                    Price = 122.30M,
                    Quantity = 15,
                    Seller = "Allright",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rękawice bokserskie Classic PU Allright",
                    Description = "Klasyczne rękawice bokserskie Classic PU to propozycja marki Allright dla początkujących adeptów boksu.",
                    Price = 99.90M,
                    Quantity = 8,
                    Seller = "Allright",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rękawice bokserskie Legend Overlord",
                    Description = "Zostały skonstruowane z myślą o osobach średniozaawansowanych oraz zaczynających swoją przygodę" +
                    " ze sportami walki. Model Legend został wykonany z bardzo wytrzymałej skóry syntetycznej 100% PU FLEX.",
                    Price = 149.99M,
                    Quantity = 22,
                    Seller = "Overlord",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Longsleeve męski Dry Park First Layer Nike",
                    Description = "Utrzymuje ciepło i nie ogranicza prędkości - koszulka męska Dry Park First Layer marki Nike" +
                    " w stu procentach ochroni Cię przed zimnem.",
                    Price = 89.99M,
                    Quantity = 6,
                    Seller = "Nike",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Piłka nożna Al Rihla Pro 5 Adidas",
                    Description = "Al Rihla Pro wykonano w większości z wytrzymałego poliuretanu. Domieszka poliestru dodatkowo" +
                    " poprawia trwałość modelu, który będzie zachwycał przez długi czas, nawet przy częstym i intensywnym użytkowaniu.",
                    Price = 469.99M,
                    Quantity = 2,
                    Seller = "Adidas",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kurtka przeciwdeszczowa męska Alaska II Joma",
                    Description = "Klasyczna odsłona sportowej kurtki przeciwdeszczowej Alaska, będzie doskonałym towarzyszem" +
                    " podczas Twoich treningów na świeżym powietrzu, a już w szczególności podczas niekorzystnej pogody.",
                    Price = 71.99M,
                    Quantity = 30,
                    Seller = "Joma",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Buty piłkarskie halowe Spirit III IT Junior Puma",
                    Description = "Buty Puma Spirit III IT Junior sprawdzą się dla dzieci, które trenują w klubach piłkarskich" +
                    " lub po prostu lubią grę w piłkę nożną. Będą idealne do trenowania w hali czy sali gimnastycznej zarówno w" +
                    " ramach zajęć sportowych, jak i zwykłego wychowania fizycznego.",
                    Price = 99.99M,
                    Quantity = 34,
                    Seller = "Dummy Seller",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Koszulka męska AeroReady 3 Stripes Adidas",
                    Description = "Poczuj się pewnie w męskiej koszulce z krótkim rękawem Adidas AeroReady 3 Stripes. Ta koszulka" +
                    " do biegania jest wyposażona w pochłaniającą wilgoć technologię AEROREADY, która zapewnia wygodę i komfort.",
                    Price = 49.99M,
                    Quantity = 25,
                    Seller = "Adidas",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Komplet piłkarski męski Park VII + Park III Nike",
                    Description = "Doskonały komplet piłkarski składający się z koszulki Park VII oraz spodenek Park III, to" +
                    " uniwersalna opcja od marki Nike. Klasyczny fason nie krępuje ruchów i sprawia, że zarówno koszulka jak" +
                    " i spodenki idealnie układają się na sylwetce.",
                    Price = 129.98M,
                    Quantity = 10,
                    Seller = "Nike",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Spodenki męskie Parma 16 Adidas",
                    Description = "Szorty zostały wyprodukowane z wysokiej jakości oddychającego materiału. Tkanina jest trwała," +
                    " więc mimo częstego użycia spodenki wciąż będą świetnie wyglądać, a dzięki ściągaczowi w pasie - nawet w czasie" +
                    " szybkiego biegu pozostaną na swoim miejscu.",
                    Price = 44.99M,
                    Quantity = 31,
                    Seller = "Adidas",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rower magnetyczny Ride 100 Kettler",
                    Description = "Rower magnetyczny Ride 100 zaprojektowany przez markę Kettler, jest podstawowym modelem, który" +
                    " może uzupełnić Twoją domową siłownię. Stworzony dla mniej wymagających użytkowników oraz tych, którzy sport" +
                    " traktują jako rekreacyjne hobby.",
                    Price = 1899.99M,
                    Quantity = 3,
                    Seller = "Kettler",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rower magnetyczny XB1500 Gymtek",
                    Description = "Rozpoczynając aktywność w okresie zimowych i decydując się na odpowiedni dla Ciebie domowy sprzęt" +
                    " fitnessowy, nie możesz przejść obojętnie obok marki Gymtek. Rower magnetyczny XB1500 został stworzony właśnie" +
                    " z myślą o Tobie i Twojej kondycji.",
                    Price = 949.00M,
                    Quantity = 16,
                    Seller = "Gymtek",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Buty Mach 5 HOKA",
                    Description = "Niska waga obuwia przekłada się na komfort i mniejsze obciążenie stóp. Cholewka obuwia jest" +
                    " wegańska, co docenią osoby, które troszczą się o stan środowiska naturalnego. Tekstylna cholewka pozwala" +
                    " na cyrkulację powietrza, dzięki której stopy mniej się pocą.",
                    Price = 769.99M,
                    Quantity = 16,
                    Seller = "HOKA",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Buty Downshifter 11 Nike",
                    Description = "Buty Downshifter 11 Nike wykorzystasz podczas aktywności fizycznej. To obuwie znakomicie " +
                    "sprawdzi się podczas biegania. Wytrzymała konstrukcja i przemyślana budowa wspiera i otula stopę, zapewniając " +
                    "dopasowanie. Obuwie wspiera stopę nawet podczas intensywnego biegu.",
                    Price = 244.7M,
                    Quantity = 7,
                    Seller = "Nike",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Buty Flyer Runner Mesh Puma",
                    Description = "Buty zostały wykonane z dbałością o detale. Dlatego są lekkie i wytrzymałe.Siateczkowa cholewka" +
                    " umożliwia wentylację stóp, dzięki którym stopy mniej się pocą. Z przodu znajduje się ochrona palców, która" +
                    " chroni przed urazami.",
                    Price = 159.99M,
                    Quantity = 20,
                    Seller = "Puma",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Buty Charged Bandit TR 2 Under Armour",
                    Description = "Model ten został wykonany z wysokiej jakości materiału, a ich konstrukcja jest starannie " +
                    "przemyślana. Niezwykle lekka, klejona cholewka z połączenia siateczki i wzmacniającej gumy jest bardzo " +
                    "elastyczna i przewiewna, abyś nie musiał martwić się o prawidłową cyrkulację powietrza podczas intensywnego biegu.",
                    Price = 367.00M,
                    Quantity = 10,
                    Seller = "Under Armour",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Namiot awaryjny 2-osobowy Survival Shelter 2 Lifesystems",
                    Description = "Został wykonany z twardej tkaniny PU, a zatem jest trwały i solidny. Posiada okienko, otwór wentylacyjny, wodoodporne panele do siedzenia oraz odblaskowe paski górne, " +
                    "zapewniające dodatkowe bezpieczeństwo.",
                    Price = 249.99M,
                    Quantity = 6,
                    Seller = "Lifesystems",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Torba termiczna Frosty Meteor",
                    Description = "Frosty marki Meteor to praktyczna torba termiczna, którą wygodnie przeniesiesz na ramieniu lub w" +
                    " dłoni. 30 litrów pojemności jest gwarancją, że schłodzonych napojów Wam nie zabraknie. Wewnętrzna warstwa " +
                    "izolacyjna pomaga utrzymać niską temperaturę produktów nawet przez kilka godzin.",
                    Price = 119.99M,
                    Quantity = 14,
                    Seller = "Meteor",
                    ThumbnailId = Guid.NewGuid(),
                },

                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Termos obiadowy Food Jug 0.75L Esbit",
                    Description = "Termos na żywność Food Jug marki Esbit, jest nowoczesnym i funkcjonalnym rozwiązaniem, " +
                    "które sprawdzi się w terenie oraz na co dzień w pracy. Jego dokładnie przemyślana konstrukcja oraz precyzyjnie" +
                    " dobrane komponenty, dbają o bezpieczeństwo Twojego posiłku, wysokiej jakości izolację oraz estetykę.",
                    Price = 124.99M,
                    Quantity = 10,
                    Seller = "Esbit",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Termos obiadowy Food Jug 0.75L Esbit",
                    Description = "Termos na żywność Food Jug marki Esbit, jest nowoczesnym i funkcjonalnym rozwiązaniem, " +
                    "które sprawdzi się w terenie oraz na co dzień w pracy. Jego dokładnie przemyślana konstrukcja oraz precyzyjnie" +
                    " dobrane komponenty, dbają o bezpieczeństwo Twojego posiłku, wysokiej jakości izolację oraz estetykę.",
                    Price = 124.99M,
                    Quantity = 10,
                    Seller = "Esbit",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Buty do biegania Nike Air Max",
                    Description = "Wygodne buty do biegania Nike Air Max zapewniają doskonałą amortyzację i wsparcie podczas treningów biegowych. Są idealne zarówno dla początkujących, jak i zaawansowanych biegaczy.",
                    Price = 299.99M,
                    Quantity = 20,
                    Seller = "Nike",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Piłka nożna Adidas Tango",
                    Description = "Oficjalna piłka nożna Adidas Tango to symbol doskonałej jakości i precyzji. Została stworzona z myślą o profesjonalnych zawodnikach oraz miłośnikach piłki nożnej na całym świecie.",
                    Price = 79.99M,
                    Quantity = 30,
                    Seller = "Adidas",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rower górski Trek X-Caliber 9",
                    Description = "Rower górski Trek X-Caliber 9 to wyjątkowy rower, który zapewni niezapomniane przejażdżki po trudnym terenie. Dzięki lekkiej ramie, solidnym komponentom i doskonałemu zawieszeniu, rower ten jest idealny do jazdy w górach.",
                    Price = 3499.00M,
                    Quantity = 5,
                    Seller = "Trek",
                    ThumbnailId = Guid.NewGuid(),
                },
                
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kask rowerowy Bell Tracker",
                    Description = "Kask rowerowy Bell Tracker to niezbędny element wyposażenia każdego rowerzysty. Zapewnia maksymalne bezpieczeństwo podczas jazdy na rowerze.",
                    Price = 79.99M,
                    Quantity = 15,
                    Seller = "Bell",
                    ThumbnailId = Guid.NewGuid(),
                },
                
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rakietka tenisowa Wilson Pro Staff",
                    Description = "Rakietka tenisowa Wilson Pro Staff to profesjonalny sprzęt dla miłośników tenisa. Została zaprojektowana z myślą o uzyskiwaniu doskonałych efektów na korcie.",
                    Price = 249.99M,
                    Quantity = 10,
                    Seller = "Wilson",
                    ThumbnailId = Guid.NewGuid(),
                },
                
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hulajnoga elektryczna Xiaomi Mi Electric Scooter",
                    Description = "Hulajnoga elektryczna Xiaomi Mi Electric Scooter to świetny środek transportu miejskiego. Jest lekka, praktyczna i ekologiczna.",
                    Price = 899.00M,
                    Quantity = 8,
                    Seller = "Xiaomi",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kurtka narciarska Columbia Alpine Action",
                    Description = "Kurtka narciarska Columbia Alpine Action zapewnia komfort i ochronę podczas zimowych sportów. Jest wodoodporna i doskonale izoluje ciepło.",
                    Price = 349.99M,
                    Quantity = 12,
                    Seller = "Columbia",
                    ThumbnailId = Guid.NewGuid(),
                },
                
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rakieta do squasha Head Nano Ti 110",
                    Description = "Rakieta do squasha Head Nano Ti 110 to sprzęt dla graczy o różnym poziomie zaawansowania. Zapewnia doskonałą kontrolę nad piłką.",
                    Price = 149.00M,
                    Quantity = 20,
                    Seller = "Head",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rakieta do squasha Head Nano Ti 110",
                    Description = "Rakieta do squasha Head Nano Ti 110 to sprzęt dla graczy o różnym poziomie zaawansowania. Zapewnia doskonałą kontrolę nad piłką.",
                    Price = 149.00M,
                    Quantity = 20,
                    Seller = "Head",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Basen dmuchany Intex Easy Set",
                    Description = "Basen dmuchany Intex Easy Set to doskonały sposób na relaks i ochłodzenie w upalne dni. Łatwy w montażu i przechowywaniu.",
                    Price = 249.99M,
                    Quantity = 7,
                    Seller = "Intex",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Narty Fischer RC4 Worldcup GS",
                    Description = "Narty Fischer RC4 Worldcup GS to profesjonalny sprzęt dla narciarzy alpejskich. Zapewniają doskonałą kontrolę na stoku.",
                    Price = 1399.00M,
                    Quantity = 6,
                    Seller = "Fischer",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rękawice bokserskie Everlast Pro Style",
                    Description = "Rękawice bokserskie Everlast Pro Style to niezbędny sprzęt dla miłośników sportów walki. Zapewniają ochronę i wygodę podczas treningów.",
                    Price = 49.99M,
                    Quantity = 18,
                    Seller = "Everlast",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Piłka do koszykówki Spalding NBA Replica",
                    Description = "Piłka do koszykówki Spalding NBA Replica to oficjalna piłka ligi NBA. Doskonała jakość i wytrzymałość.",
                    Price = 39.99M,
                    Quantity = 25,
                    Seller = "Spalding",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rolki Powerslide Swell",
                    Description = "Rolki Powerslide Swell to świetny środek transportu miejskiego. Doskonała jakość i komfort jazdy.",
                    Price = 199.00M,
                    Quantity = 9,
                    Seller = "Powerslide",
                    ThumbnailId = Guid.NewGuid(),
                },
                new ProductEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kijki do biegania Leki Micro Trail Pro",
                    Description = "Kijki do biegania Leki Micro Trail Pro to lekkie i wytrzymałe akcesorium dla biegaczy górskich. Zapewniają doskonałe wsparcie na trudnym terenie.",
                    Price = 149.99M,
                    Quantity = 11,
                    Seller = "Leki",
                    ThumbnailId = Guid.NewGuid()
                }
            };

            return products;
        }
    }
}
