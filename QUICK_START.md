# Configuration rapide - 10 minutes

## 🚀 Procédure simple

### 1. Ouvrez le projet
```bash
git clone https://github.com/jasonmontagepro-code/minecraft-mini.git
```

### 2. Préparation dans Unity

**A. Mettre à jour le Player :**
- Supprimez `Player.cs`
- Ajoutez `PlayerMovementUpgraded.cs`
- Ajoutez `PlayerStats.cs`
- Ajoutez `BlockPlacement.cs`
- Ajoutez `InventoryUI.cs`
- Ajoutez `CraftingSystem.cs`
- Tag : "Player"

**B. Créer la NavMesh :**
- Window → AI → Navigation
- Sélectionnez le sol
- Cliquez "Bake"

**C. Ajouter MobSpawner :**
- Créez un GameObject "MobSpawner"
- Ajoutez `MobSpawner.cs`
- Assignez le Player

**D. Créer HUD :**
- Créez un Canvas
- Ajoutez des panels pour vie/faim
- Ajoutez `PlayerHUDUI.cs` au Canvas
- Assignez les images et textes

### 3. Lancez le jeu !

```
Play → Sprint (SHIFT) → Combattez des mobs 🎮
```

---

Pour le détail complet, voir **SETUP_COMPLET.md**
