using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StackITmvc.Models;

namespace StackITmvc.Data
{
    public class StackItContext : DbContext
    {
        public StackItContext(DbContextOptions<StackItContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<K_Admin> K_Admin { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<SubscriptionJobs> SubscriptionJobs { get; set; }
        public DbSet<K_AdminSubscriptions> K_AdminSubscriptions { get; set; }
        public DbSet<K_Operator> K_Operator { get; set; }
        public DbSet<K_OperatorSubscriptions> K_OperatorSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionJobs>()
                .HasKey(sj => new { sj.SubscriptionId, sj.JobId });

            modelBuilder.Entity<SubscriptionJobs>()
                .HasOne(sj => sj.Subscription)
                .WithMany(s => s.SubscriptionJobs)
                .HasForeignKey(sj => sj.SubscriptionId);

            modelBuilder.Entity<SubscriptionJobs>()
                .HasOne(sj => sj.Job)
                .WithMany(j => j.SubscriptionJobs)
                .HasForeignKey(j => j.JobId);

            modelBuilder.Entity<K_AdminSubscriptions>()
                .HasKey(ks => new { ks.K_AdminId, ks.SubscriptionId });

            modelBuilder.Entity<K_AdminSubscriptions>()
                .HasOne(ks => ks.K_Admin)
                .WithMany(k => k.K_AdminSubscriptions)
                .HasForeignKey(ks => ks.K_AdminId);

            modelBuilder.Entity<K_AdminSubscriptions>()
                .HasOne(ks => ks.Subscription)
                .WithMany(s => s.K_AdminSubscriptions)
                .HasForeignKey(s => s.SubscriptionId);

            modelBuilder.Entity<K_OperatorSubscriptions>()
                .HasKey(ks => new { ks.K_OperatorId, ks.SubscriptionId });

            modelBuilder.Entity<K_OperatorSubscriptions>()
                .HasOne(ks => ks.K_Operator)
                .WithMany(k => k.K_OperatorSubscriptions)
                .HasForeignKey(ks => ks.K_OperatorId);

            modelBuilder.Entity<K_OperatorSubscriptions>()
                .HasOne(ks => ks.Subscription)
                .WithMany(s => s.K_OperatorSubscriptions)
                .HasForeignKey(s => s.SubscriptionId);
        }

    }
}
