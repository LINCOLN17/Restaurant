using Restaurant.BLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.DAL.EF
{
    public static class Seed
    {
        public static void RunSeed(DbContext context, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            // Seed operations
            //AddRoles(context);
            //AddSmallTables(context);
            //AddReservations(context);

        }

        private static void AddRoles(DbContext _context)
        {
            _context.AddRange(
                new Role { Name = "Admin" },
                new Role { Name = "User" }
                );
            _context.SaveChanges();
        }

        // deleted
        //private static void AddStatusReservations(DbContext _context)
        //{
        //    _context.AddRange(
        //        new StatusReservation { Name = "Cancelled", Description = "Cancelled" },
        //        new StatusReservation { Name = "Reserved", Description = "Reserved" }
        //        );
        //    _context.SaveChanges();
        //}

        private static void AddSmallTables(DbContext _context)
        {
            _context.AddRange(
                new SmallTable { NumberOfChairs = 2 },
                new SmallTable { NumberOfChairs = 2 },
                new SmallTable { NumberOfChairs = 3 },
                new SmallTable { NumberOfChairs = 3 },
                new SmallTable { NumberOfChairs = 3 },
                new SmallTable { NumberOfChairs = 4 },
                new SmallTable { NumberOfChairs = 4 },
                new SmallTable { NumberOfChairs = 4 },
                new SmallTable { NumberOfChairs = 4 },
                new SmallTable { NumberOfChairs = 5 },
                new SmallTable { NumberOfChairs = 5 },
                new SmallTable { NumberOfChairs = 5 },
                new SmallTable { NumberOfChairs = 5 },
                new SmallTable { NumberOfChairs = 5 }
                );
            _context.SaveChanges();
        }

        private static void AddReservations(DbContext _context)
        {
            _context.AddRange(
                new Reservation { DateCreated = System.DateTime.Now, Duration = System.DateTime.Now, NumberOfPeople = 3, Start = System.DateTime.Now, Status = StatusReservation.Reserved, UserId = "1" },
                new Reservation { DateCreated = System.DateTime.Now, Duration = System.DateTime.Now, NumberOfPeople = 3, Start = System.DateTime.Now, Status = StatusReservation.Reserved, UserId = "1" },
                new Reservation { DateCreated = System.DateTime.Now, Duration = System.DateTime.Now, NumberOfPeople = 3, Start = System.DateTime.Now, Status = StatusReservation.Reserved, UserId = "1" },
                new Reservation { DateCreated = System.DateTime.Now, Duration = System.DateTime.Now, NumberOfPeople = 3, Start = System.DateTime.Now, Status = StatusReservation.Reserved, UserId = "1" }
                );
            _context.SaveChanges();
        }

    }
}
