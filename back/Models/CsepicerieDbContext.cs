using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace back.Models;

public partial class CsepicerieDbContext : DbContext
{
    public CsepicerieDbContext()
    {
    }

    public CsepicerieDbContext(DbContextOptions<CsepicerieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achat> Achats { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Depense> Depenses { get; set; }

    public virtual DbSet<DetailsAchat> DetailsAchats { get; set; }

    public virtual DbSet<DetailsVente> DetailsVentes { get; set; }

    public virtual DbSet<Fournisseur> Fournisseurs { get; set; }

    public virtual DbSet<Parametre> Parametres { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Pointage> Pointages { get; set; }

    public virtual DbSet<Produit> Produits { get; set; }

    public virtual DbSet<Rapport> Rapports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesPermission> RolesPermissions { get; set; }

    public virtual DbSet<Sauvegarde> Sauvegardes { get; set; }

    public virtual DbSet<StockMouvement> StockMouvements { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Vente> Ventes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        // => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=csepicerie_db;Username=csepicerie_user;Password=csEpiceriePass");
        // => optionsBuilder.UseNpgsql("postgresql://neondb_owner:npg_n9fVOmLl4TPQ@ep-small-recipe-ab8ufpbg-pooler.eu-west-2.aws.neon.tech/neondb?sslmode=require&channel_binding=require;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achat>(entity =>
        {
            entity.HasKey(e => e.IdAchat).HasName("achats_pkey");

            entity.ToTable("achats");

            entity.Property(e => e.IdAchat).HasColumnName("id_achat");
            entity.Property(e => e.DateAchat).HasColumnName("date_achat");
            entity.Property(e => e.IdFournisseur).HasColumnName("id_fournisseur");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdFournisseurNavigation).WithMany(p => p.Achats)
                .HasForeignKey(d => d.IdFournisseur)
                .HasConstraintName("achats_id_fournisseur_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.IdCategorie).HasColumnName("id_categorie");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Credit)
                .HasPrecision(10, 2)
                .HasColumnName("credit");
            entity.Property(e => e.DateInscription).HasColumnName("date_inscription");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Depense>(entity =>
        {
            entity.HasKey(e => e.IdDepense).HasName("depenses_pkey");

            entity.ToTable("depenses");

            entity.Property(e => e.IdDepense).HasColumnName("id_depense");
            entity.Property(e => e.Categorie)
                .HasMaxLength(100)
                .HasColumnName("categorie");
            entity.Property(e => e.DateDepense).HasColumnName("date_depense");
            entity.Property(e => e.Justificatif).HasColumnName("justificatif");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");
            entity.Property(e => e.Montant)
                .HasPrecision(10, 2)
                .HasColumnName("montant");
        });

        modelBuilder.Entity<DetailsAchat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("details_achats_pkey");

            entity.ToTable("details_achats");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAchat).HasColumnName("id_achat");
            entity.Property(e => e.IdProduit).HasColumnName("id_produit");
            entity.Property(e => e.PrixUnitaire)
                .HasPrecision(10, 2)
                .HasColumnName("prix_unitaire");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdAchatNavigation).WithMany(p => p.DetailsAchats)
                .HasForeignKey(d => d.IdAchat)
                .HasConstraintName("details_achats_id_achat_fkey");

            entity.HasOne(d => d.IdProduitNavigation).WithMany(p => p.DetailsAchats)
                .HasForeignKey(d => d.IdProduit)
                .HasConstraintName("details_achats_id_produit_fkey");
        });

        modelBuilder.Entity<DetailsVente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("details_vente_pkey");

            entity.ToTable("details_vente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduit).HasColumnName("id_produit");
            entity.Property(e => e.IdVente).HasColumnName("id_vente");
            entity.Property(e => e.PrixUnitaire)
                .HasPrecision(10, 2)
                .HasColumnName("prix_unitaire");
            entity.Property(e => e.Quantite).HasColumnName("quantite");
            entity.Property(e => e.Remise)
                .HasPrecision(10, 2)
                .HasColumnName("remise");

            entity.HasOne(d => d.IdProduitNavigation).WithMany(p => p.DetailsVentes)
                .HasForeignKey(d => d.IdProduit)
                .HasConstraintName("details_vente_id_produit_fkey");

            entity.HasOne(d => d.IdVenteNavigation).WithMany(p => p.DetailsVentes)
                .HasForeignKey(d => d.IdVente)
                .HasConstraintName("details_vente_id_vente_fkey");
        });

