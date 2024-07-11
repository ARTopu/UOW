using Microsoft.AspNetCore.Mvc;
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
    }
}
