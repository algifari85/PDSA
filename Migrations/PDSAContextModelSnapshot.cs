﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PDSA.Models;

namespace PDSA.Migrations
{
    [DbContext(typeof(PDSAContext))]
    partial class PDSAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PDSA.Models.Etiologi", b =>
                {
                    b.Property<int>("EtiologiID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ProblemID");

                    b.HasKey("EtiologiID");

                    b.HasIndex("ProblemID");

                    b.ToTable("Etiologi");
                });

            modelBuilder.Entity("PDSA.Models.Problem", b =>
                {
                    b.Property<int>("ProblemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ProcessID");

                    b.HasKey("ProblemID");

                    b.HasIndex("ProcessID");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("PDSA.Models.Process", b =>
                {
                    b.Property<int>("ProcessID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ProcessUnitUnitID");

                    b.HasKey("ProcessID");

                    b.HasIndex("ProcessUnitUnitID");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("PDSA.Models.Solution", b =>
                {
                    b.Property<int>("SolutionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("DoEndTime");

                    b.Property<DateTime>("DoStartTime");

                    b.Property<string>("Name");

                    b.Property<int?>("ProblemID");

                    b.HasKey("SolutionID");

                    b.HasIndex("ProblemID");

                    b.ToTable("Solution");
                });

            modelBuilder.Entity("PDSA.Models.Unit", b =>
                {
                    b.Property<int>("UnitID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UnitName");

                    b.HasKey("UnitID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("PDSA.Models.Etiologi", b =>
                {
                    b.HasOne("PDSA.Models.Problem")
                        .WithMany("Etiologis")
                        .HasForeignKey("ProblemID");
                });

            modelBuilder.Entity("PDSA.Models.Problem", b =>
                {
                    b.HasOne("PDSA.Models.Process")
                        .WithMany("Problems")
                        .HasForeignKey("ProcessID");
                });

            modelBuilder.Entity("PDSA.Models.Process", b =>
                {
                    b.HasOne("PDSA.Models.Unit", "ProcessUnit")
                        .WithMany("Processes")
                        .HasForeignKey("ProcessUnitUnitID");
                });

            modelBuilder.Entity("PDSA.Models.Solution", b =>
                {
                    b.HasOne("PDSA.Models.Problem")
                        .WithMany("Solutions")
                        .HasForeignKey("ProblemID");
                });
#pragma warning restore 612, 618
        }
    }
}
