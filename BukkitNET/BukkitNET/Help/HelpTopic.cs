using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BukkitNET.Commands;

namespace BukkitNET.Help
{
    public abstract class HelpTopic
    {

        protected string name;
        protected string shortText;
        protected string fullText;
        protected string amendedPermission;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string ShortText
        {
            get
            {
                return shortText;
            }
        }

        public string FullText
        {
            get
            {
                return fullText;
            }
        }

        public abstract bool CanSee(ICommandSender player);

        public void AmendCanSee(string amendedPermission)
        {
            this.amendedPermission = amendedPermission;
        }

        public void AmendTopic(String amendedShortText, String amendedFullText)
        {
            shortText = ApplyAmendment(shortText, amendedShortText);
            fullText = ApplyAmendment(fullText, amendedFullText);
        }

        protected string ApplyAmendment(string baseText, string amendment)
        {
            if (amendment == null)
            {
                return baseText;
            }
            else
            {
                return Regex.Replace(amendment, "<text>", baseText);
            }
        }


    }
}
