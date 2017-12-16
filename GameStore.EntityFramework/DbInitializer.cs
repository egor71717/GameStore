using GameStore.Entities;
using GameStore.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;

namespace GameStore.EntityFramework
{
    class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            #region roles
            var roles = new Dictionary<String, Role>();
            roles.Add("Admin", new Role()
            {
                Name = "Admin",
                Privileges = null
            });
            roles.Add("User", new Role()
            {
                Name = "User",
                Privileges = null
            });
            roles.Add("Publisher", new Role()
            {
                Name = "Publisher",
                Privileges = null
            });
            context.Roles.AddRange(roles.Values);
            #endregion

            #region userImages
            var userImages = new Dictionary<String, UserImage>();
            userImages.Add("FilthyFace", new UserImage()
            {
                Image = ImageConverter.Convert(Resource.filthyface),
                Format = ImageConverter.FormatToString(Resource.filthyface.RawFormat)
            });
            context.UserImages.AddRange(userImages.Values);
            #endregion

            #region users
            var users = new Dictionary<String, User>();
            users.Add("AdminUser", new User()
            {
                FirstName = "Egor",
                LastName = "Vasilev",
                Login = "ev11",
                PasswordHash = null,//todo: encrypt some shit later
                Balance = 100,
                Roles = new List<Role>()
                {
                    roles["User"],
                    roles["Admin"]
                },
                Avatar = userImages["FilthyFace"]
            });
            users.Add("SimpleUser", new User()
            {
                FirstName = "Yana",
                LastName = "Lapitskaya",
                Login = "yana123",
                PasswordHash = null,//todo: encrypt some shit later
                Balance = 120,
                Roles = new List<Role>()
                {
                    roles["User"]
                }
            });
            context.Users.AddRange(users.Values);
            #endregion

            #region publisherImages
            var publisherImages = new Dictionary<String, PublisherImage>();
            publisherImages.Add("Sega", new PublisherImage()
            {
                Image = ImageConverter.Convert(Resource.sega),
                Format = ImageConverter.FormatToString(Resource.sega.RawFormat)
            });
            publisherImages.Add("Sony", new PublisherImage()
            {
                Image = ImageConverter.Convert(Resource.sony),
                Format = ImageConverter.FormatToString(Resource.sony.RawFormat)
            });
            publisherImages.Add("TelltaleGames", new PublisherImage()
            {
                Image = ImageConverter.Convert(Resource.telltale),
                Format = ImageConverter.FormatToString(Resource.telltale.RawFormat)
            });
            publisherImages.Add("Ubisoft", new PublisherImage()
            {
                Image = ImageConverter.Convert(Resource.ubisoft),
                Format = ImageConverter.FormatToString(Resource.ubisoft.RawFormat)
            });
            publisherImages.Add("Nintendo", new PublisherImage()
            {
                Image = ImageConverter.Convert(Resource.nintendo),
                Format = ImageConverter.FormatToString(Resource.nintendo.RawFormat)
            });
            publisherImages.Add("BandaiNamcoEntertainment", new PublisherImage()
            {
                Image = ImageConverter.Convert(Resource.namcobandai),
                Format = ImageConverter.FormatToString(Resource.namcobandai.RawFormat)
            });
            publisherImages.Add("ElectronicArts", new PublisherImage()
            {
                Image = ImageConverter.Convert(Resource.ea),
                Format = ImageConverter.FormatToString(Resource.ea.RawFormat)
            });
            publisherImages.Add("Blizzard", new PublisherImage()
            {
                Image = ImageConverter.Convert(Resource.blizzard),
                Format = ImageConverter.FormatToString(Resource.blizzard.RawFormat)
            });
            publisherImages.Add("DevolverDigital", new PublisherImage()
            {
                Image = ImageConverter.Convert(Resource.devolverdigital),
                Format = ImageConverter.FormatToString(Resource.devolverdigital.RawFormat)
            });
            context.PublisherImages.AddRange(publisherImages.Values);
            #endregion

