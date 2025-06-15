using System.ComponentModel;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class LibraryItem
    {
        private List<Book> Books;
        private List<Library> library;
        public HashSet<string> book_titles;

        public event Action<string> BookAdded;
        public event Action<string> BookRemoved;
        public event Action<string> BookUpdated;

        public Notification notification;



        public LibraryItem(string admin_num)
        {
            Books = new List<Book>();
            book_titles = new HashSet<string>();
            library = new List<Library>();
            notification = new Notification(admin_num);
        }

        public void AddBook(Book item)
        {
            Books.Add(item);
            book_titles.Add(item.Title);
            BookAdded?.Invoke($"The Book {item.Title} is Added!");
        }

        public void RemoveBook(Book item)
        {
            Books.Remove(item);
            book_titles.Remove(item.Title);
            BookRemoved?.Invoke($"The Book {item.Title} is removed!");
        }

        public void AddItem(Library item) => library.Add(item);

        public void RemoveItem(Library item) => library.Remove(item);


        public Book SearchByTitle(string title)
        {
            return Books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public Book SearchByAuthor(string author)
        {
            return Books.Find(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }

        public Book SearchByID(string id)
        {
            return Books.Find(book => book.ID.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public Library SearchLibraryByTitle(string title)
        {
            return library.Find(lib => lib.Title_inLib.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void ListItems()
        {
            Console.WriteLine("Library_Detailed_List:");
            Console.WriteLine("...................................................................................................................");
            foreach (var item in library)
            {
                item.Lib_Details();
            }
            Console.WriteLine("...................................................................................................................");

        }
        public void updateBook(Book book, string upt, string upa, string upi)
        {
            book.Title = upt;
            book.Author = upa;
            book.ID = upi;
            BookUpdated?.Invoke($"The Book {book.Title} is Updated!");
        }

        public void UpdateLibrary(Library lib, string newTitle, string auth, string newID)
        {
            lib.Title_inLib = newTitle;
            lib.author_inlib = auth;
            lib.ID_inLib = newID;
        }
    }
}