using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Dice_Roller_0._1.Pages
{

    public class CC1Model : PageModel
    {

        public void OnGet()
        {
            CookieOptions charCookie = new CookieOptions();
            charCookie.IsEssential = true;
            charCookie.Path = "/";
            HttpContext.Response.Cookies.Append("charCookie", "_str:12,_dex:15,_con:14,_int:10,_wis:9,_cha:11,_name:Bob,_race:elf,_class:fighter,_maxHP:12,_currHP:8,_bg:soldier,_al:LG,_size:medium", charCookie);
            ViewData["charBob"] = Request.Cookies["charCookie"];
        }

        //race(human), class(bard), ...abilities(1,2,3,4,5)
        public void OnPostCC1Submit()
        {
            string nameInput = "_name:" + Request.Query["Name"] + ",";
            string raceInput = "_race:" + Request.Query["selectRace"] + ",";
            string classInput = "_class:" + Request.Query["selectClass"] + ",";
            string maxHPInput = "_maxHP:" + Request.Query[""] + ",";
            string currHPInput = "_currHP:" + Request.Query[""] + ",";
            string bgInput = "_bg:" + Request.Query["selectBackground"] + ",";
            string alInput = "_al:" + Request.Query["selectAlignment"] + ",";

            string sizeInput = "medium";

            if (Request.Query["selectRace"].Equals("halfling") || Request.Query["selectRace"].Equals("gnome"))
            {
                sizeInput = "small";
            }

            string CC1Data = nameInput + raceInput +  classInput + maxHPInput + currHPInput + bgInput + alInput + sizeInput;
            

            CookieOptions CC1CookieObject = new CookieOptions();
            CC1CookieObject.IsEssential = true;
            CC1CookieObject.Path = "/";
            HttpContext.Response.Cookies.Append("CC1Cookie", CC1Data, CC1CookieObject);

            ViewData["CC1Data"] = Request.Cookies["CC1Cookie"];
        }
        public void OnPostTEST()
        {
            CookieOptions CC1CookieObject = new CookieOptions();
            CC1CookieObject.IsEssential = true;
            CC1CookieObject.Path = "/";
            HttpContext.Response.Cookies.Append("your_mom_cookie", "your mom", CC1CookieObject);

            ViewData["TESTVALUE"] = Request.Cookies["your_mom_cookie"];
        }
    }
}
