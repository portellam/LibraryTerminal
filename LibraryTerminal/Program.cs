using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryTerminal
{
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
			Console.Write("\nContinue? (Y)es or (N)o: ");
			while (true)
			{
				input = Console.ReadLine().ToUpper();

				if (input.Substring(0) == "Y")
				{
					return true;
				}
				else if (input.Substring(0) == "N")
				{
					return false;
				}
				else
				{
					Console.Write("(Y)es or (N)o: ");
				}
			}
		}

		// function to determine what to search books by
		// we don't need BookList in the parameters because we don't use it
		static Book AuthorOrTitle(/*List<Book> BookList*/)
		{
			string input;

			// updated prompt to be a little cleaner
			Console.Write("Do you wish to Search by Author or Title? (A/T): ");
			while (true)
			{
				/*input = Console.ReadLine();
				input = input.ToUpper().Substring(0);*/
				// can do all of the above on one line
				input = Console.ReadLine().ToUpper().Substring(0);

				if (input.Substring(0) == "A")
				{
					//ask user for input
					Console.Write("Enter Author: ");
					input = Console.ReadLine();
					// get book
					/*Book aBook = Book.SearchAuthor(input);
					return aBook;*/
					// can do all of the above on one line
					return Book.SearchAuthor(input);
				}
				else if (input.Substring(0) == "T")
				{
					//ask user for input
					Console.Write("Enter Title: ");
					input = Console.ReadLine();
					// get book
					/*Book aBook = Book.SearchTitle(input);
					return aBook;*/
					// can do all of the above on one line
					return Book.SearchTitle(input);
				}
				else
				{
					Console.WriteLine("Search by (A)uthor, or (T)itle ?");
				}
			}
		}

		static void PrintMenu()
        {
			Console.WriteLine("\nLibrary Menu Options: \n" +
				"\t1. Print all books\n" +
				"\t2. Search for a book\n" +
				"\t3. Load book list from a file\n" +
				"\t4. Save book list to a file\n");
        }

		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the Grand Circus Library!");
			/*//	ask user to read from file
			ReadFile(Book.BookList);*/

			// flag to keep track of whether we read from a file and if it was successful
			//bool readFile = false;
			/*Console.Write("Would you like to load booklist from a file? (y/n) (default = n): ");
			// read key pressed from user
			if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
				readFile = Book.ReadFile("BookList.txt");
            }*/

			/*// initialize list only if ReadFile was unsuccessful or if user did not opt to read file
			if (!readFile)
			{
			*/// initialize book list here if we are not reading from a file
			DateTime today = DateTime.Today;

			Book.BookList.Add(new Book("Green Eggs and Ham", "Dr. Seuss", true, today));
			Book.BookList.Add(new Book("The Art of War", "Sun Tzu", true, today));
			Book.BookList.Add(new Book("Queenie", "Candice Carty-Williams", false, today.AddDays(14)));
			Book.BookList.Add(new Book("The 48 Laws of Power", "Robert Greene", false, today.AddDays(14)));
			Book.BookList.Add(new Book("The Alchemist", "Paulo Coelho", true, today));
			Book.BookList.Add(new Book("Honey Girl", "Morgan Rogers", false, today.AddDays(14)));
			Book.BookList.Add(new Book("A History of Central Banking", "Stephen Mittford Goodson", false, today.AddDays(14)));
			Book.BookList.Add(new Book("Children of Blood and Bone", "Tomi Adeyemi", true, today));
			Book.BookList.Add(new Book("The Hate U Give", "Angie Thomas", true, today));
			Book.BookList.Add(new Book("Twilight", "Stephenie Meyer", false, today.AddDays(14)));
			Book.BookList.Add(new Book("To Kill a Mockingbird", "Harper Lee", true, today));
			Book.BookList.Add(new Book("Leading with My Chin", "Jay Leno", false, today.AddDays(14)));
			/*}*/

			//	loop main code here
			do
			{
				// variable to capture user input 
				string input;
				// variable to capture option from user
				int opt;

				// main menu loop
				do
				{
					// print menu
					PrintMenu();
					Console.Write("Please select an option from the menu above: ");
					input = Console.ReadLine();

					// get menu option from user
					if (!int.TryParse(input, out opt))
					{
						Console.WriteLine($"Invalid input: {input}");
						continue;
					}
					else if (opt < 1 || opt > 4)
					{
						Console.WriteLine($"Invalid option: {opt}");
						continue;
					}

					break;
				} while (true);	


				switch(opt)
                {
					case 1:
						Console.WriteLine(Book.ListBooks());
						break;
					case 2:
						Book book = AuthorOrTitle();
						if (book != null)
						{
							Console.WriteLine(book);
							Console.Write("Would you like to check out the book? (y/n): ");
							input = Console.ReadLine().ToLower();

							if (input == "y" || input == "yes")
                            {
								if (book.CheckOutBook())
								{
									Console.WriteLine($"You've successfully checked out {book.Title} by {book.Author}");
								}
								else
                                {
									Console.WriteLine($"You cannot check out {book.Title} because it is not available...");
                                }
                            }
						}
						else
						{
							Console.WriteLine("Could not find a book matching your query...");
						}
						
						break;
					case 3:
						Book.ReadFile();
						break;
					case 4:
						Book.WriteFile();
						break;
                }

				

				/*Book aBook = AuthorOrTitle();
				if (aBook != null)
				{
					Console.WriteLine(aBook);
				}
				else
				{
					Console.WriteLine("Book not found.");
				}*/
			}
			// do not need to add == true here, ContinueProgram returns a boolean
			while (ContinueProgram()/* == true*/);

			//	ask user to save to file
			/*WriteFile(Book.BookList);*/
			//	end program here
		}
	}
}
