using System.Collections;
using LibraryManagement;

public class Program
{
    static public void Main(String[] args)
    {
        string adminum = "920391021239";
        LibraryItem libraryItem = new LibraryItem(adminum);
        Console.WriteLine("Welcome to LibraryManagement System");
        

        libraryItem.BookAdded += libraryItem.notification.SendNotification;
        libraryItem.BookRemoved += libraryItem.notification.SendNotification;
        libraryItem.BookUpdated += libraryItem.notification.SendNotification;

        while(true)
        {
            Console.WriteLine("1. Adding Book\n2. Display\n3. Removing Book\n4. Searching Book\n5. Updating Book\n6. Exit");
            int option;
            try { option = Convert.ToInt32(Console.ReadLine()); }
            catch (FormatException) { Console.WriteLine("Invalid input.Enter a valid input."); continue; }
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter the Book Details:(Title, Author, ID) ");
                    string title = Console.ReadLine();
                    string author = Console.ReadLine();
                    string iD = Console.ReadLine();

                    Book b1 = new Book(title, iD, author)
                    {
                        Title = title,
                        Author = author,
                        ID = iD,
                    };

                    libraryItem.AddBook(b1);
                    b1.show();

                    Library library = new Library(title, iD, author);
                    libraryItem.AddItem(library); // Add the library item
                    Console.WriteLine("The Book Added Successfully!");
                    break;

                case 2:
                    libraryItem.ListItems(); // List all items in the library
                    break;

                case 3:
                    Console.WriteLine("Enter the Title of the Removing Book:");
                    string ti = Console.ReadLine();
                    Book removingBook = libraryItem.SearchByTitle(ti);
                    if (removingBook == null)
                    {
                        Console.WriteLine("Book Not found!..");
                    }
                    else
                    {
                        libraryItem.RemoveBook(removingBook);
                        Library removingLibraryItem = libraryItem.SearchLibraryByTitle(ti);
                        if (removingLibraryItem != null)
                        {
                            libraryItem.RemoveItem(removingLibraryItem);
                        }
                        Console.WriteLine("The Book is removed!");
                    }
                    break;

                case 4:
                    int s;
                    Console.WriteLine("Search for Book By 1. Title\n2. Author\n3. ID");
                    try
                    {
                        s = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException) { Console.WriteLine("Invalid input.Enter a valid input."); continue; }
                    Book searchedBook = null;
                    switch (s)
                    {
                        case 1:
                            Console.WriteLine("Enter the Title of the Book");
                            string tit = Console.ReadLine();
                            searchedBook = libraryItem.SearchByTitle(tit);
                            break;
                        case 2:
                            Console.WriteLine("Enter the Author of the Book");
                            string auth = Console.ReadLine();
                            searchedBook = libraryItem.SearchByAuthor(auth);
                            break;
                        case 3:
                            Console.WriteLine("Enter the ID of the Book");
                            string id_s = Console.ReadLine();
                            searchedBook = libraryItem.SearchByID(id_s);
                            break;
                        default:
                            Console.WriteLine("Enter a Valid option.");
                            break;
                    }
                    if (searchedBook != null)
                    {
                        Console.WriteLine("Book Found!...");
                        searchedBook.show();
                    }
                    else
                    {
                        Console.WriteLine("Book Not Found!.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Enter the Title of the Book to be updated");
                    string updatetitle = Console.ReadLine();
                    Book updatebook = libraryItem.SearchByTitle(updatetitle);
                    if (updatebook == null) Console.WriteLine("Book not found");
                    else
                    {
                        Console.WriteLine("Enter the updated Title:");
                        string updatedtitle = Console.ReadLine();
                        Console.WriteLine("Enter the Updated Author name:");
                        string updatedauthor = Console.ReadLine();
                        Console.WriteLine("Enter the Updated ID of the Book:");
                        string updatedid = Console.ReadLine();
                        libraryItem.updateBook(updatebook, updatedtitle, updatedauthor, updatedid);
                        Library updateLibraryItem = libraryItem.SearchLibraryByTitle(updatetitle);
                        if (updateLibraryItem != null)
                        {
                            libraryItem.UpdateLibrary(updateLibraryItem, updatedtitle, updatedauthor, updatedid);
                        }
                        Console.WriteLine("The Book is Updated!");
                    }

                    break;

                case 6:
                    Console.WriteLine("Exiting the System!");
                    return;

                default:
                    Console.WriteLine("Enter a Valid Choice!");
                    break;
            }
        }
    }
}
