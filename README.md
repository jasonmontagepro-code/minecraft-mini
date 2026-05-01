# Mini Minecraft

Un mini-jeu Minecraft créé avec Unity et C#. Monde 3D avec système de blocs, crafting, inventaire et un portail de l'End caché dans une grotte.

## Features

- 🌍 Monde 3D généré avec terrain, arbres et grotte
- 🧱 Système de blocs (placement/destruction)
- ⚒️ Crafting simple (bois → planches → bâtons, etc.)
- 🎒 Inventaire et interface utilisateur
- 🟣 Portail de l'End avec yeux d'Ender pré-placés dans la grotte
- 🎮 Contrôles fluides (WASD + souris)

## Contrôles

- **WASD** : Mouvement
- **Espace** : Sauter
- **Souris** : Regarder autour
- **Clic gauche** : Détruire un bloc
- **Clic droit** : Placer un bloc
- **I** : Ouvrir/fermer l'inventaire
- **C** : Ouvrir le crafting
- **E** : Interagir avec portail

## Structure du Projet

```
Assets/
├── Scripts/
│   ├── WorldManager.cs          # Gestion du monde et génération
│   ├── BlockType.cs             # Définition des types de blocs
│   ├── Block.cs                 # Comportement d'un bloc
│   ├── Player.cs                # Contrôle du joueur
│   ├── BlockPlacement.cs        # Placement/destruction
│   ├── CraftingSystem.cs        # Système de crafting
│   ├── InventoryUI.cs           # Interface inventaire
│   ├── EndPortal.cs             # Portail de l'End
│   └── GameManager.cs           # Gestion générale du jeu
├── Materials/
├── Prefabs/
└── Scenes/
    └── MainScene.unity
```

## Installation

1. Clonez ce repo
2. Ouvrez le projet dans Unity (2021.3 LTS ou plus récent)
3. Ouvrez la scène `Assets/Scenes/MainScene.unity`
4. Appuyez sur Play

## Monde

- **Taille** : 64x64 blocs
- **Hauteur** : 64 blocs
- **Grotte** : Y = 10-30 avec portail de l'End au fond
- **Yeux d'Ender** : 12 pré-placés dans le portail

## Développement

Pour ajouter de nouveaux blocs :
1. Ajoutez le type dans `BlockType.cs`
2. Créez une texture/matériau
3. Ajoutez une recette de crafting si nécessaire

## Auteur

jasonmontagepro-code
