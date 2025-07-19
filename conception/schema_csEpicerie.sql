-- Création des tables

CREATE TABLE categories (
    id_categorie SERIAL PRIMARY KEY,
    nom VARCHAR(100),
    description TEXT
);

CREATE TABLE produits (
    id_produit SERIAL PRIMARY KEY,
    id_categorie INT REFERENCES categories(id_categorie),
    code_barre VARCHAR(50),
    nom VARCHAR(100),
    prix_achat NUMERIC(10,2),
    prix_vente NUMERIC(10,2),
    quantite INT,
    unite VARCHAR(20),
    seuil_min INT,
    date_ajout DATE
);

CREATE TABLE fournisseurs (
    id_fournisseur SERIAL PRIMARY KEY,
    nom VARCHAR(100),
    adresse TEXT,
    telephone VARCHAR(20),
    email VARCHAR(100)
);

CREATE TABLE achats (
    id_achat SERIAL PRIMARY KEY,
    id_fournisseur INT REFERENCES fournisseurs(id_fournisseur),
    date_achat DATE,
    total NUMERIC(10,2),
    status VARCHAR(50)
);

CREATE TABLE details_achats (
    id SERIAL PRIMARY KEY,
    id_produit INT REFERENCES produits(id_produit),
    id_achat INT REFERENCES achats(id_achat),
    quantity INT,
    prix_unitaire NUMERIC(10,2)
);

CREATE TABLE stock_mouvements (
    id SERIAL PRIMARY KEY,
    id_produit INT REFERENCES produits(id_produit),
    type_mouvement VARCHAR(10), -- "ENTREE" ou "SORTIE"
    quantite INT,
    date_mouvement DATE,
    motif TEXT
);

CREATE TABLE clients (
    id_client SERIAL PRIMARY KEY,
    nom VARCHAR(100),
    telephone VARCHAR(20),
    email VARCHAR(100),
    credit NUMERIC(10,2),
    date_inscription DATE
);

CREATE TABLE utilisateur (
    id_utilisateur SERIAL PRIMARY KEY,
    id_role INT REFERENCES roles(id_role),
    nom VARCHAR(100),
    prenom VARCHAR(100),
    email VARCHAR(100),
    mot_de_passe TEXT,
    statut VARCHAR(50),
    date_creation DATE
);

CREATE TABLE ventes (
    id_vente SERIAL PRIMARY KEY,
    id_client INT REFERENCES clients(id_client),
    id_utilisateur INT REFERENCES utilisateur(id_utilisateur),
    date_vente DATE,
    total NUMERIC(10,2),
    paiement VARCHAR(50),
    status VARCHAR(50)
);

CREATE TABLE details_vente (
    id SERIAL PRIMARY KEY,
    id_vente INT REFERENCES ventes(id_vente),
    id_produit INT REFERENCES produits(id_produit),
    quantite INT,
    prix_unitaire NUMERIC(10,2),
    remise NUMERIC(10,2)
);

CREATE TABLE pointage (
    id_pointage SERIAL PRIMARY KEY,
    id_utilisateur INT REFERENCES utilisateur(id_utilisateur),
    date DATE,
    heure_arrivee TIME,
    heure_depart TIME
);

CREATE TABLE roles (
    id_role SERIAL PRIMARY KEY,
    nom_role VARCHAR(100),
    description TEXT
);

CREATE TABLE permissions (
    id_permission SERIAL PRIMARY KEY,
    nom_module VARCHAR(100),
    action VARCHAR(100),
    description TEXT
);

CREATE TABLE roles_permissions (
    id SERIAL PRIMARY KEY,
    id_role INT REFERENCES roles(id_role),
    id_permission INT REFERENCES permissions(id_permission)
);

CREATE TABLE parametres (
    id_param SERIAL PRIMARY KEY,
    cle VARCHAR(100),
    valeur TEXT,
    description TEXT
);

CREATE TABLE sauvegardes (
    id_sauvegarde SERIAL PRIMARY KEY,
    type VARCHAR(50),
    chemin_fichier TEXT,
    date_sauvegarde DATE,
    declencheur VARCHAR(100)
);

CREATE TABLE depenses (
    id_depense SERIAL PRIMARY KEY,
    libelle VARCHAR(100),
    montant NUMERIC(10,2),
    date_depense DATE,
    categorie VARCHAR(100),
    justificatif TEXT
);

CREATE TABLE rapports (
    id_rapport SERIAL PRIMARY KEY,
    type VARCHAR(50),
    periode VARCHAR(100),
    date_generation DATE,
    fichier_pdf TEXT
);

