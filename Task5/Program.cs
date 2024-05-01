namespace Task5
{
	internal class Program
	{
		//Task 10. Bir bankda müştəri məlumatlarını saxlayan Customer sinifi yaradın. Bu sinifdə ad, soyad, şəxsiyyət vəsiqəsinin nömrəsi və əlaqə məlumatları kimi müştəri məlumatlarını saxlayan private dəyişənlər olsun. Bu dəyişənləri encapsulation metodu ilə public edərək ekrana çıxarın.
		static void Main(string[] args)
		{
			Customer customer = new Customer();
			customer.Name = "     ";
			customer.Surname = "Dadashov";
			customer.Pin = "7777aaa";
			customer.Email = "Email";

            Console.WriteLine(customer.Name+".....");
        }
	}
}
