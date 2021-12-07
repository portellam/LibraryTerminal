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
			return String.Format("{0}\t{1}\t{2}\t${3}\t", Title, Author, Status, DueDate);
		}

		public static Book SearchAuthor(string input)
		{
			foreach (Book book in BookList)
			{
				if (input == book.Author)
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
				if (input == book.Title)
				{
					Console.WriteLine("Here's your book: \n");
					return book;
				}
			}
			return null;
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

		public bool Return()
		{
			// if book is already on shelf, it cannot be returned, return false (i.e. failure)
			if (Status) return false;

			// if book is not on shelf, invert status and return true (i.e. success)
			Status = !Status;
			return true;
		}

		public bool CheckOut()
		{
			// if book is not available, return false (i.e. failure)
			if (!Status) return false;

			// if book is available invert status, return true (i.e. success)
			Status = !Status;
			return true;
		}

	}
}
