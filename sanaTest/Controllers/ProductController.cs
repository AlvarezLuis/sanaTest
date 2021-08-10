using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sanaTest.DTOs;
using sanaTest.Models;
using sanaTest.Services.Interfaces;

namespace sanaTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(
            IProductService productService, 
            IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        public async Task<IActionResult> List()
        {
            string useDataInmemory = HttpContext.Session.GetString("useDataInmemory");
            if (string.IsNullOrEmpty(useDataInmemory))
            {
                useDataInmemory = "false";
                HttpContext.Session.SetString("useDataInmemory", useDataInmemory);
            }
            var producList = await productService.GetAll(Boolean.Parse(useDataInmemory));
            var result = producList.Select(x => mapper.Map<ProductDTO>(x)).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var product = mapper.Map<Product>(productDTO);
                string useDataInmemory = HttpContext.Session.GetString("useDataInmemory");                
                await productService.Add(product, Boolean.Parse(useDataInmemory));
                return RedirectToAction("List");
            }
            return View(productDTO);
        }


        [HttpPost]
        public JsonResult SetSession(string useDataInmemory)
        {
            HttpContext.Session.SetString("useDataInmemory", useDataInmemory);

            dynamic result = new System.Dynamic.ExpandoObject();
            result.useDataInmemory = HttpContext.Session.GetString("useDataInmemory");
            return Json(result);
        }
    }
}
