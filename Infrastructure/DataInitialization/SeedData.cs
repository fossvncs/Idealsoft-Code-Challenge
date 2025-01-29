using Domain.Entities;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataInitialization
{
    public static class SeedData
    {
        // this class automatically creates mocked data due to inMemory database. 
        public static void Initialize(IServiceProvider serviceProvider, MyDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.AddRange
                    (
                        new User { Id = 1 ,Name = "Alice", Surname = "Soares", Phone = "(83) 2842-0416", },
                        new User { Id = 2, Name = "Junior", Surname = "Almeida", Phone = "(62) 3893-1265", },
                        new User { Id = 3, Name = "Bruno", Surname = "Henrique", Phone = "(55) 2121-3726", },
                        new User { Id = 4, Name = "Ana", Surname = "Clara", Phone = "(81) 3351-3023", },
                        new User { Id = 5, Name = "Elizete", Surname = "Carvalho", Phone = "(85) 3270-4786", }
                    );
                context.SaveChanges();
            }
        }
    }
}
