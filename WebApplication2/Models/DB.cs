using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Data.SqlClient;
namespace WebApi_Practice.Models
{
    public class DB
    {
        private readonly string _connectionString;

        public DB(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddBook(Book book)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("INSERT INTO Books (Title, Author, Description) VALUES (@Title, @Author, @Description)", connection);
            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Description", book.Description);
            command.ExecuteNonQuery();
        }

        public void AddBookUsingProcedure(Book book)
        {
            var connection =new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("Exec AddNewBook @Title=@Title1, @Author=@Auth, @Description=@Desc", connection);
            command.Parameters.AddWithValue("@Title1", book.Title);
            command.Parameters.AddWithValue("@Auth", book.Author);
            command.Parameters.AddWithValue("@Desc", book.Description);
            command.ExecuteNonQuery();

        }

        public void DeleteBook(int id)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("Delete From Books Where Id = @id", connection);
            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();
        }
        public void DeleteBookUsingProcedure(int id)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("Exec DeleteBook @Id = @id", connection);
            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();
        }

        public List<Book> GetBooks()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("Select * From Books", connection);
            var reader = command.ExecuteReader();
            List<Book> book = new();

            while(reader.Read())
            {
                Book nbook = new Book(reader.GetInt32(0),reader.GetString(1),reader.GetString(3),reader.GetString(2));
                book.Add(nbook);
            }

            return book;

        }

        public List<Book> GetBooksUsingProcedure()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("Exec GetAllBooks", connection);
            var reader = command.ExecuteReader();
            List<Book> book = new();

            while (reader.Read())
            {
                Book nbook = new Book(reader.GetInt32(0), reader.GetString(1), reader.GetString(3), reader.GetString(2));
                book.Add(nbook);
            }

            return book;
        }

    }

}
