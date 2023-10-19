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

    //Proficiency bonus
    /*index: (18 skills)
     * 0 - Acrobatics, 1 - Animal Handling, 2 - Arcana
     * 3 - Athletics, 4 - Deception, 5 - History
     * 6 - Insight, 7 - Intimidation, 8 - Investigation
     * 9 - Medicine, 10 - Nature, 11 - Perception
     * 12 - Performance, 13 - Persuasion, 14 - Religion
     * 15 - Sleight of Hand, 16 - Stealth, 17 - Survival
     */
    public bool[] prof = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public int profBonus = 2;

    /*Available race options
     *Dwarf, elf, human, gnome, half-orc, dragonborn, tiefling, half-elf, halfling
     */
    public string race = "";

    /*Available class options
     * Barbarian, bard, cleric, druid, fighter, monk, paladin
     * ranger, rogue, sorcerer, warlock, wizard
     */
    public string _class = "";

    public string name = "";

    public string background = "";

    public string alignment = "";

    public int speed = 6;

    public int armorClass = 10;

    public string size = "medium";

    public int health = 0;

    //will track items in the player's inventory, items will be comma separated
    public string inventory = "";
    
    public Character(int[] stats, string race, string _class, string name, string background, string alignment, int health)
    {  
        //scan through each stat and check whether it is
        //too high (above 30) or too low (below 1)
        //if so, replace with 10, else keep the same
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
        //Assign a modifier to each stat based on an equation
        for(int i=0; i<6; i++)
        {
            mods[i] = (stats[i] - 10) / 2;
        }
        //assign chosen race to instance variable
        this.race = race;

        //assign chosen class to instance variable
        this._class = _class; 

        //assign chosen name to instance variable
        this.name = name;

        //assign chosen background to instance variable
        this.background = background;

        //scan through each 

        //assign alignment to instance variable
        this.alignment = alignment;

        //give the character the correct, basic armor class (not checking inventory for armor yet or abilities)
        armorClass += mods[1];

        //assigns the health value to the character
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

    //gets or sets the race of the character
    public string getRace()
    {
        return race;
    }
    public void setRace(string newRace)
    {
        race = newRace;
    }

    //gets or sets the class of the character
    public string getClass()
    {
        return _class;
    }
    public void setClass(string newClass)
    {
        _class = newClass;
    }

    //gets or sets the name of the character
    public string getName()
    {
        return name;
    }
    public void setName(string newName)
    {
        name = newName;
    }

    //gets or sets the background of the character
    public string getBackground()
    {
        return background;
    }
    public void setBackground(string newBackground)
    {
        background = newBackground;
    }

    //gets or sets the alignment of the character
    public string getAlignment()
    {
        return alignment;
    }
    public void setAlignment(string newAlignment)
    {
        alignment = newAlignment;
    }

    //gets or sets the proficiency bonus
    public int getProfBonus()
    {
        return profBonus;
    }
    public void setProfBonus(int newProfBonus)
    {
        profBonus = newProfBonus;
    }

    //gets or sets the speed of the character
    public int getSpeed()
    {
        return speed;
    }
    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    //gets or sets the armor class of the character
    public int getArmorClass()
    {
        return armorClass;
    }
    public void setArmorClass(int newArmorClass)
    {
        armorClass = newArmorClass;
    }

    //gets or sets the size of the character
    public string getSize()
    {
        return size;
    }
    public void setSize(string newSize)
    {
        size = newSize;
    }



    //gets or sets the skill bonus for each skill
    /*index: (18 skills)
     * 0 - Acrobatics, 1 - Animal Handling, 2 - Arcana
     * 3 - Athletics, 4 - Deception, 5 - History
     * 6 - Insight, 7 - Intimidation, 8 - Investigation
     * 9 - Medicine, 10 - Nature, 11 - Perception
     * 12 - Performance, 13 - Persuasion, 14 - Religion
     * 15 - Sleight of Hand, 16 - Stealth, 17 - Survival
     */
    public int getSkillBonus(int index)
    {
        return skills[index];
    }
    public void setSkillBonus(int index, int newSkillBonus)
    {
        skills[index] = newSkillBonus;
    }

    //gets or sets the health of the character
    public int getHealth()
    {
        return health;
    }
    public void takeDamage(int dmgDealt)
    {
        health -= dmgDealt;
    }

    //does a strength based attack
    //in future, will need to check that enemy and character are next to each other
    //also will need to check which weapon is being used to deal the right damage
    //also will need to check if character has proficiency in weapon being used
    public void meleeAttack(Enemy enemy)
    {
        int total = 0;
        int damage = 0;
        Random num = new Random();
        total += num.Next(1, 21);
        total += mods[0] + profBonus;
        if (total - enemy.getArmorClass() >= 0)
        {
            damage += num.Next(1, 9) + mods[0];
            enemy.takeDamage(damage);
            Console.WriteLine("You hit the enemy and dealt " + damage + " damage");
        }
        else
        {
            Console.WriteLine("You missed the enemy");
        }
    }

    //does a dex based attack typically from a distance
    //will eventually need to check distance from enemy to character compared to weapon range
    //will eventually need to check line of sight to see if character can reasonably hit enemy
    public void rangedAttack(Enemy enemy)
    {
        int total = 0;
        int damage = 0;
        Random num = new Random();
        total += num.Next(1, 21) + mods[1] + profBonus;
        if (total - enemy.getArmorClass() >= 0)
        {
            damage += num.Next(1, 9) + mods[0];
            enemy.takeDamage(damage);
            Console.WriteLine("You hit the enemy and dealt " + damage + " damage");
        } 
        else
        {
            Console.WriteLine("You missed the enemy");
        }
    }
}