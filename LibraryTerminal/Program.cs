using System;

namespace LibraryTerminal
{
	class Program
	{
		// function to control main loop
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
		static Book AuthorOrTitle()
		{
			string input;

			// updated prompt to be a little cleaner
			Console.Write("Do you wish to Search by Author or Title? (A/T): ");
			while (true)
			{
				// get input form user
				input = Console.ReadLine().ToUpper();

				if (input.Substring(0) == "A")
				{
					//ask user for input
					Console.Write("Enter Author: ");
					input = Console.ReadLine();
					// get and return book
					return Book.SearchAuthor(input);
				}
				else if (input.Substring(0) == "T")
				{
					//ask user for input
					Console.Write("Enter Title: ");
					input = Console.ReadLine();
					// get and return book
					return Book.SearchTitle(input);
				}
				else
				{
					Console.WriteLine("Search by (A)uthor, or (T)itle ?");
				}
			}
		}

		// print menu function
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

			// initialize book list here
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

				// act based on option selected
				switch(opt)
                {
					// print all books
					case 1:
						Console.WriteLine(Book.ListBooks());
						break;
					// search by author or title
					case 2:
						Book book = AuthorOrTitle();

						// only do something if a book was found
						if (book != null)
						{
							Console.WriteLine(String.Format("{0,-40} {1,-35} {2,-15} {3,-11}", "Title", "Author", "Status", "Due Date"));
							Console.WriteLine("{0,-40} {1,-35} {2,-15} {3,-11}", "=====", "======", "======", "========");
							Console.WriteLine(book);

							if (book.Status) Console.Write("\nWould you like to check out the book? (y/n): ");
							else Console.Write("\nWould you like to return the book? (y/n): ");

							input = Console.ReadLine().ToLower();

							if (input == "y" || input == "yes")
							{
								if (book.Status)
								{
									if (book.CheckOutBook()) Console.WriteLine($"You've successfully checked out {book.Title} by {book.Author}.");
								}
								else
								{
									if (book.ReturnBook()) Console.WriteLine($"You've successfully returned {book.Title} by {book.Author}.");
								}
							}
						}
						// othwerwise let the user know nothing matched the query
						else
						{
							Console.WriteLine("Could not find a book matching your query...");
						}
						break;
					case 3:
						// read booklist from a file
						Book.ReadFile();
						break;
					case 4:
						// write booklist to a file
						Book.WriteFile();
						break;
                }

			} while (ContinueProgram());

		}
	}
}
