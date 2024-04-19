using System;

namespace Matrix_exceptions
{
    public class MatrixException : ApplicationException
    {
        public MatrixException() : base() { }
        public MatrixException(string message) : base(message) { }
        public MatrixException(string message, Exception innerException) : base(message, innerException) { }
        protected MatrixException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class Matrix
    {
        private int Cols { get; set; }
        public int Rows { get; set; }
        private int[,] array;
        private Random random = new Random();

        // Конструктор класса.
        public Matrix() { }

        // Конструктор класса для инициализации матрицы заданным размером.
        public Matrix(int cols, int rows)
        {
            try
            {
                InitializeColsRows(cols, rows);
            }
            catch (MatrixException ex)
            {
                Console.WriteLine($"Ошибка при создании матрицы: {ex.Message}");
            }
        }

        // Конструктор класса для инициализации матрицы случайными значениями.
        public Matrix(int cols, int rows, Random random)
        {
            try
            {
                InitializeColsRows(cols, rows); // инициализация матрицы
                InitializeRandom(random);
            }
            catch (MatrixException ex)
            {
                Console.WriteLine($"Ошибка при создании матрицы: {ex.Message}");
            }

        }

        // метод инициализации матрицы заданым размером.
        private void InitializeColsRows(int cols, int rows)
        {
            try
            {
                if (cols <= 0 || rows <= 0)
                {
                    throw new MatrixException("Размер матрицы должен быть положительным числом.");
                }

                this.Cols = cols;
                this.Rows = rows;
                array = new int[this.Cols, this.Rows];
            }
            catch (Exception ex)
            {
                throw new MatrixException("Ошибка при инициализации матрицы.", ex);
            }
        }

        // метод инициализации матрицы случайными значениями.
        public void InitializeRandom(Random random)
        {
            try
            {
                if (random == null)
                {
                    throw new MatrixException("Ссылка на объект Random не указывает на экземпляр.");
                }
                for (int i = 0; i < this.Cols; i++)
                {
                    for (int j = 0; j < this.Rows; j++)
                    {
                        array[i, j] = random.Next(100);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new MatrixException("Ошибка при инициализации матрицы случайными значениями.", ex);
            }
        }

        // Получение элемента матрицы.
        public int GetElement(int col, int row)
        {
            try
            {
                if (col < 0 || col >= Cols || row < 0 || row >= Rows)
                {
                    throw new MatrixException("Индексы выходят за границы матрицы.");
                }
                return array[col, row];
            }
            catch (Exception ex)
            {
                throw new MatrixException("Ошибка при получении элемента матрицы.", ex);
            }
        }

        // Установка значения элемента матрицы.
        public void SetElement(int col, int row, int value)
        {
            try
            {
                if (col < 0 || col >= Cols || row < 0 || row >= Rows)
                {
                    throw new MatrixException("Индексы выходят за границы матрицы.");
                }
                array[col, row] = value;
            }
            catch (Exception ex)
            {
                throw new MatrixException("Ошибка при установке значения элемента матрицы.", ex);
            }
        }

        // Печать матрицы   
        public void PrintMatrix()
        {
            try
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                throw new MatrixException("Ошибка при печати матрицы.", ex);
            }
        }

        // Сложение матриц.
        public static Matrix Addition(Matrix a, Matrix b)
        {
            try
            {
                if (a.Cols != b.Cols || a.Rows != b.Rows)
                {
                    throw new MatrixException("Невозможно сложить матрицы разной размерности.");
                }
                Matrix result = new Matrix(a.Cols, a.Rows);
                for (int i = 0; i < a.Cols; i++)
                {
                    for (int j = 0; j < a.Rows; j++)
                    {
                        result.array[i, j] = a.array[i, j] + b.array[i, j];
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new MatrixException("Ошибка при сложении матриц.", ex);
            }
        }

        // Вычитание матриц.
        public static Matrix Subtraction(Matrix a, Matrix b)
        {
            try
            {
                if (a.Cols != b.Cols || a.Rows != b.Rows)
                {
                    throw new MatrixException("Невозможно вычесть матрицы разной размерности.");
                }
                Matrix result = new Matrix(a.Cols, a.Rows);
                for (int i = 0; i < a.Cols; i++)
                {
                    for (int j = 0; j < a.Rows; j++)
                    {
                        result.array[i, j] = a.array[i, j] - b.array[i, j];
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new MatrixException("Ошибка при вычитании матриц.", ex);
            }
        }
        
        // Умножение матриц.
        public static Matrix Multiplication(Matrix a, Matrix b)
        {
            try
            {
                if (a.Cols != b.Rows)
                {
                    throw new MatrixException("Невозможно умножить матрицы с данными размерностями.");
                }
                Matrix result = new Matrix(b.Cols, a.Rows);

                for (int i = 0; i < result.Rows; i++)
                {
                    for (int j = 0; j < result.Cols; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < a.Cols; k++)
                        {
                            sum += a.array[i, k] * b.array[k, j];
                        }
                        result.array[i, j] = sum;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new MatrixException("Ошибка при умножении матриц.", ex);
            }
        }
        
        // запись в файл
        public void WriteToFile(Matrix matrix, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Cols; j++)
                        {
                            writer.Write(array[i, j] + "\t");
                        }
                        writer.WriteLine();
                    }
                }
                Console.WriteLine("Матрица успешно записана в файл.");
            }
            catch (Exception ex)
            {
                throw new MatrixException($"Ошибка при записи матрицы в файл: {ex.Message}", ex);
            }
        }
    }
}
