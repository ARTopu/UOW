using Microsoft.AspNetCore.Mvc;
using UOW.Models;
using UOW.Repositories;

namespace UOW.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.ProductRepo.GetProducts();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, ProductName, Price, Qty")] Product product )
        {

            if(ModelState.IsValid) 
            {
                await _unitOfWork.ProductRepo.Add(product);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

    }
}
