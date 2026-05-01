# Guide de Configuration - Setup Complet Unity

## ✅ Configuration Automatique

Tous les scripts sont prêts ! Voici comment les configurer dans Unity :

## 🎮 ÉTAPE 1 : Mettre à jour le Player

### 1.1 Remplacer le script Player

1. Sélectionnez le **Player** dans la Hierarchy
2. Dans l'Inspector, trouvez le script **Player.cs**
3. **Supprimez-le** (clic droit sur le composant → Remove Component)
4. **Ajoutez** le script **PlayerMovementUpgraded.cs**

### 1.2 Ajouter PlayerStats

1. Toujours sur le Player, cliquez **Add Component**
2. Cherchez **PlayerStats.cs** et l'ajouter
3. Les valeurs par défaut sont OK :
   - Max Health: 20
   - Max Hunger: 100
   - Hunger Decay Rate: 0.1
   - Sprint Hunger Cost: 0.5

### 1.3 Ajouter BlockPlacement (si pas présent)

1. **Add Component** → **BlockPlacement.cs**
2. Assigner la Camera du joueur
3. La référence InventoryUI sera auto-détectée

### 1.4 Ajouter InventoryUI

1. **Add Component** → **InventoryUI.cs**
2. Assigner les panels d'inventaire si vous les avez créés

### 1.5 Ajouter CraftingSystem

1. **Add Component** → **CraftingSystem.cs**

## 🧟‍♂️ ÉTAPE 2 : Créer NavMesh

**IMPORTANT : Ceci est OBLIGATOIRE pour que les mobs se déplacent !**

1. Allez dans **Window → AI → Navigation**
2. Sélectionnez le **Terrain** (ou le sol de votre monde)
3. Dans l'onglet "Bake", gardez les paramètres par défaut
4. Cliquez **"Bake"** (ça peut prendre quelques secondes)
5. Un fond bleu/vert devrait apparaître sur le sol

**Si pas de surface bleu/vert :** Le terrain n'est pas bien taguée comme "Walkable"

## 🕷️ ÉTAPE 3 : Configurer MobSpawner

### 3.1 Créer le GameObject

1. **Clic droit** dans Hierarchy → **Create Empty**
2. Nommez-le **"MobSpawner"**
3. Position : (0, 0, 0) c'est OK

### 3.2 Ajouter le script

1. Sélectionnez MobSpawner
2. **Add Component** → **MobSpawner.cs**
3. Dans l'Inspector, assignez le **Player** au champ "Player Transform"

### 3.3 Paramètres (optionnel)

- **Max Mob Count** : 50 (nombre max de mobs simultanés)
- **Spawn Radius** : 50 (distance d'apparition autour du joueur)
- **Spawn Cooldown** : 5 (secondes entre chaque spawn)

## 🏷️ ÉTAPE 4 : Ajouter les Tags

**IMPORTANT : Sans les tags, les mobs ne pourront pas attaquer le joueur !**

### 4.1 Tag "Player"

1. Sélectionnez le **Player**
2. En haut à droite, trouvez le dropdown **"Tag"**
3. Cliquez sur **"Add Tag"**
4. Créez un nouveau tag appelé **"Player"**
5. Assignez ce tag au Player

### 4.2 Tag "Mob"

1. Cliquez sur **"Add Tag"** à nouveau
2. Créez un tag **"Mob"**
3. Les mobs créés par MobSpawner auront ce tag automatiquement

## 📊 ÉTAPE 5 : Créer l'UI HUD

### 5.1 Créer un Canvas pour l'HUD

1. **Clic droit** dans Hierarchy → **UI** → **Canvas**
2. Nommez-le **"HUD"
3. Sélectionnez le Canvas, allez dans **Canvas Scaler**
4. Mode UI Scale : "Scale With Screen Size"

### 5.2 Ajouter les barres de vie

1. Sélectionnez le Canvas HUD
2. **Clic droit** → **UI** → **Panel**
3. Nommez-le **"HealthPanel"**
4. Positionnez-le en haut à gauche
5. Ajoutez une **Image** comme enfant (pour la barre verte)
6. Assignez l'Image au script **PlayerHUDUI** (champ "Health Bar")

### 5.3 Ajouter les barres de faim

1. Créez une autre panel **"HungerPanel"**
2. Positionnez-la à côté ou dessous
3. Ajoutez une Image (couleur orange/jaune)
4. Assignez-la au script **PlayerHUDUI** (champ "Hunger Bar")

### 5.4 Ajouter le texte

1. Ajoutez du texte à chaque panel (Text component)
2. Assignez les textes à **PlayerHUDUI**
3. Ce texte affichera : "Santé: 20 / 20" et "Faim: 100 / 100"

### 5.5 Ajouter le script HUD

1. Sélectionnez le Canvas HUD
2. **Add Component** → **PlayerHUDUI.cs**
3. Assignez les barres d'images et les textes dans les champs correspondants

## ✅ Vérification finale

Avant de lancer le jeu, vérifiez :

- ✅ Player a **PlayerMovementUpgraded.cs**
- ✅ Player a **PlayerStats.cs**
- ✅ Player a **BlockPlacement.cs**
- ✅ Player a le tag "Player"
- ✅ **NavMesh** est bakée (surface bleu/vert sur le terrain)
- ✅ **MobSpawner** GameObject existe avec le script
- ✅ MobSpawner a une référence au Player
- ✅ HUD Canvas avec barres de vie/faim
- ✅ Camera est enfant du Player

## 🎮 Test !

Clic sur **Play** et testez :

- Vous pouvez vous déplacer (WASD)
- Vous pouvez sprinter (SHIFT) - la faim diminue
- Vous pouvez vous accroupir (CTRL)
- Les mobs apparaissent autour de vous
- Les mobs vous attaquent et vous perdez de la vie
- L'HUD affiche votre santé et faim

## 🐛 Troubleshooting

**Les mobs n'apparaissent pas :**
- Vérifiez que NavMesh est bien bakée
- Vérifiez que MobSpawner a une référence au Player

**Les mobs ne vous attaquent pas :**
- Vérifiez que le Player a le tag "Player"
- Vérifiez que les colliders sont bien configurés

**L'HUD ne s'affiche pas :**
- Vérifiez que PlayerHUDUI a des références aux Images et Textes
- Vérifiez que le Canvas est en "World Space" ou "Screen Space"

**Les contrôles ne fonctionnent pas :**
- Allez dans **Edit → Project Settings → Input Manager**
- Vérifiez que les axes "Horizontal" et "Vertical" existent

---

**Vous avez besoin d'aide ?** 👍
