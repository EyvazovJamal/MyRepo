using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using App.Models;

namespace App.Validators;

public class BookValidator: AbstractValidator<Book>
{
    private const int titleMaxLength=70;
    private const int authorMaxLength=70;
    private const int minPages=1;
    private const int maxPages=20000;
    private const int descriptionMaxLength=5000;


    public BookValidator()
    {
        RuleFor((book)=> book.Title)
            .NotEmpty()
                .WithMessage("The title should not be empty ")
            .MaximumLength(titleMaxLength)
                .WithMessage($"The title cannot be more than {titleMaxLength} characters ");
        RuleFor(book => book.Author)
            .NotEmpty()
                .WithMessage("The author should not be empty.")
            .MaximumLength(authorMaxLength)
                .WithMessage($"The author's name cannot be more than {authorMaxLength} characters.");

        RuleFor(book => book.PublishedDate)
            .NotEmpty()
                .WithMessage("Published date is required.")
            .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("Published date cannot be in the future.");

        RuleFor(book => book.Pages)
            .InclusiveBetween(minPages, maxPages)
                .WithMessage($"Pages should be between {minPages} and {maxPages}.");

        RuleFor(book => book.Description)
            .MaximumLength(descriptionMaxLength)
                .WithMessage($"Description cannot be more than {descriptionMaxLength} characters.");
        
    }
}
