# 📚 Guide d'Import - Configurez votre projet en 15 minutes

## 🎯 Avant de commencer

✅ Assurez-vous d'avoir :
- Unity 2021.3 LTS ou plus récent
- Le projet cloné depuis GitHub
- Un terminal/IDE ouvert

---

## 📋 ÉTAPE 1 : Structure des dossiers (VÉRIFICATION)

**Vérifiez que tous les dossiers existent :**

```
Assets/
├── Scripts/
│   ├── Player/              ✅ Contient 3 fichiers
│   ├── UI/                  ✅ Contient 3 fichiers
│   ├── World/               ✅ Contient 5 fichiers
│   └── Mobs/                ✅ Contient 23 fichiers
├── Materials/               ⚠️ À CRÉER
├── Prefabs/                 ⚠️ À CRÉER
└── Scenes/                  ✅ À CRÉER (MainScene.unity)
```

**Si des dossiers manquent, créez-les :**
1. Dans Project (Assets), clic droit
2. **Create Folder**
3. Nommez-le (Materials, Prefabs, etc.)

---

## 🎮 ÉTAPE 2 : Créer la scène principale

### 2.1 Créer la scène

1. **Clic droit** dans Assets/Scenes/
2. **Create** → **Scene**
3. Nommez-la **"MainScene"**
4. **Sauvegardez** (Ctrl+S ou Cmd+S)

### 2.2 Configurer la scène

1. **Ouvrez** MainScene.unity
2. **Clic droit** dans Hierarchy → **3D Object** → **Plane**
3. Nommez-le **"Ground"**
4. Scale : (10, 1, 10)

---

## 🎨 ÉTAPE 3 : Créer les préfabs

### 3.1 Créer le Prefab Block

1. **Clic droit** dans Hierarchy → **3D Object** → **Cube**
2. Nommez-le **"Block"**
3. Scale : (1, 1, 1)
4. **Ajoutez** un **Material** :
   - Assets/Materials/ → **Clic droit** → **Material**
   - Nommez-le **"BlockMaterial"**
   - Assignez-le au Cube
