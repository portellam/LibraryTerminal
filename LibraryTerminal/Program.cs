using System;
using System.Collections.Generic;

namespace LibraryTerminal
{
	class Book
	{
		public string Title;
		public string Author;
		public bool Status;
		public int DueDate;
		public static List<Book> BookList = new List<Book>();

		public Book(string title, string author, bool status, int dueDate)
		{
			Title = title;
			Author = author;
			Status = status;
			DueDate = dueDate;
		}

		public string BookStatus(bool status)
		{
			if (status == true)
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

	}

	class Program
	{
		//Display the entire list of books. Format it nicely.


		//
		//Search for a book by author.



		//Search for a book by title keyword.



		//Select a book from the list to check out.


		//	-If it’s already checked out, let them know.


		//	-If not, check it out to them and set the due date to 2 weeks from today. (The DateTime class will be helpful)


		//Return a book.

		static void Main(string[] args)
		{

			List<Book> BookList = new List<Book>();
			Book.BookList.Add(new Book ("Green Eggs and Ham", "Dr. Seuss", true, 0));   // Green Eggs is on the shelf
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
			//harry potter
			//art of war
			//

		}
	}
}

//test, this from branch alex