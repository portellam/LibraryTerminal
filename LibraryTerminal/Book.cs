using System;
using System.Collections.Generic;

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

		public bool CheckOut()
        {
			// if book is not available, return false (i.e. failure)
			if (!Status) return false;

			// if book is available invert status, return true (i.e. success)
			Status = !Status;
			return true;
        }

		public bool Return()
        {
			// if book is already on shelf, it cannot be returned, return false (i.e. failure)
			if (Status) return false;

			// if book is not on shelf, invert status and return true (i.e. success)
			Status = !Status;
			return true;
        }

		public override string ToString()
		{
			return String.Format("{0}\t{1}\t{2}\t${3}\t", Title, Author, Status, DueDate);
		}
	}
}
