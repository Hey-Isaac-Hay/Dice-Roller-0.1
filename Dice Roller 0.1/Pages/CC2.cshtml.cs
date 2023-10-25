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

        public void OnPostButtonTest() 
        {
            
        }

        public void makeCharacter(int[] stats,  string name, string race, string _class, int maxHP, int currHP, string background, string alignment, string size)
        {

            Character Steve = new Character(stats, name, race, _class, maxHP, currHP, background, alignment);
        }        
    }
}
