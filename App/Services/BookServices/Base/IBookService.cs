using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Services.BookServices.Base;

public interface IBookService
{
    
    Task<IEnumerable<Book>> GetAllBooksAsync(); 
    Task<Book?> GetBookByIdAsync(int id); 
    Task AddBookAsync(Book book); 
    Task UpdateBookAsync(Book book); 
    Task DeleteBookAsync(int id); 
}


