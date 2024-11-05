﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ganbare.src.Database;
using ganbare.src.Entity;

#nullable disable

namespace ganbare.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241105074735_haya")]
    partial class haya
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "quiz_level", new[] { "n5", "n4", "n3", "n2", "n1" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "role", new[] { "admin", "customer" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ganbare.src.Entity.Leaderboard", b =>
                {
                    b.Property<Guid>("LeaderboardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("LeaderboardId");

                    b.ToTable("Leaderboards");
                });

            modelBuilder.Entity("ganbare.src.Entity.Option", b =>
                {
                    b.Property<Guid>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("choice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("ganbare.src.Entity.Question", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid?>("QuizId")
                        .HasColumnType("uuid");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ganbare.src.Entity.Quiz", b =>
                {
                    b.Property<Guid>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<QuizLevel>("Level")
                        .HasColumnType("quiz_level");

                    b.Property<int>("QuizScore")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ResultId")
                        .HasColumnType("uuid");

                    b.Property<float?>("TimeTaken")
                        .HasColumnType("real");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("QuizId");

                    b.HasIndex("ResultId");

                    b.HasIndex("UserId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("ganbare.src.Entity.Result", b =>
                {
                    b.Property<Guid>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LeaderboardId")
                        .HasColumnType("uuid");

                    b.Property<TimeSpan?>("Speed")
                        .HasColumnType("interval");

                    b.Property<double?>("TotalScore")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ResultId");

                    b.HasIndex("LeaderboardId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("ganbare.src.Entity.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Role>("Role")
                        .HasColumnType("role");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ganbare.src.Entity.Option", b =>
                {
                    b.HasOne("ganbare.src.Entity.Question", null)
                        .WithMany("Options")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("ganbare.src.Entity.Question", b =>
                {
                    b.HasOne("ganbare.src.Entity.Quiz", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuizId");
                });

            modelBuilder.Entity("ganbare.src.Entity.Quiz", b =>
                {
                    b.HasOne("ganbare.src.Entity.Result", null)
                        .WithMany("Quizzes")
                        .HasForeignKey("ResultId");

                    b.HasOne("ganbare.src.Entity.User", null)
                        .WithMany("Quizzes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ganbare.src.Entity.Result", b =>
                {
                    b.HasOne("ganbare.src.Entity.Leaderboard", null)
                        .WithMany("Results")
                        .HasForeignKey("LeaderboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ganbare.src.Entity.Leaderboard", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("ganbare.src.Entity.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("ganbare.src.Entity.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ganbare.src.Entity.Result", b =>
                {
                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("ganbare.src.Entity.User", b =>
                {
                    b.Navigation("Quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
