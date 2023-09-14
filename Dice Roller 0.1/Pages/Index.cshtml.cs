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

        public async Task OnPostButton()
        {
            RollDice(mod);
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
        int[] dice = { 0, 0, 0, 0, 0, 0, 0};
        int mod = 0;

        public void OnGet()
        {
            dice[0] = 1;
            dice[1] = 1;
            dice[2] = 1;
            dice[3] = 1;
            dice[4] = 1;
            dice[5] = 1;
            dice[6] = 1;
            Console.WriteLine(RollDice(5));
         
        }

        public void MoreLessDice(int die,bool add)
        {
            int mod = 0;
            //if True, add a die
            //if False, subtract a die
            if (add == true)
                mod = 1;
            else
                mod = -1;

            //find what die we want to add/subtract from array
            if (die == 4)
                dice[0] += mod;
            if (die == 6)
                dice[1] += mod;
            if (die == 8)
                dice[2] += mod;
            if (die == 10)
                dice[3] += mod;
            if (die == 100)
                dice[4] += mod;
            if (die == 12)
                dice[5] += mod;
            if (die == 20)
                dice[6] += mod;
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