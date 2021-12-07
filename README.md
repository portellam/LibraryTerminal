# LibraryTerminal
Grand Circus C#2021-22, Week 4, OOP Project

LIBRARY TERMINAL

Write a console program which allows a user to search a library catalog and check
out books.

	● Your solution must include some kind of a book class with a title, author,
	status, and due date if checked out.

		o Status should be On Shelf or Checked Out (or other statuses you can
		imagine).
	
	● The library should offer at least 12 books, all stored in a list.

	● Allow the user to:

		o Display the entire list of books. Format it nicely.
	
		o Search for a book by author.
	
		o Search for a book by title keyword.
	
		o Select a book from the list to check out.
	
			▪ If it’s already checked out, let them know.
		
			▪ If not, check it out to them and set the due date to 2 weeks
			from today. (The DateTime class will be helpful)
					
		o Return a book. (You can decide how that looks/what questions it
		asks.)
				
Optional enhancements:
  
	● (Moderate) When the user quits, save the current library book list (including
	due dates and statuses) to the text file so the next time the program runs, it
	remembers.
			
	● (Julius Caesar) Burn down the library of Alexandria and set human Civilization
	back by a few hundred years.
