using System;
using System.IO;
using Domain;

namespace Storage
{
    public class TextFileRepository : IFileRepository
    {
        public void SaveEntities(string path, IEntity[] entities)
        {
            if (string.IsNullOrWhiteSpace(path) || entities == null)
                throw new ArgumentNullException();

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var e in entities)
                {
                    writer.WriteLine(e.GetType().Name + " " + e.FirstName + e.LastName);
                    writer.WriteLine("{");
                    writer.WriteLine("\"firstname\": \"" + e.FirstName + "\",");
                    writer.WriteLine("\"lastname\": \"" + e.LastName + "\"");
                    writer.WriteLine("};");
                }
            }
        }

        public IEntity[] LoadEntities(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException();

            if (!File.Exists(path))
                throw new FileNotFoundException();

            
            string[] lines = File.ReadAllLines(path);
            IEntity[] result = new IEntity[0];
            return result;
        }
    }
}
