using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Dice_Roller_0._1.Pages
{
    public class CC2Model : PageModel
    {
        public void OnGet()
        {
            Character testChar = makeCharacter(ViewData["CC1Char"]!.ToString()!);
            //Console.WriteLine(testChar.getBg());
            //Console.WriteLine("Made a(n) " + testChar.getRace() + " " + testChar.getClass());
            string encryptedChar = "_str:" + testChar.getStr() + ",_dex:" + testChar.getDex() + ",_con:" + testChar.getCon() +
                ",_int:" + testChar.getInt() + ",_wis:" + testChar.getWis() + ",_cha:" + testChar.getCha() +
                ",_name:" + testChar.getName() + ",_race:" + testChar.getRace() + ",_class:" + testChar.getClass() +
                ",_maxHP:" + testChar.getMaxHP() + ",_currHP:" + testChar.getCurrHP() + ",_bg:" + testChar.getBg() +
                ",_al:" + testChar.getAl() + ",_size:" + testChar.getSize();
            ViewData["CC2Display"] = encryptedChar;
        }

        public void OnPostTEST()
        {

            
            Character testChar = makeCharacter(ViewData["CC1Char"]!.ToString()!);
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
        public void OnPostStoreStats()
        {
            string tempStorage = "_str:" + ViewData["strStat"] + ",_dex:" + ViewData["dexStat"] + ",_con:" + ViewData["conStat"] + ",_int:" + ViewData["intStat"] + ",_wis:" + ViewData["wisStat"] + ",_cha:" + ViewData["chaStat"];

            //Console.WriteLine(tempStorage + Request.Cookies["CC1Data"]);
            ViewData["CC2Char"] = tempStorage + Request.Cookies["CC1Data"];
        }

    }
}
