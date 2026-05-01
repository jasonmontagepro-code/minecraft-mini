# 📦 MINECRAFT-MINI - PACKAGE COMPLET

## 🎯 Contenu du package

Ce repo contient **TOUT** ce qu'il faut pour créer un mini Minecraft en Unity avec :

### 🎮 **Gameplay Complet**
- ✅ **Monde 3D** 64x64 avec terrain, arbres, grotte
- ✅ **Système de blocs** - Placement, destruction
- ✅ **Portail de l'End** - 12 yeux pré-placés
- ✅ **Crafting** - Recipes simples
- ✅ **Inventaire** - Gestion des items

### 👤 **Système de Joueur Avancé**
- ✅ **Sprint** (SHIFT) - Consomme la faim
- ✅ **Accroupissement** (CTRL) - Plus lent
- ✅ **Santé** (20 points) - Régenère lentement
- ✅ **Faim** (100 points) - Diminue en continu
- ✅ **HUD** - Barres de vie/faim visibles

### 🧟 **25 MOBS UNIQUES**

**Passifs (amicaux):**
1. Cow, 2. Sheep, 3. Pig, 4. Chicken, 5. Horse

**Agressifs de jour:**
6. Vampire, 7. Wizard, 8. Swordsman

**Agressifs de nuit:**
9. Zombie, 10. Spider, 11. Skeleton, 12. Enderman

**Spéciaux:**
13. Creeper (explosion), 14. Ghast (feu), 15. Bat (chauve-souris)
16. Drone (laser), 17. GiantWorm, 18. Miner, 19. Demon
20. Golem (100 HP), 21. MiniBoss (150 HP, 2 phases)
22. Fairy (soigne), 23. MiniDragon (crache feu)

### 📊 **Scripts Organisés**
- 8 scripts Joueur + UI
- 4 scripts Monde
- 20+ scripts Mobs
- 1 script Spawner automatique

## 📁 **Structure du repo**

```
Assets/
├── Scripts/
│   ├── Player/          → Contrôle, Stats, Blocs
│   ├── UI/              → HUD, Inventaire, Crafting
│   ├── World/           → Monde, Blocs, Portail
│   └── Mobs/            → 25 mobs uniques + Spawner
├── Materials/           → (À créer) Matériaux
├── Prefabs/             → (À créer) Prefabs
└── Scenes/              → (À créer) MainScene.unity
```

## 🚀 **Installation rapide**

### 1. Cloner
```bash
git clone https://github.com/jasonmontagepro-code/minecraft-mini.git
```

### 2. Ouvrir dans Unity
- Unity Hub → Open → Sélectionner le dossier

### 3. Configurer
- **Suivez** `IMPORT_GUIDE.md` (15 min)
- **Ou** `QUICK_START.md` (5 min ultra-rapide)
- **Ou** `SETUP_COMPLET.md` (30 min détaillé)

### 4. Lancer
- Play button → Profitez ! 🎮

## 📚 **Fichiers de configuration**

| Fichier | Durée | Niveau |
|---------|-------|--------|
| `IMPORT_GUIDE.md` | 15 min | 👍 RECOMMANDÉ |
| `QUICK_START.md` | 5 min | ⚡ Express |
| `SETUP_COMPLET.md` | 30 min | 🔧 Détaillé |

## 🎮 **Contrôles**

| Touche | Action |
|--------|--------|
| **WASD** | Mouvement |
| **SHIFT** | Sprint (faim -0.5/s) |
| **CTRL** | Accroupi |
| **Espace** | Sauter |
| **Clic gauche** | Casser bloc |
| **Clic droit** | Placer bloc |
| **I** | Inventaire |
| **C** | Crafting |
| **E** | Interagir |

## 💾 **Compatibilité**

- ✅ Unity 2021.3 LTS+
- ✅ Windows, Mac, Linux
- ✅ .NET Framework 4.x

## 🎨 **Customisation**

Facile à modifier :
- Ajouter de nouveaux mobs (copier Zombie.cs)
- Changer les couleurs (BlockType.cs)
- Augmenter le monde (WorldManager.cs)
- Ajouter des items (InventoryUI.cs)

## 📞 **Support**

Problème ? Consultez :
1. `IMPORT_GUIDE.md` section "TROUBLESHOOTING"
2. Console Unity (Window → General → Console)
3. Messages d'erreur en détail

## 🎯 **Prochaines améliorations**

- [ ] Textures réalistes
- [ ] Génération procédurale
- [ ] Sons et musique
- [ ] Sauvegarde du monde
- [ ] Multiplayer
- [ ] Plus de biomes
- [ ] Boss final

## 📝 **Licence**

Code libre d'utilisation pour projets personnels et éducatifs.

---

**Bon développement !** 🚀

*Créé par jasonmontagepro-code*
