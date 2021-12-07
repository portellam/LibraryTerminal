using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryTerminal
{
	public class Book
	{
		// static booklist to hold all books
		public static List<Book> BookList = new List<Book>();

		// book member variables
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

		// return specific book
		public bool ReturnBook()
		{
			// if book is already on shelf, it cannot be returned, return false (i.e. failure)
			if (Status) return false;

			// if book is not on shelf, invert status and return true (i.e. success)
			Status = !Status;
			return true;
		}

		// check out specific book
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
		// search by author
		public static Book SearchAuthor(string input)
		{
			foreach (Book book in BookList)
			{
				if (book.Author.ToLower().Contains(input.ToLower()))
				{
					Console.WriteLine("\nHere's your book:");
					return book;
				}
			}
			return null;
		}
		
		// search by title
		public static Book SearchTitle(string input)
		{
			foreach (Book book in BookList)
			{
				if (book.Title.ToLower().Contains(input.ToLower()))
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
		public static void ReadFile()
		{
			// get file name from user
			Console.Write("Enter filename: ");
			string path = Console.ReadLine();

			try
			{
				// clear booklist to avoid duplicates, etc
				if (BookList.Count > 0) BookList.Clear();

				// initialized streamreader to reading from file
				StreamReader sr = new StreamReader(path);
				// variable to capure line from file
				string line;
				//	Continue to read until you reach end of file
				while ((line = sr.ReadLine()) != null)
				{
					// split line into delimited elements
					string[] info = line.Split(',');
					// create a new book
					Book aBook = new Book(info[0], info[1], bool.Parse(info[2]), DateTime.Parse(info[3]));
					//	add aBook to BookList
					Book.BookList.Add(aBook);
				}
				//	close the file
				sr.Close();
			}
			catch (Exception ex)
			{
				// updated error ouput message
				Console.WriteLine($"Error reading from file: {ex.Message} (Path: {path})");
			}
		}

		// moved to Book as a static method for saving BookList to a file
		public static void WriteFile()
		{
			// get file name from user
			Console.Write("Enter filename: ");
			string path = Console.ReadLine();

			try
			{
				// if booklist is empty, throw exception to let user know they can't save an empty list
				if (BookList.Count <= 0) throw new Exception("Cannot save an empty list of books...");

				// initialized streamwriter to write to file
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
		}
	}

}