5. **Drag & Drop** le Block dans **Assets/Prefabs/**
6. **Supprimez** le Block de la scène

### 3.2 Créer le Prefab Player

1. **Clic droit** dans Hierarchy → **3D Object** → **Capsule**
2. Nommez-le **"Player"**
3. Position : (0, 5, 0)
4. **Ajoutez un Rigidbody** :
   - Mass : 1
   - Drag : 5
   - Angular Drag : 0.05
5. **Ajoutez une Camera** :
   - Clic droit sur Player → **3D Object** → **Camera**
   - Position : (0, 0.6, 0)
   - Renommez-la "MainCamera"
6. **Ajoutez les scripts** :
   - PlayerMovementUpgraded.cs
   - PlayerStats.cs
   - BlockPlacement.cs
   - InventoryUI.cs
   - CraftingSystem.cs
7. **Dans l'Inspector**, assignez la Camera au script PlayerMovementUpgraded
8. **Tag** : "Player"
9. **Drag & Drop** le Player dans **Assets/Prefabs/**

### 3.3 Créer les GameObjects de la scène

1. **Clic droit** Hierarchy → **Create Empty**
2. Nommez-le **"WorldManager"**
3. **Add Component** → **WorldManager.cs**
4. Assignez le Block Prefab et le BlockMaterial

---

## 🧟 ÉTAPE 4 : Configurer les Mobs

### 4.1 Créer le Prefab Mob (optionnel)

1. **Clic droit** Hierarchy → **3D Object** → **Capsule**
2. Nommez-le **"Mob"**
3. **Ajoutez** :
   - Rigidbody
   - CapsuleCollider
   - NavMeshAgent
   - Mob.cs (classe de base)
4. **Tag** : "Mob"
5. **Sauvegardez** dans Assets/Prefabs/ (optionnel)
6. **Supprimez** de la scène

### 4.2 Créer MobSpawner

1. **Clic droit** Hierarchy → **Create Empty**
2. Nommez-le **"MobSpawner"**
3. **Add Component** → **MobSpawner.cs**
4. **Assignez** le Player Transform dans l'Inspector

---

## 🗺️ ÉTAPE 5 : Créer la NavMesh (IMPORTANT!)

**SANS CECI, LES MOBS NE FONCTIONNERONT PAS !**

1. **Window** → **AI** → **Navigation**
2. **Sélectionnez** le Ground (Plane)
3. Dans l'onglet "Bake" :
   - Agent Radius: 0.5
   - Agent Height: 2
   - Max Slope: 45
4. Cliquez **"Bake"**
5. Un maillage **bleu/vert** devrait apparaître sur le sol

---

## 📊 ÉTAPE 6 : Créer l'UI HUD

### 6.1 Créer le Canvas

1. **Clic droit** Hierarchy → **UI** → **Canvas**
2. Nommez-le **"HUD"
3. **Sélectionnez** le Canvas
4. Dans **Canvas Scaler** :
   - UI Scale Mode : "Scale With Screen Size"
   - Reference Resolution : (1920, 1080)

### 6.2 Ajouter les barres de vie/faim

1. **Clic droit** HUD → **UI** → **Panel**
2. Nommez-le **"HealthPanel"**
3. Positionnez-le en haut à gauche
4. **Ajoutez une Image** enfant :
   - Clic droit HealthPanel → **UI** → **Image**
   - Nommez-la **"HealthBar"**
   - Couleur : Vert
   - Image Type : "Filled"
   - Fill Method : "Horizontal"
5. **Ajoutez du texte** enfant :
   - Clic droit HealthPanel → **UI** → **Text**
   - Nommez-le **"HealthText"**
   - Contenu : "Santé: 20 / 20"

### 6.3 Répéter pour la faim

1. **Dupliquez** HealthPanel (Ctrl+D)
2. Renommez-le **"HungerPanel"**
3. Changez la couleur à Orange
4. Changez le texte à "Faim: 100 / 100"

### 6.4 Ajouter le script HUD

1. **Sélectionnez** le Canvas HUD
2. **Add Component** → **PlayerHUDUI.cs**
3. **Assignez** :
   - Health Bar → Image du HealthPanel
   - Hunger Bar → Image du HungerPanel
   - Health Text → Text du HealthPanel
   - Hunger Text → Text du HungerPanel

---

## 🏃 ÉTAPE 7 : Configurer le Player

1. **Drag & Drop** le Player Prefab depuis Assets/Prefabs/ dans la scène
2. Position : (0, 10, 0)
3. **Sélectionnez** le Player
4. Dans l'Inspector :
   - **PlayerMovementUpgraded** → Assigner la Camera
   - **PlayerStats** → Valeurs par défaut OK
   - **BlockPlacement** → Assigner la Camera
5. **Tag** : "Player"

---

## ✅ VÉRIFICATION FINALE

Avant de lancer :

- ✅ Player a tous les scripts
- ✅ Player a le tag "Player"
- ✅ NavMesh est bakée (surface colorée)
- ✅ MobSpawner existe et a une référence au Player
- ✅ HUD Canvas avec barres de vie/faim
- ✅ WorldManager avec Block Prefab assigné
- ✅ Tous les dossiers Scripts, Materials, Prefabs, Scenes existent

---

## 🎮 LANCER LE JEU

1. Appuyez sur **Play**
2. Testez :
   - **WASD** → Mouvement
   - **SHIFT** → Sprint
   - **CTRL** → Accroupi
   - **Clic gauche** → Casser bloc
   - **Clic droit** → Placer bloc
   - **I** → Inventaire
   - **C** → Crafting

---

## 🐛 TROUBLESHOOTING

### Les mobs n'apparaissent pas
```
❌ NavMesh n'est pas bakée
✅ Refaites l'ÉTAPE 5

❌ MobSpawner n'a pas le Player assigné
✅ Assignez le Player Transform dans l'Inspector
```

### Les mobs ne bougent pas
```
❌ NavMesh n'existe pas
✅ Faites l'ÉTAPE 5
```

### L'HUD ne s'affiche pas
```
❌ Pas d'assignation dans PlayerHUDUI
✅ Assignez toutes les images et textes

❌ Canvas en World Space
✅ Changez en Screen Space - Overlay
```

### Les contrôles ne répondent pas
```
❌ Player n'est pas bien configuré
✅ Vérifiez que la Camera est enfant du Player
✅ Vérifiez que PlayerMovementUpgraded a la Camera assignée
```

---

## 📞 Besoin d'aide ?

Si quelque chose ne fonctionne pas :
1. Vérifiez la console (Window → General → Console)
2. Lisez les messages d'erreur rouges
3. Relisez cette section "TROUBLESHOOTING"

**Bon jeu !** 🎮
