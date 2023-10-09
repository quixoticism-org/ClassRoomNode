﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20231003111923_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Application.Domain.Entities.ClassMember", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClassRoomId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<Guid>("OrgMemberId")
                        .HasColumnType("uuid");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("OrgMemberId");

                    b.ToTable("ClassMembers");
                });

            modelBuilder.Entity("Application.Domain.Entities.ClassRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OrgMemberCreatorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("OrgMemberCreatorId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Application.Domain.Entities.OrgMember", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("OrgMembers");
                });

            modelBuilder.Entity("Application.Domain.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("UserCreatorId")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatorId");

                    b.HasIndex("UserCreatorId", "Name")
                        .IsUnique();

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Application.Domain.Entities.ClassMember", b =>
                {
                    b.HasOne("Application.Domain.Entities.ClassRoom", "ClassRoom")
                        .WithMany("ClassMemberList")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Domain.Entities.OrgMember", "OrgMember")
                        .WithMany("ClassMemberList")
                        .HasForeignKey("OrgMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");

                    b.Navigation("OrgMember");
                });

            modelBuilder.Entity("Application.Domain.Entities.ClassRoom", b =>
                {
                    b.HasOne("Application.Domain.Entities.OrgMember", "OrgMemberCreator")
                        .WithMany("MyCreatedClassRoomList")
                        .HasForeignKey("OrgMemberCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Domain.Entities.Organization", "Organization")
                        .WithMany("ClassRoomList")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrgMemberCreator");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Application.Domain.Entities.OrgMember", b =>
                {
                    b.HasOne("Application.Domain.Entities.Organization", "Organization")
                        .WithMany("MemberList")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Application.Domain.Entities.ClassRoom", b =>
                {
                    b.Navigation("ClassMemberList");
                });

            modelBuilder.Entity("Application.Domain.Entities.OrgMember", b =>
                {
                    b.Navigation("ClassMemberList");

                    b.Navigation("MyCreatedClassRoomList");
                });

            modelBuilder.Entity("Application.Domain.Entities.Organization", b =>
                {
                    b.Navigation("ClassRoomList");

                    b.Navigation("MemberList");
                });
#pragma warning restore 612, 618
        }
    }
}