            #region publishers
            var publishers = new Dictionary<String, Publisher>();
            publishers.Add("Sega", new Publisher()
            {
                Name = "Sega",
                Country = "Япония",
                Logo = publisherImages["Sega"],
                Description = "Service Games или просто Sega — международная компания," +
                " производившая видеоигры и оборудование для них до 2001 года. После реструктуризации" +
                " компания в основном занимается разработкой и издательством игр на различные игровые платформы."
            });
            publishers.Add("TelltaleGames", new Publisher()
            {
                Name = "Telltale Games",
                Country = "США",
                Logo = publisherImages["TelltaleGames"],
                Description = "Telltale Games — независимая компания, издатель и дистрибьютор" +
                " компьютерных игр. Одна из самых известных компаний по производству " +
                "приключенческих видеоигр, основанных на популярных телевизионных шоу и комиксах." +
                " Основана в июне 2004 года как Telltale, Incorporated. Основной офис располагается" +
                " в городе Сан-Рафаэл. В студии задействованы дизайнеры, ранее работавшие в LucasArts." +
                " Бизнес-модель заключается в создании эпизодической игровой системы и цифровой дистрибуции."
            });
            publishers.Add("Sony", new Publisher()
            {
                Name = "Sony Interactive Entertainment",
                Country = "США",
                Logo = publisherImages["Sony"],
                Description = "Американская видеоигровая компания, одно из подразделений" +
                " корпорации Sony, специализирующееся на видеоиграх и игровых приставках." +
                " Она была основана 16 ноября 1993 года. Логотип был использован с 1994 года." +
                " Sony Interactive Entertainment разрабатывает видеоигры, аппаратное и программное" +
                " обеспечение для консолей PlayStation, компания также издаёт видеоигры, предназначенные для её консолей."
            });
            publishers.Add("Blizzard", new Publisher()
            {
                Name = "Activision Blizzard",
                Country = "США",
                Logo = publisherImages["Blizzard"],
                Description = "Activision Blizzard, Inc. — американская компания," +
                " одна из крупнейших в сфере компьютерных игр и развлечений со штаб-квартирой" +
                " в Санта-Монике, Калифорния. Была основана в 2008 году в результате" +
                " слияния Vivendi Games и Activision. "
            });
            publishers.Add("DevolverDigital", new Publisher()
            {
                Name = "Devolver Digital",
                Country = "США",
                Logo = publisherImages["DevolverDigital"],
                Description = "GHI Media LLC (действует под торговой маркой Devolver Digital)" +
                " — американский издатель компьютерных игр и кинодистрибьютор. Компания была" +
                " основана в 2009 году в Остине, штат Техас. Её основателями являются" +
                " Майк Уилсон, Гарри Миллер и Рик Сталтс, ранее основавшие издательство" +
                " Gathering of Developers и Gamecock Media Group. Деятельность компании" +
                " сфокусирована на рынке цифровой дистрибуции и поддержке независимых разработчиков" +
                " за счёт рекламного продвижения и финансовой поддержки их игр."
            });
            publishers.Add("Nintendo", new Publisher()
            {
                Name = "Nintendo",
                Country = "Япония",
                Logo = publisherImages["Nintendo"],
                Description = "Nintendo (яп. 任天堂株式会社 Нинтэндо: кабусикигайся) — японская компания," +
                " специализирующаяся на создании видеоигр и игровых консолей."
            });
            publishers.Add("ElectronicArts", new Publisher()
            {
                Name = "Electronic Arts",
                Country = "США",
                Logo = publisherImages["ElectronicArts"],
                Description = "Electronic Arts (EA) (NASDAQ: EA) — американская корпорация," +
                " которая занимается распространением видеоигр." +
                "Штаб - квартира компании расположена в городе Редвуд - Сити," +
                "Калифорния. Компания была основана 28 мая 1982 Трипом Хокинсом, " +
                "и стала одной из первых компаний в игровой индустрии, и отличалась тем," +
                " что популяризировала людей, работавших над играми — дизайнеров и программистов." +
                " Стартовый капитал, сформированный целиком за счёт личных накоплений Хокинса," +
                " составил 200 тыс.долларов США.В то время компания называлась Amazin\' Software. " +
                "Первоначально EA была лишь издателем игр.В конце 1980 - х, компания начала развивать" +
                " поддержку консольных игр. Скоро издательство выросло и приобрело нескольких успешных" +
                " разработчиков. К началу 2000 - х EA стала одним из самых больших в мире издательств," +
                " и занимала среди них 3 - е место."
            });
            publishers.Add("BandaiNamcoEntertainment", new Publisher()
            {
                Name = "Bandai Namco Entertainment",
                Country = "Япония",
                Logo = publisherImages["BandaiNamcoEntertainment"],
                Description = "Bandai Namco Entertainment Inc. ( Бней ) -  Это аркада," +
                " мобильный и домашний видео игры издатель, базирующейся в Японии." +
                " Компания также публикует видео, музыку и другие развлекательные продукты ," +
                " связанные с его видеоиграми IP - адресами . Это является результатом слияния" +
                " видеоигры подразделений развития Bandai и Namco . Первоначально называют" +
                " на Западе как Namco Bandai Games , компания была переименована в международном" +
                " Bandai Namco Games в январе 2014 г. В декабре 2014 года Bandai Namco Holdings" +
                " объявила , что она будет меняет свое название разделения игр от Bandai Namco" +
                " Games для Bandai Namco Entertainment , начиная с апреля 2015 года."
            });
            publishers.Add("Ubisoft", new Publisher()
            {
                Name = "Ubisoft",
                Country = "Франция",
                Logo = publisherImages["Ubisoft"],
                Description = "Ubisoft Entertainment — французская компания, специализирующаяся" +
                " на разработке и издании компьютерных видеоигр, главный офис которой располагается" +
                " в Монтрёй, Франция. Компания включает в себя студии в более чем 20 странах," +
                " среди них Россия, Канада, Испания, Китай, США, Германия, Болгария, Украина," +
                " Румыния и Италия. Ubisoft является одним из крупнейших игровых издателей в Европе."
            });
            context.Publishers.AddRange(publishers.Values);
            #endregion

