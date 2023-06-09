﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aspenlaub.Net.GitHub.CSharp.DotNetEfToy.Migrations {
    [DbContext(typeof(ToyContext))]
    [Migration("20230425060415_EntityFrameworkCore702")]
    partial class EntityFrameworkCore702 {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aspenlaub.Net.GitHub.CSharp.DotNetEfToy.Toy", b => {
                b.Property<string>("Guid")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Guid");

                b.ToTable("Toys");
            });
#pragma warning restore 612, 618
        }
    }
}
