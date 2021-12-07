using System;
using System.Collections.Generic;
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
			return $"{Title}\t{Author}\t{BookStatus()}\t{DueDate}\t";
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

	}
}
