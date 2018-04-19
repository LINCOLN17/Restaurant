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
            AddRoles(context);
            AddStatusReservations(context);
            AddSmallTables(context);

        }

        private static void AddRoles(DbContext _context)
        {
            _context.AddRange(
                new Role { Name = "Admin" },
                new Role { Name = "User" }
                );
            _context.SaveChanges();
        }

        private static void AddStatusReservations(DbContext _context)
        {
            _context.AddRange(
                new StatusReservation { Name = "Cancelled", Description = "Cancelled" },
                new StatusReservation { Name = "Reserved", Description = "Reserved" }
                );
            _context.SaveChanges();
        }

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

    }
}
