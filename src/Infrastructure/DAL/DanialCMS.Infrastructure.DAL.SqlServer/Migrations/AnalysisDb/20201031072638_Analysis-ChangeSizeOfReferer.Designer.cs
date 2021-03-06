﻿// <auto-generated />
using System;
using DanialCMS.Infrastructure.DAL.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Migrations.AnalysisDb
{
    [DbContext(typeof(AnalysisDbContext))]
    [Migration("20201031072638_Analysis-ChangeSizeOfReferer")]
    partial class AnalysisChangeSizeOfReferer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DanialCMS.Core.Domain.Analysis.Entities.CMSAnalysis", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrowserName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<long?>("ContentLength")
                        .HasColumnType("bigint");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("HasCockies")
                        .HasColumnType("bit");

                    b.Property<string>("Host")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HttpMethod")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<bool?>("IsHttps")
                        .HasColumnType("bit");

                    b.Property<string>("OSArchitecture")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("OsName")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(700)")
                        .HasMaxLength(700);

                    b.Property<int?>("Port")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<string>("Protocol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Referer")
                        .HasColumnType("nvarchar(700)")
                        .HasMaxLength(700);

                    b.Property<string>("RemoteIpAddress")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int?>("RemotePort")
                        .HasColumnType("int");

                    b.Property<int?>("SatusCode")
                        .HasColumnType("int");

                    b.Property<string>("Scheme")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("CMSAnalysis");
                });
#pragma warning restore 612, 618
        }
    }
}
