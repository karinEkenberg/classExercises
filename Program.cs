/*
 Definiera klassen Land, som innehåller:
Medlemmars privata data:
• landets namn (max 30 tecken)
• namnet på huvudstaden (högst 20 tecken)
• statens yta - totalt antal invånare.
Metoder för offentliga medlemmar:
• metoder för att mata in och skriva ut uppgifter om staten. Skriv även ut befolkningstätheten vid utskrift
• den metod som bestämmer landets befolkningstäthet (antal invånare/km).
Definiera följande globala metoder:
• metoden i vilken n (n<10) givna tillstånd sorteras i stigande ordning efter befolkningstäthet;
• metoden där data skrivs om landet med lägst befolkningstäthet.
 */
namespace classExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Country[] countries = new Country[]
                       {
                new Country("Sweden", "Stockholm", 10000000),
                new Country("Norway", "Oslo", 5300000),
                new Country("Denmark", "Copenhagen", 5800000)
                       };

            // Loopa över varje land
            foreach (var country in countries)
            {
                country.addInfo();
            }

            foreach (var country in countries)
            {
                country.CalculatePopulationDensity();
            }

            // Anropa de globala metoderna med den uppdaterade informationen
            Country.SortCountryDensity(countries);
            Country.WriteAboutCountryWithLowestDensity(countries);
        }

        
    }
    class Country
    {
        private string nameOfCountry;
        private string nameOfCapitalCity;
        private int amountOfCitizens;

        public string NameOfCountry
        {
            get { return nameOfCountry; }
            set
            {
                if (value.Length <= 30)
                    nameOfCountry = value;
                else
                    Console.WriteLine("Wrong! The name of the country can at most contain 30 characters.");
            }
        }
        public string NameOfCapitalCity
        {
            get { return nameOfCapitalCity; }
            set
            {
                if (value.Length <= 20)
                    nameOfCapitalCity = value;
                else
                    Console.WriteLine("Wrong! The name of the capital city may only contain 20 characters.");
            }
        }
        public int AmountOfCitizens
        {
            get { return amountOfCitizens; }
            set
            {
                if (amountOfCitizens >= 0)
                    amountOfCitizens = value;
                else
                    Console.WriteLine("Wrong! The amount of citizens must be a non negative number.");
            }
        }
        public Country(string nameOfCountry, string nameOfCapitalCity, int amountOFCitizens)
        {
            NameOfCapitalCity = nameOfCapitalCity;
            NameOfCountry = nameOfCountry;
            AmountOfCitizens = amountOFCitizens;
        }
        public void addInfo()
        {
            bool myBool = true;
            while (myBool)
            {
                Console.WriteLine("Add countries press A for adding, press X to stop.");
                string input = Console.ReadLine().ToUpper();
                if (input == "A")
                {
                    Console.WriteLine("State the name of the country:");
                    NameOfCountry = Console.ReadLine();
                    Console.WriteLine("State the capital city of the country:");
                    NameOfCapitalCity = Console.ReadLine();
                    Console.WriteLine("State the amount of citizens in the country:");
                    int.TryParse(Console.ReadLine(), out amountOfCitizens);
                    AmountOfCitizens = amountOfCitizens;
                }
                else if (input == "X")
                {
                    myBool = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                    continue;
                }
       
            }
   
        }
        public double CalculatePopulationDensity()
        {
            double countryArea = 1000;
            return AmountOfCitizens / countryArea;
        }
        public static void SortCountryDensity(Country[] countries)
        {
            Array.Sort(countries, (a, b) =>
            {
                double tät1 = a.CalculatePopulationDensity();
                double tät2 = b.CalculatePopulationDensity();
                return tät1.CompareTo(tät2);
            });

            Console.WriteLine("Countries sorted after population density:");
            foreach (var countryy in countries)
            {
                Console.WriteLine($"{countryy.NameOfCountry}: {countryy.CalculatePopulationDensity()} citizens per km²");
            }
        }
        public static void WriteAboutCountryWithLowestDensity(Country[] countries)
        {
            Country countryWithLowestDensity = countries[0];
            foreach (var countryy in countries)
            {
                if (countryy.CalculatePopulationDensity() < countryWithLowestDensity.CalculatePopulationDensity())
                {
                    countryWithLowestDensity = countryy;
                }
            }
            Console.WriteLine($"The country with the lowest population density {countryWithLowestDensity.NameOfCountry} with {countryWithLowestDensity.CalculatePopulationDensity()} citizens per km²");
        }
    }
}
