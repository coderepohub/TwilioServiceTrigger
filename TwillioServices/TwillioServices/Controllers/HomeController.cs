using System.Collections.Generic;
using System.Web.Mvc;

namespace TwillioServices.Controllers
{
    public class HomeController : Controller
    {
     
        /// <summary>
        /// Default Action Called while application loads
        /// A simple Dashboard to Update and view the Plans based on days and hour
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Creating a List which contains Days as Text and Value to be displayed in dropdown
            var daysList = new List<SelectListItem>
            {
                new SelectListItem{Text="MONDAY",Value="MONDAY"},
                new SelectListItem{Text="TUESDAY",Value="TUESDAY"},
                new SelectListItem{Text="WEDNESDAY",Value="WEDNESDAY"},
                new SelectListItem{Text="THURSDAY",Value="THURSDAY"},
                new SelectListItem{Text="FRIDAY",Value="FRIDAY"},
                new SelectListItem{Text="SATURDAY",Value="SATURDAY"},
            };

            //Creating a List which contains hours in a day to be displayed in dropdown
            var hourList = new List<SelectListItem>
            {
                new SelectListItem{Text="08",Value="08"},
                new SelectListItem{Text="09",Value="09"},
                new SelectListItem{Text="10",Value="10"},
                new SelectListItem{Text="11",Value="11"},
                new SelectListItem{Text="12",Value="12"},
                new SelectListItem{Text="13",Value="13"},
                new SelectListItem{Text="14",Value="14"},
                new SelectListItem{Text="15",Value="15"},
                new SelectListItem{Text="16",Value="16"},
                new SelectListItem{Text="17",Value="17"},
                new SelectListItem{Text="18",Value="18"},
                new SelectListItem{Text="19",Value="19"},
                new SelectListItem{Text="20",Value="20"},
                new SelectListItem{Text="21",Value="21"},
                new SelectListItem{Text="22",Value="22"}
            };

            //Storing both the data in View to be retrieved from View(Page)
            ViewData["listOfDays"] = daysList;
            ViewData["listOfHours"] = hourList;
            return View();
        }
    }
}
