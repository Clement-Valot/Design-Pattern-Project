using System;

//To further add polymorphism to our program, we created this class.
//Its purpose is to be able to choose an end condition to the game easily.
//If we want to add one, we simply add a switch case which returns the 
//created function returning a boolean
public class EndCondition
{
    //We need this attribute to access the list of players.
    private GameMaster gameMaster;
    //Constructor taking in parameters the gamemaster of the game along with
    //an integer scenario choosing which end condition to play with.
	public bool EndGame(int scenario, GameMaster gameMaster)
	{
        this.gameMaster = gameMaster;
        switch (scenario)
        {
            case 1:
                return EndByTours(3);
            default:
                return EndByTours(2);
        }
	}
	
    //End condition function.
    //Don't forget to write the winning message adapted for each end condition.
	public bool EndByTours(int tours)
    {
        bool end = false;
        foreach(Player player in this.gameMaster.players)
        {
            if(player.tours>=tours)
            {
                end=true;
                Console.WriteLine($"\nPlayer {player.name} won the game because he accomplished {tours} tours first!");
                break;
            }
        }
        return end;
    }
}