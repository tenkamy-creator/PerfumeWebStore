using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Seeder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebStoreAdmin.Models;
using WebStoreAdmin.ViewModels;

namespace WebStoreAdmin.Seeder
{
    public class Program
    {
        public static async Task Main()
        {
            using var context = DbContextFactory.CreateDbContext();

            // Une seule instance de Random pour tout le seeder — en créer plusieurs
            // à quelques lignes d'intervalle risque de produire les mêmes séquences
            // (graine basée sur l'horloge système).
            var random = new Random();

            // 1. Vider les données transactionnelles existantes — dans l'ordre enfants -> parents
            //    pour respecter les FK. Les Categories NE SONT PAS supprimées : ce sont des
            //    données de référence fixes qui doivent survivre à un reseed.
            context.ImagesParfum.RemoveRange(context.ImagesParfum);
            context.ArticlesCommande.RemoveRange(context.ArticlesCommande);
            context.Commandes.RemoveRange(context.Commandes);
            context.Parfums.RemoveRange(context.Parfums);
            context.Clients.RemoveRange(context.Clients);
            // ... autres tables

            await context.SaveChangesAsync();

            // 2. Réinitialiser les compteurs IDENTITY (obligatoire sur SQL Server après un DELETE).
            //    Categorie n'est plus dans cette liste puisqu'on ne supprime plus ses lignes.
            var tablesAReseeder = new[]
            {
    context.Model.FindEntityType(typeof(ImageParfum))!.GetTableName(),
    context.Model.FindEntityType(typeof(ArticleCommande))!.GetTableName(),
    context.Model.FindEntityType(typeof(Commande))!.GetTableName(),
    context.Model.FindEntityType(typeof(Parfum))!.GetTableName(),
};

            foreach (var table in tablesAReseeder)
            {
                await context.Database.ExecuteSqlRawAsync(
                    $"DBCC CHECKIDENT ('{table}', RESEED, 0);");
            }

            // 3. Réinsérer les données de seed comme d'habitude

            var categories = await context.Categories.ToListAsync();

            if (!categories.Any())
            {
                Console.WriteLine("Aucune catégorie trouvée. Assure-toi que les catégories de référence ont été seedées (migration ou seeder dédié) avant d'exécuter ce seeder.");
                return;
            }

            var parfumsFaker = new Faker<Parfum>("fr")
                .RuleFor(x => x.Nom,
                    f => f.UniqueIndex + " - " +
                f.PickRandom(
                        "Velours Noir",
                        "Bois Sacré",
                        "Ambre Royal",
                        "Nuit Orientale",
                        "Rose Impériale",
                        "Éclat de Vanille",
                        "Santal Mystique",
                        "Fleur d'Or",
                        "Oud Prestige",
                        "Lune Blanche"
                    ))

                .RuleFor(x => x.Marque,
                    f => f.PickRandom(
                        "L'Essence Atelier",
                        "Maison Élégance",
                        "Parfums Royale",
                        "Atelier Prestige",
                        "Maison d'Ambre"
                    ))

                .RuleFor(x => x.Description,
                    f => f.Commerce.ProductDescription())

                .RuleFor(x => x.Prix,
                    f => Math.Round(f.Random.Double(30, 150), 2))

                .RuleFor(x => x.Volume,
    f => f.PickRandom(30, 50, 75, 100, 125, 150))  // volumes courants en mL

                .RuleFor(x => x.Stock,
                    f => f.Random.Int(0, 100))

                .RuleFor(x => x.Genre, f => f.PickRandom(Genres.Homme, Genres.Femme, Genres.Fille, Genres.Garçon, Genres.Unisex))

                .RuleFor(x => x.CategorieId,
                    f => f.PickRandom(categories).Id)

                .FinishWith((f, x) =>
                {
                    x.Id = 0;
                });

            var parfums = parfumsFaker.Generate(50);

            // Attribution ordonnée des images : Parfum1 -> Image1,2,3 | Parfum2 -> Image4,5,6 | ...
            for (int i = 0; i < parfums.Count; i++)
            {
                var parfum = parfums[i];
                int baseIndex = (i * 3) + 1;

                for (int j = 0; j < 3; j++)
                {
                    int numeroImage = baseIndex + j;
                    parfum.Images.Add(new ImageParfum
                    {
                        Url = $"/Images/Parfums/Image{numeroImage}.png",
                        ImagePrincipale = j == 0,
                        OrdreAffichage = j + 1
                    });
                }
            }

            // =========================================================
            // ATTRIBUTION DES NOTES OLFACTIVES
            // =========================================================
            Console.WriteLine("Attribution des notes olfactives...");

            const int IdFamilleFixateurSynthetique = 9;

            var toutesNotes = await context.NotesOlfactives.ToListAsync();
            var notesFixateurSynthetique = toutesNotes
                .Where(n => n.FamilleOlfactiveId == IdFamilleFixateurSynthetique)
                .ToList();

            if (!toutesNotes.Any())
            {
                Console.WriteLine("Aucune note olfactive trouvée. Assure-toi d'avoir appliqué la migration des notes.");
            }
            else if (!notesFixateurSynthetique.Any())
            {
                Console.WriteLine("Aucun fixateur synthétique trouvé (FamilleOlfactiveId = 9). Vérifie le seed des familles.");
            }
            else
            {
                foreach (var parfum in parfums)
                {
                    // Notes de tête : 3 notes aléatoires distinctes
                    var notesTete = toutesNotes
                        .OrderBy(_ => random.Next())
                        .Take(3)
                        .ToList();

                    // Notes de cœur : 2 notes aléatoires distinctes, différentes des notes de tête
                    var notesCoeur = toutesNotes
                        .Where(n => !notesTete.Contains(n))
                        .OrderBy(_ => random.Next())
                        .Take(2)
                        .ToList();

                    // Notes de fond : 1 fixateur synthétique obligatoire + 3 autres notes aléatoires
                    var fixateurObligatoire = notesFixateurSynthetique[random.Next(notesFixateurSynthetique.Count)];

                    var autresNotesFond = toutesNotes
                        .Where(n => n.Id != fixateurObligatoire.Id
                                 && !notesTete.Contains(n)
                                 && !notesCoeur.Contains(n))
                        .OrderBy(_ => random.Next())
                        .Take(3)
                        .ToList();

                    var notesFond = new List<NoteOlfactive> { fixateurObligatoire };
                    notesFond.AddRange(autresNotesFond);

                    foreach (var note in notesTete)
                    {
                        parfum.Notes.Add(new ParfumNote
                        {
                            NoteOlfactiveId = note.Id,
                            Type = TypeNote.Tete
                        });
                    }

                    foreach (var note in notesCoeur)
                    {
                        parfum.Notes.Add(new ParfumNote
                        {
                            NoteOlfactiveId = note.Id,
                            Type = TypeNote.Coeur
                        });
                    }

                    foreach (var note in notesFond)
                    {
                        parfum.Notes.Add(new ParfumNote
                        {
                            NoteOlfactiveId = note.Id,
                            Type = TypeNote.Fond
                        });
                    }
                }
            }

            context.Parfums.AddRange(parfums);

            await context.SaveChangesAsync();

            Console.WriteLine("Nettoyage des donnees existantes...");
            var seedEmails = new[]
            {
                "admin@test.com",
                "employe@test.com",
                "client@test.com"
            };
            var existingUsers = await context.Users.Where(u => seedEmails.Contains(u.Email!)).ToListAsync();
            var existingIds = existingUsers.Select(u => u.Id).ToList();

            context.UserRoles.RemoveRange(context.UserRoles.Where(r => existingIds.Contains(r.UserId)));
            context.Employes.RemoveRange(context.Employes.Where(e => existingIds.Contains(e.UserId)));
            context.Clients.RemoveRange(context.Clients.Where(e => existingIds.Contains(e.UserId)));
            context.UserClaims.RemoveRange(context.UserClaims.Where(c => existingIds.Contains(c.UserId)));
            context.Users.RemoveRange(existingUsers);
            await context.SaveChangesAsync();

            Console.WriteLine("Creation des roles...");
            foreach (var roleName in new[] { Roles.Administrateur, Roles.Gestionnaire, Roles.Vendeur })
            {
                if (!await context.Roles.AnyAsync(r => r.Name == roleName))
                {
                    context.Roles.Add(new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = roleName,
                        NormalizedName = roleName.ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
                }
            }
            await context.SaveChangesAsync();

            var roleAdmin = await context.Roles.FirstAsync(r => r.Name == Roles.Administrateur);
            var roleGestionnaire = await context.Roles.FirstAsync(r => r.Name == Roles.Gestionnaire);
            var roleVendeur = await context.Roles.FirstAsync(r => r.Name == Roles.Vendeur);

            var hasher = new PasswordHasher<ApplicationUser>();

            // =========================================================
            // PHOTOS ALÉATOIRES DES EMPLOYÉS
            // =========================================================
            var dossierImagesEmployes = TrouverDossierImagesEmployes();

            var imagesEmployesDisponibles = dossierImagesEmployes != null
                ? Directory.GetFiles(dossierImagesEmployes)
                    .Where(f => new[] { ".jpg", ".jpeg", ".png", ".webp" }
                        .Contains(Path.GetExtension(f).ToLowerInvariant()))
                    .Select(Path.GetFileName)
                    .Where(nom => nom != null)
                    .Select(nom => nom!)
                    .ToList()
                : new List<string>();

            if (!imagesEmployesDisponibles.Any())
            {
                Console.WriteLine("Aucune image trouvée dans /Images/Employes — les employés seront créés sans photo.");
            }

            string? ImageAleatoireEmploye()
            {
                if (!imagesEmployesDisponibles.Any())
                    return null;

                var fichier = imagesEmployesDisponibles[random.Next(imagesEmployesDisponibles.Count)];
                return $"/Images/Employes/{fichier}";
            }

            // --- Admin ---
            Console.WriteLine("Creation de l'administrateur...");
            var admin = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@test.com",
                NormalizedUserName = "admin@test.com".ToUpper(),
                Email = "admin@test.com",
                NormalizedEmail = "admin@test.com".ToUpper(),
                EmailConfirmed = true,
                Surnom = "Admin",
                Nom = "Systeme",
                Prenom = "Admin",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            admin.PasswordHash = hasher.HashPassword(admin, "Admin1234!");
            context.Users.Add(admin);
            context.UserClaims.AddRange(
                new IdentityUserClaim<string> { UserId = admin.Id, ClaimType = "Surnom", ClaimValue = admin.Surnom },
                new IdentityUserClaim<string> { UserId = admin.Id, ClaimType = "TypeUtilisateur", ClaimValue = "Employe" },
                new IdentityUserClaim<string> { UserId = admin.Id, ClaimType = "Departement", ClaimValue = "Administration" }
            );
            context.Employes.Add(new Employe
            {
                UserId = admin.Id,
                Poste = "Administrateur systeme",
                Departement = "Administration",
                DateEmbauche = new DateTime(2020, 1, 1),
                PhotoUrl = ImageAleatoireEmploye()
            });

            // AJOUT : donner aussi un Client à l'admin pour qu'il puisse avoir un panier
            context.Clients.Add(new Client
            {
                UserId = admin.Id,
                Commandes = new List<Commande>()
            });

            context.UserRoles.Add(new IdentityUserRole<string> { UserId = admin.Id, RoleId = roleAdmin.Id });

            // --- Employe ---
            Console.WriteLine("Creation de l'employe...");
            var employe = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "employe@test.com",
                NormalizedUserName = "employe@test.com".ToUpper(),
                Email = "employe@test.com",
                NormalizedEmail = "employe@test.com".ToUpper(),
                EmailConfirmed = true,
                Surnom = "Bob",
                Nom = "Tremblay",
                Prenom = "Bob",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            employe.PasswordHash = hasher.HashPassword(employe, "Test1234!");
            context.Users.Add(employe);
            context.UserClaims.AddRange(
                new IdentityUserClaim<string> { UserId = employe.Id, ClaimType = "Surnom", ClaimValue = employe.Surnom },
                new IdentityUserClaim<string> { UserId = employe.Id, ClaimType = "TypeUtilisateur", ClaimValue = "Employe" },
                new IdentityUserClaim<string> { UserId = employe.Id, ClaimType = "Departement", ClaimValue = "Informatique" }
            );
            context.Employes.Add(new Employe
            {
                UserId = employe.Id,
                Poste = "Developpeur",
                Departement = "Informatique",
                DateEmbauche = new DateTime(2020, 1, 15),
                PhotoUrl = ImageAleatoireEmploye()
            });
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = employe.Id, RoleId = roleGestionnaire.Id });

