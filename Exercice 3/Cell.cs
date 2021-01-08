using System;

//We are using a factory pattern hence the need of an abstract being the parent class.
//THis class has properties and functions that all cells share like a name or 
//the playAction function which triggers the action to do when a player lands
//on the cell (Go to jail for the GoToJail cell for example).
public abstract class Cell
{
    public string name;
    public abstract void playAction(GameMaster gameMaster);
}

//Subclass of Cell.
public class GoToJailCell : Cell
{
    public GoToJailCell(string name)
    {
        this.name=name;
    }
    public override void playAction(GameMaster gameMaster)
    {
        Console.WriteLine("He fell on the GoToJail Cell, he is being transfered to Prison (position 10).");
        gameMaster.sendToJail();
    }
}

//Subclass of Cell.
public class SimpleCell : Cell
{
    public SimpleCell(string name)
    {
        this.name=name;
    }
    public override void playAction(GameMaster gameMaster)
    {
        
    }
}

//enum that registers all different types of cell on the board.
//If we want to add a type of cell, we have to first add its name to this enum.
public enum CellType
{
    SimpleCell,
    GoToJailCell
}

//Factory class that chooses which subclass of cell to build according
//to the list of CellType created in GameBoard.cs.
//To continue on this example of adding a type, the second step is to add
//a switch case.
//The last step is of course to create the corresponding subclass above.
public static class CellFactory
{
    public static Cell GetCell(CellType type, string name)
    {
        switch (type)
        {
            case CellType.GoToJailCell:
                return new GoToJailCell(name);
            default:
                return new SimpleCell(name);
        }
        
    }
}