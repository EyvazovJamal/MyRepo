using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models;
public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public int Pages { get; set; }
    public string? Description { get; set; }
}
