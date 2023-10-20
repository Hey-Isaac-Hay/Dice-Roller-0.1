using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dice_Roller_0._1.Pages
{

    public class CC1Model : PageModel
    {

        public void OnGet()
        {
            CookieOptions ClassCookie = new CookieOptions();
            ClassCookie.IsEssential = true;
            ClassCookie.Path = "/";
            HttpContext.Response.Cookies.Append("CharacterCookie", "A Value Goes Here", ClassCookie);

        }

        //race(human), class(bard), ...abilities(1,2,3,4,5)
        public void OnPostGetCookie()
        {
            ViewData["testCookie"] = Request.Cookies["CharacterCookie"];
            Console.Write("GET COOKIE RAN");
        }
        public void OnPostSubmitPt1()
        {
            
        }
    }
}
