global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading.Channels;

namespace Matrix_exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\programming\\Visual Studio\\repos\\Matrix_exceptions\\matrix.txt";
            Random random = new Random();
            Matrix matrix1 = new Matrix(5, 5, random);//Создание matrix1  со случайными значениями
            Matrix matrix2 = new Matrix(5, 5, random); // Создание matrix2  со случайными значениями
            
            Console.WriteLine("Матрица 1:");
            matrix1.PrintMatrix();
            Console.WriteLine("\nМатрица 2:");
            matrix2.PrintMatrix();

            Matrix sum = Matrix.Addition(matrix1, matrix2);
            Console.WriteLine($"\nСумма матриц 1 и 2: ");
            sum.PrintMatrix();

            Matrix sub = Matrix.Subtraction(matrix1, matrix2);
            Console.WriteLine("\nРазность матриц 1 и 2: ");
            sub.PrintMatrix();
            
            Matrix mul = Matrix.Multiplication(matrix1, matrix2);
            Console.WriteLine("\nПроизведение матриц 1 и 2: ");
            mul.PrintMatrix();
            mul.WriteToFile(mul, path); // Запись в файл
        }
    }
}