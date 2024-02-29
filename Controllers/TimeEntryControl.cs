using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternTimeProject.Controllers
{
    public class TimeEntryController : Controller
    {
        private object timeEntryService;

        [Authorize(Roles = "Intern")]
        public ActionResult EnterTime()
        {
            // Display the page to enter time
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Intern")]
        public ActionResult EnterTime(TimeEntryViewModel model)
        {
            timeEntryService.EnterTime(model);

            // Redirect to a success page or display a confirmation message
            return RedirectToAction("EnterTime");
        }
    }

}