            #region categories
            var categories = new Dictionary<String, Category>();
            categories.Add("Horror", new Category()
            {
                Name = "Horror"
            });
            categories.Add("Shooter", new Category()
            {
                Name = "Shooter"
            });
            categories.Add("OpenWorld", new Category()
            {
                Name = "Open World"
            });
            categories.Add("Indie", new Category()
            {
                Name = "Indie"
            });
            categories.Add("Action", new Category()
            {
                Name = "Action"
            });
            categories.Add("Humour", new Category()
            {
                Name = "Humour"
            });
            categories.Add("Adventure", new Category()
            {
                Name = "Adventure"
            });
            categories.Add("Survival", new Category()
            {
                Name = "Survival"
            });
            context.Categories.AddRange(categories.Values);
            #endregion

            #region gameImages
            var gameImages = new Dictionary<String, GameImage>();
            gameImages.Add("CrazyNight", new GameImage()
            {
                Image = ImageConverter.Convert(Resource.crazynight),
                Format = ImageConverter.FormatToString(Resource.crazynight.RawFormat)
            });
            gameImages.Add("Bulletstorm", new GameImage()
            {
                Image = ImageConverter.Convert(Resource.bullet),
                Format = ImageConverter.FormatToString(Resource.bullet.RawFormat)
            });
            gameImages.Add("TheSignalFromTolva", new GameImage()
            {
                Image = ImageConverter.Convert(Resource.thesignal),
                Format = ImageConverter.FormatToString(Resource.thesignal.RawFormat)
            });
            gameImages.Add("WhiteNoise2", new GameImage()
            {
                Image = ImageConverter.Convert(Resource.white),
                Format = ImageConverter.FormatToString(Resource.white.RawFormat)
            });
            gameImages.Add("LegoCityUndercover", new GameImage()
            {
                Image = ImageConverter.Convert(Resource.lego),
                Format = ImageConverter.FormatToString(Resource.lego.RawFormat)
            });
            context.GameImages.AddRange(gameImages.Values);
            #endregion

