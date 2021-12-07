using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryTerminal
{
	public class Book
	{
		public static List<Book> BookList = new List<Book>();

		public string Title;
		public string Author;
		public bool Status;
		public DateTime DueDate;

		/* CONSTRUCTORS */
		public Book(string title, string author, bool status, DateTime dueDate)
		{
			Title = title;
			Author = author;
			Status = status;
			DueDate = dueDate;
		}

		/* MEMBER METHODS */
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

		public bool ReturnBook()
		{
			// if book is already on shelf, it cannot be returned, return false (i.e. failure)
			if (Status) return false;

			// if book is not on shelf, invert status and return true (i.e. success)
			Status = !Status;
			return true;
		}

		public bool CheckOutBook()
		{
			// if book is not available, return false (i.e. failure)
			if (!Status) return false;

			// if book is available invert status, return true (i.e. success)
			Status = !Status;
			DueDate = DateTime.Today.AddDays(14);
			return true;
		}

		/* OVERRIDES */
		public override string ToString()
		{
			return String.Format("{0,-40} {1,-35} {2,-15} {3,-11}", Title, Author, BookStatus(), Status ? "N/A" : DueDate.ToString("d"));
		}

		/* STATIC BOOK METHODS */
		public static Book SearchAuthor(string input)
		{
			foreach (Book book in BookList)
			{
				if (book.Author.Contains(input))
				{
					Console.WriteLine("Here's your book: \n");
					return book;
				}
			}
			return null;
		}

		public static Book SearchTitle(string input)
		{
			foreach (Book book in BookList)
			{
				if (book.Title.Contains(input))
				{
					Console.WriteLine("Here's your book: \n");
					return book;
				}
			}
			return null;
		}

		// list all books in BookList
		public static string ListBooks()
		{
			string output = "";
            Console.WriteLine(String.Format("\n{0,-40} {1,-35} {2,-15} {3,-11}", "Title", "Author", "Status", "Due Date"));
            Console.WriteLine("{0,-40} {1,-35} {2,-15} {3,-11}", "=====", "======", "======", "========");
            for (int index = 0; index < BookList.Count; index++)
			{
				Book aBook = BookList[index];
				output += aBook.ToString() + "\n";
			}
			return output;
		}

		// moved to Book as a static method for initializing BookList from a file
		public static bool ReadFile()
		{
			// input is unecessary here since we are not looping
			string /*input,*/ line;

			//no need to ask user if they want to read from a file inside ReadFile()
			//Console.WriteLine("Do you wish to read the Library Inventory from file? (Y)es or (N)o:\t");
			/*while (true)
			{
			input = Console.ReadLine();
			input = input.ToUpper().Substring(0);
			if (input == "Y")
			{*/
			// we just need try..catch since we are not looping inside of ReadFile()

			// get file name from user
			Console.Write("Enter filename: ");
			string path = Console.ReadLine();

			try
			{
				if (BookList.Count > 0) BookList.Clear();

				//	Read from file
				StreamReader sr = new StreamReader(path);
				//	Continue to read until you reach end of file
				//	Read the first line of text
				while ((line = sr.ReadLine()) != null)
				{
					//	TODO: implement write to file, each quality of class Book in BookList
					string[] info = line.Split(',');
					Book aBook = new Book(info[0], info[1], bool.Parse(info[2]), DateTime.Parse(info[3]));
					//	add aBook to BookList
					Book.BookList.Add(aBook);
				}
				//	close the file
				sr.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}

			return true;
			/*}
			else if (input == "N")
			{
				return;
			}
			else
			{
				Console.WriteLine("(Y)es or (N)o:\t");
			}*/
		}

		// moved to Book as a static method for saving BookList to a file
		public static void WriteFile()
		{
			//	TODO: ask user if they wish to write to file
			//string input;

			// line below is unecessary as we can ask the user if they want to save to a file before we call WriteFile()
			//Console.WriteLine("Do you wish to read the Library Inventory from file? (Y)es or (N)o:\t");
			/*while (true)
			{*/
			//input = Console.ReadLine();
			//input = input.ToUpper().Substring(0);
			/*if (input == "Y")
			{
			*/
			// we just need the try catch block since we are not looping inside of WriteFile

			// get file name from user
			Console.Write("Enter filename: ");
			string path = Console.ReadLine();

			try
			{
				if (BookList.Count <= 0) throw new Exception("Cannot save an empty list of books...");

				// using path parameter to control what the file is called and where it should be saved
				StreamWriter sw = new StreamWriter(path);
				//	Write BookList to file 
				for (int index = 0; index < BookList.Count; index++)
				{
					Book aBook = BookList[index];
					//	write aBook to next line
					sw.WriteLine($"{aBook.Title},{aBook.Author},{aBook.Status},{aBook.DueDate.ToString("d")}");
				}
				//	Close the file
				sw.Close();
			}
			catch (Exception ex)
			{
				// updated error ouput message
				Console.WriteLine($"Error writing to file: {ex.Message} (Path: {path})");
			}
			/*
			}
			
			else if (input == "N")
			{
				return;
			}
			else
			{
				Console.WriteLine("(Y)es or (N)o:\t");
			}*/
		}
	}

}
