using BLL;
using BOL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private IProductBs objProductBs;
        private IManufacturerBs objManufacturerBs;
        public ProductController(IProductBs _objProductBs, IManufacturerBs _objManufacturerBs)
        {
            objProductBs = _objProductBs;
            objManufacturerBs = _objManufacturerBs;
        }
        public IActionResult Index()
        {
            var list = objProductBs.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            Products obj = new Products();

            ViewBag.ManufacturerList = new SelectList(objManufacturerBs.GetAll(), "ManufacturerId", "Name");

            if (id > 0)
            {
                obj = objProductBs.GetById(id);
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult CreateOrEdit(Products model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ProductId > 0) //update
                    {
                        objProductBs.Update(model);
                    }
                    else //insert
                    {
                        objProductBs.Insert(model);
                    }
                    TempData["SuccessMsg"] = "Record saved successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                //log
                TempData["ErrorMsg"] = "Error: " + ex.Message;
                return RedirectToAction(nameof(CreateOrEdit));
            }

        }
    }
}
