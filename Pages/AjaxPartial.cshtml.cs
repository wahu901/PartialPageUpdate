using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PartialPageUpdate.Models;
using PartialPageUpdate.Services;

namespace PartialPageUpdate
{
    public class AjaxPartialModel : PageModel
    {
        private CarService _carService;
        public AjaxPartialModel(CarService carService)
        {
            _carService = carService;
        }

        public List<Car> Cars { get; set; }
        public void OnGet()
        {
            //Cars = _carService.GetAll();
            Cars = new List<Car>();
        }

        
        public void OnPostCarPartial1()
        {
            Cars = _carService.GetAll();
        }

        public PartialViewResult OnGetCarPartial2()
        {
            Cars = _carService.GetAll();
            return Partial("_CarPartial2", Cars);
        }

        public JsonResult OnGetCarPartial3()
        {
            Cars = _carService.GetAll();
            return new JsonResult(Cars);
        }


    }
}