using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Flowerpot : MaterialData
    {

        public Flowerpot()
            : base(Material.FlowerPot)
        {
        }

        public Flowerpot(int type)
            : base(type)
        {
        }

        public Flowerpot(Material type)
            : base(type)
        {
        }

        public Flowerpot(int type, byte data)
            : base(type, data)
        {
        }

        public Flowerpot(Material type, byte data)
            : base(type, data)
        {
        }

        public MaterialData GetContents()
        {
            switch (Data)
            {
                case 1:
                    return new MaterialData(Material.RedRose);
                case 2:
                    return new MaterialData(Material.YellowFlower);
                case 3:
                    return new Tree(TreeSpecies.Generic);
                case 4:
                    return new Tree(TreeSpecies.Redwood);
                case 5:
                    return new Tree(TreeSpecies.Birch);
                case 6:
                    return new Tree(TreeSpecies.Jungle);
                case 7:
                    return new MaterialData(Material.RedMushroom);
                case 8:
                    return new MaterialData(Material.BrownMushroom);
                case 9:
                    return new MaterialData(Material.Cactus);
                case 10:
                    return new MaterialData(Material.DeadBush);
                case 11:
                    return new LongGrass(GrassSpecies.FernLike);
                default:
                    return null;
            }
        }

        public void SetContents(MaterialData materialData)
        {
            Material mat = materialData.ItemType;

            if (mat == Material.RedRose)
            {
                Data = ((byte)1);
            }
            else if (mat == Material.YellowFlower)
            {
                Data = ((byte)2);
            }
            else if (mat == Material.RedMushroom)
            {
                Data = ((byte)7);
            }
            else if (mat == Material.BrownMushroom)
            {
                Data = ((byte)8);
            }
            else if (mat == Material.Cactus)
            {
                Data = ((byte)9);
            }
            else if (mat == Material.DeadBush)
            {
                Data = ((byte)10);
            }
            else if (mat == Material.Sapling)
            {
                TreeSpecies species = ((Tree)materialData).Species;

                if (species == TreeSpecies.Generic)
                {
                    Data = ((byte)3);
                }
                else if (species == TreeSpecies.Redwood)
                {
                    Data = ((byte)4);
                }
                else if (species == TreeSpecies.Birch)
                {
                    Data = ((byte)5);
                }
                else
                {
                    Data = ((byte)6);
                }
            }
            else if (mat == Material.LongGrass)
            {
                GrassSpecies species = ((LongGrass)materialData).Species;

                if (species == GrassSpecies.FernLike)
                {
                    Data = ((byte)11);
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + " containing " + GetContents();
        }

    }
}
