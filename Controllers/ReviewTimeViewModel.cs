using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternTimeProject.Controllers
{
	internal class ReviewTimeViewModel
	{
		public List<Intern> Interns { get; set; }
		public SelectList Weeks { get; set; }
	}
}