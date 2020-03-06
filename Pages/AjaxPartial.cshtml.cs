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
            Cars = _carService.GetAll();
        }

        
        public PartialViewResult OnGetCarPartial()
        {
            Cars = _carService.GetAll();
            return Partial("_CarPartial", Cars);
        }


      
    }
}