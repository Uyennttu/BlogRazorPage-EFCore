using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogRazorPage.Models;

namespace BlogRazorPage.Data
{
    public class BlogRazorPageContext : DbContext
    {
        public BlogRazorPageContext(DbContextOptions<BlogRazorPageContext> options)
            : base(options)
        {
        }
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Blog> Blog { get; set; } = default!;

        // defines the one-to-many relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
            .HasOne(b => b.Author)      // Blog has one Author
            .WithMany()                 // No navigation property on Author
            .HasForeignKey(b => b.AuthorId)  // Foreign key is AuthorId in Blog
            .OnDelete(DeleteBehavior.Cascade);  // Optional: cascade delete                

            // Seed Author
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Author1"
                }
            );

            // Seed Blog and link it to the Author
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    Title = "Blog1",
                    Content = "Blog1 Content",
                    CreatedDate = DateTime.UtcNow,
                    AuthorId = 1 // Foreign key to Author table
                }

            );
            // Call the base OnModelCreating
            base.OnModelCreating(modelBuilder);
        }

        }
        }
    