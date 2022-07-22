using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookApi.Models
{
    public partial class MeetingRoomAppBooksContext : DbContext
    {
        public MeetingRoomAppBooksContext()
        {
        }

        public MeetingRoomAppBooksContext(DbContextOptions<MeetingRoomAppBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-6PJL0PD;Database=MeetingRoomAppBooks;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.MeetingRoomId).HasColumnName("meetingRoomId");

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
