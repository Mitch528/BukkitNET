using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BukkitNET.Block;
using BukkitNET.Inventory;
using BukkitNET.Potions;

namespace BukkitNET.Entities
{
    public interface ILivingEntity : IEntity, IDamageable
    {

        double GetEyeHeight();

        double GetEyeHeight(bool ignoreSneaking);

        Location GetEyeLocation();

        List<IBlock> GetLineOfSight(HashSet<byte> transparent, int maxDistance);

        IBlock GetTargetBlock(HashSet<byte> transparent, int maxDistance);

        List<IBlock> GetLastTwoTargetBlocks(HashSet<byte> transparent, int maxDistance);

        T LaunchProjectile<T>(Type projectile);

        int GetRemainingAir();

        void SetRemainingAir(int ticks);

        int GetMaximumAir();

        void SetMaximumAir(int ticks);

        int GetMaximumNoDamageTicks();

        void SetMaximumNoDamageTicks(int ticks);

        int GetLastDamage();

        void SetLastDamage(int damage);

        int GetNoDamageTicks();

        void SetNoDamageTicks(int ticks);

        IPlayer GetKiller();

        bool AddPotionEffect(PotionEffect effect);

        bool AddPotionEffect(PotionEffect effect, bool force);

        bool AddPotionEffects(Collection<PotionEffect> effects);

        bool HasPotionEffect(PotionEffectType type);

        void RemovePotionEffect(PotionEffectType type);

        Collection<PotionEffect> GetActivePotionEffects();

        bool HasLineOfSight(IEntity other);

        bool GetRemoveWhenFarAway();

        void SetRemoveWhenFarAway(bool remove);

        IEntityEquipment GetEquipment();

        void SetCanPickupItems(bool pickup);

        bool GetCanPickupItems();

        void SetCustomName(string name);

        string GetCustomName();

        void SetCustomNameVisible(bool flag);

        bool IsCustomNameVisible();

    }
}
