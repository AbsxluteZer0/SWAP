using Microsoft.EntityFrameworkCore;
using SWAP.DAL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.DAL.Data.Contexts
{
    public partial class GameStoreDbContext : DbContext
    {
        public string ConnectionString { get; private set; }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameGenre> GameGenres { get; set; }
        public virtual DbSet<GameOrder> GameOrders { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public GameStoreDbContext(string connection)
        {
            ConnectionString = connection;
            Database.EnsureCreated();
        }

        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(7,2)")
                    .HasColumnName("price");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.ToTable("game_genre");

                entity.HasKey(e => e.RelationId);

                entity.Property(e => e.RelationId).HasColumnName("relation_id");

                entity.HasIndex(e => e.GameId, "game_id");

                entity.HasIndex(e => e.GenreId, "genre_id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("game_genre_ibfk_1");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("game_genre_ibfk_2");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.TransactionKey);

                entity.ToTable("order");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.TransactionKey)
                    .HasMaxLength(64)
                    .HasColumnName("transaction_key")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .HasConstraintName("order_ibfk_1");
            });

            modelBuilder.Entity<GameOrder>(entity =>
            {
                entity.ToTable("game_order");

                entity.HasKey(e => e.RelationId);

                entity.Property(e => e.RelationId).HasColumnName("relation_id");

                entity.HasIndex(e => e.GameId, "game_id");

                entity.HasIndex(e => e.OrderId, "order_id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id")
                                               .HasMaxLength(64)
                                               .IsFixedLength(true);

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("game_order_ibfk_1");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("game_order_ibfk_2");
            });

            modelBuilder.Entity<User>(entity => 
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(320)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.RelationId);

                entity.ToTable("shopping_cart");

                entity.Property(e => e.RelationId).HasColumnName("relation_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.HasIndex(e => e.GameId, "game_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(u => u.UserId)
                    .HasConstraintName("shopping_cart_ibfk_1");

                entity.HasOne(g => g.Game)
                    .WithMany()
                    .HasForeignKey(g => g.GameId)
                    .HasConstraintName("shopping_cart_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
