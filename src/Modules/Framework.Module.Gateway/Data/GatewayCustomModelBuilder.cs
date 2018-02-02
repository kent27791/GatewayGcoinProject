using Framework.Infrastructure.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Module.Gateway.Models;
namespace Framework.Module.Gateway.Data
{
    public class GatewayCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchant>(b =>
            {
                b.HasKey(me => me.Id);
                b.ToTable("Gateway_Merchant");
            });

            modelBuilder.Entity<Transaction>(b =>
            {
                b.HasKey(ts => ts.Id);
                b.ToTable("Gateway_Transaction");
            });

            modelBuilder.Entity<UserConfig>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.ToTable("Gateway_UserConfig");
            });

            modelBuilder.Entity<UserWallet>(b =>
            {
                b.HasKey(uw => uw.Id);
                b.ToTable("Gateway_UserWallet");
            });

            modelBuilder.Entity<UserWallet>(b =>
            {
                b.HasOne(uw => uw.UserConfig).WithOne(uc => uc.UserWallet);
            });

            modelBuilder.Entity<Merchant>(b =>
            {
                b.HasMany(me => me.Transactions)
                    .WithOne(ts => ts.Merchant)
                    .HasForeignKey(ts => ts.MerchantId);
                b.HasOne(me => me.UserWallet)
                    .WithMany(uw => uw.Merchants)
                    .HasForeignKey(me => me.UserId);
                b.HasOne(me => me.UserConfig)
                    .WithMany(uc => uc.Merchants)
                    .HasForeignKey(me => me.UserId);
            });
        }
    }
}
