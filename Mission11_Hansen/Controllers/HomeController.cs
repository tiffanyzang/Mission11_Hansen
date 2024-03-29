using Microsoft.AspNetCore.Mvc;
using Mission11_Hansen.Models;
using Mission11_Hansen.Models.ViewModels;


//using Mission11_Hansen.Models;
using System.Diagnostics;

namespace Mission11_Hansen.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum, string? bookType)
        {
            var pageSize = 10;

            var bookData = new BooksListViewModel
            {
                Books = _repo.Books
                    .Where(x => x.Category == bookType || bookType == null)
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = bookType == null ? _repo.Books.Count() : _repo.Books.Where(x => x.Category == bookType).Count()
                },

                CurrentBookType = bookType

            };

            return View(bookData);
        }

    }
}
