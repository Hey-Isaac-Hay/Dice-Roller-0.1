using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            int str = 0;
            int dex = 0;
            int con = 0;
            int intel = 0;
            int wis = 0;
            int cha = 0;
            string? info = "";
            info = Request.Cookies["charCookie"];
            
            str = int.Parse(info.Substring(info.IndexOf("_str:") + 5, info.IndexOf(",_dex:")));

            Console.WriteLine("Character strength: " +  str);
            return new int[] { str, dex, con, intel, wis, cha }; 
        }

    }
}
