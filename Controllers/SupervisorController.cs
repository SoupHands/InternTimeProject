using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternTimeProject.Controllers
{
	[Authorize(Roles ="Supervisor")]

	public class SupervisorService
	{
		private readonly ApplicationDbContext _dbContext;

		public SupervisorService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Intern> GetInterns()
		{
			// Implement logic to retrieve a list of interns from the database
			return _dbContext.Interns.ToList();
		}

		public List<DateTime> GetWeeks()
		{
			// Implement logic to retrieve a list of weeks with time entries from the database
			return _dbContext.TimeEntries.Select(te => te.WeekStartDate).Distinct().ToList();
		}

		public List<TimeEntry> GetTimeEntries(int internId, DateTime weekStartDate)
		{
			// Implement logic to retrieve time entries for a specific intern and week
			return _dbContext.TimeEntries
				.Where(te => te.InternId == internId && te.WeekStartDate == weekStartDate)
				.ToList();
		}

		public void ApproveTime(int internId, DateTime weekStartDate)
		{
			// Implement logic to mark time entries as approved for a specific intern and week
			var timeEntriesToApprove = _dbContext.TimeEntries
				.Where(te => te.InternId == internId && te.WeekStartDate == weekStartDate)
				.ToList();

			foreach (var entry in timeEntriesToApprove)
			{
				entry.IsApproved = true;
			}

			_dbContext.SaveChanges();
		}

		public Report GenerateReport(DateTime weekStartDate)
		{
			

			return new Report();
		}
	}

	public class Report
	{
	}

	[Authorize(Roles = "Supervisor")]
	public class SupervisorController : Controller
	{
		private readonly SupervisorService _supervisorService;

		public SupervisorController(SupervisorService supervisorService)
		{
			_supervisorService = supervisorService;
		}

		public ActionResult ReviewTime()
		{
			var interns = _supervisorService.GetInterns();
			var weeks = _supervisorService.GetWeeks();

			var viewModel = new ReviewTimeViewModel
			{
				Interns = interns,
				Weeks = new SelectList(weeks),
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult ApproveTime(int internId, DateTime selectedWeek)
		{
			_supervisorService.ApproveTime(internId, selectedWeek);

			return RedirectToAction("ReviewTime");
		}

		public ActionResult ViewReport(DateTime weekStartDate)
		{
			var report = _supervisorService.GenerateReport(weekStartDate);


			return View(report);
		}
	}

}
