using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Help
{

    public class HelpTopicComparator : IComparer<HelpTopic>
    {

        private static TopicNameComparator tnc = new TopicNameComparator();

        private HelpTopicComparator()
        {
        }

        public static TopicNameComparator TopicNameComparatorInstance()
        {
            return tnc;
        }

        private static HelpTopicComparator htc = new HelpTopicComparator();

        public static HelpTopicComparator HelpTopicComparatorInstance()
        {
            return htc;
        }


        public int Compare(HelpTopic x, HelpTopic y)
        {
            return tnc.Compare(x.Name, y.Name);
        }

    }

    public class TopicNameComparator : IComparer<string>
    {

        internal TopicNameComparator() { }

        public int Compare(string x, string y)
        {
            bool lhsStartSlash = x.StartsWith("/");
            bool rhsStartSlash = y.StartsWith("/");

            if (lhsStartSlash && !rhsStartSlash)
            {
                return 1;
            }
            else if (!lhsStartSlash && rhsStartSlash)
            {
                return -1;
            }
            else
            {
                return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            }
        }
    }

}
