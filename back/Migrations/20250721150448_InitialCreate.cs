using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id_categorie = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categories_pkey", x => x.id_categorie);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id_client = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    credit = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    date_inscription = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clients_pkey", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "depenses",
                columns: table => new
                {
                    id_depense = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    libelle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    montant = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    date_depense = table.Column<DateOnly>(type: "date", nullable: true),
                    categorie = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    justificatif = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("depenses_pkey", x => x.id_depense);
                });

            migrationBuilder.CreateTable(
                name: "fournisseurs",
                columns: table => new
                {
                    id_fournisseur = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    adresse = table.Column<string>(type: "text", nullable: true),
                    telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("fournisseurs_pkey", x => x.id_fournisseur);
                });

            migrationBuilder.CreateTable(
                name: "parametres",
                columns: table => new
                {
                    id_param = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    valeur = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("parametres_pkey", x => x.id_param);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id_permission = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom_module = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("permissions_pkey", x => x.id_permission);
                });

            migrationBuilder.CreateTable(
                name: "rapports",
                columns: table => new
                {
                    id_rapport = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    periode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    date_generation = table.Column<DateOnly>(type: "date", nullable: true),
                    fichier_pdf = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rapports_pkey", x => x.id_rapport);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom_role = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_pkey", x => x.id_role);
                });

            migrationBuilder.CreateTable(
                name: "sauvegardes",
                columns: table => new
                {
                    id_sauvegarde = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    chemin_fichier = table.Column<string>(type: "text", nullable: true),
                    date_sauvegarde = table.Column<DateOnly>(type: "date", nullable: true),
                    declencheur = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sauvegardes_pkey", x => x.id_sauvegarde);
                });

            migrationBuilder.CreateTable(
                name: "produits",
                columns: table => new
                {
                    id_produit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_categorie = table.Column<int>(type: "integer", nullable: true),
                    code_barre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    prix_achat = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    prix_vente = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    quantite = table.Column<int>(type: "integer", nullable: true),
                    unite = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    seuil_min = table.Column<int>(type: "integer", nullable: true),
                    date_ajout = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("produits_pkey", x => x.id_produit);
                    table.ForeignKey(
                        name: "produits_id_categorie_fkey",
                        column: x => x.id_categorie,
                        principalTable: "categories",
                        principalColumn: "id_categorie");
                });

            migrationBuilder.CreateTable(
                name: "achats",
                columns: table => new
                {
                    id_achat = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_fournisseur = table.Column<int>(type: "integer", nullable: true),
                    date_achat = table.Column<DateOnly>(type: "date", nullable: true),
                    total = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("achats_pkey", x => x.id_achat);
                    table.ForeignKey(
                        name: "achats_id_fournisseur_fkey",
                        column: x => x.id_fournisseur,
                        principalTable: "fournisseurs",
                        principalColumn: "id_fournisseur");
                });

            migrationBuilder.CreateTable(
                name: "roles_permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_role = table.Column<int>(type: "integer", nullable: true),
                    id_permission = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_permissions_pkey", x => x.id);
                    table.ForeignKey(
                        name: "roles_permissions_id_permission_fkey",
                        column: x => x.id_permission,
                        principalTable: "permissions",
                        principalColumn: "id_permission");
                    table.ForeignKey(
                        name: "roles_permissions_id_role_fkey",
                        column: x => x.id_role,
                        principalTable: "roles",
                        principalColumn: "id_role");
                });

            migrationBuilder.CreateTable(
                name: "utilisateur",
                columns: table => new
                {
                    id_utilisateur = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_role = table.Column<int>(type: "integer", nullable: true),
                    nom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    prenom = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    mot_de_passe = table.Column<string>(type: "text", nullable: true),
                    statut = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    date_creation = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("utilisateur_pkey", x => x.id_utilisateur);
                    table.ForeignKey(
                        name: "utilisateur_id_role_fkey",
                        column: x => x.id_role,
                        principalTable: "roles",
                        principalColumn: "id_role");
                });

            migrationBuilder.CreateTable(
                name: "stock_mouvements",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_produit = table.Column<int>(type: "integer", nullable: true),
                    type_mouvement = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    quantite = table.Column<int>(type: "integer", nullable: true),
                    date_mouvement = table.Column<DateOnly>(type: "date", nullable: true),
                    motif = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("stock_mouvements_pkey", x => x.id);
                    table.ForeignKey(
                        name: "stock_mouvements_id_produit_fkey",
                        column: x => x.id_produit,
                        principalTable: "produits",
                        principalColumn: "id_produit");
                });

            migrationBuilder.CreateTable(
                name: "details_achats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_produit = table.Column<int>(type: "integer", nullable: true),
                    id_achat = table.Column<int>(type: "integer", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: true),
                    prix_unitaire = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("details_achats_pkey", x => x.id);
                    table.ForeignKey(
                        name: "details_achats_id_achat_fkey",
                        column: x => x.id_achat,
                        principalTable: "achats",
                        principalColumn: "id_achat");
                    table.ForeignKey(
                        name: "details_achats_id_produit_fkey",
                        column: x => x.id_produit,
                        principalTable: "produits",
                        principalColumn: "id_produit");
                });

            migrationBuilder.CreateTable(
                name: "pointage",
                columns: table => new
                {
                    id_pointage = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_utilisateur = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: true),
                    heure_arrivee = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    heure_depart = table.Column<TimeOnly>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pointage_pkey", x => x.id_pointage);
                    table.ForeignKey(
                        name: "pointage_id_utilisateur_fkey",
                        column: x => x.id_utilisateur,
                        principalTable: "utilisateur",
                        principalColumn: "id_utilisateur");
                });

            migrationBuilder.CreateTable(
                name: "ventes",
                columns: table => new
                {
                    id_vente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_client = table.Column<int>(type: "integer", nullable: true),
                    id_utilisateur = table.Column<int>(type: "integer", nullable: true),
                    date_vente = table.Column<DateOnly>(type: "date", nullable: true),
                    total = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    paiement = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ventes_pkey", x => x.id_vente);
                    table.ForeignKey(
                        name: "ventes_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "clients",
                        principalColumn: "id_client");
                    table.ForeignKey(
                        name: "ventes_id_utilisateur_fkey",
                        column: x => x.id_utilisateur,
                        principalTable: "utilisateur",
                        principalColumn: "id_utilisateur");
                });

            migrationBuilder.CreateTable(
                name: "details_vente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_vente = table.Column<int>(type: "integer", nullable: true),
                    id_produit = table.Column<int>(type: "integer", nullable: true),
                    quantite = table.Column<int>(type: "integer", nullable: true),
                    prix_unitaire = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    remise = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("details_vente_pkey", x => x.id);
                    table.ForeignKey(
                        name: "details_vente_id_produit_fkey",
                        column: x => x.id_produit,
                        principalTable: "produits",
                        principalColumn: "id_produit");
                    table.ForeignKey(
                        name: "details_vente_id_vente_fkey",
                        column: x => x.id_vente,
                        principalTable: "ventes",
                        principalColumn: "id_vente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_achats_id_fournisseur",
                table: "achats",
                column: "id_fournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_details_achats_id_achat",
                table: "details_achats",
                column: "id_achat");

            migrationBuilder.CreateIndex(
                name: "IX_details_achats_id_produit",
                table: "details_achats",
                column: "id_produit");

            migrationBuilder.CreateIndex(
                name: "IX_details_vente_id_produit",
                table: "details_vente",
                column: "id_produit");

            migrationBuilder.CreateIndex(
                name: "IX_details_vente_id_vente",
                table: "details_vente",
                column: "id_vente");

            migrationBuilder.CreateIndex(
                name: "IX_pointage_id_utilisateur",
                table: "pointage",
                column: "id_utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_produits_id_categorie",
                table: "produits",
                column: "id_categorie");

            migrationBuilder.CreateIndex(
                name: "IX_roles_permissions_id_permission",
                table: "roles_permissions",
                column: "id_permission");

            migrationBuilder.CreateIndex(
                name: "IX_roles_permissions_id_role",
                table: "roles_permissions",
                column: "id_role");

            migrationBuilder.CreateIndex(
                name: "IX_stock_mouvements_id_produit",
                table: "stock_mouvements",
                column: "id_produit");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateur_id_role",
                table: "utilisateur",
                column: "id_role");

            migrationBuilder.CreateIndex(
                name: "IX_ventes_id_client",
                table: "ventes",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_ventes_id_utilisateur",
                table: "ventes",
                column: "id_utilisateur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "depenses");

            migrationBuilder.DropTable(
                name: "details_achats");

            migrationBuilder.DropTable(
                name: "details_vente");

            migrationBuilder.DropTable(
                name: "parametres");

            migrationBuilder.DropTable(
                name: "pointage");

            migrationBuilder.DropTable(
                name: "rapports");

            migrationBuilder.DropTable(
                name: "roles_permissions");

            migrationBuilder.DropTable(
                name: "sauvegardes");

            migrationBuilder.DropTable(
                name: "stock_mouvements");

            migrationBuilder.DropTable(
                name: "achats");

            migrationBuilder.DropTable(
                name: "ventes");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "produits");

            migrationBuilder.DropTable(
                name: "fournisseurs");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "utilisateur");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
