﻿using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Campaign> Campaigns => Set<Campaign>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<CustomerGroup> CustomerGroups => Set<CustomerGroup>();
        public DbSet<CampaignGroup> CampaignGroups => Set<CampaignGroup>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(_ => !_.IsDeleted && _.IsActive);
            modelBuilder.Entity<Group>().HasQueryFilter(_ => !_.IsDeleted && _.IsActive);
            modelBuilder.Entity<Customer>().HasQueryFilter(_ => !_.IsDeleted && _.IsActive);
            modelBuilder.Entity<Campaign>().HasQueryFilter(_ => !_.IsDeleted && _.IsActive);
        }
    }
}
