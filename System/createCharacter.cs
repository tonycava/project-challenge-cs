namespace Project_CS.System
{
    public class CreateCharacter
    {
        public static void SetupCharacter()
        {
            Hero newHero = new Hero();
            Console.WriteLine("Please enter your character name:");
            newHero.HeroName = Console.ReadLine();

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
                        newHero.HeroClass = "Warrior";
                        availableOptionChosen = true;
                        break;
                    case "2":
                        newHero.HeroClass = "Mage";
                        availableOptionChosen = true;
                        break;
                    case "3":
                        newHero.HeroClass = "Rogue";
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
    class Character
    {
        protected int CharacterMaxHealth;
        protected int CharacterStrength;
        protected int CharacterIntelligence;
        protected int CharacterAgility;
        protected int CharacterStamina;
    }

    class Hero : Character
    {
        public string HeroName;
        public string HeroClass;
        private int Level, Experience, Gold;

        public static void ClassSelect(Hero newHero)
        {
            newHero.CharacterStrength = 10;
            newHero.CharacterAgility = 10;
            newHero.CharacterIntelligence = 10;
            newHero.CharacterMaxHealth = 100;
            newHero.CharacterStamina = 100;
            newHero.Level = 1;
            newHero.Experience = 0;
            newHero.Gold = 0;
           

            switch (newHero.HeroClass)
            {
                case "Warrior":
                    newHero.CharacterMaxHealth = newHero.CharacterMaxHealth * 115 / 100;
                    newHero.CharacterStrength = newHero.CharacterStrength * 200 / 100;
                    break;
                case "Mage":
                    newHero.CharacterIntelligence = newHero.CharacterIntelligence * 160 / 100;
                    break;
                case "Rogue":
                    newHero.CharacterAgility = newHero.CharacterAgility * 110 / 100;
                    break;
            }

            Console.WriteLine($"Your name is {newHero.HeroName}");
            Console.WriteLine($"Your class is {newHero.HeroClass}");
            Console.WriteLine($"Your Level is {newHero.Level}");
            Console.WriteLine($"Your Experience is {newHero.Experience}");
            Console.WriteLine($"Your Gold is {newHero.Gold}");
            Console.WriteLine($"Your Health is {newHero.CharacterMaxHealth}");
            Console.WriteLine($"Your Strength is {newHero.CharacterStrength}");
            Console.WriteLine($"Your Intelligence is {newHero.CharacterIntelligence}");
            Console.WriteLine($"Your Agility is {newHero.CharacterAgility}");
            Console.WriteLine($"Your Stamina is {newHero.CharacterStamina}");
        }
    }
}
