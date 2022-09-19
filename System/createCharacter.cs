namespace Game.Engine
{
    public class CreateCharacter
    {
        public static void SetupCharacter()
        {
            Hero newHero = new Hero();

            Console.WriteLine("Now choose your character's class");
            Console.WriteLine("Warrior......1");
            Console.WriteLine("Mage........2");
            Console.WriteLine("Rogue........3");

            string classChosen = Console.ReadLine();
            bool availableOptionChosen = false;
            while (availableOptionChosen == false)
            {
                switch (classChosen)
                {
                    case "1":
                        newHero.Class = "Warrior";
                        availableOptionChosen = true;
                        break;
                    case "2":
                        newHero.Class = "Mage";
                        availableOptionChosen = true;
                        break;
                    case "3":
                        newHero.Class = "Rogue";
                        availableOptionChosen = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a correct value.");
                        break;
                }

                if (!availableOptionChosen)
                    classChosen = Console.ReadLine();
                else break;
            }

            Hero.ClassSelect(newHero);
        }
    }

    interface IHero
    {
        int MaxHealth { get; set; }
        int Strength { get; set; }
        int Intelligence { get; set; }
        int Agility { get; set; }
        int Stamina { get; set; }
    }

    class Hero : IHero
    {
        public string Class;
        private int Level, Experience, Gold;
        public int MaxHealth { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Stamina { get; set; }

        public static void ClassSelect(Hero newHero)
        {
            newHero.Strength = 10;
            newHero.Agility = 10;
            newHero.Intelligence = 10;
            newHero.MaxHealth = 100;
            newHero.Stamina = 100;
            newHero.Level = 1;
            newHero.Experience = 0;
            newHero.Gold = 0;
           

            switch (newHero.Class)
            {
                case "Warrior":
                    newHero.MaxHealth = newHero.MaxHealth * 115 / 100;
                    newHero.Strength = newHero.Strength * 200 / 100;
                    break;
                case "Mage":
                    newHero.MaxHealth = newHero.MaxHealth * 20 / 1000;
                    newHero.Intelligence = newHero.Intelligence * 160 / 100;
                    break;
                case "Rogue":
                    newHero.Agility = newHero.Agility * 110 / 100;
                    break;
            }
            
            Console.WriteLine($"Your class is {newHero.Class}");
            Console.WriteLine($"Your Level is {newHero.Level}");
            Console.WriteLine($"Your Experience is {newHero.Experience}");
            Console.WriteLine($"Your Gold is {newHero.Gold}");
            Console.WriteLine($"Your Health is {newHero.MaxHealth}");
            Console.WriteLine($"Your Strength is {newHero.Strength}");
            Console.WriteLine($"Your Intelligence is {newHero.Intelligence}");
            Console.WriteLine($"Your Agility is {newHero.Agility}");
            Console.WriteLine($"Your Stamina is {newHero.Stamina}");
        }
    }
}
