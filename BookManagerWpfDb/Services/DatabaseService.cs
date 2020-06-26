using BookManagerWpf.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerWpf.Services
{
    class DatabaseService
    {
        private SqlConnection _sqlConnection;
        public bool Initialize()
        {
            bool retVal = false;
            string connetionString = @"Data Source=.\SqlExpress;Initial Catalog=Books;User ID=WpfApp;Password=WpfApp";

            _sqlConnection = new SqlConnection(connetionString);
            _sqlConnection.Open();
            //_sqlConnection.Close();

            return retVal;
        }

        public void ReadSomething()
        {
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output="";

            sql = "select * from Table_1";
            command = new SqlCommand(sql, _sqlConnection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output += dataReader.GetValue(0).ToString() + dataReader.GetValue(1).ToString() + "\n";
            }

            dataReader.Close();
        }

        public List<Book> ReadBooks()
        {
            List<Book> retVal = new List<Book>();

            SqlCommand command;
            SqlDataReader dataReader;

            // wir setzen voraus, dass die Tabelle Books folgende Spalten hat: Isbn(int), Title(string), AuthorFirstname(string) und AuthorLastname(string)
            command = new SqlCommand("select * from Books", _sqlConnection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Book book = new Book();

                book.Isbn = (int)dataReader.GetValue(0);
                book.Title = dataReader.GetValue(1).ToString();
                book.AuthorFirstname = dataReader.GetValue(2).ToString();
                book.AuthorLastname = dataReader.GetValue(3).ToString();

                retVal.Add(book);
            }

            dataReader.Close();

            return retVal;
        }

        public void AddBook(Book bookToAdd)
        {
            SqlCommand command;
            String sqlString;

            sqlString = "insert into Books (Isbn, Title, AuhtorFirstname, AuthorLastname) values (" + 
                bookToAdd.Isbn.ToString() + ", '" +
                bookToAdd.Title +"', '" +
                bookToAdd.AuthorFirstname + "', '" +
                bookToAdd.AuthorLastname + "')";


            command = new SqlCommand(sqlString, _sqlConnection);
            command.ExecuteNonQuery();
        }

        public void DeleteBook(int isbnToDelete)
        {
            SqlCommand command;
            String sqlString;

            sqlString = "delete Books where Isbn=" + isbnToDelete.ToString();

            command = new SqlCommand(sqlString, _sqlConnection);
            command.ExecuteNonQuery();
        }
    }
}
