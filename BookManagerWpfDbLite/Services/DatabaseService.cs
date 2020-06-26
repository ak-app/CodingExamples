using BookManagerWpf.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BookManagerWpf.Services
{
    class DatabaseService
    {
        string _dbConnectionString = "Data Source=database.db";

        public List<Book> ReadBooks()
        {
            List<Book> retVal = new List<Book>();
            SQLiteDataReader dataReader;

            //setup the connection to the database
            using (var dbConnection = new SQLiteConnection(_dbConnectionString))
            {
                dbConnection.Open();

                //open a new command
                SQLiteCommand command = new SQLiteCommand("select Isbn, Title, AuthorFirstname, AuthorLastname from Books;", dbConnection);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Book book = new Book();

                    book.Isbn = int.Parse(dataReader.GetValue(0).ToString());
                    book.Title = dataReader.GetValue(1).ToString();
                    book.AuthorFirstname = dataReader.GetValue(2).ToString();
                    book.AuthorLastname = dataReader.GetValue(3).ToString();

                    retVal.Add(book);
                }
            }

            return retVal;
        }

        public void AddBook(Book bookToAdd)
        {
            String sqlString;

            using (var dbConnection = new SQLiteConnection(_dbConnectionString))
            {
                dbConnection.Open();

                sqlString = String.Format("insert into Books (Isbn, Title, AuthorFirstname, AuthorLastname) values ({0}, '{1}', '{2}', '{3}');", bookToAdd.Isbn, bookToAdd.Title, bookToAdd.AuthorFirstname, bookToAdd.AuthorLastname);

                SQLiteCommand command = new SQLiteCommand(sqlString, dbConnection);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int isbnToDelete)
        {
            using (var dbConnection = new SQLiteConnection(_dbConnectionString))
            {
                dbConnection.Open();

                string sqlString = "delete from Books where Isbn=" + isbnToDelete.ToString() + ";";

                SQLiteCommand command = new SQLiteCommand(sqlString, dbConnection);
                command.ExecuteNonQuery();
            }
        }

        public void SaveBook(Book book)
        {
            String sqlString;

            using (var dbConnection = new SQLiteConnection(_dbConnectionString))
            {
                dbConnection.Open();

                // update Books set Isbn=444, Title='Vögel', AuhtorFirstname='Stefan', AuthorLastname='Vogel'
                sqlString = String.Format("update Books set Title='{1}', AuthorFirstname='{2}', AuthorLastname='{3}' where Isbn={0};", book.Isbn, book.Title, book.AuthorFirstname, book.AuthorLastname);

                SQLiteCommand command = new SQLiteCommand(sqlString, dbConnection);
                command.ExecuteNonQuery();
            }
        }
    }
}
