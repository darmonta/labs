using System;
using System.Collections.Generic;
public interface IChessPiece
{
    string GetPosition();
    List<IChessPiece> GetKillablePieces();
}
public abstract class ChessPiece : IChessPiece
{
    protected string position;
    public ChessPiece(string position)
    {
        this.position = position;
    }
    public string GetPosition()
    {
        return position;
    }
    public abstract List<IChessPiece> GetKillablePieces();
    public bool CanKill(IChessPiece otherPiece)
    {
        List<IChessPiece> killablePieces = GetKillablePieces();
        return killablePieces.Contains(otherPiece);
    }
}
public class Queen : ChessPiece
{
    public Queen(string position) : base(position)
    {
    }
    public override List<IChessPiece> GetKillablePieces()
    {
        List<IChessPiece> killablePieces = new List<IChessPiece>();
        int row = position[1] - '1';
        int col = position[0] - 'A';
        // Проверка горизонтали и вертикали
        for (int i = 0; i < 8; i++)
        {
            if (i != row)
                killablePieces.Add(new Queen($"{(char)('A' + col)}{i + 1}"));
            if (i != col)
                killablePieces.Add(new Queen($"{(char)('A' + i)}{row + 1}"));
        }
 
    // Проверка диагоналей
for (int i = -7; i < 8; i++)
        {
            int newRow = row + i;
            int newCol = col + i;
            if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8 && i != 0)
                killablePieces.Add(new Queen($"{(char)('A' + newCol)}{newRow +
                1}"));
            newRow = row - i;
            newCol = col + i;
            if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8 && i != 0)
                killablePieces.Add(new Queen($"{(char)('A' + newCol)}{newRow +
                1}"));
        }
        return killablePieces;
    }
    ~Queen()
    {
        // Деструктор
        Console.WriteLine("Объект \'Queen' удален");
    }
}
public class Pawn : ChessPiece
{
    public Pawn(string position) : base(position)
    {
    }
    public override List<IChessPiece> GetKillablePieces()
    {
        List<IChessPiece> killablePieces = new List<IChessPiece>();
        int row = position[1] - '1';
        int col = position[0] - 'A';
        // Проверка для белых пешек
        if (row > 0)
        {
            if (col > 0)
                killablePieces.Add(new Pawn($"{(char)('A' + col - 1)}{row}"));
            if (col < 7)
                killablePieces.Add(new Pawn($"{(char)('A' + col + 1)}{row}"));
        }
        // Проверка для черных пешек
       
    if (row < 7)
        {
            if (col > 0)
                killablePieces.Add(new Pawn($"{(char)('A' + col - 1)}{row +
                2}"));
            if (col < 7)
                killablePieces.Add(new Pawn($"{(char)('A' + col + 1)}{row +
                2}"));
        }
        return killablePieces;
    }
    ~Pawn()
    {
        // Деструктор
        Console.WriteLine("Объект \'Pawn' удален");
    }
}
public class Knight : ChessPiece
{
    public Knight(string position) : base(position)
    {
    }
    public override List<IChessPiece> GetKillablePieces()
    {
        List<IChessPiece> killablePieces = new List<IChessPiece>();
        int row = position[1] - '1';
        int col = position[0] - 'A';
        int[] rowOffsets = { -2, -2, -1, -1, 1, 1, 2, 2 };
        int[] colOffsets = { -1, 1, -2, 2, -2, 2, -1, 1 };
        for (int i = 0; i < 8; i++)
        {
            int newRow = row + rowOffsets[i];
            int newCol = col + colOffsets[i];
            if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                killablePieces.Add(new Knight($"{(char)('A' + newCol)}{newRow +
                1}"));
        }
        return killablePieces;
    }
    ~Knight()
    { 

    // Деструктор
    Console.WriteLine("Объект \'Knight' удален");
    }
}
public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Введите фигуру (queen, pawn или knight):");
            string figure = Console.ReadLine();
            if (figure != "queen" && figure != "pawn" && figure != "knight")
            {
                Console.WriteLine("Некорректно введена фигура. Попробуйте  снова.");
                Console.WriteLine();
                continue;
            }
            Console.WriteLine("Введите позицию фигуры (например, D5):");
            string position = Console.ReadLine();
            if (position.Length != 2 || !char.IsLetter(position[0]) ||
            !char.IsDigit(position[1]))
            {
                Console.WriteLine("Некорректно введена позиция фигуры. Попробуйте снова.");
                Console.WriteLine();
                continue;
            }
            ChessPiece selectedPiece = null;
            switch (figure.ToLower())
            {
                case "queen":
                    selectedPiece = new Queen(position);
                    break;
                case "pawn":
                    selectedPiece = new Pawn(position);
                    break;
                case "knight":
                    selectedPiece = new Knight(position);
                    break;
                default:
                    Console.WriteLine("Неизвестная фигура. Попробуйте снова.");
                    Console.WriteLine();
                    continue;
                 
            }
            if (selectedPiece == null)
            {
                Console.WriteLine("Неизвестная фигура. Попробуйте снова.");
                Console.WriteLine();
                continue;
            }
            // Получение списка убиваемых фигур
            List<IChessPiece> killablePieces = selectedPiece.GetKillablePieces();
            Console.WriteLine("Фигура на позиции {0} может убить следующие фигуры: ", selectedPiece.GetPosition());
        foreach (IChessPiece piece in killablePieces)
            {
                Console.WriteLine(piece.GetPosition());
            }
            Console.WriteLine();
        }
    }
}