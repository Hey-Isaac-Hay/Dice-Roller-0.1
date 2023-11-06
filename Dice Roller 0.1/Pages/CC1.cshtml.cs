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


            
            ViewData["charBob"] = Request.Cookies["charCookie"];
            
            

            
        }

        //race(human), class(bard), ...abilities(1,2,3,4,5)
        public void OnPostComplete()
            
        {
            //Console.WriteLine("TEST!!!!!");
            Cookie CC1Cookie = new Cookie("CC1Cookie", "");

            
            string nameInput = HttpContext.Request.Query["Name"].ToString();
            string raceInput = HttpContext.Request.Query["selectRace"].ToString();
            string classInput = HttpContext.Request.Query["selectClass"].ToString();
            string maxHPInput = HttpContext.Request.Query[""].ToString();
            string currHPInput = HttpContext.Request.Query[""].ToString();
            string bgInput = HttpContext.Request.Query["selectBackground"].ToString();
            string alInput = HttpContext.Request.Query["selectAlignment"].ToString();
            string sizeInput = HttpContext.Request.Query["selectRace"].ToString()   ;

            if (sizeInput.Equals("halfling") || sizeInput.Equals("gnome"))
            {
                sizeInput = "small";
            }
            else
            {
                sizeInput = "medium";
            }

            //string CC1Data = nameInput + raceInput + classInput + maxHPInput + currHPInput + bgInput + alInput + sizeInput;

            string CC1Data = "_name:" + nameInput + "," + "_race:" + raceInput + "," + "_class:" + classInput + "," + "_maxHP:" + maxHPInput + "," + "_currHP:" + currHPInput + "," + "_bg:" + bgInput + "," + "_al:" + alInput + "," + "_sizeL:" + sizeInput;

            //set cookie value to CC1Data
            CC1Cookie.Value = CC1Data;
            //set domain to the entire website to make cookie global
            //CC1Cookie.Domain = "localhost:44331";


            //instantiate character cookie
            /*
            CookieOptions CC1CookieObject = new CookieOptions();
            CC1CookieObject.IsEssential = true;
            CC1CookieObject.Path = "/";
            HttpContext.Response.Cookies.Append("CC1Cookie", CC1Data, CC1CookieObject);
            */


            //ViewData["CC1Data"] = Request.Cookies["CC1Cookie"];
            ViewData["CC1Data"] = CC1Data;
            HttpContext.Response.Redirect("https://localhost:44331/CC2");
        }
    }
}
