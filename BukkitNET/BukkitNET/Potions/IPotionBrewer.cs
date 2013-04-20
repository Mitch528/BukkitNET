using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BukkitNET.Potions
{
    public interface IPotionBrewer
    {

        PotionEffect CreateEffect(PotionEffectType potion, int duration, int amplifier);

        Collection<PotionEffect> GetEffectsFromDamage(int damage);

    }
}
