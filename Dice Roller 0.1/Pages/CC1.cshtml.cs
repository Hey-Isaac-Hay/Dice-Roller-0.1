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

            //FROM CC2 FOR STATS
            ViewData["stat1"] = fourDropLowest();
            ViewData["stat2"] = fourDropLowest();
            ViewData["stat3"] = fourDropLowest();
            ViewData["stat4"] = fourDropLowest();
            ViewData["stat5"] = fourDropLowest();
            ViewData["stat6"] = fourDropLowest();

            //Console.WriteLine(Request.Cookies["charCookie"]);
        }

        //race(human), class(bard), ...abilities(1,2,3,4,5)
        public void OnPostComplete()
            
        {
            /*
            //Console.WriteLine("TEST!!!!!");
            Cookie CC1Cookie = new Cookie("CC1Cookie", "");
            CC1Cookie.Expires = DateTime.Now.AddYears(50);

            
            string nameInput = HttpContext.Request.Query["Name"].ToString();
            string raceInput = HttpContext.Request.Query["selectRace"].ToString();
            string classInput = HttpContext.Request.Query["selectClass"].ToString();
            string maxHPInput = HttpContext.Request.Query[""].ToString();
            string currHPInput = HttpContext.Request.Query[""].ToString();
            string bgInput = HttpContext.Request.Query["selectBackground"].ToString();
            string alInput = HttpContext.Request.Query["selectAlignment"].ToString();
            string sizeInput = HttpContext.Request.Query["selectRace"].ToString();

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


            //ViewData["CC1Data"] = Request.Cookies["CC1Cookie"];
            ViewData["CC1Data"] = CC1Data;


            Console.WriteLine("Name: " + nameInput);

            //HttpContext.Response.Redirect("https://localhost:44331/CC2");
            //Console.WriteLine("Complete Method Ran!");
            */
        }
        public int RollDice(int[] arr, int mod)
        {   //Rolls all Dice in Array and adds the Mod
            int sum = 0;
            Random roll = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i]; j++)
                {
                    //check which die type is being rolled
                    if (i == 0)
                    {//d4
                        sum += roll.Next(1, 5);
                        Console.WriteLine("Rolled d4");
                    }
                    else if (i == 1)
                    {//d6
                        sum += roll.Next(1, 7);
                        Console.WriteLine("Rolled d6");
                    }
                    else if (i == 2)
                    {//d8
                        sum += roll.Next(1, 9);
                        Console.WriteLine("Rolled d8");
                    }
                    else if (i == 3)
                    {//d10
                        sum += roll.Next(1, 11);
                        Console.WriteLine("Rolled d10");
                    }
                    else if (i == 4)
                    {//d10 (percentile)
                        sum += (roll.Next(1, 11) * 10);
                        Console.WriteLine("Rolled a d10 pct");
                    }
                    else if (i == 5)
                    {//d12
                        sum += roll.Next(1, 13);
                        Console.WriteLine("Rolled a d12");
                    }
                    else if (i == 6)
                    {//d20
                        sum += roll.Next(1, 21);
                        Console.WriteLine("Rolled a d20");
                    }
                }//roll loop
            }//position loop

            //add mod to sum
            sum += mod;
            //return rolled sum
            return sum;
        }


        public int fourDropLowest()
        {   //for creating stats
            int[] four = { 0, 0, 0, 0, 0, 0, 0 };

            //int logic
            int hold = 0;
            int low = 9999999;
            int sum = 0;

            for (int i = 0; i < 4; i++)
            {   //Roll single d6
                four[1] = 1;
                hold = RollDice(four, 0);

                //Add to total
                sum += hold;

                //Keep track of lowest value
                if (hold < low)
                    low = hold;
            }

            //Now drop lowest value
            sum -= low;

            //Return sum of dice rolls minus lowest value
            return sum;
        }
    }
}
