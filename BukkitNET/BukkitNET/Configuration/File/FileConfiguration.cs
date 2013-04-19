using System;
using System.Diagnostics;
using System.IO;

namespace BukkitNET.Configuration.File
{
    public abstract class FileConfiguration : MemoryConfiguration
    {

        public FileConfiguration()
            : base()
        {
        }

        public FileConfiguration(IConfiguration defaults)
            : base(defaults)
        {
        }

        public void Save(FileInfo file)
        {

            Debug.Assert(file != null, "File cannot be null");

            if (file.Directory == null)
                throw new DirectoryNotFoundException();

            Directory.CreateDirectory(file.Directory.FullName);

            String data = SaveToString();

            StreamWriter writer = new StreamWriter(file.FullName);

            try
            {
                writer.Write(data);
            }
            finally
            {
                writer.Close();
            }
        }

        public void Save(string file)
        {
            Debug.Assert(file != null, "File cannot be null");

            Save(new FileInfo(file));
        }

        public abstract string SaveToString();

        public void Load(string file)
        {
            Load(new FileInfo(file));
        }

        public void Load(FileInfo file)
        {

            Debug.Assert(file != null, "File cannot be null");

            Load(new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read));

        }

        public void Load(FileStream fs)
        {

            StreamReader reader = new StreamReader(fs);

            LoadFromString(reader.ReadToEnd());

        }

        public abstract void LoadFromString(String contents);

        public new FileConfigurationOptions Options()
        {
            if (options == null)
            {
                options = new FileConfigurationOptions(this);
            }

            return (FileConfigurationOptions)options;
        }

    }
}
