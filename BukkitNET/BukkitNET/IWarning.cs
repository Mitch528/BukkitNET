using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET
{

    public interface IWarning
    {

        bool GetValue();

        string GetReason();

    }

    public enum WarningState
    {

        On,
        Off,
        Default = 0

    }

    public static class WarningStateHelper
    {

        private static Dictionary<string, WarningState> values = new Dictionary<string, WarningState>();

        static WarningStateHelper()
        {

            values.Add("off", WarningState.Off);
            values.Add("false", WarningState.Off);
            values.Add("f", WarningState.Off);
            values.Add("no", WarningState.Off);
            values.Add("n", WarningState.Off);
            values.Add("on", WarningState.On);
            values.Add("true", WarningState.On);
            values.Add("t", WarningState.On);
            values.Add("yes", WarningState.On);
            values.Add("y", WarningState.On);
            values.Add("", WarningState.Default);
            values.Add("default", WarningState.Default);

        }

        public static WarningState GetValue(string value)
        {

            if (string.IsNullOrEmpty(value))
                return default(WarningState);

            return values[value];

        }

    }

}
