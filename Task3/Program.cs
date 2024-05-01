using Task3.Models;

namespace Task3
{
	internal class Program
	{
		//Task 9. Parametrli constructor-dan istifadə edərək rombun sahəsini tapın. Romb adında class olmalıdır. Tərəf və hündürlük adında private field istifadə edilsin. (Rombun sahesi S=a*h ilə təyin edilir).
		static void Main(string[] args)
		{
			try
			{
				double side = double.Parse(Console.ReadLine());
				double height = double.Parse(Console.ReadLine());

				Romb romb = new Romb(side, height);
				Console.WriteLine($"Rombun sahesi: {romb.CalculateArea()}");

			} catch(Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
	}
}
