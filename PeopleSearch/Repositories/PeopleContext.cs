namespace PeopleSearch
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PeopleContext : DbContext
    {
        public PeopleContext()
            : base("name=PeopleContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.NameLast)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .Property(e => e.AddressPostcode)
                .IsFixedLength();
        }
    }
}
