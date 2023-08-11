﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Data;

#nullable disable

namespace ToDoApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230811201322_AddingNotificationsOnToDoTask")]
    partial class AddingNotificationsOnToDoTask
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("ToDoApp.Entities.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("ToDoTaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ToDoTaskId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ToDoApp.Entities.Models.ToDoTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Color")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CompletedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Notify")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ToDoTasks");
                });

            modelBuilder.Entity("ToDoApp.Entities.Models.Notification", b =>
                {
                    b.HasOne("ToDoApp.Entities.Models.ToDoTask", "ToDoTask")
                        .WithMany()
                        .HasForeignKey("ToDoTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDoTask");
                });
#pragma warning restore 612, 618
        }
    }
}
