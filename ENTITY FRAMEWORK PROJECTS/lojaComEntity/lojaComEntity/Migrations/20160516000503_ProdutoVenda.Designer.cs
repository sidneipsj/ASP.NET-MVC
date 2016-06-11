using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using lojaComEntity;

namespace lojaComEntity.Migrations
{
    [DbContext(typeof(EntidadesContext))]
    [Migration("20160516000503_ProdutoVenda")]
    partial class ProdutoVenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lojaComEntity.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("lojaComEntity.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Nome");

                    b.Property<decimal>("preco");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("lojaComEntity.Entidades.ProdutoVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProdutoId");

                    b.Property<int?>("VendaId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("lojaComEntity.Entidades.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("lojaComEntity.Entidades.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProdutoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("lojaComEntity.Entidades.Produto", b =>
                {
                    b.HasOne("lojaComEntity.Entidades.Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("lojaComEntity.Entidades.ProdutoVenda", b =>
                {
                    b.HasOne("lojaComEntity.Entidades.Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("lojaComEntity.Entidades.Venda")
                        .WithMany()
                        .HasForeignKey("VendaId");
                });

            modelBuilder.Entity("lojaComEntity.Entidades.Venda", b =>
                {
                    b.HasOne("lojaComEntity.Entidades.Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("lojaComEntity.Entidades.Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });
        }
    }
}
