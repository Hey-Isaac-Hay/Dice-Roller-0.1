using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Dice_Roller_0._1.Pages
{
    public class CC2Model : PageModel
    {
        public void OnGet()
        {
            int stat1 = fourDropLowest();
            int stat2 = fourDropLowest();
            int stat3 = fourDropLowest();
            int stat4 = fourDropLowest();
            int stat5 = fourDropLowest();
            int stat6 = fourDropLowest();
            ViewData["stat1"] = stat1;
            ViewData["stat2"] = stat2;
            ViewData["stat3"] = stat3;
            ViewData["stat4"] = stat4;
            ViewData["stat5"] = stat5;
            ViewData["stat6"] = stat6;
        }

        public void OnPostTEST()
        {

            
            Character testChar = makeCharacter(ViewData["CC2Char"]!.ToString()!);
            //Console.WriteLine(testChar.getBg());
            //Console.WriteLine("Made a(n) " + testChar.getRace() + " " + testChar.getClass());
            string encryptedChar = "_str:" + testChar.getStr() + ",_dex:" + testChar.getDex() + ",_con:" + testChar.getCon() + 
                ",_int:" + testChar.getInt() + ",_wis:" + testChar.getWis() + ",_cha:" + testChar.getCha() + 
                ",_name:" + testChar.getName() + ",_race:" + testChar.getRace() + ",_class:" + testChar.getClass() + 
                ",_maxHP:" + testChar.getMaxHP() + ",_currHP:" + testChar.getCurrHP() + ",_bg:" + testChar.getBg() + 
                ",_al:" + testChar.getAl() + ",_size:" + testChar.getSize();
            //ViewData["testChar"] = encryptedChar;
            
        }

        public Character makeCharacter(string input)
        {
            //creates a character using only a encrypted string
            //creates all of the variables that will be used to make the character
            int[] stats = new int[6];
            string name = "";
            string race = "";
            string _class = "";
            int maxHP = 0;
            int currHP = 0;
            string bg = "";
            string al = "";

            //splits the inputed encrypted string into an array of strings
            char[] delimitersChars = { '_', ':', ',' };

            string[] splitInfo = input.Split(delimitersChars);

            //sorts out all of the empty strings in splitInfo

            string[] sortedInfo = new string[28];
            int index = 0;
            for (int i = 0; i < splitInfo.Length; i++)
            {
                if (splitInfo[i] != "")
                {
                    sortedInfo[index] = splitInfo[i];
                    index++;
                }
            }

            stats[0] = Convert.ToInt32(sortedInfo[1]);
            stats[1] = Convert.ToInt32(sortedInfo[3]);
            stats[2] = Convert.ToInt32(sortedInfo[5]);
            stats[3] = Convert.ToInt32(sortedInfo[7]);
            stats[4] = Convert.ToInt32(sortedInfo[9]);
            stats[5] = Convert.ToInt32(sortedInfo[11]);

            name = sortedInfo[Array.IndexOf(sortedInfo,"name") + 1];
            race = sortedInfo[Array.IndexOf(sortedInfo, "race") + 1];
            _class = sortedInfo[Array.IndexOf(sortedInfo, "class") + 1];
            maxHP = Convert.ToInt32(sortedInfo[Array.IndexOf(sortedInfo, "maxHP") + 1]);
            currHP = Convert.ToInt32(sortedInfo[Array.IndexOf(sortedInfo, "currHP") + 1]);
            bg = sortedInfo[Array.IndexOf(sortedInfo, "bg") + 1];
            al = sortedInfo[Array.IndexOf(sortedInfo, "al") + 1];

            Character test = new Character(stats, name, race, _class, maxHP, currHP, bg, al);
            return test;
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



        //this is an old method used to test how to retrieve data from an encrypted string
        /*
        public int[] retrieve()
        {
            char[] delimitersChars = { '_', ':', ',' };
            //string info = "_str:12,_dex:15,_con:14,_int:10,_wis:9,_cha:11,_name:Bob,_race:elf,_class:fighter,_maxHP:12,_currHP:8,_bg:soldier,_al:LG,_size:medium";
            string info = Convert.ToString(ViewData["charBob"])!;
            int str = 0;
            int dex = 0;
            int con = 0;
            int intel = 0;
            int wis = 0;
            int cha = 0;

            //splits the decrypted string but doesn't sort out the empty strings
            string[] splitInfo = info.Split(delimitersChars);

            //Console.WriteLine(splitInfo.Length);
            //foreach(string x in splitInfo)
            //{
            //    Console.WriteLine(x);
            //}

            //sorts out all of the empty strings in splitInfo

            string[] sortedInfo = new string[28];
            int index = 0;
            for (int i = 0; i<splitInfo.Length; i++)
            {
                if (splitInfo[i] != "")
                {
                    sortedInfo[index] = splitInfo[i];
                    index++;
                }
            }

            //str = Convert.ToInt32(info.Substring(info.IndexOf("_str:") + 5, info.IndexOf(",_dex:") - 5));

            //decrypts the string
            str = Convert.ToInt32(sortedInfo[1]);
            dex = Convert.ToInt32(sortedInfo[3]);
            con = Convert.ToInt32(sortedInfo[5]);
            intel = Convert.ToInt32(sortedInfo[7]);
            wis = Convert.ToInt32(sortedInfo[9]);
            cha = Convert.ToInt32(sortedInfo[11]);

            //tests to see if the strenght is correctly retreived
            //Console.WriteLine("Character strength: " +  str);
            return new int[] { str, dex, con, intel, wis, cha }; 
        }*/

    }
}
