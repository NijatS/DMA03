using System;
using System.Collections;
using System.Collections.Specialized;
using static System.Formats.Asn1.AsnWriter;
using System.Xml;

namespace Collections
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region ArrayList
			//ArrayList numbers = new ArrayList();
			//numbers.Add(1);
			//numbers.Add(25);
			//numbers.Add(3);
			//numbers.Add(78);
			//numbers.Add(-5);
			//numbers.Add(3);
			//numbers.Add(-5);
			//numbers.Add(3);


			//foreach (int item in numbers)
			//{
			//             Console.WriteLine(item);
			//         }

			//numbers.Remove(3);
			//numbers.RemoveAt(3);

			//numbers.RemoveRange(3,2);


			// numbers.Sort();
			//numbers.Reverse();

			//List<int> numbers2 = new List<int>();
			//numbers2.Add(1);
			//numbers2.Add(25);
			//numbers2.Add(3);

			//numbers.Insert(3, 56);
			//numbers.InsertRange(3, new ArrayList() { 1, 5, 7, 68 });
			//numbers.InsertRange(3, numbers2);

			//numbers.AddRange(numbers2);
			//var result = numbers.Contains(-5);
			// Console.WriteLine(result);

			//var result = numbers.IndexOf(-7);
			//var result = numbers.IndexOf(3,3);
			//var result = numbers.LastIndexOf(3);

			//Console.WriteLine(result);

			//         foreach (var item in numbers)
			//{
			//	Console.WriteLine(item);
			//}
			#endregion

			#region List

			List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, };

			//Console.WriteLine(numbers.Count);


			List<Person> people = new List<Person>();

			people.Add(new Person() { Id = 1, Name = "Person 1", Age = 30 });
			people.Add(new Person() { Id = 2, Name = "Person 2", Age = 32 });
			people.Add(new Person() { Id = 3, Name = "Person 3", Age = 30 });
			people.Add(new Person() { Id = 4, Name = "Person 4", Age = 32 });
			people.Add(new Person() { Id = 5, Name = "Person 5", Age = 30 });

			//Person? findedPerson = people.FirstOrDefault(p => p.Id == 4);
			//if(findedPerson is not null)
			//{
			//             Console.WriteLine(findedPerson.Name);
			//         }

			// var findedPersons = 	people.Where(p=> p.Age == 32).ToList();
			//foreach(var person in findedPersons)
			//{
			//	Console.WriteLine(person.Name);
			//}

			//Console.WriteLine(people[^2].Name);
			#endregion

			#region SortedList


			Dictionary<string, string> persons = new Dictionary<string, string>();


			persons.Add("ab", "Person1");

			persons.Add("A", "Person2");
			persons.Add("C", "Person3");
			persons.Add("a", "Person4");
			persons.Add("k", "Person5");






			//foreach (var person in persons)
			//{
			//             Console.WriteLine(person.Value);
			//         }


			//if (persons.ContainsKey("a"))
			//{
			//	persons.Remove("k");
			//         }


			//if (persons.ContainsKey("k"))
			//	persons["k"]= "Changed Person";

			//foreach (var person in persons)
			//{
			//	Console.WriteLine(person.Value);
			//}

			#endregion
			#region Stack Queue

			//Stack<int> ints = new Stack<int>();

			//ints.Push(1);
			//ints.Push(2);
			//ints.Push(3);
			//ints.Push(4);

			//while(ints.Count > 0)
			//{
			//             Console.WriteLine(ints.Pop());
			//         }
			//Console.WriteLine(ints.Peek());


			//Stack ints2 = new Stack();

			//ints2.Push(5);
			//ints2.Push("abc");

			//while( ints2.Count > 0 )
			//             Console.WriteLine(ints2.Pop());



			//Queue<int> queue = new Queue<int>();

			//queue.Enqueue(5);
			//queue.Enqueue(6);
			//queue.Enqueue(11);
			//queue.Enqueue(-5);
			//queue.Enqueue(4);

			//while(queue.Count > 0)
			//             Console.WriteLine(queue.Dequeue());


			//Queue queue2 = new Queue();

			//queue2.Enqueue(5);
			//queue2.Enqueue("a");


			//ListDictionary listDictionary = new ListDictionary();

			//listDictionary.Add(1, 5);
			//listDictionary.Add(-1, "a");

			//LinkedList<int> listLinkedList = new LinkedList<int>();
			//listLinkedList.AddFirst(5);
			//listLinkedList.AddFirst(6);
			//listLinkedList.AddLast(11);


			//foreach (var item in listLinkedList)
			//{
			//             Console.WriteLine(item);
			//         }

			#endregion
			#region HasTable

			//Hashtable hashtable = new Hashtable();

			//HashSet<int> hasSet = new HashSet<int>();

			//hashtable.Add(1,5);
			//hashtable.Add(2,"a");
			//hashtable.Add(3,"b");
			//hashtable.Add(4,"c");


			//foreach (DictionaryEntry i in hashtable)
			//           Console.WriteLine(i.Value);
			#endregion
			#region Task

			//Create a console application that reads a sentence from the user, tokenizes it into words, and then counts the frequency of each unique word using a Dictionary< string, int>.Follow these steps:
			//1.Ask the user to enter a sentence. 
			// 2.Tokenize the sentence into words(ignoring punctuation and case sensitivity). 
			// 3.Use a Dictionary<string, int> to store each unique word as a key and its frequency as the corresponding value.
			// 4.Display the list of unique words along with their frequencies in alphabetical order. 
			//  For example, if the user enters the sentence: “The quick brown fox jumps over the lazy dog”, your program should output something like this: Word Frequency: 
			//------------------
			// brown: 1
			//dog: 1
			//fox: 1
			//jumps: 1
			//lazy: 1
			//over: 1
			//quick: 1
			//the: 2

			Console.WriteLine("Cumle daxil edin:");
			string sentence = Console.ReadLine();
			List<string> words = sentence.Trim().Split(' ', '.', ',').ToList();
			IDictionary<string, int> wordscount = new Dictionary<string, int>();
			foreach (string word in words)
			{
				if (string.IsNullOrWhiteSpace(word))
					continue;
				if (wordscount.ContainsKey(word.ToLower()))
				{
					wordscount[word]++;
				}
				else
				{
					wordscount.Add(word.ToLower(), 1);
				}
			}

			foreach (KeyValuePair<string, int> word in wordscount)
			{
				Console.WriteLine(word.Key + ":" + word.Value);
			}
			#endregion



		}
	}
}
