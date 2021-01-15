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

        [BindProperty]
        public List<Car> Cars { get; set; }
        public void OnGet()
        {
            //Cars = _carService.GetAll();
            Console.WriteLine("on get");
            Cars = new List<Car>();
            //Cars.Add(_carService.newCar2());

        }


 

        public PartialViewResult OnGetCarPartial1()
        {
            Cars = _carService.GetAll();
            return Partial("_CarPartial_View", Cars);
        }

        public PartialViewResult OnPostCarPartial2()
        {
            Console.WriteLine("On Post");
            Cars = _carService.GetAll();
            return Partial("_CarPartial_View", Cars);
        }


        public PartialViewResult OnGetCarPartial3()
        {
            if (Cars == null)
            {
                Console.WriteLine("Null Car List");
                Cars = new List<Car>();
            }
            else
            {
                Console.WriteLine("Not Null Car List");
            }
            Cars.Add(new Car());
            return Partial("_CarPartial_Edit", Cars);
        }


        public PartialViewResult OnPostCarPartial4()
        {
            Cars.Add(new Car());
            return Partial("_CarPartial_Edit", Cars);
        }


    }
}