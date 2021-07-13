﻿// <auto-generated />
using System;
using CadEscola.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadEscola.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210713011138_responsaveis")]
    partial class responsaveis
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CadEscola.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NumeroCertidaoNova")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId");

                    b.HasIndex("ResponsavelId")
                        .IsUnique();

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("CadEscola.Models.Responsavel", b =>
                {
                    b.Property<int>("ResponsavelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Nome")
                        .HasMaxLength(180)
                        .HasColumnType("int");

                    b.HasKey("ResponsavelId");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("CadEscola.Models.Aluno", b =>
                {
                    b.HasOne("CadEscola.Models.Responsavel", "Responsavel")
                        .WithOne("Aluno")
                        .HasForeignKey("CadEscola.Models.Aluno", "ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsavel");
                });

            modelBuilder.Entity("CadEscola.Models.Responsavel", b =>
                {
                    b.Navigation("Aluno");
                });
#pragma warning restore 612, 618
        }
    }
}
