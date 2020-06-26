using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BookManagerWpf.Services;
using BookManagerWpf.Entities;

namespace BookManagerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Fields

        private BooksService _booksService = new BooksService();

        #endregion Private Fields


        #region Properties

        public List<Book> Books { get; set; }

        #endregion Properties


        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            _booksService.Initialize();

            Books = _booksService.Books;

            // set data context, so we can bind to this object (MainWindow)
            DataContext = this;
        }

        private void Bookslist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // get the selected Book
            Book selectedBook = uiBookslist.SelectedValue as Book;

            // if a book is selected
            if (selectedBook != null)
            {
                // fill text boxes with values of the selected book
                uiTextTitle.Text = selectedBook.Title;
                uiTextAuthorFirstname.Text = selectedBook.AuthorFirstname;
                uiTextAuthorLastname.Text = selectedBook.AuthorLastname;
                uiTextIsbn.Text = selectedBook.Isbn.ToString();
            }
        }

        private void BtnClick_Save(object sender, RoutedEventArgs e)
        {
            // get the selected Book
            Book selectedBook = uiBookslist.SelectedValue as Book;

            if (ValidateInputs())
            {
                if (_booksService.SaveBook(selectedBook, uiTextTitle.Text, uiTextAuthorFirstname.Text, uiTextAuthorLastname.Text, int.Parse(uiTextIsbn.Text)) == false)
                {
                    MessageBox.Show("Error: The book was not saved, ISBN number already exists in list.");
                }

                CollectionViewSource.GetDefaultView(uiBookslist.ItemsSource).Refresh();
            }
        }

        private void BtnClick_Delete(object sender, RoutedEventArgs e)
        {
            // get the selected Book
            Book selectedBook = uiBookslist.SelectedValue as Book;

            _booksService.DeleteBook(selectedBook);

            CollectionViewSource.GetDefaultView(uiBookslist.ItemsSource).Refresh();
        }

        private void BtnClick_Add(object sender, RoutedEventArgs e)
        {
            // get the selected Book
            Book newBook = new Book();

            if (ValidateInputs())
            {
                newBook.Title = uiTextTitle.Text;
                newBook.AuthorFirstname = uiTextAuthorFirstname.Text;
                newBook.AuthorLastname = uiTextAuthorLastname.Text;
                newBook.Isbn = int.Parse(uiTextIsbn.Text);

                if (_booksService.AddBook(newBook) == false)
                {
                    MessageBox.Show("Error: The book was not added, ISBN number already exists in list.");
                }

                CollectionViewSource.GetDefaultView(uiBookslist.ItemsSource).Refresh();
            }
        }

        /// <summary>
        /// ValidateInputs check all possible input fields, if their values are correct.
        /// </summary>
        /// <returns>Returns true, if all input fields are correct.</returns>
        private bool ValidateInputs()
        {
            bool retVal = false;
            int intValue;

            if (int.TryParse(uiTextIsbn.Text, out intValue) == false)
            {
                MessageBox.Show("Error: ISBN " + uiTextIsbn.Text + " cannot be converted to a number!");
            }
            else if (uiTextTitle.Text == string.Empty)
            {
                MessageBox.Show("Error: The title must not be empty.");
            }
            else if (uiTextAuthorFirstname.Text == string.Empty)
            {
                MessageBox.Show("Error: The first name of the author must not be empty.");
            }
            else if (uiTextAuthorLastname.Text == string.Empty)
            {
                MessageBox.Show("Error: The last name of the author must not be empty.");
            }
            else
            {
                retVal = true;
            }

            return retVal;
        }
    }
}
