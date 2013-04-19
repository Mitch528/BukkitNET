using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BukkitNET.Configuration.File
{
    public class JsonConfiguration : FileConfiguration
    {

        public override string SaveToString()
        {
            return JsonConvert.SerializeObject(this.map, Formatting.Indented);
        }

        public override void LoadFromString(string contents)
        {

            var o = new JObject(contents);

            map = Recurse(o);

        }

        private Dictionary<string, object> Recurse(JObject jo)
        {

            foreach (var s in jo)
            {

                string key = s.Key;

                JToken tok = s.Value;

                if (tok.Type == JTokenType.Object)
                {
                    map.Add(key, Recurse(s.Value.ToObject<JObject>()));
                }
                else if (tok.Type == JTokenType.Array)
                {
                    map.Add(key, tok.ToObject<List<object>>());
                }
                else if (tok.Type == JTokenType.Boolean)
                {
                    map.Add(key, tok.ToObject<bool>());
                }
                else if (tok.Type == JTokenType.Bytes)
                {
                    map.Add(key, tok.ToObject<List<byte>>());
                }
                else if (tok.Type == JTokenType.Comment)
                {
                    //do nothing
                }
                else if (tok.Type == JTokenType.Float)
                {
                    map.Add(key, tok.ToObject<float>());
                }
                else if (tok.Type == JTokenType.Integer)
                {
                    map.Add(key, tok.ToObject<int>());
                }
                else if (tok.Type == JTokenType.Null)
                {
                    map.Add(key, null);
                }
                else if (tok.Type == JTokenType.String)
                {
                    map.Add(key, tok.ToObject<string>());
                }

            }

        }

    }
}
