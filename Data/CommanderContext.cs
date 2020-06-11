using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Command>().HasData(
                new Command
                {
                    Id = 1,
                        HowTo = "Boil an egg",
                        Line = "Boil water",
                        Platform = "Kettle & Pan"
                },
                new Command
                {
                    Id = 2,
                        HowTo = "Cut bread",
                        Line = "Get a knife",
                        Platform = "Knife & chopping board"
                },
                new Command
                {
                    Id = 3,
                        HowTo = "Make cup of tea",
                        Line = "Place teabug in cup",
                        Platform = "Kettle & Cup"
                }
            );
        }
    }
}