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

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var product = await _unitOfWork.ProductRepo.GetProductById(id);
            if (product == null)
            {
                return View();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Id, ProductName, Price, Qty")] Product product)
        {
            if (id != product.Id)
            {
                return View();
            }
            if (ModelState.IsValid) 
            {
                await _unitOfWork.ProductRepo.Update(product);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(product);

        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var product = await _unitOfWork.ProductRepo.GetProductById(id);
            if (product == null)
            {
                return View();
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var product = await _unitOfWork.ProductRepo.GetProductById(id);
            if (product == null)
            {
                return View();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id, ProductName, Price, Qty")] Product product)
        {
            if (id != product.Id)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                await _unitOfWork.ProductRepo.Delete(id);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(product);

        }


    }
}
