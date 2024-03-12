namespace LibraryProject
{
    class Library
    {
        static List<Book> library;
        static List<User> users;
        public static void Main(string[] args)
        {
            PopulateLibrary();
            users = new List<User>(); 
            users.Add(new User(1, "Bassel Adel", "+645312085"));
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Search by Keyword");
                Console.WriteLine("2. All The Books");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. User Info");
                Console.WriteLine("5. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Enter a keyword to search for:");
                        string keyword = Console.ReadLine();
                        SearchFor(keyword);
                        PromptBorrow(users[0]);
                        break;
                    }
                    case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("We Currently Have:");
                        foreach (var book in library)
                        {
                            Console.WriteLine(book.Index + " " + book.Title);
                        }
                        PromptBorrow(users[0]);
                        break;
                    }
                    case 3:
                    {
                        Console.Clear();
                        Console.Clear();
                        users[0].Info();
                        Console.WriteLine("Type the index of the book you want to return:");
                        int r = int.Parse(Console.ReadLine()) - 1;
                        users[0].Returned(library[r]);
                        break;
                    }
                    case 4:
                    {
                        Console.Clear();
                        users[0].Info();
                        Console.WriteLine();
                        break;
                    }
                    case 5:
                    {
                        exit = true;
                        break;
                    } 
                    default: 
                        Console.Clear();
                        Console.WriteLine("Your number was out of range\nPlease type a number from 1 to 5");
                        break;
                }
            }
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Thank You!");
        }

        public static void PromptBorrow(User u)
        {
            Console.WriteLine("Would you like to borrow any of those? (y/n)");
            string r = Console.ReadLine();
            if (r == "y" || r == "Y")
            {
                Console.WriteLine("Type the index of the book you want:");
                int want = int.Parse(Console.ReadLine()) - 1;
                u.SetBorrowedBook(library[want]);
            }
            Console.Clear();
        }
        public static void SearchFor(string keyword)
        {
            Console.Clear();
            List<Book> result = library.Where(book => book.Title.Contains(keyword)).ToList();
            Console.WriteLine("Search Results for \"" + keyword + "\":");
            if (result.Count == 0)
            {
                Console.WriteLine("No matching books found.");
            }
            else
            {
                foreach (Book book in result)
                {
                    Console.WriteLine(book.Index + " " + book.Title);
                }
            }
        }
        public static void PopulateLibrary()
        {
            library = new List<Book>();

            string[] lines = File.ReadAllLines("E:\\C sharp Projects\\Sol1\\LibraryProject\\books.txt");
            int i = 0;
            foreach (string line in lines)
            {
                i++;
                library.Add(new Book(line, i));
            }
        }
    }
}