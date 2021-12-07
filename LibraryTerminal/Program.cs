using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryTerminal
{
/*
	class Book
	{
		public static List<Book> BookList = new List<Book>();

		public string Title;
		public string Author;
		public bool Status;
		public int DueDate;


		public Book(string title, string author, bool status, int dueDate)
		{
			Title = title;
			Author = author;
			Status = status;
			DueDate = dueDate;
		}

		public string BookStatus()
		{
			if (Status)
			{
				return "On Shelf";
			}
			else
			{
				return "Checked Out";
			}

		}

		public override string ToString()
		{
			return String.Format("{0}\t{1}\t{2}\t{3}\t", Title, Author, Status, DueDate);
		}

		public static string ListBook()
		{
			string output = "";
			Console.WriteLine($"#\tTITLE\tAUTHOR\tSTATUS\tDUE DATE (days)");

			for (int index = 0; index < BookList.Count; index++)
			{
				Book aBook = BookList[index];
				output += index + 1 + "\t" + aBook.ToString() + "\n";
			}
			return output;
		}
*/

	}
	class Program
	{
		
		//Search for a book by title keyword.
		
		//Search for a book by author.
		//TODO:	implement search by methods and ask user if they wish to return a checked out book and vice versa
		//Select a book from the list to check out.

		//	-If it’s already checked out, let them know.

		//	-If not, check it out to them and set the due date to 2 weeks from today. (The DateTime class will be helpful)

		//Return a book.
    
		static bool ContinueProgram()
		{
			string input;

			Console.WriteLine("Continue? (Y)es or (N)o:\t");

			while (true)
			{
				input = Console.ReadLine();
				input = input.ToUpper().Substring(0);
				if (input == "Y")
				{
					return true;
				}
				else if (input == "N")
				{
					return false;
				}
				else
				{
					Console.WriteLine("(Y)es or (N)o:\t");
				}
			}
		}

		static void ReadFile(List<Book> BookList)
		{
			string input, line;
			//ask user to read from file
			Console.WriteLine("Do you wish to read the Library Inventory from file? (Y)es or (N)o:\t");
			while (true)
			{
				input = Console.ReadLine();
				input = input.ToUpper().Substring(0);
				if (input == "Y")
				{
					try
					{
						//Read from file
						StreamReader sr = new StreamReader("BookList.txt");

						//Continue to read until you reach end of file
						//Read the first line of text
						while ((line = sr.ReadLine()) != null)
						{
							//TODO: implement write to file, each quality of class Book in BookList
							string[] info = line.Split('\t');
							Book aBook = new Book(info[0], info[1], bool.Parse(info[2]), int.Parse(info[3]));
							//add aBook to BookList
							Book.BookList.Add(aBook);
							//Read the next line
							line = sr.ReadLine();
						}
						//close the file
						sr.Close();
						Console.ReadLine();
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
				else if (input == "N")
				{
					return;
				}
				else
				{
					Console.WriteLine("(Y)es or (N)o:\t");
				}
			}
		}

		static void WriteFile(List<Book> BookList)
		{
			//TODO: ask user if they wish to write to file
			string input;

			Console.WriteLine("Do you wish to read the Library Inventory from file? (Y)es or (N)o:\t");
			while (true)
			{
				input = Console.ReadLine();
				input = input.ToUpper().Substring(0);
				if (input == "Y")
				{
					try
					{
						//Create or update file
						StreamWriter sw = new StreamWriter("BookList.txt");
						//Write BookList to file 
						for (int index = 0; index < BookList.Count; index++)
						{
							Book aBook = BookList[index];
							//write aBook to next line
							sw.WriteLine(aBook.ToString());
						}
						//Close the file
						sw.Close();
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
				else if (input == "N")
				{
					return;
				}
				else
				{
					Console.WriteLine("(Y)es or (N)o:\t");
				}
			}
    }

		static void Main(string[] args)
		{
  		//TODO: implement to read/write from/to text file, to save BookList for later runs
			//	read from text file
			ReadFile(BookList);
  
			//
			Book.BookList.Add(new Book("Green Eggs and Ham", "Dr. Seuss", true, 0));   // Green Eggs is on the shelf
			Book.BookList.Add(new Book("The Art of War", "Sun Tzu", true, 0));
			Book.BookList.Add(new Book("Queenie", "Candice Carty-Williams", false, 14));
			Book.BookList.Add(new Book("The 48 Laws of Power", "Robert Greene", false, 12));
			Book.BookList.Add(new Book("The Alchemist", "Paulo Coelho", true, 0));
			Book.BookList.Add(new Book("Honey Girl", "Morgan Rogers", false, 6));
			Book.BookList.Add(new Book("A History of Central Banking", "Stephen Mittford Goodson", false, 7));
			Book.BookList.Add(new Book("Children of Blood and Bone", "Tomi Adeyemi", true, 0));
			Book.BookList.Add(new Book("The Hate U Give", "Angie Thomas", true, 0));
			Book.BookList.Add(new Book("Twilight", "Stephenie Meyer", false, 2));
			Book.BookList.Add(new Book("To Kill a Mockingbird", "Harper Lee", true, 0));
			Book.BookList.Add(new Book("Leading with My Chin", "Jay Leno", false, 9));

      //TODO: implement main loop
			//	main code here
			do
			{
			//	begin code here
        
			Book book = Book.SearchAuthor("foobar");
			if (book != null) Console.WriteLine(book);
			else Console.WriteLine("No authors found");
        
      //	end code here
			} while (ContinueProgram() == true);
			//	
      //TODO: implement write to text file, contents of BookList
			//	read from text file
		  WriteFile(BookList);
			//
			//	end program here
			}
		}
	}
}