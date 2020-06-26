using System.Collections.Generic;
using BookManagerWpf.Entities;

namespace BookManagerWpf.Services
{
    /// <summary>
    /// The BooksService is a service which holds a list of books. 
    /// It contains methods to manage this list (add new book, delete existing book, change existing book...)
    /// </summary>
    public class BooksService
    {
        #region Properties

        /// <summary>
        /// This is the list with all books.
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();

        #endregion Properties


        #region Public Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public BooksService()
        {
            CreateDefaultList();
        }

        /// <summary>
        /// Save an existing book.
        /// </summary>
        /// <param name="book">The existing book, which should be saved.</param>
        /// <param name="newTitle">New title of book to save.</param>
        /// <param name="newAuthorFirstname">New fist name of author of book to save.</param>
        /// <param name="newAuthorLastname">New last name of author of book to save</param>
        /// <param name="newIsbn">New ISBN of book to save.</param>
        /// <returns>Return false, if boook was not saved, because the new ISBN already exists in list.</returns>
        public bool SaveBook(Book book, string newTitle, string newAuthorFirstname, string newAuthorLastname, int newIsbn)
        {
            bool retVal = false;

            if (Books.Contains(book) && IsIsbnInUse(book.Isbn, book) == false)
            {
                book.Title = newTitle;
                book.AuthorFirstname = newAuthorFirstname;
                book.AuthorLastname = newAuthorLastname;
                book.Isbn = newIsbn;

                retVal = true;
            }

            return retVal;
        }

        /// <summary>
        /// Delete an existing book from book list.
        /// </summary>
        /// <param name="book">The book, which should be deleted.</param>
        /// <returns></returns>
        public bool DeleteBook(Book book)
        {
            bool retVal = false;

            if (Books.Contains(book))
            {
                Books.Remove(book);

                retVal = true;
            }

            return retVal;
        }

        /// <summary>
        /// Add a new book to book list.
        /// </summary>
        /// <param name="book">The book, which should be added.</param>
        /// <returns>Returns false, if book was not added, because ISBN number already exists in list.</returns>
        public bool AddBook(Book book)
        {
            bool retVal = false;

            if (IsIsbnInUse(book.Isbn, null) == false)
            {
                Books.Add(book);
                retVal = true;
            }

            return retVal;
        }

        #endregion Public Methods


        #region Private Methods

        /// <summary>
        /// Adds some 'dummy' books to the list of books.
        /// </summary>
        private void CreateDefaultList()
        {
            Books.Add(new Book() { Title = "Buch1", AuthorFirstname = "Hans", AuthorLastname = "Erhart", Isbn = 123456 });
            Books.Add(new Book() { Title = "Buch2", AuthorFirstname = "Herman", AuthorLastname = "Hartmann", Isbn = 222444 });
            Books.Add(new Book() { Title = "Buch3", AuthorFirstname = "Susi", AuthorLastname = "Burgstaller", Isbn = 333555 });
        }

        /// <summary>
        /// Check if an ISBN number is already in list.
        /// </summary>
        /// <param name="isbnToCheck"></param>
        /// <returns>Returns true, if ISBN is already in list.</returns>
        private bool IsIsbnInUse(int isbnToCheck, Book bookToExclude)
        {
            bool retVal = false;

            foreach (Book oneBook in Books)
            {
                if (oneBook.Isbn == isbnToCheck && oneBook != bookToExclude)
                {
                    retVal = true;
                    break;
                }
            }

            return retVal;
        }

        #endregion Private Methods
    }
}
