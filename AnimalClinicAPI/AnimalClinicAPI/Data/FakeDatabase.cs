using System;
using System.Collections.Generic;
using AnimalClinicAPI.Models;

namespace AnimalClinicAPI.Data
{
    public static class FakeDatabase
    {
        public static List<Animal> Animals { get; set; } = new List<Animal>
        {
            new Animal
            {
                Id = 1,
                Name = "Buddy",
                Category = "Dog",
                Weight = 12.5,
                FurColor = "Brown",
                Visits = new List<Visit>
                {
                    new Visit
                    {
                        Id = 1,
                        DateOfVisit = DateTime.Now.AddDays(-10),
                        Description = "Regular check-up",
                        Price = 50,
                        AnimalId = 1
                    }
                }
            },
            new Animal
            {
                Id = 2,
                Name = "Whiskers",
                Category = "Cat",
                Weight = 4.3,
                FurColor = "Black"
            }
        };

        public static List<Visit> Visits { get; set; } = new List<Visit>
        {
            // If needed, more visits can be added here; note that visits are also stored per animal.
        };
    }
}