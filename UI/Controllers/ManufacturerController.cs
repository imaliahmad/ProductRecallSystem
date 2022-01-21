using BLL;
using BOL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class ManufacturerController : Controller
    {
        private IManufacturerBs objManufacturerBs;
        public ManufacturerController(IManufacturerBs _objManufacturerBs)
        {
            objManufacturerBs = _objManufacturerBs;
        }
        public IActionResult Index()
        {
            var list = objManufacturerBs.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            Manufactureres obj = new Manufactureres();



            
            if (id > 0)
            {
                obj = objManufacturerBs.GetById(id);
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult CreateOrEdit(Manufactureres model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ManufacturerId > 0) //update
                    {
                        objManufacturerBs.Update(model);
                    }
                    else //insert
                    {
                        objManufacturerBs.Insert(model);
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
