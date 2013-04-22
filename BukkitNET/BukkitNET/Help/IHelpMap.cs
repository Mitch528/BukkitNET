using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BukkitNET.Commands;

namespace BukkitNET.Help
{
    public interface IHelpMap
    {

        HelpTopic GetHelpTopic(string topicName);

        Collection<HelpTopic> GetHelpTopics();

        void AddTopic(HelpTopic topic);

        void Clear();

        void RegisterHelpTopicFactory<T>(Type commandType, IHelpTopicFactory<T> factory) where T : Command;

        List<string> GetIgnoredPlugins();

    }
}
