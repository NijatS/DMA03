namespace Task1
{
	public  class Program
	{
		public static void Main(string[] args)
		{
			Person person = new Person();
			try
			{
				person.SetId(6);
				Console.WriteLine(person.GetId());

				person.SetName( "  " );
				Console.WriteLine(person.GetName());

			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}




        }
	}
}
