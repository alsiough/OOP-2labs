using System;
using Domain;
using Storage;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class ConsoleMenu
    {
        private readonly IFileRepository _repo;
        private IEntity[] _entities;

        public ConsoleMenu(IFileRepository repo)
        {
            _repo = repo;
            _entities = new IEntity[0];
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Menu ===");
                Console.WriteLine("1. Add sample data");
                Console.WriteLine("2. List all");
                Console.WriteLine("3. Save to file");
                Console.WriteLine("4. Load from file");
                Console.WriteLine("5. Find by lastname");
                Console.WriteLine("6. Find by StudentID");
                Console.WriteLine("7. Delete by StudentID");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                var c = Console.ReadLine();
                switch (c)
                {
                    case "1": AddSampleData(); break;
                    case "2": ListAll(); break;
                    case "3": Save(); break;
                    case "4": Load(); break;
                    case "5": FindByLastName(); break;
                    case "6": FindByStudentId(); break;
                    case "7": DeleteByStudentId(); break;
                    case "0": return;
                    default: Console.WriteLine("Unknown"); break;
                }
            }
        }

        private void AddSampleData()
        {
            var arr = new IEntity[]
            {
                new Student("Vasia","Pupkin","KB123456",3),
                new Student("Olia","Ivanova","KB654321",2),
                new Teacher("Ivan","Ivanov","Math"),
                new Musician("John","Doe","Guitar"),
                new Student("Anna","Bond","AB000001",1),
                new Musician("Mary","Star","Piano")
            };
            _entities = arr;
            Console.WriteLine("Sample data added.");
        }

        private void ListAll()
        {
            if (_entities == null || _entities.Length == 0)
            {
                Console.WriteLine("No data loaded.");
                return;
            }
            foreach (var e in _entities) Console.WriteLine(e.ToString());
        }

        private void Save()
        {
            Console.Write("Enter path to save (e.g. data.txt): ");
            var p = Console.ReadLine();
            try
            {
                _repo.SaveEntities(p, _entities ?? new IEntity[0]);
                Console.WriteLine("Saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving: " + ex.Message);
            }
        }

        private void Load()
        {
            Console.Write("Enter path to load (e.g. data.txt): ");
            var p = Console.ReadLine();
            try
            {
                _entities = _repo.LoadEntities(p);
                Console.WriteLine($"Loaded {_entities.Length} entities.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading: " + ex.Message);
            }
        }

        private void FindByLastName()
        {
            Console.Write("LastName: ");
            var ln = Console.ReadLine();
            var found = _entities.Where(e => e.LastName.Equals(ln, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (found.Length == 0) { Console.WriteLine("None."); return; }
            foreach (var f in found) Console.WriteLine(f);
        }

        private void FindByStudentId()
        {
            Console.Write("StudentId: ");
            var id = Console.ReadLine();
            var found = _entities.Where(e => !string.IsNullOrEmpty(e.UniqueId) && e.UniqueId.Equals(id, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (found.Length == 0) { Console.WriteLine("None."); return; }
            foreach (var f in found) Console.WriteLine(f);
        }

        private void DeleteByStudentId()
        {
            Console.Write("StudentId to delete: ");
            var id = Console.ReadLine();
            var arr = _entities;
            int removed = 0;
            var temp = new List<IEntity>();
            foreach (var e in arr)
            {
                if (!string.IsNullOrEmpty(e.UniqueId) && e.UniqueId.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    removed++;
                    continue;
                }
                temp.Add(e);
            }
            _entities = temp.ToArray();
            Console.WriteLine($"Removed {removed} items.");
        }
    }
}
