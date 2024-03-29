using Microsoft.AspNetCore.Mvc;

namespace Mission11_Hansen.Components
{
    public class BookTypesViewComponent: ViewComponent
    {
        private Models.IBookRepository _bookRepo;

        public BookTypesViewComponent(Models.IBookRepository temp)
        {
            _bookRepo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedBookType = RouteData?.Values["bookType"];
            
            var bookTypes = _bookRepo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(bookTypes);
        }
    }
}
