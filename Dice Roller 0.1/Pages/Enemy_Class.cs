using System;

public class Enemy
{
    //Stats and Modifiers
    //index: 0 is strength, 1 is dexterity, 2 is constitution
    //index: 3 is intelligence, 4 is wisdom, 5 is charisma
    public int[] stats = { 10, 10, 10, 10, 10, 10 };
    public int[] mods = { 0, 0, 0, 0, 0, 0 };

    public int speed = 6;

    public int armorClass = 10;

    public string alignment = "";

    public string race = "";

    public string size = "medium";

    public int health = 0;

    public Enemy(int[] stats, string race, string alignment, string size, int armorClass, int health)
    {
        //assigns the stat values and the correct modifier
        for (int i = 0; i < 6; i++)
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
        for (int i = 0; i < 6; i++)
        {
            mods[i] = (stats[i] - 10) / 2;
        }

        //assigns values to the instance variables
        this.race = race;
        this.size = size;
        this.alignment = alignment;
        this.armorClass = armorClass;
        this.health = health;
    }

    //retrieves a desired stat
    public int getStr()
    {
        return stats[0];
    }
    public int getDex()
    {
        return stats[1];
    }
    public int getCon()
    {
        return stats[2];
    }
    public int getInt()
    {
        return stats[3];
    }
    public int getWis()
    {
        return stats[4];
    }
    public int getCha()
    {
        return stats[5];
    }

    //sets the value of a desired stat
    public void setStr(int str)
    {
        stats[0] = str;
        mods[0] = (str - 10) / 2;
    }
    public void setDex(int dex)
    {
        stats[1] = dex;
        mods[1] = (dex - 10) / 2;
    }
    public void setCon(int con)
    {
        stats[2] = con;
        mods[2] = (con - 10) / 2;
    }
    public void setInt(int intel)
    {
        stats[3] = intel;
        mods[3] = (intel - 10) / 2;
    }
    public void setWis(int wis)
    {
        stats[4] = wis;
        mods[4] = (wis - 10) / 2;
    }
    public void setCha(int cha)
    {
        stats[5] = cha;
        mods[5] = (cha - 10) / 2;
    }

    //gets or sets the race of the enemy
    public string getRace()
    {
        return race;
    }
    public void setRace(string newRace)
    {
        race = newRace;
    }

    //gets or sets the alignment of the enemy
    public string getAlignment()
    {
        return alignment;
    }
    public void setAlignment(string newAlignment)
    {
        alignment = newAlignment;
    }

    //gets or sets the speed of the enemy
    public int getSpeed()
    {
        return speed;
    }
    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    //gets or sets the armor class of the enemy
    public int getArmorClass()
    {
        return armorClass;
    }
    public void setArmorClass(int newArmorClass)
    {
        armorClass = newArmorClass;
    }

    //gets or sets the size of the enemy
    public string getSize()
    {
        return size;
    }
    public void setSize(string newSize)
    {
        size = newSize;
    }

    //gets or sets the health of the enemy
    public int getHealth()
    {
        return health;
    }
    public void takeDamage(int dmgDealt)
    {
        health -= dmgDealt;
    }
}