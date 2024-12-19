using System.ComponentModel.DataAnnotations;

namespace AnimalManager.Domain.Entities
{
    public class Animal : BaseEntity
    {
        public string Name { get; private set; }
        public string Species { get; private set; }
        public int Age { get; private set; }

        public Animal(string name, string species, int age)
        {
            Validate(name, species, age);
            Name = name;
            Species = species;
            Age = age;
        }

        public void Update(string name, string species, int age)
        {
            Validate(name, species, age);

            Name = name;
            Species = species;
            Age = age;
            UpdateTimestamp();
        }

        private static void Validate(string name, string species, int age)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
            if (string.IsNullOrWhiteSpace(species)) throw new ArgumentException("Species cannot be empty.");
            if (age <= 0) throw new ArgumentException("Age must be greater than zero.");
        }
    }
}
