using DigitalKeyMarket.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
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
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins").HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens").HasNoKey();
        modelBuilder.Entity<RoleEntity>().ToTable("user_roles");
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("user_role_claims");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("user_role_owners").HasNoKey();
        
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.Username).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<UserEntity>().HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);

        modelBuilder.Entity<RoleEntity>().HasKey(u => u.Id);
        modelBuilder.Entity<RoleEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<RoleEntity>().HasIndex(x => x.Name).IsUnique();

        modelBuilder.Entity<PlatformEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<PlatformEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<PlatformEntity>().HasIndex(x => x.Name).IsUnique();

        modelBuilder.Entity<MarketplaceEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<MarketplaceEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<MarketplaceEntity>().HasIndex(x => x.Name).IsUnique();

        modelBuilder.Entity<PlaygateEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<PlaygateEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<PlaygateEntity>().HasIndex(x => new { x.PlatformId, x.ExternalId }).IsUnique();
        modelBuilder.Entity<PlaygateEntity>().HasOne(x => x.Platform)
            .WithMany(x => x.Marketplaces)
            .HasForeignKey(x => x.PlatformId);
        modelBuilder.Entity<PlaygateEntity>().HasOne(x => x.Marketplace)
            .WithMany(x => x.Platforms)
            .HasForeignKey(x => x.MarketplaceId);

        modelBuilder.Entity<GenreEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<GenreEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<GenreEntity>().HasIndex(x => x.Name).IsUnique();

        modelBuilder.Entity<GameEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<GameEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<GameEntity>().HasIndex(x => new { x.Name, x.ReleaseDate }).IsUnique();
        modelBuilder.Entity<GameEntity>().HasMany(x => x.Genres)
            .WithMany(x => x.Games)
            .UsingEntity(x => x.ToTable("Tag"));

        modelBuilder.Entity<EditionEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<EditionEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<EditionEntity>().HasIndex(x => x.Name).IsUnique();

        modelBuilder.Entity<ItemEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ItemEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<ItemEntity>().HasIndex(x => new { x.GameId, x.PlaygateId, x.EditionId }).IsUnique();
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
        modelBuilder.Entity<PurchaseEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<PurchaseEntity>().HasIndex(x => new { x.UserId, x.ItemId, x.Date }).IsUnique();
        modelBuilder.Entity<PurchaseEntity>().HasOne(x => x.User)
            .WithMany(x => x.Purchases)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<PurchaseEntity>().HasOne(x => x.Item)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.ItemId);
    }
}