namespace App.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Logging;
using App.Models;
using App.Services.BookServices;
using App.Services.BookServices.Base;

[Route("[controller]")]
public class BookController : Controller
{


    private readonly IBookService bookService;
    private readonly IValidator<Book> bookValidator;

    public BookController(IBookService bookService,IValidator<Book> bookValidator)
    {
        this.bookService=bookService;
        this.bookValidator=bookValidator;
    }
    
    [HttpGet("Create")]
    public ActionResult Create(){
        if(TempData.TryGetValue("validation_errors", out object? validationErrorsObject)) 
        {
            if(validationErrorsObject is string validationErrorsJson) 
            {
                var validationErrors = JsonSerializer.Deserialize<IEnumerable<ValidationErrorItem>>(validationErrorsJson);

                ViewData["validation_errors"] = validationErrors;
            }
        }
        return base.View();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(Book book)
    {
        var validationResult=await bookValidator.ValidateAsync(book);
        if (validationResult.IsValid==false)
        {
            TempData["validation_errors"]=JsonSerializer.Serialize(validationResult.Errors.Select(error=>{
                return new ValidationErrorItem{
                    Message=error.ErrorMessage,
                    Property=error.PropertyName
                };
            }));
            return RedirectToAction("Create");
        }
        
        await bookService.AddBookAsync(book);
        return RedirectToAction("AllBooks");
        
    }

    [HttpGet("AllBooks")]
    public async Task<ActionResult> AllBooks()
    {
        var books = await bookService.GetAllBooksAsync();
        return View(books);
    }

    [HttpPost("Delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        
        await bookService.DeleteBookAsync(id);

       
        return RedirectToAction("AllBooks");
    }


    
    [HttpGet("Edit/{id}")]
    public async Task<ActionResult> Edit(int id)
    {
        var book = await bookService.GetBookByIdAsync(id);
        
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost("Edit/{id}")]
    public async Task<ActionResult> Edit(int id, Book updatedBook)
    {
        if (id != updatedBook.Id)
        {
            return BadRequest();
        }

        await bookService.UpdateBookAsync(updatedBook);
        return RedirectToAction("AllBooks");
    }




}
