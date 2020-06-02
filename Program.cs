
using System;
using System.Collections.Generic;

namespace MyNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new Helper();
            var rows = helper.ReadConsoleValue("rows");
            var cols = helper.ReadConsoleValue("cols");
            Console.Clear();
            var matrix1 = new MatrixRW(rows, cols);
            matrix1.GenerateRandomMatrix(10);
            matrix1.WriteMatrixToFile("Matrix1.txt");

            Console.WriteLine("1=======================1");
            Console.WriteLine(matrix1.ToString());

            matrix1.FillMatrixWithValue(1);
            matrix1.WriteMatrixToFile("Matrix2.txt");
            Console.WriteLine("2=======================2");
            Console.WriteLine(matrix1.ToString());

            var matrix2 = new MatrixRW();
            matrix2.ReadMatrixFromFile("Matrix2.txt");
            Console.WriteLine("3=======================3");
            Console.WriteLine(matrix2.ToString());

            var resultMatrix = matrix1.SumMatrix(matrix2);
            Console.WriteLine("4=======================4");
            Console.WriteLine(resultMatrix.ToString());

            resultMatrix = matrix1.MultiplyMatrixToValue(2);
            Console.WriteLine("5=======================5");
            Console.WriteLine(resultMatrix.ToString());

            resultMatrix.WriteMatrixToFile("result.txt");

            var lst = new List<double>() { 1, 2, 3 };
            matrix1.InsertCol(lst, 0);
            Console.WriteLine("6=======================6");
            Console.WriteLine(matrix1.ToString());
            lst.Add(4);
            matrix1.InsertRow(lst, 0);
            Console.WriteLine("7=======================7");
            Console.WriteLine(matrix1.ToString());
            Console.ReadLine();
        }
    }
}
