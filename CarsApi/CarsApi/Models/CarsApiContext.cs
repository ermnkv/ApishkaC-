using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarsApi.Models;

public partial class CarsApiContext : DbContext
{
    public CarsApiContext()
    {
    }

    public CarsApiContext(DbContextOptions<CarsApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Channel> Channels { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.IdCar);

            entity.ToTable("cars");

            entity.Property(e => e.IdCar).HasColumnName("id_car");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cars_users");
        });

        modelBuilder.Entity<Channel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__channels__3213E83FF13B4603");

            entity.ToTable("channels");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.Channels)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKc6sorav30ddgywp6vt99wen6x");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.IdCom);

            entity.ToTable("comment");

            entity.Property(e => e.IdCom).HasColumnName("id_com");
            entity.Property(e => e.ComPost).HasColumnName("com_post");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.ComPostNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ComPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comment_posts");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comment_users");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent);

            entity.ToTable("events");

            entity.Property(e => e.IdEvent)
                .ValueGeneratedNever()
                .HasColumnName("id_event");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_events_users");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__posts__3213E83F79A02219");

            entity.ToTable("posts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChannelId).HasColumnName("channel_id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Channel).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ChannelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK5d144ba1aao7dgdj6ksonkp32");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.IdTrip);

            entity.ToTable("trips");

            entity.Property(e => e.IdTrip)
                .ValueGeneratedNever()
                .HasColumnName("id_trip");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.EndData)
                .HasColumnType("datetime")
                .HasColumnName("end_data");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.StartData)
                .HasColumnType("datetime")
                .HasColumnName("start_data");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Trips)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_trips_users");

            entity.HasMany(d => d.IdUsers).WithMany(p => p.IdTrips)
                .UsingEntity<Dictionary<string, object>>(
                    "Tripsparticipation",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tripsparticipation_users"),
                    l => l.HasOne<Trip>().WithMany()
                        .HasForeignKey("IdTrip")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tripsparticipation_trips"),
                    j =>
                    {
                        j.HasKey("IdTrip", "IdUser");
                        j.ToTable("tripsparticipation");
                        j.IndexerProperty<long>("IdTrip").HasColumnName("id_trip");
                        j.IndexerProperty<long>("IdUser").HasColumnName("id_user");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FD758E07C");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasMany(d => d.IdChannels).WithMany(p => p.IdUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "Follower",
                    r => r.HasOne<Channel>().WithMany()
                        .HasForeignKey("IdChannel")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_followers_channels"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_followers_users"),
                    j =>
                    {
                        j.HasKey("IdUser", "IdChannel");
                        j.ToTable("followers");
                        j.IndexerProperty<long>("IdUser").HasColumnName("id_user");
                        j.IndexerProperty<long>("IdChannel").HasColumnName("id_channel");
                    });

            entity.HasMany(d => d.LikePosts).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "Like",
                    r => r.HasOne<Post>().WithMany()
                        .HasForeignKey("LikePost")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_likes_posts"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_likes_users"),
                    j =>
                    {
                        j.HasKey("Id", "LikePost");
                        j.ToTable("likes");
                        j.IndexerProperty<long>("Id").HasColumnName("id");
                        j.IndexerProperty<long>("LikePost").HasColumnName("like_post");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
