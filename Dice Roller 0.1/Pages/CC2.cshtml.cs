using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Dice_Roller_0._1.Pages
{
    public class CC2Model : PageModel
    {
        public void OnGet()
        {
            ViewData["charBob"] = Request.Cookies["charCookie"];
            
        }

        public void OnPostTEST()
        {
            retrieve();
        }

        public void makeCharacter(int[] stats,  string name, string race, string _class, int maxHP, int currHP, string background, string alignment, string size)
        {

            Character test = new Character(retrieve(), name, race, _class, maxHP, currHP, background, alignment);
        }   
        
        public int[] retrieve()
        {
            string? info = "_str:12,_dex:15,_con:14,_int:10,_wis:9,_cha:11,_name:Bob,_race:elf,_class:fighter,_maxHP:12,_currHP:8,_bg:soldier,_al:LG,_size:medium";
            int str = 0;
            int dex = 0;
            int con = 0;
            int intel = 0;
            int wis = 0;
            int cha = 0;

            str = Convert.ToInt32(info.Substring(info.IndexOf("_str:") + 5, info.IndexOf(",_dex:") - 5));
            
            
            Console.WriteLine("Character strength: " +  str);
            return new int[] { str, dex, con, intel, wis, cha }; 
        }

    }
}
