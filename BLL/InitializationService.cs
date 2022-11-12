using SWAP.DAL.Data;
using SWAP.DAL.Data.Interfaces;

namespace SWAP.BLL
{
    internal class InitializationService
    {
        public static void Initialize(IApplicationContext context)
        {
            context.LoadData();
            if (context.Games.Any())
            {
                return;
            }

            Game[] games = new Game[]
            {
                new Game(){ Title = "Elden Ring",
                    Price = 799,
                    Description = "НОВИЙ ФЕНТЕЗІЙНИЙ РОЛЬОВИЙ БОЙОВИК. Повстань, згасла душа! Міжзем'я чекає свого володаря. Нехай благодать приведе тебе до Кільця Елден."
                },
                new Game(){ Title = "Forza Horizon 5",
                    Price = 1019,
                    Description = "На вас чекає нескінченний калейдоскоп пригод Horizon! Здійснюйте захоплюючі поїздки неймовірно красивим і самобутнім світом Мексики за кермом найбільших автомобілів в історії. Почніть свою пригоду Horizon вже сьогодні!"
                },
                new Game(){ Title = "Ghostwire: Tokyo",
                    Price = 969,
                    Description = "Населення Токіо зникло без сліду, але в вулицях міста панують смертоносні потойбічні сили. Використовуйте сили стихій, щоб розкрити таємницю зникнення людей та врятувати Токіо."
                },
                new Game{ Title = "Dead Space™ 2",
                    Price = 699,
                    Description = "НІЧНИЙ КОШМАР ПОВЕРТАЄТЬСЯ."
                },
                new Game{ Title = "Subnautica: Below Zero",
                    Price = 379,
                    Description = "Вирушайте в крижану підводну пригоду на чужій планеті. Дія Below Zero розгортається за два роки після подій оригінальної гри Subnautica."
                },
                new Game{ Title = "Risk of Rain 2",
                    Price = 329,
                    Description = "Втікайте з хаотичної інопланетної планети, борючись із ордами несамовитих монстрів – з друзями чи самостійно. Комбінуйте видобуток дивовижними способами та опануйте кожного персонажа, поки не станете хаосом, якого ви боялися під час першої аварійної посадки."
                },
                new Game{Title = "Divinity: Original Sin 2",
                    Price = 529,
                    Description = "Знаменитая рольова гра від розробників Baldur's Gate 3. Зберіть відряд. Освойте потужну боєву систему. Пригласите з собою до трьох друзів, але пам'ятайте, що тільки один з вас зможе стати богом."
                }
            };

            foreach (var game in games)
            {
                context.Games.Add(game);
            }

            var genres = new Genre[]
            {
                new Genre(){ Name = "Екшен"},
                new Genre(){ Name = "Рольова гра"},
                new Genre(){ Name = "Гонки"},
                new Genre(){ Name = "Рогалик"},
                new Genre(){ Name = "Симулятор виживання"},
                new Genre(){ Name = "Пригоди"},
                new Genre(){ Name = "Покрокова стратегія"},
                new Genre(){ Name = "Хоррор"}
            };

            foreach (var genre in genres)
            {
                context.Genres.Add(genre);
            }

            var gameGenres = new GameGenre[]
            {
                new GameGenre(){ Game = games.First(g => g.Title == "Elden Ring"), Genre = genres.First(g => g.Name == "Екшен") },
                new GameGenre(){ Game = games.First(g => g.Title == "Elden Ring"), Genre = genres.First(g => g.Name == "Рольова гра") },
                new GameGenre(){ Game = games.First(g => g.Title == "Forza Horizon 5"), Genre = genres.First(g => g.Name == "Гонки") },
                new GameGenre(){ Game = games.First(g => g.Title == "Ghostwire: Tokyo"), Genre = genres.First(g => g.Name == "Екшен") },
                new GameGenre(){ Game = games.First(g => g.Title == "Dead Space™ 2"), Genre = genres.First(g => g.Name == "Хоррор") },
                new GameGenre(){ Game = games.First(g => g.Title == "Dead Space™ 2"), Genre = genres.First(g => g.Name == "Екшен") },
                new GameGenre(){ Game = games.First(g => g.Title == "Dead Space™ 2"), Genre = genres.First(g => g.Name == "Симулятор виживання") },
                new GameGenre(){ Game = games.First(g => g.Title == "Subnautica: Below Zero"), Genre = genres.First(g => g.Name == "Пригоди") },
                new GameGenre(){ Game = games.First(g => g.Title == "Subnautica: Below Zero"), Genre = genres.First(g => g.Name == "Симулятор виживання") },
                new GameGenre(){ Game = games.First(g => g.Title == "Risk of Rain 2"), Genre = genres.First(g => g.Name == "Рогалик") },
                new GameGenre(){ Game = games.First(g => g.Title == "Risk of Rain 2"), Genre = genres.First(g => g.Name == "Екшен") },
                new GameGenre(){ Game = games.First(g => g.Title == "Divinity: Original Sin 2"), Genre = genres.First(g => g.Name == "Покрокова стратегія") },
                new GameGenre(){ Game = games.First(g => g.Title == "Divinity: Original Sin 2"), Genre = genres.First(g => g.Name == "Рольова гра") }
            };

            foreach (var gameGenre in gameGenres)
            {
                context.GameGenres.Add(gameGenre);
            }

            context.SaveData();
        }
    }
}
