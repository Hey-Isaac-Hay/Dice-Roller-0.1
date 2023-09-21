using System;

public class Character
{
    //Stats and Modifiers
    //index: 0 is strength, 1 is dexterity, 2 is constitution
    //index: 3 is intelligence, 4 is wisdom, 5 is charisma
    public int[] stats = { 10, 10, 10, 10, 10, 10 };
    public int[] mods = { 0, 0, 0, 0, 0, 0 };

     /*index: (18 skills)
     * 0 - Acrobatics, 1 - Animal Handling, 2 - Arcana
     * 3 - Athletics, 4 - Deception, 5 - History
     * 6 - Insight, 7 - Intimidation, 8 - Investigation
     * 9 - Medicine, 10 - Nature, 11 - Perception
     * 12 - Performance, 13 - Persuasion, 14 - Religion
     * 15 - Sleight of Hand, 16 - Stealth, 17 - Survival
     */   
    public int[] skills = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


    public Character(int[] stats)
    {
        
        for (int i = 0;  i < 6; i++)
        {
            if (stats[i] > 30 || stats[i] < 1)
            {
                this.stats[i] = 10;
            }
            else
            {
                this.stats[i] = stats[i];
            }

        }

        for(int i=0; i<6; i++)
        {
            mods[i] = (stats[i] - 10) / 2;
        }
    }

    public int getStr()
    {
        return 0;
    }
}