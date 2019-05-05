namespace FormApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=dataConnection")
        {
        }

        public virtual DbSet<Fields> Fields { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fields>()
                .HasMany(e => e.Forms)
                .WithRequired(e => e.Fields)
                .HasForeignKey(e => e.FieldId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Forms)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);
        }
    }
}
