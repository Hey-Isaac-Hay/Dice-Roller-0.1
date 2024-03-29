﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dice_Roller_0._1.Pages
{
    public class IndexModel : PageModel
    {

        /* Comment out to match video
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        */

        /*
        * 1st - d4
        * 2nd - d6
        * 3rd - d8
        * 4th - d10
        * 5th - d10 (percentile)
        * 6th - d12
        * 7th - d20
        */

        //A default array for test buttons to use
        int[] dice = { 0, 0, 0, 0, 0, 0, 0 };
        int mod = 2;

        public void OnGet()
        {//Make a default array of 1 of each die
            int[] deArray = { 1, 1, 1, 1, 1, 1, 1 };
            Console.WriteLine(RollDice(deArray, 2));
            OnPostFourDrop();


        }

        public void MoreLessDice(int[] arr, int die,int add)
        {   //Adds or Subtracts a Die from the Array
            //add should be -1 or 1
            //find what die we want to add/subtract from array
            if (die == 4)
                arr[0] += add;
            else if (die == 6)
                arr[1] += add;
            else if (die == 8)
                arr[2] += add;
            else if (die == 10)
                arr[3] += add;
            else if (die == 100)
                arr[4] += add;
            else if (die == 12)
                arr[5] += add;
            else if (die == 20)
                arr[6] += add;
        }

        public int RollDice(int[] arr, int mod)
        {   //Rolls all Dice in Array and adds the Mod
            int sum = 0;
            Random roll = new Random();

            for(int i = 0; i < arr.Length;i++)
            {
               for(int j = 0; j < arr[i]; j++)
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

            for (int i = 0;i < 4;i++)
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

        public void OnPostButton()
        { 
            dice[0] = 1;
            dice[1] = 1;
            dice[2] = 1;
            dice[3] = 1;
            dice[4] = 1;
            dice[5] = 1;
            dice[6] = 1;
            Console.WriteLine(RollDice(dice, mod));  
        }

        public void OnPostTestClick()
        {
            Console.WriteLine("TEST");
        }
        public void OnPostFourDrop()
        {
            Console.WriteLine(fourDropLowest());
        }

    }
}