using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET
{

    public enum Statistic
    {

        [StatisticInfo(2020)]
        DamageDealt,

        [StatisticInfo(2021)]
        DamageTaken,

        [StatisticInfo(2022)]
        Deaths,

        [StatisticInfo(2023)]
        MobKills,

        [StatisticInfo(2024)]
        PlayerKills,

        [StatisticInfo(2025)]
        FishCaught,

        [StatisticInfo(16777216, true)]
        MineBlock,

        [StatisticInfo(6908288, false)]
        UseItem,

        [StatisticInfo(16973824, true)]
        BreakItem

    }

    public static class StatisticHelper
    {

        public static Statistic GetById(int id)
        {

            var vals = Enum.GetValues(typeof(Statistic));

            return vals.Cast<Statistic>().FirstOrDefault(stat => stat.GetAttribute<StatisticInfoAttribute>().Id == id);

        }

    }

    public static class StatisticExtensions
    {

        public static int GetId(this Statistic stat)
        {
            return GetAttribtue(stat).Id;
        }

        public static bool IsSubstatistic(this Statistic stat)
        {
            return GetAttribtue(stat).IsSubstatistic;
        }

        public static bool IsBlock(this Statistic stat)
        {
            return GetAttribtue(stat).IsBlock;
        }

        private static StatisticInfoAttribute GetAttribtue(Statistic stat)
        {
            return stat.GetAttribute<StatisticInfoAttribute>();
        }

    }

}
