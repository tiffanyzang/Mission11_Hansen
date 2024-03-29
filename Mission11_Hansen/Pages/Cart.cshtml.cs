using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission11_Hansen.Infrastructure;
using Mission11_Hansen.Models;

namespace Mission11_Hansen.Pages
{
    public class CartModel : PageModel
    {
        private IBookRepository _repo;
        public CartModel(IBookRepository temp) 
        {
            _repo = temp;
        }
        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = _repo.Books
                .FirstOrDefault(x => x.BookId == bookId);

            if (b != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(b, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage(new { returnUrl = returnUrl } );
 
        }
    }
}
