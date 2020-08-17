using Microsoft.EntityFrameworkCore;
using RVTR.Account.ObjectModel.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using RVTR.Account.DataContext.DTOModels;

namespace RVTR.Account.DataContext
{
    /// <summary>
    /// Represents the _Account_ context
    /// </summary>
    public class AccountContext : DbContext
    {
    //public DbSet<AccountModel> Accounts { get; set; }
    //public DbSet<ProfileModel> Profiles { get; set; }

    //public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<AccountModel>().HasKey(e => e.Id);
    //    modelBuilder.Entity<AddressModel>().HasKey(e => e.Id);
    //    modelBuilder.Entity<BankCardModel>().HasKey(e => e.Id);
    //    modelBuilder.Entity<NameModel>().HasKey(e => e.Id);
    //    modelBuilder.Entity<PaymentModel>().HasKey(e => e.Id);
    //    modelBuilder.Entity<ProfileModel>().HasKey(e => e.Id);

    //}
    public DbSet<AccountDTO> Accounts { get; set; }
    public DbSet<ProfileDTO> Profiles { get; set; }

    public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<AccountDTO>().HasKey(e => e.Id);
      modelBuilder.Entity<AddressDTO>().HasKey(e => e.Id);
      modelBuilder.Entity<BankCardDTO>().HasKey(e => e.Id);
      modelBuilder.Entity<NameDTO>().HasKey(e => e.Id);
      modelBuilder.Entity<PaymentDTO>().HasKey(e => e.Id);
      modelBuilder.Entity<ProfileDTO>().HasKey(e => e.Id);

    }
  }
}
