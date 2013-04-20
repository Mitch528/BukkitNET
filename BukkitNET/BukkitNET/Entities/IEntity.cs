using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Metadata;
using BukkitNET.Util;

namespace BukkitNET.Entities
{
    public interface IEntity : IMetadatable
    {

        Location GetLocation();

        Location GetLocation(Location loc);

        void SetVelocity(Vector velocity);

        Vector GetVelocity();

        bool IsOnGround();

        IWorld GetWorld();

        bool Teleport(Location location);

        bool Teleport(Location location, TeleportCause cause);

        bool Teleport(IEntity destination);

        bool Teleport(IEntity destination, TeleportCause cause);

        List<IEntity> GetNearbyEntities(double x, double y, double z);

        int GetEntityId();

        int GetFireTicks();

        int GetMaxFireTicks();

        void SetFireTicks(int ticks);

        void Remove();

        bool IsDead();

        bool IsValid();

        Server GetServer();

        IEntity GetPassenger();

        void SetPassenger(IEntity passenger);

        bool IsEmpty();

        bool Eject();

        float GetFallDistance();

        void SetFallDistance(float distance);

        void SetLastDamageCause(EntityDamageEvent evt);

        EntityDamageEvent GetLastDamageCause();

        Guid GetUniqueId();

        int GetTicksLived();

        void SetTicksLived(int value);

        void PlayEffect(EntityEffect type);

        EntityType GetEntityType();

        bool IsInsideVehicle();

        bool LeaveVehicle();

        IEntity GetVehicle();

    }
}
