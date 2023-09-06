using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using Microsoft.EntityFrameworkCore;
using ShoppingList.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace ShoppingList.Controllers
{
    [Authorize(AuthenticationSchemes = "AdminAuthentication")]
    public class AdminController : Controller
    {
        MyDbContext _context;
        public object PageUtility { get; private set; }

        public AdminController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product(int categoryid, string p, string categoryFilter)
        {
            var product = _context.Products
                .Select(p => new AdminAddFileViewModel()
                {
                    ProductName = p.ProductName,
                    ProductImage = p.ProductImage,
                    CategoryName = p.Category.CategoryName,
                    ProductId = p.ProductId
                })
                .ToList();
            //arama
            if (!string.IsNullOrEmpty(p))
            {
                product = product.Where(x => x.ProductName.ToLower().Contains(p.ToLower())).ToList();
            }
            //filtreleme
            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryName.ToString(),
                Text = c.CategoryName
            }).ToList();
            ViewBag.Categories = categories;
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                if (categoryFilter != "all")
                {
                    product = product.Where(x => x.CategoryName == categoryFilter).ToList();
                }
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AdminAddFileViewModel adminAddFileViewModel, IFormFile fileUpload)
        {
            if (_context.Products.Any(c => c.ProductName == adminAddFileViewModel.ProductName))
            {
                TempData["ErrorMessage"] = "Ürün zaten var";
                return RedirectToAction("AddProduct", "Admin");
            }
            var product = new Product
            {
                ProductName = adminAddFileViewModel.ProductName,
                CategoryId = adminAddFileViewModel.CategoryId
            };
            if (fileUpload != null)
            {
                var localPath = "/wwwroot/images/products/";
                var path = Path.Join(Directory.GetCurrentDirectory(), localPath, fileUpload.FileName);
                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }

                product.ProductImage = fileUpload.FileName;
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Product", "Admin");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int productId)
        {
            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

            ViewBag.Categories = categories;
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return NotFound();
            }
            var productUpdateViewModel = new AdminAddFileViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                ProductImage = product.ProductImage
            };
            return View(productUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(AdminAddFileViewModel viewModel, IFormFile fileUpload)
        {

            var product = _context.Products.FirstOrDefault(p => p.ProductId == viewModel.ProductId);
            if (product == null)
            {
                return NotFound();
            }
            if (fileUpload != null)
            {
                var localPath = "/wwwroot/images/products/";
                var path = Path.Join(Directory.GetCurrentDirectory(), localPath, fileUpload.FileName);
                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }

                product.ProductImage = fileUpload.FileName;

            }
            product.ProductName = viewModel.ProductName;
            product.CategoryId = viewModel.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("Product", "Admin");
        }
        public IActionResult DeleteProduct(AdminAddFileViewModel adminEditFileViewModel)
        {
            var productsToDelete = _context.Products.Where(p => p.ProductId == adminEditFileViewModel.ProductId).SingleOrDefault();

            if (productsToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _context.Products.Remove(productsToDelete);
                _context.SaveChanges();
                return RedirectToAction("Product", "Admin");
            }
        }
        public IActionResult Category()
        {
            var kategori = _context.Categories.ToList();
            return View(kategori);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (_context.Categories.Any(c => c.CategoryName == category.CategoryName))
            {
                TempData["ErrorMessage"] = "Kategori zaten var";
                return RedirectToAction("AddCategory", "Admin");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Category", "Admin");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            return View(category);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (_context.Categories.Any(c => c.CategoryName == category.CategoryName))
            {
                ViewData["ErrorMessage"] = "Kategori zaten var";
                return RedirectToAction("Category", "Admin");
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
            ViewData["SuccessMessage"] = "Kategori güncellendi";
            return RedirectToAction("Category", "Admin");
        }
        public IActionResult DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId); ;
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Category", "Admin");
        }
    }
}
