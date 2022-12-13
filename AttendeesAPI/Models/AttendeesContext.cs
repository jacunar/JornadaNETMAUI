using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AttendeesAPI.Models {
    public partial class AttendeesContext : DbContext {
        public AttendeesContext() {
        }

        public AttendeesContext(DbContextOptions<AttendeesContext> options)
            : base(options) {
        }

        public virtual DbSet<Attendee> Attendees { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<SessionAttendee> SessionAttendees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Attendee>(entity => {
                entity.Property(e => e.AttendanceDate).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Session>(entity => {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SessionAttendee>(entity => {
                entity.HasKey(e => e.SessionAttendeesId)
                    .HasName("PK__SessionA__5F28A6C323AAC996");

                entity.HasOne(d => d.Attendee)
                    .WithMany(p => p.SessionAttendees)
                    .HasForeignKey(d => d.AttendeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SessionAt__Atten__3B75D760");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionAttendees)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SessionAt__Sessi__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}