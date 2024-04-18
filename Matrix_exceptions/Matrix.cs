namespace Matrix_exceptions;

// Данный класс реализует функционал математического объекта «матрица». 
public class Matrix
{
    private int Cols { get; set; }
    public int Rows { get; set;}
    private int[,] array;
    private Random random = new Random();
    
    // Конструктор класса.
    public Matrix() {}

    // Конструктор класса для инициализации матрицы заданными значениями.
    public Matrix(int cols, int rows)
    {
        InitializeColsRows(cols, rows);
    }
    
    // Конструктор класса для инициализации матрицы случайными значениями.
    public Matrix(int cols, int rows, Random random)
    {
        InitializeRandom(random);
    }
    
    // метод инициализации матрицы заданым размером.
    private void InitializeColsRows(int cols, int rows)
    {
        this.Cols = cols;
        this.Rows = rows;
        array = new int[this.Cols, this.Rows];
    }
    
    // метод инициализации матрицы cлучайными значениями.
    public void InitializeRandom(Random random)
    {
        for (int i = 0; i < this.Cols; i++)
        {
            for (int j = 0; j < this.Rows; j++)
            {
                array[i, j] = random.Next(100);
            }
        }
    }
    
    
}
