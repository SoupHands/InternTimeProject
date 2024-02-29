using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternTimeProject.Controllers
{
    [AllowAnonymous]
    public ActionResult Login(string returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        // Your login logic using SignInManager
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LogOff()
    {
        // Your logout logic using AuthenticationManager
    }

}
