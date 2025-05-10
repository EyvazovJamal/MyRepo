using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using App.Models;
using App.Options;
using App.Repositories.BookRepository.Base;

namespace App.Repositories.BookRepository;

public class BookRepository : IBookRepository
{
    private readonly string connectionString;

    public BookRepository(IOptionsSnapshot<DataBaseOptions> options)
    {
        connectionString = options.Value.ConnectionString;
    }

    public async Task AddBookAsync(Book book)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            await connection.ExecuteAsync(
                @"INSERT INTO Books (Title, Author, PublishedDate, Pages, Description) 
                  VALUES (@Title, @Author, @PublishedDate, @Pages, @Description);",
                book);
        }
    }

   public async Task DeleteBookAsync(int id)
    {
    using (var connection = new SqlConnection(connectionString))
    {
        await connection.OpenAsync();

        await connection.ExecuteAsync(
            @"DELETE FROM Books WHERE Id = @Id;",
            new { Id = id });
    }
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            return await connection.QueryAsync<Book>(
                @"SELECT * FROM Books;");
        }
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            return await connection.QueryFirstOrDefaultAsync<Book>(
                @"SELECT * FROM Books WHERE Id = @Id;",
                new { Id = id });
        }
    }

    public async Task UpdateBookAsync(Book book)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            await connection.ExecuteAsync(
                @"UPDATE Books 
                  SET Title = @Title, 
                      Author = @Author, 
                      PublishedDate = @PublishedDate, 
                      Pages = @Pages, 
                      Description = @Description 
                  WHERE Id = @Id;",
                book);
        }
    }
}