            #region games
            var games = new Dictionary<String, Game>();
            games.Add("CrazyNight", new Game()
            {
                Name = "Crazy Night",
                Description = "Crazy night makes the mouse mad and he kills roaches",
                Price = 20,
                Discount = 0.5,
                Requirements = null,
                Picture = gameImages["CrazyNight"],
                Date = DateTime.UtcNow,
                Categories = new List<Category>()
                {
                    categories["Shooter"],
                    categories["Survival"]
                },
                Publisher = publishers["Ubisoft"]
            });
            games.Add("TheSignalFromTolva", new Game()
            {
                Name = "The Signal From Tölva",
                Description = "The Signal From Tölva is an open-world first-person" +
                " shooter set on a distant, haunted, future world. Unlock savage weapons" +
                " and recruit robots to fight alongside you as rival factions struggle" +
                " to discover the source of the mysterious signal. What you discover will" +
                " decide the fate of a world.",
                Price = 13,
                Discount = 0,
                Requirements = "Windows",
                Picture = gameImages["TheSignalFromTolva"],
                Date = DateTime.UtcNow,
                Categories = new List<Category>()
                {
                    categories["Shooter"],
                    categories["OpenWorld"]
                },
                Publisher = publishers["Sega"]
            });
            games.Add("WhiteNoise2", new Game()
            {
                Name = "White Noise 2",
                Description = "Быть частью команды исследователя, или взять контроль над" +
                " существом и поедать их! Белый шум 2 предлагает 4vs1 асимметричный опыт" +
                " ужаса, который никого не оставит равнодушным.",
                Price = 7,
                Discount = 0,
                Requirements = "Windows, Mac, Steam",
                Picture = gameImages["WhiteNoise2"],
                Date = DateTime.UtcNow,
                Categories = new List<Category>()
                {
                    categories["Horror"],
                    categories["Indie"]
                },
                Publisher = publishers["Nintendo"]
            });
            games.Add("Bulletstorm", new Game()
            {
                Name = "Bulletstorm: Full Clip Edition",
                Description = "Вы — Грейсон Хант. После крушения корабля вы" +
                " оказались на заброшенной планете-курорте Стигия и должны сделать" +
                " выбор: спасаться или отомстить предателю.",
                Price = 25,
                Discount = 0,
                Requirements = "Windows, Mac",
                Picture = gameImages["Bulletstorm"],
                Date = DateTime.UtcNow,
                Categories = new List<Category>()
                {
                    categories["Action"],
                    categories["Adventure"],
                    categories["Humour"]
                },
                Publisher = publishers["Blizzard"]
            });
            games.Add("LegoCityUndercover", new Game()
            {
                Name = "LEGO CITY Undercover",
                Description = "Присоединяйтесь к Чейзу! В игре LEGO® CITY" +
                " Undercover вы примерите на себя роль Чейза Маккейна — офицера полиции," +
                " которому поручена операция под прикрытием по поиску преступника Рекса Фьюри.",
                Price = 40,
                Discount = 0,
                Requirements = "Windows, Mac",
                Picture = gameImages["LegoCityUndercover"],
                Date = DateTime.UtcNow,
                Categories = new List<Category>()
                {
                    categories["Action"],
                    categories["OpenWorld"],
                },
                Publisher = publishers["Sony"]
            });
            context.Games.AddRange(games.Values);
            #endregion

            #region comments
            var comments = new Dictionary<String, Comment>();
            comments.Add("comment1", new Comment()
            {
                Text = "Очень понравилась игра! Интригующий сюжет :)",
                User = users["SimpleUser"],
                Date = DateTime.UtcNow,
                Game = games["CrazyNight"]
            });
            comments.Add("comment2", new Comment()
            {
                Text = "Забавная. Но для этого жанра слабовато.",
                User = users["SimpleUser"],
                Date = DateTime.UtcNow,
                Game = games["CrazyNight"]
            });
            comments.Add("comment3", new Comment()
            {
                Text = "Первая часть лучше!",
                User = users["SimpleUser"],
                Date = DateTime.UtcNow,
                Game = games["CrazyNight"]
            });
            comments.Add("comment4", new Comment()
            {
                Text = "Люблю лего.",
                User = users["SimpleUser"],
                Date = DateTime.UtcNow,
                Game = games["CrazyNight"]
            });
            comments.Add("comment5", new Comment()
            {
                Text = "Prepare to be banned, motherfuckers!",
                User = users["AdminUser"],
                Date = DateTime.UtcNow,
                Game = games["CrazyNight"]
            });
            context.Comments.AddRange(comments.Values);
            #endregion

            #region purchases
            var purchases = new List<Purchase>()
            {
                new Purchase()
                {
                    Game = games["CrazyNight"],
                    Date = DateTime.UtcNow,
                    User = null
                },
                new Purchase()
                {
                    Game = games["WhiteNoise2"],
                    Date = DateTime.UtcNow,
                    User = null
                },
                new Purchase()
                {
                    Game = games["Bulletstorm"],
                    Date = DateTime.UtcNow,
                    User = null
                }
            };
            context.Purchases.AddRange(purchases);
            #endregion

            context.SaveChanges();
        }
    }
}