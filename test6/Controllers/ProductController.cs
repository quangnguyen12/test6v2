using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using test6.Models;

namespace test6.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL productDAL = new ProductDAL();
        public IActionResult Index()
        {
            List<ProductInfo> prolist = new List<ProductInfo>();
            prolist = productDAL.GetAllProduct().ToList();
            return View(prolist);
        }
        [HttpGet]
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ProductInfo objpro)
        {
            if (ModelState.IsValid)
            {
                productDAL.AddProduct(objpro);
                return RedirectToAction("Index");
            }
            return View(objpro);
        }
       
        public IActionResult Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductInfo pro = productDAL.GetproductbyID(id);
            if(pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,[Bind] ProductInfo objPro)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                productDAL.updateproduct(objPro);
                return RedirectToAction("Index");
            }
            return View(productDAL);
        }
        [HttpGet]
        public IActionResult Details (int? id)
        {
            if (id== null)
            {
                return NotFound();

            }
            ProductInfo pro = productDAL.GetproductbyID(id);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductInfo pro = productDAL.GetproductbyID(id);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(int? id)
        {
            productDAL.deleteproduct(id);
            return RedirectToAction("Index");
        }

    }
}
