using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core.Models;

namespace OseredokManagementSystem.Server.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>()
                .HasOne(c => c.User)
                .WithOne(u => u.Client)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Session>()
                .HasOne(s => s.Coach)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.CoachId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Session>()
                .HasOne(s => s.Client)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Session>()
               .HasOne(s => s.Gym)
               .WithMany(g => g.Sessions)
               .HasForeignKey(s => s.GymId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Coach>()
                .HasOne(c => c.User)
                .WithOne(u => u.Coach)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Client>()
                .HasOne(c => c.Gym)
                .WithMany(g => g.Clients)
                .HasForeignKey(c => c.GymId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Role>()
                .HasData(
                new Role
                {
                    Id = 1,
                    Name = "admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "coach"
                },
                new Role
                {
                    Id = 3,
                    Name = "client"
                }
                );
            builder.Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Nazar",
                    LastName = "Sachuk",
                    MiddleName = "Igorovych",
                    DateOfBirth = new DateTime(2002, 06, 09),
                    RegDate = DateTime.Now,
                    RoleId = 3,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                    ProfileImgPath = "some/path"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Nazar2",
                    LastName = "Sachuk2",
                    MiddleName = "Igorovych2",
                    DateOfBirth = new DateTime(2002, 06, 09),
                    RegDate = DateTime.Now,
                    RoleId = 3,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                    ProfileImgPath = "some/path"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Nazar3",
                    LastName = "Sachuk3",
                    MiddleName = "Igorovych3",
                    DateOfBirth = new DateTime(2002, 06, 09),
                    RegDate = DateTime.Now,
                    RoleId = 3,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                    ProfileImgPath = "some/path"
                },
                new User
                {
                    Id = 4,
                    FirstName = "Max",
                    LastName = "Smirnov",
                    MiddleName = "lorem",
                    DateOfBirth = new DateTime(2002, 06, 09),
                    RegDate = DateTime.Now,
                    RoleId = 2,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                    ProfileImgPath = "some/path"
                },
                new User
                {
                    Id = 5,
                    FirstName = "Masha",
                    LastName = "lorem",
                    MiddleName = "lorem",
                    DateOfBirth = new DateTime(2002, 06, 09),
                    RegDate = DateTime.Now,
                    RoleId = 1,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                    ProfileImgPath = "some/path"
                },
                new User
                {
                    Id = 6,
                    FirstName = "Pasha",
                    LastName = "Mamchyr",
                    MiddleName = "Olexandrovych",
                    DateOfBirth = new DateTime(2002, 03, 15),
                    RegDate = DateTime.Now,
                    RoleId = 2,
                    Password = "loremIpsum123",
                    PhoneNumber = "0509781078",
                    ProfileImgPath = "some/path"
                }
                );
            builder.Entity<Admin>()
                .HasData(
                new Admin
                {
                    Id = 1,
                    UserId = 5,
                    Salary = 6000,
                    GymId = 1,
                }
                );
            builder.Entity<ClientPayment>()
                .HasData(
                new ClientPayment
                {
                    Id = 1,
                    Balance = 100,
                    LastPaymentDate = new DateTime(2022, 06, 05),
                    LastPaymentSum = 100,
                    PaymentPerSession = 50
                }
            );
            builder.Entity<Coach>()
                .HasData(
                new Coach
                {
                    Id = 1,
                    UserId = 4,
                    PercentagePerSession = 10,
                    GymId = 1,
                }
                );
            builder.Entity<Client>()
                .HasData(
                new Client
                {
                    Id = 1,
                    UserId = 1,
                    ClientPaymentId = 1,
                    CoachId = 1,
                    GymId = 1
                }
                );
            builder.Entity<Gym>()
                .HasData(
                new Gym
                {
                    Id = 1,
                    Address = "someAddress",
                    ClientCapacity = 5,
                }
                );
            builder.Entity<SessionStatus>()
                .HasData(
                new SessionStatus
                {
                    Id = 4,
                    Name = "awaiting"
                },
                new SessionStatus
                {
                    Id = 5,
                    Name = "accepted"
                },
                new SessionStatus
                {
                    Id = 6,
                    Name = "inProcess"
                },
                new SessionStatus
                {
                    Id = 7,
                    Name = "completed"
                }
                );
            builder.Entity<Session>()
                .HasData(
                new Session
                {
                    Id = 1,
                    SessionDate = new DateTime(2022, 06, 05),
                    CoachId = 1,
                    ClientId = 1,
                    GymId = 1,
                    SessionStatusId = 5
                },
                new Session
                {
                    Id = 2,
                    SessionDate = new DateTime(2022, 06, 05),
                    CoachId = 1,
                    ClientId = 1,
                    GymId = 1,
                    SessionStatusId = 6
                },
                new Session
                {
                    Id = 3,
                    SessionDate = new DateTime(2022, 06, 05),
                    CoachId = 1,
                    ClientId = 1,
                    GymId = 1,
                    SessionStatusId = 7
                }
                );
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionStatus> SessionStatuses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<ClientPayment> ClientPayments { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}