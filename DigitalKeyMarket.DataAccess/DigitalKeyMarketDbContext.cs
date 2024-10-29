using DigitalKeyMarket.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalKeyMarket.DataAccess;
public class DigitalKeyMarketDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<PlatformEntity> Platforms { get; set; }
    public DbSet<MarketplaceEntity> Marketplaces { get; set; }
    public DbSet<PlaygateEntity> Playgates { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<GameEntity> Games { get; set; }
    public DbSet<EditionEntity> Editions { get; set; }
    public DbSet<ItemEntity> Items { get; set; }
    public DbSet<PurchaseEntity> Purchases { get; set; }

    public DigitalKeyMarketDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        
        modelBuilder.Entity<RoleEntity>().HasKey(u => u.Id);
        modelBuilder.Entity<RoleEntity>().HasMany(x => x.Users)
            .WithMany(x => x.Roles)
            .UsingEntity(x => x.ToTable("Permission"));
        
        modelBuilder.Entity<PlatformEntity>().HasKey(x => x.Id);
        
        modelBuilder.Entity<MarketplaceEntity>().HasKey(x => x.Id);
        
        modelBuilder.Entity<PlaygateEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<PlaygateEntity>().HasOne(x => x.Platform)
            .WithMany(x => x.Marketplaces)
            .HasForeignKey(x => x.PlatformId);
        modelBuilder.Entity<PlaygateEntity>().HasOne(x => x.Marketplace)
            .WithMany(x => x.Platforms)
            .HasForeignKey(x => x.MarketplaceId);

        modelBuilder.Entity<GenreEntity>().HasKey(x => x.Id);
        
        modelBuilder.Entity<GameEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<GameEntity>().HasMany(x => x.Genres)
            .WithMany(x => x.Games)
            .UsingEntity(x => x.ToTable("Tag"));

        modelBuilder.Entity<EditionEntity>().HasKey(x => x.Id);
        
        modelBuilder.Entity<ItemEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ItemEntity>().HasOne(x => x.Game)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.GameId);
        modelBuilder.Entity<ItemEntity>().HasOne(x => x.Edition)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.EditionId);
        modelBuilder.Entity<ItemEntity>().HasOne(x => x.Playgate)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.PlaygateId);
        
        
        modelBuilder.Entity<PurchaseEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<PurchaseEntity>().HasOne(x => x.User)
            .WithMany(x => x.Purchases)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<PurchaseEntity>().HasOne(x => x.Item)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ItemId);
    }
}