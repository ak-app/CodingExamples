
namespace BookManagerWpf.Entities
{
    /// <summary>
    /// A simple book.
    /// A book has a title, a ISBN and more.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// ISBN number of book
        /// </summary>
        public int Isbn { get; set; }
        /// <summary>
        /// Title of the book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// First name of book author
        /// </summary>
        public string AuthorFirstname { get; set; }

        /// <summary>
        /// Last name of book author
        /// </summary>
        public string AuthorLastname { get; set; }
    }

}
