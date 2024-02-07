using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dice_Roller_0._1.Pages
{
    public class MapMakerModel : PageModel
    {
        public void OnGet()
        {
            //Instantiate ViewData with default values
            //Not necessary, but a good programming habit
            //Needs to be instantiated here to be accessed in the .cshtml file without fails
            ViewData["isPost"] = "false";
        }

        public void OnPostMakeMap()
        {
                ViewData["isPost"] = "true";

        }
    }
}
