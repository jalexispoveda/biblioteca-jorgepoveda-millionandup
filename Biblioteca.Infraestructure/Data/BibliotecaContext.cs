using System;
using Biblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Biblioteca.Infraestructure.Data
{
    public partial class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
        {
        }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<AutoresLibros> AutoresLibros { get; set; }
        public virtual DbSet<Editoriales> Editoriales { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autores>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AutoresLibros>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Autores_Libros");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK_Autores_Libros_Autores");

                entity.HasOne(d => d.IdLibrosNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdLibros)
                    .HasConstraintName("FK_Autores_Libros_Libros");
            });

            modelBuilder.Entity<Editoriales>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libros>(entity =>
            {
                entity.Property(e => e.NPaginas)
                    .HasColumnName("N_paginas")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis).HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEditorial)
                    .HasConstraintName("FK_Libros_Editorial");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
