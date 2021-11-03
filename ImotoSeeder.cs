using imotoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI
{
    public class ImotoSeeder
    {
        private readonly ImotoDbContext _dbContext;

        public ImotoSeeder(ImotoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.AnnoucementStatuses.Any())
                {
                    var annoucementStatuses = GetAnnoucementStatuses();
                    _dbContext.AnnoucementStatuses.AddRange(annoucementStatuses);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.ModeratorStatuses.Any())
                {
                    var moderatorStatuses = GetModeratorStatuses();
                    _dbContext.ModeratorStatuses.AddRange(moderatorStatuses);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Voivodeships.Any())
                {
                    var voivodeshpis = GetVoivodeships();
                    _dbContext.Voivodeships.AddRange(voivodeshpis);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<AnnoucementStatus> GetAnnoucementStatuses()
        {
            var statuses = new List<AnnoucementStatus>()
            {
                new AnnoucementStatus()
                {
                    Name = "aktualne",
                    Description = "ogłoszenie jest aktualne",
                    Editable = false
                },
                new AnnoucementStatus()
                {
                    Name = "usunięte",
                    Description = "ogłoszenie zostało usunięte",
                    Editable = false
                },
                new AnnoucementStatus()
                {
                    Name = "zawieszone",
                    Description = "ogłoszenie aktualnie nie jest dostępne",
                    Editable = false
                }
            };

            return statuses;
        }

        public IEnumerable<ModeratorStatus> GetModeratorStatuses()
        {
            var statuses = new List<ModeratorStatus>()
            {
                new ModeratorStatus()
                {
                    Name = "admin",
                    Description = "posiada wszystkie uprawnienia",
                    Editable = false
                },
                new ModeratorStatus()
                {
                    Name = "dezaktywowane",
                    Description = "konto wygasło",
                    Editable = false
                }
            };

            return statuses;
        }

        private IEnumerable<Voivodeship> GetVoivodeships()
        {
            var voivodeships = new List<Voivodeship>()
            {
                new Voivodeship()
                {
                    Name = "dolnośląskie"
                },
                new Voivodeship()
                {
                    Name = "kujawsko-pomorskie"
                },
                new Voivodeship()
                {
                    Name = "lubelskie"
                },
                new Voivodeship()
                {
                    Name = "lubuskie"
                },
                new Voivodeship()
                {
                    Name = "łódzkie"
                },
                new Voivodeship()
                {
                    Name = "małopolskie"
                },
                new Voivodeship()
                {
                    Name = "mazowieckie"
                },
                new Voivodeship()
                {
                    Name = "opolskie"
                },
                new Voivodeship()
                {
                    Name = "podkarpackie"
                },
                new Voivodeship()
                {
                    Name = "podlaskie"
                },
                new Voivodeship()
                {
                    Name = "pomorskie"
                },
                new Voivodeship()
                {
                    Name = "śląskie"
                },
                new Voivodeship()
                {
                    Name = "świętokrzyskie"
                },
                new Voivodeship()
                {
                    Name = "warmińsko-mazurskie"
                },
                new Voivodeship()
                {
                    Name = "wielkopolskie"
                },
                new Voivodeship()
                {
                    Name = "zachodniopomorskie"
                }
            };

            return voivodeships;
        }
    }
}
