using System;
using System.Diagnostics.Eventing.Reader;

public class Tile
{
	bool onFire;
	bool isFlammable;
	bool underWater;
	bool difficultTerrain;
	bool isDark;
	bool isMagicallyDark;

	int northCover;
	int southCover;
	int westCover;
	int eastCover;

	int height;

	String picture;


	//default constructor
	//assign default values to instance variables
	public Tile()
	{
		//Needs Many Instance Variables
		onFire = false;
		isFlammable = false;
		underWater = false;
		difficultTerrain = false;
		isDark = false;
		isMagicallyDark = false;

		//In which directions does this Tile have Cover
		/*
		 * 0 - No cover
		 * 1 - Half cover
		 * 2 - 3/4ths cover
		 * 3 - Full cover
		 */
		northCover = 0;
		southCover = 0;
		westCover = 0;
		eastCover = 0;

		//Height is in feet
		//A flat map will have all Heights at 0 feet.
		//Used for fall damage, climbing, jumping, etc
		height = 0;
		picture = "images/DirtTile.png";

	}

	//Return the Value of the Specified Parameter
	/* Bool Parameters:
	 * onFire
	 * isFlammable
	 * underWater
	 * difficultTerrain
	 * isDark
	 * isMagicallyDark
	 */
	public bool getBoolValue(String parameter)
	{
		if (parameter == "onFire")
			return onFire;
		else if (parameter == "isFlammable")
			return isFlammable;
		else if (parameter == "underWater")
			return underWater;
		else if (parameter == "difficultTerrain")
			return difficultTerrain;
		else if (parameter == "isDark")
			return isDark;
		else if (parameter == "isMagicallyDark")
			return isMagicallyDark;
		else
			return false;
    }

    /* Int Parameters:
	 * northCover
	 * southCover
	 * westCover
	 * eastCover
	 * height
	 */
    public int getIntValue(String parameter)
    {
		if (parameter == "northCover")
			return northCover;
		else if (parameter == "southCover")
			return southCover;
		else if (parameter == "westCover")
			return westCover;
		else if (parameter == "eastCover")
			return eastCover;
		else if (parameter == "height")
			return height;
		else
			return 0;
    }

	/* String Parameters:
	 * picture
	 */
    public String getStringValue(String parameter)
    {
		if (parameter == "picture")
			return picture;
		else
			return "";
    }

	//Set the Value of the Specified Parameter
    public void setBoolValue(String parameter, bool value)
	{
		if (parameter == "onFire")
			onFire = value;
		else if (parameter == "isFlammable")
			isFlammable = value;
		else if (parameter == "underWater")
			underWater = value;
		else if (parameter == "difficultTerrain")
			difficultTerrain = value;
		else if (parameter == "isDark")
			isDark = value;
		else if (parameter == "isMagicallyDark")
			isMagicallyDark = value;
    }

	public void setIntValue(String parameter, int value)
	{
        if (parameter == "northCover")
            northCover = value;
        else if (parameter == "southCover")
            southCover = value;
        else if (parameter == "westCover")
            westCover = value;
        else if (parameter == "eastCover")
            eastCover = value;
        else if (parameter == "height")
            height = value;
    }

	public void setStringValue(String parameter, String value)
	{
		if (parameter == "picture")
			picture = value;
	}
}
