using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dice_Roller_0._1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /*
        * 1st - d4
        * 2nd - d6
        * 3rd - d8
        * 4th - d10
        * 5th - d10 (percentile)
        * 6th - d12
        * 7th - d20
        */
        int[] dice = { 0, 0, 0, 0, 0, 0, 0 };

        public void OnGet()
        {
            dice[0] = 2;
            Console.WriteLine(RollDice(2));
         
        }

        public int RollDice(int mod)
        {
            int sum = 0;
            Random roll = new Random();

            for( int i = 0; i < dice.Length;i++)
            {
               for(int j = 0; j < dice[i]; j++)
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
                        Console.WriteLine("Rolled d4");
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
                    else
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


    }
}