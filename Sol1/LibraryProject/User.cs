using System.Linq;

namespace LibraryProject
{
    public class User
    {
        public int ID;
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public List<Book> BorrowedBook;
        public List<Book> BorrowedHistory;

        public User(int id, string name, string phone)
        {
            ID = id;
            Name = name;
            PhoneNum = phone;
            BorrowedBook = new List<Book>();
            BorrowedHistory = new List<Book>();
        }
        
        public void SetBorrowedBook(Book book)
        {
            BorrowedBook.Add(book);
            BorrowedHistory.Add(book);
        }

        public void Returned(Book book)
        {
            BorrowedBook.Remove(book);
        }

        public void Info()
        {
            Console.WriteLine("CURRENTLY BORROWING:");
            foreach (var book in BorrowedBook)
            {
                Console.WriteLine(book.Index + " " + book.Title);
            }
            Console.WriteLine();
            Console.WriteLine("BORROWING HISTORY:");
            foreach (var book in BorrowedHistory)
            {
                Console.WriteLine(book.Index + " " + book.Title);
            }
        }
    }
}
