﻿// <auto-generated />
using GerenciamentoDeOportunidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciamentoDeOportunidades.Migrations
{
    [DbContext(typeof(OportunidadesContext))]
    [Migration("20220902004347_FifthMigration")]
    partial class FifthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GerenciamentoDeOportunidades.Oportunidade", b =>
                {
                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodEstadoIBGE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoDeAtividades")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("ValorMonetario")
                        .HasColumnType("real");

                    b.HasKey("CNPJ");

                    b.HasIndex("UsuarioEmail");

                    b.ToTable("Oportunidades");
                });

            modelBuilder.Entity("GerenciamentoDeOportunidades.Usuario", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Regiao")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GerenciamentoDeOportunidades.Oportunidade", b =>
                {
                    b.HasOne("GerenciamentoDeOportunidades.Usuario", null)
                        .WithMany("Oportunidades")
                        .HasForeignKey("UsuarioEmail");
                });

            modelBuilder.Entity("GerenciamentoDeOportunidades.Usuario", b =>
                {
                    b.Navigation("Oportunidades");
                });
#pragma warning restore 612, 618
        }
    }
}
