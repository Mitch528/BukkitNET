﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface ILivingEntity : IEntity, IDamageable
    {

        double GetEyeHeight();

        double GetEyeHeight(bool ignoreSneaking);

        Location GetEyeLocation();

        List<Block> GetLineOfSight(HashSet<byte> transparent, int maxDistance);

        Block GetTargetBlock(HashSet<byte> transparent, int maxDistance);

        List<Block> GetLastTwoTargetBlocks(HashSet<byte> transparent, int maxDistance);

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

        Player GetKiller();

        bool AddPotionEffect(PotionEffect effect);

        bool AddPotionEffect(PotionEffect effect, bool force);

        bool AddPotionEffects(Collection<PotionEffect> effects);

        bool HasPotionEffect(PotionEffectType type);

        void RemovePotionEffect(PotionEffectType type);

        Collection<PotionEffect> GetActivePotionEffects();

        bool HasLineOfSight(IEntity other);

        bool GetRemoveWhenFarAway();

        void SetRemoveWhenFarAway(bool remove);

        EntityEquipment GetEquipment();

        void SetCanPickupItems(bool pickup);

        bool GetCanPickupItems();

        void SetCustomName(string name);

        string GetCustomName();

        void SetCustomNameVisible(bool flag);

        bool IsCustomNameVisible();

    }
}