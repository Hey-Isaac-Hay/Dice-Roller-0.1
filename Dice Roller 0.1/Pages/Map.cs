using System;
using System.Collections;

public class Map
{
	int c;
	int r;
	Tile[,] grid;

	//Modified Constructor
	//No Default Constructor (can't really assume the size of a map)
	public Map(int rows,int columns)
	{
		r = rows;
        c = columns;

		//The Map is a 2D-Array of Tiles
		//Each Tile is Unique, and may have many properties
		grid = new Tile[r,c];

		//Go through the columns of every rows
		//And create a Tile at that position
		for(int i = 0; i < r;i++)
		{
			for(int j = 0;j < c;j++)
			{
				grid[i,j] = new Tile();
			}
		}
	}

	//Grabs Value of Specified Instance Variable at (r,c)
	//(0,0) is the top left
	//(1,2) is 1 down, 2 right from (0,0)
	public bool getTileBool(int r,int c,String parameter)
	{
		return grid[r,c].getBoolValue(parameter);
	}

    public int getTileInt(int r, int c, String parameter)
    {
        return grid[r, c].getIntValue(parameter);
    }

    public String getTileString(int r, int c, String parameter)
    {
        return grid[r, c].getStringValue(parameter);
    }

    //Assigns New Value to Specified Instance Variable at (r,c)
    //(0,0) is the top left
    //(1,2) is 1 down, 2 right from (0,0)
    public void setTileBool(int r, int c,String parameter, bool value)
	{
		grid[r,c].setBoolValue(parameter, value);
	}

    public void setTileInt(int r, int c, String parameter, int value)
    {
        grid[r, c].setIntValue(parameter, value);
    }

    public void setTileString(int r, int c, String parameter, String value)
    {
        grid[r, c].setStringValue(parameter, value);
    }
}
