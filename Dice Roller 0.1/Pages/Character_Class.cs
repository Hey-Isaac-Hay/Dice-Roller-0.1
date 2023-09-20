using System;

public class Character
{
    public string name;
    public int[] stats = new int[6];

    public Character()
    {
        name = "bob";
        for (int i = 0; i < 6; i++)
        {
            stats[i] = 10;
        }
    }

    public Character(string newName, int[] stats)
    {
        name = newName;
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
    }
}