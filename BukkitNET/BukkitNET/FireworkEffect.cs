using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET;
using BukkitNET.Configuration.Serialization;

namespace BukkitNET
{
    public sealed class FireworkEffect : IConfigurationSerializable
    {

        private static string FLICKER = "flicker";
        private static string TRAIL = "trail";
        private static string COLORS = "colors";
        private static string FADE_COLORS = "fade-colors";
        private static string TYPE = "type";

        private bool flicker;
        private bool trail;
        private List<Color> colors;
        private List<Color> fadeColors;
        private FireworkEffectType type;
        private string str = null;

        public bool HasFlicker
        {
            get
            {
                return flicker;
            }
        }

        public bool HasTrail
        {
            get
            {
                return trail;
            }
        }

        public List<Color> Colors
        {
            get
            {
                return colors;
            }
        }

        public List<Color> FadeColors
        {
            get
            {
                return fadeColors;
            }
        }

        public FireworkEffectType Type
        {
            get
            {
                return type;
            }
        }

        public FireworkEffect(bool flicker, bool trail, List<Color> colors, List<Color> fadeColors, FireworkEffectType type)
        {
            if (!colors.Any())
            {
                throw new Exception("Cannot make FireworkEffect without any color");
            }
            this.flicker = flicker;
            this.trail = trail;
            this.colors = colors;
            this.fadeColors = fadeColors;
            this.type = type;
        }

        public static IConfigurationSerializable Deserialize<T>(Dictionary<string, object> map)
        {

            FireworkEffectType type;

            if (Enum.TryParse((string)map[TYPE], out type))
            {
                throw new ArgumentException((string)map[TYPE] + " is not a valid Type");
            }

            return Builder.NewBuilder()
                .Flicker((bool)map[FLICKER])
                .Trail((bool)map[TRAIL])
                .WithColor((List<T>)map[COLORS])
                .WithFade((List<T>)map[FADE_COLORS])
                .With(type)
                .Build();
        }

        public Dictionary<string, object> Serialize()
        {

            var dict = new Dictionary<string, object>
                           {
                               {FLICKER, flicker},
                               {TRAIL, trail},
                               {COLORS, colors},
                               {FADE_COLORS, fadeColors},
                               {TYPE, type.ToString()}
                           };

            return dict;

        }
    }

    public enum FireworkEffectType
    {
        Ball,
        BallLarge,
        Star,
        Burst,
        Creeper
    }

    public class Builder
    {

        private bool flickr = false;
        private bool trail = false;
        private List<Color> colors = new List<Color>();
        private List<Color> fadeColors = new List<Color>();
        private FireworkEffectType type = FireworkEffectType.Ball;

        private Builder()
        {
        }

        public static Builder NewBuilder()
        {
            return new Builder();
        }

        public Builder With(FireworkEffectType type)
        {
            Debug.Assert(type != default(FireworkEffectType), "Cannot have null type");
            this.type = type;
            return this;
        }

        public Builder WithFlicker()
        {
            flickr = true;
            return this;
        }

        public Builder Flicker(bool flicker)
        {
            this.flickr = flicker;
            return this;
        }

        public Builder WithTrail()
        {
            trail = true;
            return this;
        }

        public Builder Trail(bool trail)
        {
            this.trail = trail;
            return this;
        }

        public Builder WithColor(Color color)
        {
            Debug.Assert(color != null, "Cannot have null color");

            colors.Add(color);

            return this;
        }

        public Builder WithColor(params Color[] colors)
        {
            Debug.Assert(colors != null, "Cannot have null colors");
            if (colors.Length == 0)
            {
                return this;
            }

            List<Color> list = this.colors;
            foreach (Color color in colors)
            {
                Debug.Assert(color != null, "Color cannot be null");
                list.Add(color);
            }

            return this;
        }

        public Builder WithColor<T>(List<T> colors)
        {
            Debug.Assert(colors != null, "Cannot have null colors");

            List<Color> list = this.colors;
            foreach (object color in colors)
            {
                if (!(color is Color))
                {
                    throw new ArgumentException(color + " is not a Color in " + colors);
                }
                list.Add((Color)color);
            }

            return this;
        }

        public Builder WithFade(Color color)
        {
            Debug.Assert(color != null, "Cannot have null color");

            if (fadeColors == null)
            {
                fadeColors = new List<Color>();
            }

            fadeColors.Add(color);

            return this;
        }

        public Builder WithFade(params Color[] colors)
        {
            Debug.Assert(colors != null, "Cannot have null colors");
            if (colors.Length == 0)
            {
                return this;
            }

            List<Color> list = this.fadeColors;
            if (list == null)
            {
                list = this.fadeColors = new List<Color>();
            }

            foreach (Color color in colors)
            {
                Debug.Assert(color != null, "Color cannot be null");
                list.Add(color);
            }

            return this;
        }

        public Builder WithFade<T>(List<T> colors)
        {
            Debug.Assert(colors != null, "Cannot have null colors");

            List<Color> list = this.fadeColors;
            if (list == null)
            {
                list = this.fadeColors = new List<Color>();
            }

            foreach (object color in colors)
            {
                if (!(color is Color))
                {
                    throw new ArgumentException(color + " is not a Color in " + colors);
                }
                list.Add((Color)color);
            }

            return this;
        }

        public FireworkEffect Build()
        {
            return new FireworkEffect(
                flickr,
                trail,
                colors,
                fadeColors == null ? new List<Color>() : fadeColors,
                type
            );
        }

    }

}
