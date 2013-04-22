using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory.Meta
{
    public interface IFireworkMeta : IItemMeta
    {

        void AddEffect(FireworkEffect effect);

        void AddEffects(params FireworkEffect[] effects);

        void AddEffects(IEnumerable<FireworkEffect> effects);

        List<FireworkEffect> GetEffects();

        int GetEffectsSize();

        void RemoveEffect(int index);

        void ClearEffects();

        int GetPower();

        void SetPower(int power);

        new IFireworkMeta Clone();

    }
}