            // --- Etudiant ---
            Console.WriteLine("Creation du client...");
            var client = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "client@test.com",
                NormalizedUserName = "client@test.com".ToUpper(),
                Email = "client@test.com",
                NormalizedEmail = "client@test.com".ToUpper(),
                EmailConfirmed = true,
                Surnom = "Alice",
                Nom = "Gagnon",
                Prenom = "Alice",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            client.PasswordHash = hasher.HashPassword(client, "Test1234!");
            context.Users.Add(client);
            context.UserClaims.AddRange(
                new IdentityUserClaim<string> { UserId = client.Id, ClaimType = "Surnom", ClaimValue = client.Surnom },
                new IdentityUserClaim<string>
                {
                    UserId = client.Id,
                    ClaimType = "TypeUtilisateur",
                    ClaimValue = "Client"
                },
                new IdentityUserClaim<string> { UserId = client.Id, ClaimType = "Programme", ClaimValue = "Techniques de l'informatique" }
            );
            context.Clients.Add(new Client
            {
                UserId = client.Id,
                Commandes = new List<Commande>()
            });
            context.UserRoles.Add(
                new IdentityUserRole<string>
                {
                    UserId = client.Id,
                    RoleId = roleVendeur.Id
                });

            await context.SaveChangesAsync();

            Console.WriteLine($"Admin -> {Roles.Administrateur}");
            Console.WriteLine($"Employé -> {Roles.Gestionnaire}");
            Console.WriteLine($"Client -> {Roles.Vendeur}");
            Console.WriteLine("Seed terminé avec succès !");
        }

        // Recherche le dossier wwwroot/Images/Employes en remontant l'arborescence
        // depuis le dossier d'exécution du seeder, pour éviter un chemin en dur fragile.
        private static string? TrouverDossierImagesEmployes()
        {
            var dossier = new DirectoryInfo(AppContext.BaseDirectory);

            for (int i = 0; i < 10 && dossier != null; i++)
            {
                var candidatAvecProjet = Path.Combine(dossier.FullName, "WebStoreAdmin", "wwwroot", "Images", "Employes");
                if (Directory.Exists(candidatAvecProjet))
                    return candidatAvecProjet;

                var candidatDirect = Path.Combine(dossier.FullName, "wwwroot", "Images", "Employes");
                if (Directory.Exists(candidatDirect))
                    return candidatDirect;

                dossier = dossier.Parent;
            }

            return null;
        }
    }
}