using System;
using System.Collections.Generic;
using CharacterGen.DataTypes;
using Microsoft.EntityFrameworkCore;

namespace CharacterGen.DataStorage
{
    public class SqliteDataStore : IDataStructure
    {
        // Creates storage place for context and the database path
        private readonly CharactersContext context;
        private readonly string dbPath;

        // Constructor that sets the database context
        // @parameter string for database path
        public SqliteDataStore(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            context = new CharactersContext(dbPath);
        }

        // @parameter receives a character to add
        public void AddCharacter(Character c)
        {
            context.Characters.Add(c);
            context.SaveChanges();
        }

        // Returns all characters
        public IEnumerable<Character> GetAllCharacters()
        {
            return context.Characters;
        }
    }

    class CharactersContext : DbContext
    {
        private static bool _created = false;
        private readonly string dbPath;

        public CharactersContext(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));

            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite($@"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasKey(c => c.Id);
        }

        public DbSet<Character> Characters { get; set; }
    }
}
