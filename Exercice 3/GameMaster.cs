using System;
using System.Threading;

public class GameMaster
{
    //This variable is used to change the way of running for the program.
    //if set to true, users don't have to interact anymore with program.
    //Otherwise, they have to press enter to toss the dice.
    //It is useful for us but if we add more functions to our monopoly, this boolean
    //should always be set to false since players need to interact with the game. 
    bool auto = true;

    //GameMaster has 5 attributes:
    //  -The gameBoard it is affiliated to
    //  -the list of players of the game
    //  -the current player playing
    //  -the integer turn which represents whose turn it is to play.
    //at the end of each turn (one turn representing all the actions
    //done by one player before he passes the dice), turn is incremented by one.
    //We don't care if this number exceeds the max number of player since we always modulate
    //it by the number of player.
    //  -the integer scenario which chooses which condition to reach to end the game
    public GameBoard gameBoard;
    public Player[] players;
    public Player currentPlayer;
    private int turn;
    private int scenario;

	public GameMaster(int MAX_PLAYER, int scenario, GameBoard gameBoard)
	{
        this.gameBoard= gameBoard;
        this.players = createPlayers(MAX_PLAYER);
        this.currentPlayer= getCurrentPlayer();
        this.scenario=scenario;
        this.turn=0;
	}

    //create the players of the game.
    //Takes in parameter the number of players for the game given by MAX_PLAYER in the constructor.
    //Asks the user(s) to enter a name (in input) for each player.
    //Returns an array of class Player and size MAX_PLAYER.
    public Player[] createPlayers(int number)
    {
        Player[] list_players= new Player[number];
        for(int i=0; i<number; i++)
        {
            Console.Write($"Type name of player {i}: ");
            string name = Console.ReadLine();
            list_players[i]= new Player(i, name);
        }
        return list_players;
    }

    //Returns the current player playing.
    //We simply modulate the number of turns already achieved by the number of players in the game
    //to get the position in the array (ID) of the player
    public Player getCurrentPlayer()
    {
        return players[turn%this.players.GetLength(0)];
    }

    //Returns a boolean to check whether or not the end condition is reached.
    public bool endCondition(int scenario)
    {
        EndCondition end = new EndCondition();
        return end.EndGame(scenario, this);
    }

    //Move the player to its next position and apply the action of the cell he falls on.
    public void movePlayer(int position)
    {
        int ncells=this.gameBoard.cells.GetLength(0);
        if(position>=ncells)
        {
            this.currentPlayer.tours+=1;
            position=position%ncells;
        }
        this.currentPlayer.position=position;
        this.gameBoard.cells[position].playAction(this);
    }

    //This method makes the whole functionning of the game.
    //We have 5 different cases to distinguish:
    //  -the player is free and plays a double (the first or the second in a row): 
    //he moves to his next position and is allowed to play again (if didn't fall on GoToJail cell)
    //  -the player is free and plays his third double in a row:
    //he goes directly to jail and pass the dice to next player
    //  -the player is free and doesn't play any double:
    //he goes to his next position and pass the dice to next player
    //  -the player is in jail and plays a double:
    //he goes to his next position and pass the dice to next player
    //  -the player is in jail and doesn't play any double:
    //he stays in prison and pass the dice to next player
    public void rollDice(int doubles)
    {
        if(this.currentPlayer.inJail) Console.WriteLine("He is in Prison and needs a double to get out of it.");
        if(auto==false)
        {
            Console.WriteLine("Press enter to pass the dice to next player.");
            Console.ReadKey();
        }
        else Thread.Sleep(500);

        Random rand = new Random();
        int die1= rand.Next(1,7);
        int die2= rand.Next(1,7);
        int new_position = this.currentPlayer.position + die1 + die2;
        Console.WriteLine($"{this.currentPlayer.name} tossed {die1} {die2}.");
        if(die1==die2)
        {   
            if(this.currentPlayer.inJail)
            {
                Console.WriteLine($"It's a double, he can get free of jail but isn't allowed to play again."); 
                Console.WriteLine($"He travels {die1+die2} cells.");
                movePlayer(new_position);
                switchTurn();
            }
            else
            {
                doubles++;
                if(doubles!=3)
                {
                    Console.WriteLine("It's a double, he gets to play again.");
                    Console.WriteLine($"He travels {die1+die2} cells.");
                    movePlayer(new_position);
                    if(currentPlayer.inJail==false) rollDice(doubles);
                    else switchTurn();
                }
                else
                {
                    Console.WriteLine($"{this.currentPlayer.name} made 3 doubles in a row ! He is being transfered to prison (position 10) due to extreme unfair luck.");
                    sendToJail();
                    switchTurn();
                }
            }
        }
        else
        {
            if(this.currentPlayer.inJail)
            {
                this.currentPlayer.turnsInJail++;
                Console.WriteLine($"Too bad, no double. You get to spend one more turn in jail, {this.currentPlayer.turnsInJail} so far (you are being freed after 3 turns in jail).");
                if(this.currentPlayer.turnsInJail==3) this.currentPlayer.inJail=false;
                switchTurn();
            }
            else
            {
                Console.WriteLine($"He travels {die1+die2} cells.");
                movePlayer(new_position);
                switchTurn();
            }
        }
    }

    //Send a player to jail.
    //Used when a player makes 3 doubles in a row and in the overriden playFunction method 
    //of subclass GoToJailCell.
    //We need to set the player's attribute inJail to true and reset its turnsInJail attribute to 0 if he already
    //went to prison.
    public void sendToJail()
    {
        movePlayer(10);
        this.currentPlayer.inJail=true;
        this.currentPlayer.turnsInJail=0;
    }

    //Core function of the program starting the game and terminating it when end condition reached.
    public void startGame()
    {
        while(this.endCondition(scenario)==false)
        {
            Console.Clear();
            displayScores();
            Console.WriteLine($"\nTurn {turn+1}. It is {currentPlayer.name}'s time to play.");
            rollDice(0);
        }
    }

    //After a player moved and end his turn, this function passes the dice to the next player
    //by incrementing the turn integer and getting the new current player.
    public void switchTurn()
    {
        if(auto==false)
        {
            Console.WriteLine("Press enter to pass the dice to next player.");
            Console.ReadKey();
        }
        else Thread.Sleep(500);
        turn++;
        this.currentPlayer=getCurrentPlayer();
    }

    //Display informations on players (name, position, jail condition)
    public void displayScores()
    {
        foreach(Player player in this.players)
        {
            player.toString();
        }
    }
}