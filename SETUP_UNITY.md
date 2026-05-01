# Guide d'Installation - Mini Minecraft pour Unity

## 📋 Prérequis

- Unity 2021.3 LTS ou plus récent
- TextMeshPro (inclus par défaut dans Unity)

## 🚀 Étapes d'Installation

### 1. Cloner le Projet

```bash
git clone https://github.com/jasonmontagepro-code/minecraft-mini.git
cd minecraft-mini
```

### 2. Ouvrir dans Unity

1. Ouvrez **Unity Hub**
2. Cliquez sur **"Open"
3. Sélectionnez le dossier `minecraft-mini`
4. Attendez que le projet se charge

### 3. Structure du Projet

```
Assets/
├── Scripts/                 # Tous les scripts C#
│   ├── WorldManager.cs
│   ├── BlockType.cs
│   ├── Block.cs
│   ├── Player.cs
│   ├── BlockPlacement.cs
│   ├── InventoryUI.cs
│   ├── EndPortal.cs
│   ├── CraftingSystem.cs
│   └── GameManager.cs
├── Materials/              # (À créer) Matériaux des blocs
├── Prefabs/                # (À créer) Prefabs Unity
└── Scenes/
    └── MainScene.unity     # (À créer) Scène principale
```

## ⚙️ Configuration dans Unity

### Étape 1 : Créer la Scène

1. Dans Project, allez dans `Assets/Scenes/`
2. **Clic droit** → **Create** → **Scene**
3. Nommez-la `MainScene`
4. Sauvegardez (Ctrl+S)

### Étape 2 : Créer les GameObjects

**WorldManager :**
1. Clic droit dans Hierarchy → **Create Empty**
2. Nommez-le `WorldManager`
3. Ajoutez le script `WorldManager.cs` via Inspector
4. Draggez-déposez le BlockPrefab dans le slot correspondant

**GameManager :**
1. Clic droit dans Hierarchy → **Create Empty**
2. Nommez-le `GameManager`
3. Ajoutez le script `GameManager.cs`

### Étape 3 : Créer le Prefab du Joueur

1. Créez un **Cube** : Clic droit → **3D Object** → **Cube**
2. Nommez-le `Player`
3. Position : (32, 35, 32)
4. Ajoutez un **Rigidbody**
5. Ajoutez une **Camera** en tant qu'enfant
6. Ajoutez les scripts :
   - `Player.cs`
   - `BlockPlacement.cs`
   - `InventoryUI.cs`
   - `CraftingSystem.cs`
7. Créez un dossier `Assets/Prefabs/`
8. Draggez le Player dans le dossier Prefabs
9. Dans GameManager, assignez ce Prefab

### Étape 4 : Créer le Prefab du Bloc

1. Créez un **Cube** : Clic droit → **3D Object** → **Cube**
2. Nommez-le `Block`
3. Ajoutez un **Box Collider**
4. Ajoutez un **MeshRenderer**
5. Ajoutez le script `Block.cs`
6. Créez un matériau par défaut : **Assets/Materials/DefaultBlock.mat**
7. Assignez le matériau au MeshRenderer
8. Draggez `Block` dans `Assets/Prefabs/`
9. Dans WorldManager, assignez ce Prefab et le matériau

### Étape 5 : Créer l'Interface Inventaire

1. Créez un **Canvas** : Clic droit → **UI** → **Panel**
2. Nommez-le `InventoryPanel`
3. Ajoutez un **Scroll View** comme enfant
4. Dans le Player, assignez ce panel à InventoryUI

## 🎮 Contrôles

- **WASD** : Mouvement
- **Espace** : Saut
- **Souris** : Regard (la souris doit être verrouillée)
- **Clic gauche** : Détruire bloc
- **Clic droit** : Placer bloc
- **I** : Inventaire
- **C** : Crafting

## 🐛 Dépannage

### Les blocs n'apparaissent pas
- Assurez-vous que le BlockPrefab est assigné à WorldManager
- Vérifiez que le matériau est assigné au Cube

### Le joueur ne bouge pas
- Assurez-vous que le Rigidbody est assigné au Player
- Vérifiez que les axes d'input sont configurés (Edit → Project Settings → Input)

### La caméra ne suit pas la souris
- Vérifiez que la caméra est enfant du joueur
- Assurez-vous que le script Player est attaché au bon GameObject

## 📝 Notes

- Le monde est généré au démarrage
- La grotte est au centre du monde (32, 15, 32)
- Le portail de l'End est en bas de la grotte
- 12 yeux d'Ender sont pré-placés

## 🎯 Prochaines Améliorations

- Ajouter des textures réelles
- Améliorer la génération procédurale
- Ajouter plus de mobs
- Optimiser le rendu des blocs
- Système de journée/nuit

---

Bon jeu ! 🎮
