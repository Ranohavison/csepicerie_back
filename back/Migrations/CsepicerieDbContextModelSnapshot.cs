﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using back.Models;

#nullable disable

namespace back.Migrations
{
    [DbContext(typeof(CsepicerieDbContext))]
    partial class CsepicerieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("back.Models.Achat", b =>
                {
                    b.Property<int>("IdAchat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_achat");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdAchat"));

                    b.Property<DateOnly?>("DateAchat")
                        .HasColumnType("date")
                        .HasColumnName("date_achat");

                    b.Property<int?>("IdFournisseur")
                        .HasColumnType("integer")
                        .HasColumnName("id_fournisseur");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("status");

                    b.Property<decimal?>("Total")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("total");

                    b.HasKey("IdAchat")
                        .HasName("achats_pkey");

                    b.HasIndex("IdFournisseur");

                    b.ToTable("achats", (string)null);
                });

            modelBuilder.Entity("back.Models.Category", b =>
                {
                    b.Property<int>("IdCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_categorie");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCategorie"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Nom")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nom");

                    b.HasKey("IdCategorie")
                        .HasName("categories_pkey");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("back.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_client");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdClient"));

                    b.Property<decimal?>("Credit")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("credit");

                    b.Property<DateOnly?>("DateInscription")
                        .HasColumnType("date")
                        .HasColumnName("date_inscription");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("Nom")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nom");

                    b.Property<string>("Telephone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("telephone");

                    b.HasKey("IdClient")
                        .HasName("clients_pkey");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("back.Models.Depense", b =>
                {
                    b.Property<int>("IdDepense")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_depense");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdDepense"));

                    b.Property<string>("Categorie")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("categorie");

                    b.Property<DateOnly?>("DateDepense")
                        .HasColumnType("date")
                        .HasColumnName("date_depense");

                    b.Property<string>("Justificatif")
                        .HasColumnType("text")
                        .HasColumnName("justificatif");

                    b.Property<string>("Libelle")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("libelle");

                    b.Property<decimal?>("Montant")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("montant");

                    b.HasKey("IdDepense")
                        .HasName("depenses_pkey");

                    b.ToTable("depenses", (string)null);
                });

            modelBuilder.Entity("back.Models.DetailsAchat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdAchat")
                        .HasColumnType("integer")
                        .HasColumnName("id_achat");

                    b.Property<int?>("IdProduit")
                        .HasColumnType("integer")
                        .HasColumnName("id_produit");

                    b.Property<decimal?>("PrixUnitaire")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("prix_unitaire");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("details_achats_pkey");

                    b.HasIndex("IdAchat");

                    b.HasIndex("IdProduit");

