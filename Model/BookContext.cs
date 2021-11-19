using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFWithFluentApi.Model
{
    internal class BookContext: DbContext
    {
        //we connect the model`s class in this context
        public DbSet<Book> Books { get; set; }

        //we can build the database in this overrided method 
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=book.db");
        }

        //We avoid the use of annotations with Fluent API in this overrided method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(x => x.ID);

            modelBuilder.Entity<Book>()
                .Property(x => x.Actor)
                .IsRequired()
                .HasColumnName("the actor of this book");

            modelBuilder.Entity<Book>()
                .Property(x => x.Title)
                .IsRequired()
                .HasColumnName("the title of this book");

            modelBuilder.Entity<Book>()
                .Property(x => x.Description)
                .HasMaxLength(20)
                .HasColumnName("the description of this book");
        }
    }
}
