using Task2.ENtities;

namespace Task2
{
	internal class Program
	{

		//Task 8. Vehicle adlı sinif yaradın və bu sinfə modifier kimi protected status adinda field əlavə edin. Bus, Motorcycle, Truck adlı classlar bu sinfdən miras alsın və ekrana statuslarını ("Working","Damaged","Under repair") çıxarın.
		static void Main(string[] args)
		{
            Console.WriteLine("Please enter status of your bus:");
            string argb = Console.ReadLine();
            Console.WriteLine("Please enter status of your motocysle:");
            string argm = Console.ReadLine();
            Console.WriteLine("Please enter status of your truck:");
            string argt = Console.ReadLine();
			Bus bus1 = new Bus();
			bus1.SetStatus(argb);

			Motocycle motocycle1 = new Motocycle();
			motocycle1.SetStatus(argm);

			Truck truck = new Truck();
			truck.SetStatus(argt);

            Console.WriteLine($"Bus status is {bus1.GetStatus()}");
            Console.WriteLine($"Motocycle status is {motocycle1.GetStatus()}");
            Console.WriteLine($"Truck status is {truck.GetStatus()}");
        }
	}
}
