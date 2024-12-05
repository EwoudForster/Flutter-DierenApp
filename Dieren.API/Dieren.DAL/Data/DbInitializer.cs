using Dieren.DAL.Models;

namespace Dieren.DAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Seed Roles
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                var dieren = new[] {
                    new Dier { Name = "Leeuw", Description = "Koning van de jungle, deze kat achtige staat gekend als een van de gevaarlijkste roofdieren in het continent Afrika.", Points = 900 },
                    new Dier { Name = "Tijger", Description = "Een gestreepte roofkat die bekend staat om zijn kracht en snelheid, vooral in Azië.", Points = 850 },
                    new Dier { Name = "Olifant", Description = "Het grootste landzoogdier, beroemd om zijn intelligentie en indrukwekkende slagtanden.", Points = 700 },
                    new Dier { Name = "Neushoorn", Description = "Een massief dier met een kenmerkende hoorn op zijn neus, bedreigd door stroperij.", Points = 650 },
                    new Dier { Name = "Giraffe", Description = "Met zijn lange nek is de giraffe een unieke herbivoor die bladeren uit hoge bomen eet.", Points = 400 },
                    new Dier { Name = "Cheetah", Description = "Het snelste landdier ter wereld, dat korte afstanden met enorme snelheid kan rennen.", Points = 600 },
                    new Dier { Name = "Krokodil", Description = "Een gevaarlijke reptielensoort die vaak in rivieren en meren in Afrika leeft.", Points = 500 },
                    new Dier { Name = "Luipaard", Description = "Een schuwe en solitaire kat met een gevlekte vacht, vaak in bomen te vinden.", Points = 750 },
                    new Dier { Name = "Zebra", Description = "Een grasetend dier dat bekend staat om zijn unieke zwart-witte strepen.", Points = 300 },
                    new Dier { Name = "Hippopotamus", Description = "Een groot waterdier dat bekend staat om zijn agressieve aard en grote kaken.", Points = 700 },
                    new Dier { Name = "Hyena", Description = "Een aaseter die bekend staat om zijn lachen en het leven in clans.", Points = 450 },
                    new Dier { Name = "Flamingo", Description = "Een roze vogel die zijn kleur krijgt door zijn dieet van schaaldieren en algen.", Points = 250 },
                    new Dier { Name = "Aap", Description = "Slimme primaten die in groepen leven en vaak menselijk gedrag nabootsen.", Points = 350 },
                    new Dier { Name = "Papegaai", Description = "Een kleurrijke vogel die bekend staat om zijn vermogen om menselijke spraak te imiteren.", Points = 300 },
                    new Dier { Name = "Slang", Description = "Een reptiel zonder poten, soms giftig en vaak in bossen en woestijnen te vinden.", Points = 500 },
                    new Dier { Name = "Panter", Description = "Een mysterieuze en zeldzame grote kat met een zwarte of gevlekte vacht.", Points = 800 },
                    new Dier { Name = "Wolf", Description = "Een sociale en krachtige roofdier, bekend als een voorouder van de hond.", Points = 700 },
                    new Dier { Name = "Arend", Description = "Een roofvogel met scherpe klauwen en een uitstekend gezichtsvermogen.", Points = 600 },
                    new Dier { Name = "Ijsbeer", Description = "De koning van het noordpoolgebied, een krachtige beer die zich aan koud weer aanpast.", Points = 900 },
                    new Dier { Name = "Kangoeroe", Description = "Een buideldier dat vooral voorkomt in Australië, beroemd om zijn sprongen.", Points = 400 },
                    new Dier { Name = "Pinguïn", Description = "Een vogel die niet kan vliegen, bekend om zijn elegante zwemmen in ijskoude wateren.", Points = 350 },

                };
                context.Dieren.AddRange(dieren);
                context.SaveChanges();
            }

            // Seed Genres
            if (!context.Users.Any())
            {
                var dier1 = context.Dieren.FirstOrDefault(a => a.DierId == 1);
                var dier2 = context.Dieren.FirstOrDefault(a => a.DierId == 3);
                var dier3 = context.Dieren.FirstOrDefault(a => a.DierId == 4);
                var dier4 = context.Dieren.FirstOrDefault(a => a.DierId == 5);

                var users = new[] {
                    new User { Name = "Jon", Phone = "0468748392", Email = "jon@mail.com", Dieren = new List<Dier> {dier1 } },
                    new User { Name = "Alice", Phone = "0456123456", Email = "alice@mail.com", Dieren = new List<Dier> {dier1, dier2 }  },
                    new User { Name = "Bob", Phone = "0467123456", Email = "bob@mail.com", Dieren = new List<Dier> {dier3 }  },
                    new User { Name = "Charlie", Phone = "0478123456", Email = "charlie@mail.com"  },
                    new User { Name = "Diana", Phone = "0489123456", Email = "diana@mail.com", Dieren = new List<Dier> {dier3, dier4 }  },
                    new User { Name = "Eve", Phone = "0490123456", Email = "eve@mail.com", Dieren = new List<Dier> {dier2 }  },

                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }

        }
    }
}
