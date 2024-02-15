using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using System.Net;

namespace Dice_Roller_0._1.Pages
{

    public class CC1Model : PageModel
    {

        public void OnGet()
        {

            Cookie charCookie = new Cookie("charCookie", "_str:12,_dex:15,_con:14,_int:10,_wis:9,_cha:11,_name:Bob,_race:elf,_class:fighter,_maxHP:12,_currHP:8,_bg:soldier,_al:LG,_size:medium");
            //Cookie goober = new Cookie("newCookie", Request.Cookies["charCookie"]);
            Response.Cookies.Append("charCookie", charCookie.Value);
            ViewData["charBob"] = Request.Cookies["charCookie"];

            //Console.WriteLine(Request.Cookies["charCookie"]);

            ViewData["IsPost"] = false;
        }

        public void OnPost()
        {
            ViewData["IsPost"] = true;
        }

        //race(human), class(bard), ...abilities(1,2,3,4,...)
    }
}