        modelBuilder.Entity<Fournisseur>(entity =>
        {
            entity.HasKey(e => e.IdFournisseur).HasName("fournisseurs_pkey");

            entity.ToTable("fournisseurs");

            entity.Property(e => e.IdFournisseur).HasColumnName("id_fournisseur");
            entity.Property(e => e.Adresse).HasColumnName("adresse");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Parametre>(entity =>
        {
            entity.HasKey(e => e.IdParam).HasName("parametres_pkey");

            entity.ToTable("parametres");

            entity.Property(e => e.IdParam).HasColumnName("id_param");
            entity.Property(e => e.Cle)
                .HasMaxLength(100)
                .HasColumnName("cle");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Valeur).HasColumnName("valeur");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.IdPermission).HasName("permissions_pkey");

            entity.ToTable("permissions");

            entity.Property(e => e.IdPermission).HasColumnName("id_permission");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasColumnName("action");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.NomModule)
                .HasMaxLength(100)
                .HasColumnName("nom_module");
        });

        modelBuilder.Entity<Pointage>(entity =>
        {
            entity.HasKey(e => e.IdPointage).HasName("pointage_pkey");

            entity.ToTable("pointage");

            entity.Property(e => e.IdPointage).HasColumnName("id_pointage");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.HeureArrivee).HasColumnName("heure_arrivee");
            entity.Property(e => e.HeureDepart).HasColumnName("heure_depart");
            entity.Property(e => e.IdUtilisateur).HasColumnName("id_utilisateur");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.Pointages)
                .HasForeignKey(d => d.IdUtilisateur)
                .HasConstraintName("pointage_id_utilisateur_fkey");
        });

        modelBuilder.Entity<Produit>(entity =>
        {
            entity.HasKey(e => e.IdProduit).HasName("produits_pkey");

            entity.ToTable("produits");

            entity.Property(e => e.IdProduit).HasColumnName("id_produit");
            entity.Property(e => e.CodeBarre)
                .HasMaxLength(50)
                .HasColumnName("code_barre");
            entity.Property(e => e.DateAjout).HasColumnName("date_ajout");
            entity.Property(e => e.IdCategorie).HasColumnName("id_categorie");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.PrixAchat)
                .HasPrecision(10, 2)
                .HasColumnName("prix_achat");
            entity.Property(e => e.PrixVente)
                .HasPrecision(10, 2)
                .HasColumnName("prix_vente");
            entity.Property(e => e.Quantite).HasColumnName("quantite");
            entity.Property(e => e.SeuilMin).HasColumnName("seuil_min");
            entity.Property(e => e.Unite)
                .HasMaxLength(20)
                .HasColumnName("unite");

            entity.HasOne(d => d.IdCategorieNavigation).WithMany(p => p.Produits)
                .HasForeignKey(d => d.IdCategorie)
                .HasConstraintName("produits_id_categorie_fkey");
        });

        modelBuilder.Entity<Rapport>(entity =>
        {
            entity.HasKey(e => e.IdRapport).HasName("rapports_pkey");

            entity.ToTable("rapports");

            entity.Property(e => e.IdRapport).HasColumnName("id_rapport");
            entity.Property(e => e.DateGeneration).HasColumnName("date_generation");
            entity.Property(e => e.FichierPdf).HasColumnName("fichier_pdf");
            entity.Property(e => e.Periode)
                .HasMaxLength(100)
                .HasColumnName("periode");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.NomRole)
                .HasMaxLength(100)
                .HasColumnName("nom_role");
        });

        modelBuilder.Entity<RolesPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_permissions_pkey");

            entity.ToTable("roles_permissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPermission).HasColumnName("id_permission");
            entity.Property(e => e.IdRole).HasColumnName("id_role");

            entity.HasOne(d => d.IdPermissionNavigation).WithMany(p => p.RolesPermissions)
                .HasForeignKey(d => d.IdPermission)
                .HasConstraintName("roles_permissions_id_permission_fkey");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.RolesPermissions)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("roles_permissions_id_role_fkey");
        });

        modelBuilder.Entity<Sauvegarde>(entity =>
        {
            entity.HasKey(e => e.IdSauvegarde).HasName("sauvegardes_pkey");

            entity.ToTable("sauvegardes");

            entity.Property(e => e.IdSauvegarde).HasColumnName("id_sauvegarde");
            entity.Property(e => e.CheminFichier).HasColumnName("chemin_fichier");
            entity.Property(e => e.DateSauvegarde).HasColumnName("date_sauvegarde");
            entity.Property(e => e.Declencheur)
                .HasMaxLength(100)
                .HasColumnName("declencheur");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<StockMouvement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stock_mouvements_pkey");

            entity.ToTable("stock_mouvements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateMouvement).HasColumnName("date_mouvement");
            entity.Property(e => e.IdProduit).HasColumnName("id_produit");
            entity.Property(e => e.Motif).HasColumnName("motif");
            entity.Property(e => e.Quantite).HasColumnName("quantite");
            entity.Property(e => e.TypeMouvement)
                .HasMaxLength(10)
                .HasColumnName("type_mouvement");

            entity.HasOne(d => d.IdProduitNavigation).WithMany(p => p.StockMouvements)
                .HasForeignKey(d => d.IdProduit)
                .HasConstraintName("stock_mouvements_id_produit_fkey");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("utilisateur_pkey");

            entity.ToTable("utilisateur");

            entity.Property(e => e.IdUtilisateur).HasColumnName("id_utilisateur");
            entity.Property(e => e.DateCreation).HasColumnName("date_creation");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.MotDePasse).HasColumnName("mot_de_passe");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(100)
                .HasColumnName("prenom");
            entity.Property(e => e.Statut)
                .HasMaxLength(50)
                .HasColumnName("statut");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Utilisateurs)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("utilisateur_id_role_fkey");
        });

        modelBuilder.Entity<Vente>(entity =>
        {
            entity.HasKey(e => e.IdVente).HasName("ventes_pkey");

            entity.ToTable("ventes");

            entity.Property(e => e.IdVente).HasColumnName("id_vente");
            entity.Property(e => e.DateVente).HasColumnName("date_vente");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdUtilisateur).HasColumnName("id_utilisateur");
            entity.Property(e => e.Paiement)
                .HasMaxLength(50)
                .HasColumnName("paiement");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Ventes)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("ventes_id_client_fkey");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.Ventes)
                .HasForeignKey(d => d.IdUtilisateur)
                .HasConstraintName("ventes_id_utilisateur_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
