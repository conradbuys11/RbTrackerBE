﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RbTrackerBE.DatabaseContext;

#nullable disable

namespace RbTrackerBE.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250202022245_PlayoffPicture")]
    partial class PlayoffPicture
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RbTrackerBE.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("integer");

                    b.Property<int?>("AwayTeamScore")
                        .HasColumnType("integer");

                    b.Property<int>("GameType")
                        .HasColumnType("integer");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("integer");

                    b.Property<int?>("HomeTeamScore")
                        .HasColumnType("integer");

                    b.Property<int>("WeekId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("WeekId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("RbTrackerBE.Models.PlayoffPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("WeekId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WeekId")
                        .IsUnique();

                    b.ToTable("PlayoffPicture");
                });

            modelBuilder.Entity("RbTrackerBE.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Conference")
                        .HasColumnType("integer");

                    b.Property<int>("Division")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("RbTrackerBE.Models.TeamInYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ByeId")
                        .HasColumnType("integer");

                    b.Property<float>("DfRating")
                        .HasColumnType("real");

                    b.Property<int>("LikelyLosses")
                        .HasColumnType("integer");

                    b.Property<int>("LikelyTies")
                        .HasColumnType("integer");

                    b.Property<int>("LikelyWins")
                        .HasColumnType("integer");

                    b.Property<int>("Losses")
                        .HasColumnType("integer");

                    b.Property<float>("OfRating")
                        .HasColumnType("real");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.Property<int>("Ties")
                        .HasColumnType("integer");

                    b.Property<int>("Wins")
                        .HasColumnType("integer");

                    b.Property<int>("YearId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ByeId");

                    b.HasIndex("TeamId");

                    b.HasIndex("YearId");

                    b.ToTable("TeamsInYears");
                });

            modelBuilder.Entity("RbTrackerBE.Models.TiyInPlayoffPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Conference")
                        .HasColumnType("integer");

                    b.Property<int>("PlayoffPictureId")
                        .HasColumnType("integer");

                    b.Property<string>("Record")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Seed")
                        .HasColumnType("integer");

                    b.Property<int>("TeamInYearId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayoffPictureId");

                    b.HasIndex("TeamInYearId");

                    b.ToTable("TiyInPlayoffPicture");
                });

            modelBuilder.Entity("RbTrackerBE.Models.Week", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("WeekNo")
                        .HasColumnType("integer");

                    b.Property<int>("YearId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("YearId");

                    b.ToTable("Weeks");
                });

            modelBuilder.Entity("RbTrackerBE.Models.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("YearNo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Years");
                });

            modelBuilder.Entity("RbTrackerBE.Models.Game", b =>
                {
                    b.HasOne("RbTrackerBE.Models.TeamInYear", "AwayTeam")
                        .WithMany("AwayGames")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RbTrackerBE.Models.TeamInYear", "HomeTeam")
                        .WithMany("HomeGames")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RbTrackerBE.Models.Week", null)
                        .WithMany("Games")
                        .HasForeignKey("WeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("RbTrackerBE.Models.PlayoffPicture", b =>
                {
                    b.HasOne("RbTrackerBE.Models.Week", "Week")
                        .WithOne("PlayoffPicture")
                        .HasForeignKey("RbTrackerBE.Models.PlayoffPicture", "WeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Week");
                });

            modelBuilder.Entity("RbTrackerBE.Models.TeamInYear", b =>
                {
                    b.HasOne("RbTrackerBE.Models.Week", "Bye")
                        .WithMany("Byes")
                        .HasForeignKey("ByeId");

                    b.HasOne("RbTrackerBE.Models.Team", "Team")
                        .WithMany("TeamInYears")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RbTrackerBE.Models.Year", null)
                        .WithMany("TeamInYears")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bye");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("RbTrackerBE.Models.TiyInPlayoffPicture", b =>
                {
                    b.HasOne("RbTrackerBE.Models.PlayoffPicture", "PlayoffPicture")
                        .WithMany("TiyInPlayoffPictures")
                        .HasForeignKey("PlayoffPictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RbTrackerBE.Models.TeamInYear", "TeamInYear")
                        .WithMany()
                        .HasForeignKey("TeamInYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayoffPicture");

                    b.Navigation("TeamInYear");
                });

            modelBuilder.Entity("RbTrackerBE.Models.Week", b =>
                {
                    b.HasOne("RbTrackerBE.Models.Year", "Year")
                        .WithMany("Weeks")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Year");
                });

            modelBuilder.Entity("RbTrackerBE.Models.PlayoffPicture", b =>
                {
                    b.Navigation("TiyInPlayoffPictures");
                });

            modelBuilder.Entity("RbTrackerBE.Models.Team", b =>
                {
                    b.Navigation("TeamInYears");
                });

            modelBuilder.Entity("RbTrackerBE.Models.TeamInYear", b =>
                {
                    b.Navigation("AwayGames");

                    b.Navigation("HomeGames");
                });

            modelBuilder.Entity("RbTrackerBE.Models.Week", b =>
                {
                    b.Navigation("Byes");

                    b.Navigation("Games");

                    b.Navigation("PlayoffPicture");
                });

            modelBuilder.Entity("RbTrackerBE.Models.Year", b =>
                {
                    b.Navigation("TeamInYears");

                    b.Navigation("Weeks");
                });
#pragma warning restore 612, 618
        }
    }
}
