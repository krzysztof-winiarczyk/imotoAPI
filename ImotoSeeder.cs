using imotoAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI
{
    public class ImotoSeeder
    {
        private readonly ImotoDbContext _dbContext;
        private readonly IPasswordHasher<Moderator> _passwordHasher;

        public ImotoSeeder(ImotoDbContext dbContext, IPasswordHasher<Moderator> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                //applying pending migartions
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

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

                if (!_dbContext.UserStatuses.Any())
                {
                    var userStatuses = GetUserStatuses();
                    _dbContext.UserStatuses.AddRange(userStatuses);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Voivodeships.Any())
                {
                    var voivodeshpis = GetVoivodeships();
                    _dbContext.Voivodeships.AddRange(voivodeshpis);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.CarYears.Any())
                {
                    for (int i = 1990; i <= 2025; i++)
                    {
                        var year = new CarYear()
                        {
                            YearOfProduction = i
                        };

                        _dbContext.CarYears.Add(year);
                        _dbContext.SaveChanges();
                    }
                }

                if (!_dbContext.Moderators.Any())
                {
                    var moderators = GetModerators();
                    _dbContext.Moderators.AddRange(moderators);
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
                     Name = "moderator danych",
                    Description = "moderator zajmujący się aktualizowaniem bazy danych",
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

        public IEnumerable<UserStatus> GetUserStatuses()
        {
            var statuses = new List<UserStatus>()
            {
                new UserStatus()
                {
                    Name = "aktywne",
                    Description = "konto aktywne",
                    Editable = false
                },
                new UserStatus()
                {
                    Name = "dezaktywowane",
                    Description = "konto zostało dezaktywowane",
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

        private IEnumerable<Moderator> GetModerators()
        {
            var adminStatus = _dbContext.ModeratorStatuses.FirstOrDefault(s => s.Name == "admin");
            var admin = new Moderator()
            {
                ModeratorStatusId = adminStatus.Id,
                Login = "admin",
                Email = "admin@example.com",
                Name = "admin",
                PhoneNumber = "111111111"
            };
            var passwordHash = _passwordHasher.HashPassword(admin, "admin");
            admin.PasswordHash = passwordHash;

            var moderators = new List<Moderator>();
            moderators.Add(admin);
            
            return moderators;

        }
    }
}
