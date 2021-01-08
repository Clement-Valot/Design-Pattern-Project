using System;
 
public class GameBoard
{
    public Cell[] cells;

    //Constructor of class GameBoard.
    //Takes in parameter the number of cell composing the board.
    //Has only one attribute cells being an array of Cell objects.
	public GameBoard(int composition)
	{
        this.cells = createBoard(composition);
	}
	
    //Main method of this class.
    //Create the board using the Factory design pattern with the CellFactory class.
    public Cell[] createBoard(int composition)
    {
        CellType[] listTypeCell = ComposeBoard(composition);
        int ncells= listTypeCell.GetLength(0);
        Cell[] Board = new Cell[listTypeCell.GetLength(0)];
        for(int pos=0; pos< ncells; pos++)
        {
            Board[pos]=CellFactory.GetCell(listTypeCell[pos], list_names[pos]);
        }
        return Board;
    }

    //Get a specific cell according to its position in the board.
	public Cell getCell (int position)
    { 
        return this.cells[position];
    }

    //This function returns a list of cell types.
    //All types allowed are registered in the enum CellType in Cell.cs.
    //Thanks to this array of types, the createBoard method knows to which position 
    //assign a specific type of cell with Factory pattern.
    //A type of cell can be got to jail, jail, departure, property etc.
    public CellType[] ComposeBoard(int composition)
    {
        int ncells=40;
        CellType[] types = new CellType[ncells];
        switch (composition)
        {
            default:
                for(int i=0; i<ncells; i++)
                {
                    if(i==30) types[i]=CellType.GoToJailCell;
                    else types[i]=CellType.SimpleCell;
                }
                break;                
        }
        return types;
    }

    //List of names for the cells.
    string[] list_names = {"Departure",
    "Budapest",
    "Sofia",
    "Berlin",
    "Vienne",
    "Berne",
    "Rome",
    "Madrid",
    "Lisbonne",
    "Londres",
    "Jail",
    "Dublin",
    "Oslo",
    "Stockholm",
    "Helsinki",
    "Riga",
    "Varsovie",
    "Moscou",
    "Zagreb",
    "Paris",
    "Bruxelles",
    "Copenhague",
    "Amsterdam",
    "Luxembourg",
    "Monaco",
    "Vilnius",
    "Athenes",
    "Belgrade",
    "Bratislava",
    "Kiev",
    "Go to jail",
    "Tallinn",
    "Lyon",
    "Ljubljana",
    "Podgorica",
    "Chisinau",
    "Pekin",
    "Singapour",
    "Hong Kong",
    "Tokyo"};

}