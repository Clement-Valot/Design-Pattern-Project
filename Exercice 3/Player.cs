using System;

//Simple class Player with 6 attributes with getters and setters:
//  - the id corresponding to the order of players creation (0 for first, 1 for second, etc )
//This attribute is useful to pass the hand to the next player each time one finishes his turn
//  - the name chose at the beginning of the party
//  - the inJail boolean indicating whether or not the player is in jail.
//This is mostly useful for the RollDice function.
//  - the position of the player, set to 0
//  - the number of tours accomplished, set to 0
//  - the number of turns passed in jail since we have to free a player that has 
//passed three consecutives turns in jail hence the need to count them.  
public class Player
{
	public Player(int id, string name)
	{
        this.id = id;
		this.name = name;
        this.inJail = false;
        this.position = 0;
        this.tours= 0;
        this.turnsInJail= 0;
	}
	
	public string name { get; set; }
	public int id { get; set; }
    public bool inJail { get; set; }
    public int position { get; set; }
    public int tours { get; set; }
    public int turnsInJail { get; set; }

    //Method that displays the situation of a player (name, position and if in jail or not)
    public void toString()
    {
        string jail="";
        if(this.inJail) jail="He is in Prison.";
        Console.WriteLine($"Player {this.name} is in position {this.position} and has completed {this.tours} tours. {jail}");
    }
}