                    b.ToTable("details_achats", (string)null);
                });

            modelBuilder.Entity("back.Models.DetailsVente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdProduit")
                        .HasColumnType("integer")
                        .HasColumnName("id_produit");

                    b.Property<int?>("IdVente")
                        .HasColumnType("integer")
                        .HasColumnName("id_vente");

                    b.Property<decimal?>("PrixUnitaire")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("prix_unitaire");

                    b.Property<int?>("Quantite")
                        .HasColumnType("integer")
                        .HasColumnName("quantite");

                    b.Property<decimal?>("Remise")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("remise");

                    b.HasKey("Id")
                        .HasName("details_vente_pkey");

                    b.HasIndex("IdProduit");

                    b.HasIndex("IdVente");

                    b.ToTable("details_vente", (string)null);
                });

            modelBuilder.Entity("back.Models.Fournisseur", b =>
                {
                    b.Property<int>("IdFournisseur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_fournisseur");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdFournisseur"));

                    b.Property<string>("Adresse")
                        .HasColumnType("text")
                        .HasColumnName("adresse");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("Nom")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nom");

                    b.Property<string>("Telephone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("telephone");

                    b.HasKey("IdFournisseur")
                        .HasName("fournisseurs_pkey");

                    b.ToTable("fournisseurs", (string)null);
                });

            modelBuilder.Entity("back.Models.Parametre", b =>
                {
                    b.Property<int>("IdParam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_param");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdParam"));

                    b.Property<string>("Cle")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("cle");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Valeur")
                        .HasColumnType("text")
                        .HasColumnName("valeur");

                    b.HasKey("IdParam")
                        .HasName("parametres_pkey");

                    b.ToTable("parametres", (string)null);
                });

            modelBuilder.Entity("back.Models.Permission", b =>
                {
                    b.Property<int>("IdPermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_permission");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPermission"));

                    b.Property<string>("Action")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("action");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("NomModule")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nom_module");

                    b.HasKey("IdPermission")
                        .HasName("permissions_pkey");

                    b.ToTable("permissions", (string)null);
                });

            modelBuilder.Entity("back.Models.Pointage", b =>
                {
                    b.Property<int>("IdPointage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_pointage");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPointage"));

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<TimeOnly?>("HeureArrivee")
                        .HasColumnType("time without time zone")
                        .HasColumnName("heure_arrivee");

                    b.Property<TimeOnly?>("HeureDepart")
                        .HasColumnType("time without time zone")
                        .HasColumnName("heure_depart");

                    b.Property<int?>("IdUtilisateur")
                        .HasColumnType("integer")
                        .HasColumnName("id_utilisateur");

                    b.HasKey("IdPointage")
                        .HasName("pointage_pkey");

                    b.HasIndex("IdUtilisateur");

                    b.ToTable("pointage", (string)null);
                });

            modelBuilder.Entity("back.Models.Produit", b =>
                {
                    b.Property<int>("IdProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_produit");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProduit"));

                    b.Property<string>("CodeBarre")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("code_barre");

                    b.Property<DateOnly?>("DateAjout")
                        .HasColumnType("date")
                        .HasColumnName("date_ajout");

                    b.Property<int?>("IdCategorie")
                        .HasColumnType("integer")
                        .HasColumnName("id_categorie");

                    b.Property<string>("Nom")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nom");

                    b.Property<decimal?>("PrixAchat")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("prix_achat");

                    b.Property<decimal?>("PrixVente")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("prix_vente");

                    b.Property<int?>("Quantite")
                        .HasColumnType("integer")
                        .HasColumnName("quantite");

                    b.Property<int?>("SeuilMin")
                        .HasColumnType("integer")
                        .HasColumnName("seuil_min");

                    b.Property<string>("Unite")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("unite");

                    b.HasKey("IdProduit")
                        .HasName("produits_pkey");

                    b.HasIndex("IdCategorie");

                    b.ToTable("produits", (string)null);
                });

            modelBuilder.Entity("back.Models.Rapport", b =>
                {
                    b.Property<int>("IdRapport")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_rapport");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdRapport"));

                    b.Property<DateOnly?>("DateGeneration")
                        .HasColumnType("date")
                        .HasColumnName("date_generation");

                    b.Property<string>("FichierPdf")
                        .HasColumnType("text")
                        .HasColumnName("fichier_pdf");

                    b.Property<string>("Periode")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("periode");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("type");

                    b.HasKey("IdRapport")
                        .HasName("rapports_pkey");

                    b.ToTable("rapports", (string)null);
                });

            modelBuilder.Entity("back.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_role");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdRole"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("NomRole")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nom_role");

                    b.HasKey("IdRole")
                        .HasName("roles_pkey");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("back.Models.RolesPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdPermission")
                        .HasColumnType("integer")
                        .HasColumnName("id_permission");

                    b.Property<int?>("IdRole")
                        .HasColumnType("integer")
                        .HasColumnName("id_role");

                    b.HasKey("Id")
                        .HasName("roles_permissions_pkey");

                    b.HasIndex("IdPermission");

                    b.HasIndex("IdRole");

                    b.ToTable("roles_permissions", (string)null);
                });

            modelBuilder.Entity("back.Models.Sauvegarde", b =>
                {
                    b.Property<int>("IdSauvegarde")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_sauvegarde");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdSauvegarde"));

                    b.Property<string>("CheminFichier")
                        .HasColumnType("text")
                        .HasColumnName("chemin_fichier");

                    b.Property<DateOnly?>("DateSauvegarde")
                        .HasColumnType("date")
                        .HasColumnName("date_sauvegarde");

                    b.Property<string>("Declencheur")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("declencheur");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("type");

                    b.HasKey("IdSauvegarde")
                        .HasName("sauvegardes_pkey");

                    b.ToTable("sauvegardes", (string)null);
                });

            modelBuilder.Entity("back.Models.StockMouvement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DateMouvement")
                        .HasColumnType("date")
                        .HasColumnName("date_mouvement");

                    b.Property<int?>("IdProduit")
                        .HasColumnType("integer")
                        .HasColumnName("id_produit");

                    b.Property<string>("Motif")
                        .HasColumnType("text")
                        .HasColumnName("motif");

                    b.Property<int?>("Quantite")
                        .HasColumnType("integer")
                        .HasColumnName("quantite");

                    b.Property<string>("TypeMouvement")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("type_mouvement");

                    b.HasKey("Id")
                        .HasName("stock_mouvements_pkey");

                    b.HasIndex("IdProduit");

                    b.ToTable("stock_mouvements", (string)null);
                });

            modelBuilder.Entity("back.Models.Utilisateur", b =>
                {
                    b.Property<int>("IdUtilisateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_utilisateur");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUtilisateur"));

                    b.Property<DateOnly?>("DateCreation")
                        .HasColumnType("date")
                        .HasColumnName("date_creation");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<int?>("IdRole")
                        .HasColumnType("integer")
                        .HasColumnName("id_role");

                    b.Property<string>("MotDePasse")
                        .HasColumnType("text")
                        .HasColumnName("mot_de_passe");

                    b.Property<string>("Nom")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nom");

                    b.Property<string>("Prenom")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("prenom");

                    b.Property<string>("Statut")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("statut");

                    b.HasKey("IdUtilisateur")
                        .HasName("utilisateur_pkey");

                    b.HasIndex("IdRole");

                    b.ToTable("utilisateur", (string)null);
                });

            modelBuilder.Entity("back.Models.Vente", b =>
                {
                    b.Property<int>("IdVente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_vente");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdVente"));

                    b.Property<DateOnly?>("DateVente")
                        .HasColumnType("date")
                        .HasColumnName("date_vente");

                    b.Property<int?>("IdClient")
                        .HasColumnType("integer")
                        .HasColumnName("id_client");

                    b.Property<int?>("IdUtilisateur")
                        .HasColumnType("integer")
                        .HasColumnName("id_utilisateur");

                    b.Property<string>("Paiement")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("paiement");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("status");

                    b.Property<decimal?>("Total")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("total");

                    b.HasKey("IdVente")
                        .HasName("ventes_pkey");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdUtilisateur");

                    b.ToTable("ventes", (string)null);
                });

            modelBuilder.Entity("back.Models.Achat", b =>
                {
                    b.HasOne("back.Models.Fournisseur", "IdFournisseurNavigation")
                        .WithMany("Achats")
                        .HasForeignKey("IdFournisseur")
                        .HasConstraintName("achats_id_fournisseur_fkey");

                    b.Navigation("IdFournisseurNavigation");
                });

            modelBuilder.Entity("back.Models.DetailsAchat", b =>
                {
                    b.HasOne("back.Models.Achat", "IdAchatNavigation")
                        .WithMany("DetailsAchats")
                        .HasForeignKey("IdAchat")
                        .HasConstraintName("details_achats_id_achat_fkey");

                    b.HasOne("back.Models.Produit", "IdProduitNavigation")
                        .WithMany("DetailsAchats")
                        .HasForeignKey("IdProduit")
                        .HasConstraintName("details_achats_id_produit_fkey");

                    b.Navigation("IdAchatNavigation");

                    b.Navigation("IdProduitNavigation");
                });

            modelBuilder.Entity("back.Models.DetailsVente", b =>
                {
                    b.HasOne("back.Models.Produit", "IdProduitNavigation")
                        .WithMany("DetailsVentes")
                        .HasForeignKey("IdProduit")
                        .HasConstraintName("details_vente_id_produit_fkey");

                    b.HasOne("back.Models.Vente", "IdVenteNavigation")
                        .WithMany("DetailsVentes")
                        .HasForeignKey("IdVente")
                        .HasConstraintName("details_vente_id_vente_fkey");

                    b.Navigation("IdProduitNavigation");

                    b.Navigation("IdVenteNavigation");
                });

            modelBuilder.Entity("back.Models.Pointage", b =>
                {
                    b.HasOne("back.Models.Utilisateur", "IdUtilisateurNavigation")
                        .WithMany("Pointages")
                        .HasForeignKey("IdUtilisateur")
                        .HasConstraintName("pointage_id_utilisateur_fkey");

                    b.Navigation("IdUtilisateurNavigation");
                });

            modelBuilder.Entity("back.Models.Produit", b =>
                {
                    b.HasOne("back.Models.Category", "IdCategorieNavigation")
                        .WithMany("Produits")
                        .HasForeignKey("IdCategorie")
                        .HasConstraintName("produits_id_categorie_fkey");

                    b.Navigation("IdCategorieNavigation");
                });

            modelBuilder.Entity("back.Models.RolesPermission", b =>
                {
                    b.HasOne("back.Models.Permission", "IdPermissionNavigation")
                        .WithMany("RolesPermissions")
                        .HasForeignKey("IdPermission")
                        .HasConstraintName("roles_permissions_id_permission_fkey");

                    b.HasOne("back.Models.Role", "IdRoleNavigation")
                        .WithMany("RolesPermissions")
                        .HasForeignKey("IdRole")
                        .HasConstraintName("roles_permissions_id_role_fkey");

                    b.Navigation("IdPermissionNavigation");

                    b.Navigation("IdRoleNavigation");
                });

            modelBuilder.Entity("back.Models.StockMouvement", b =>
                {
                    b.HasOne("back.Models.Produit", "IdProduitNavigation")
                        .WithMany("StockMouvements")
                        .HasForeignKey("IdProduit")
                        .HasConstraintName("stock_mouvements_id_produit_fkey");

                    b.Navigation("IdProduitNavigation");
                });

            modelBuilder.Entity("back.Models.Utilisateur", b =>
                {
                    b.HasOne("back.Models.Role", "IdRoleNavigation")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("IdRole")
                        .HasConstraintName("utilisateur_id_role_fkey");

                    b.Navigation("IdRoleNavigation");
                });

            modelBuilder.Entity("back.Models.Vente", b =>
                {
                    b.HasOne("back.Models.Client", "IdClientNavigation")
                        .WithMany("Ventes")
                        .HasForeignKey("IdClient")
                        .HasConstraintName("ventes_id_client_fkey");

                    b.HasOne("back.Models.Utilisateur", "IdUtilisateurNavigation")
                        .WithMany("Ventes")
                        .HasForeignKey("IdUtilisateur")
                        .HasConstraintName("ventes_id_utilisateur_fkey");

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdUtilisateurNavigation");
                });

            modelBuilder.Entity("back.Models.Achat", b =>
                {
                    b.Navigation("DetailsAchats");
                });

            modelBuilder.Entity("back.Models.Category", b =>
                {
                    b.Navigation("Produits");
                });

            modelBuilder.Entity("back.Models.Client", b =>
                {
                    b.Navigation("Ventes");
                });

            modelBuilder.Entity("back.Models.Fournisseur", b =>
                {
                    b.Navigation("Achats");
                });

            modelBuilder.Entity("back.Models.Permission", b =>
                {
                    b.Navigation("RolesPermissions");
                });

            modelBuilder.Entity("back.Models.Produit", b =>
                {
                    b.Navigation("DetailsAchats");

                    b.Navigation("DetailsVentes");

                    b.Navigation("StockMouvements");
                });

            modelBuilder.Entity("back.Models.Role", b =>
                {
                    b.Navigation("RolesPermissions");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("back.Models.Utilisateur", b =>
                {
                    b.Navigation("Pointages");

                    b.Navigation("Ventes");
                });

            modelBuilder.Entity("back.Models.Vente", b =>
                {
                    b.Navigation("DetailsVentes");
                });
#pragma warning restore 612, 618
        }
    }
}
