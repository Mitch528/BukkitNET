using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IDamageable
    {

        void Damage(int amount);

        void Damage(int amount, IEntity source);

        int GetHealth();

        void SetHealth(int health);

        int GetMaxHealth();

        void SetMaxHealth(int health);

        void ResetMaxHealth();

    }
}
