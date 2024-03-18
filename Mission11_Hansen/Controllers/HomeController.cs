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

        public IActionResult Index(int pageNum)
        {
            var pageSize = 10;

            var bookData = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum-1) *pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count(),
                }


            };

            return View(bookData);
        }

    }
}
