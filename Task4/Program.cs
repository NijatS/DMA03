using Task4.Models;

namespace Task4
{
	internal class Program
	{
		//Task 11. Figure adında bir class yaradın. Bu classı Üçbucaq, Dördbucaq, Kvadrat adında classlar miras alsın. CalculatePerimeter metodu ilə həmin fiqurların perimetrlərini hesablayın.
		static void Main(string[] args)
		{
            Console.WriteLine("uc bucaqin terefini daxil edin");
            double uTeref= double.Parse(Console.ReadLine());
			UcBucaq ucBucaq = new UcBucaq();
			ucBucaq.SetTeref(uTeref);
			Console.WriteLine(ucBucaq.CalculatePerimeter());

			Console.WriteLine("kvadratin  terefini daxil edin");
			double kt = double.Parse(Console.ReadLine());
			Kvadrat kvadrat = new Kvadrat();
			kvadrat.SetTeref(kt);
			Console.WriteLine(kvadrat.CalculatePerimeter());

			Console.WriteLine("DordBucaq  terefini daxil edin");
			double db = double.Parse(Console.ReadLine());
			Console.WriteLine("DordBucaqin enini daxil edin");
			double dbEn = double.Parse(Console.ReadLine());
			DordBucaq DordBucaq = new DordBucaq();
			DordBucaq.SetEn(dbEn);
			DordBucaq.SetTeref(db);
			Console.WriteLine(DordBucaq.CalculatePerimeter());


		}
	}
}
