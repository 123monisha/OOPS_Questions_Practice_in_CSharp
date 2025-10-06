using System;
using System.Collections.Generic;

namespace OOPS_Questions_Practice_in_CSharp
{
    interface IBorrowable
    {
        void Borrow(Member member);
        void Return(Member member);
    }
    class Book : IBorrowable
    {
        public string Title;
        public string Author;
        public string ISBN;
        public bool IsBorrowed = false;

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public void Borrow(Member member)
        {
            if (!IsBorrowed && member.BorrowedBooks.Count < 3) // max 3 books per member
            {
                IsBorrowed = true;
                member.BorrowedBooks.Add(this);
                Console.WriteLine($"{member.Name} borrowed '{Title}'");
            }
            else if (IsBorrowed)
            {
                Console.WriteLine($"Sorry! '{Title}' is already borrowed.");
            }
            else
            {
                Console.WriteLine($"{member.Name} cannot borrow more than 3 books.");
            }
        }

        public void Return(Member member)
        {
            if (member.BorrowedBooks.Contains(this))
            {
                IsBorrowed = false;
                member.BorrowedBooks.Remove(this);
                Console.WriteLine($"{member.Name} returned '{Title}'");
            }
            else
            {
                Console.WriteLine($"{member.Name} did not borrow '{Title}'");
            }
        }
    }

    class Member
    {
        public string Name;
        public List<Book> BorrowedBooks = new List<Book>();

        public Member(string name)
        {
            Name = name;
        }
    }

    class Librarian
    {
        public string Name;
        public List<Book> LibraryBooks = new List<Book>();

        public Librarian(string name)
        {
            Name = name;
        }

        public void AddBook(Book book)
        {
            LibraryBooks.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to the library.");
        }
    }

    // Loan class
    class Loan
    {
        public Book LoanedBook;
        public Member Borrower;
        public DateTime LoanDate;
        public DateTime DueDate;

        public Loan(Book book, Member member, DateTime loanDate, DateTime dueDate)
        {
            LoanedBook = book;
            Borrower = member;
            LoanDate = loanDate;
            DueDate = dueDate;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Librarian librarian = new Librarian("Emma");

            // Create books
            Book book1 = new Book("C# Basics", "John Doe", "ISBN001");
            Book book2 = new Book("Data Structures", "Alice Brown", "ISBN002");
            Book book3 = new Book("Learn ASP.NET", "Jane Smith", "ISBN003");

            // Add books to library
            librarian.AddBook(book1);
            librarian.AddBook(book2);
            librarian.AddBook(book3);

            // Create members
            Member member1 = new Member("Monisha");
            Member member2 = new Member("Raj");

            // Borrow books
            book1.Borrow(member1);  // Monisha borrowed 'C# Basics'
            book2.Borrow(member1);  // Monisha borrowed 'Data Structures'
            book3.Borrow(member1);  // Monisha borrowed 'Learn ASP.NET'
            book1.Borrow(member2);  // Already borrowed
            book2.Borrow(member2);  // Already borrowed
            book3.Borrow(member2);  // Max books reached for Monisha

            // Return books
            book1.Return(member1);  // Monisha returned 'C# Basics'
            book1.Borrow(member2);  // Now Raj can borrow 'C# Basics'
        }
    }
}