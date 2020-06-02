using System;
using System.IO;
using System.Text;

namespace MyNameSpace
{
    public class MatrixRW
    {
        /// <summary>
        /// Values of matrix.
        /// </summary>
        public double[,] Array { get; set; }
        /// <summary>
        /// Rows of matrix.
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// Cols of matrix.
        /// </summary>
        public int Cols { get; set; }
        public MatrixRW()
        {
            Array = new double[1, 1];
            Rows = 1;
            Cols = 1;
        }
        public MatrixRW(int rows, int cols)
        {
            Array = new double[rows, cols];
            Rows = rows;
            Cols = cols;
        }
        /// <summary>
        /// Write down Matrix to file.
        /// </summary>
        /// <param name="path"></param>
        public void WriteMatrixToFile(string path)
        {
            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        sw.Write($"{Array[i, j]} ");
                    }
                    sw.WriteLine();
                }
            }
        }
        /// <summary>
        /// Read out Matrix from file.
        /// </summary>
        /// <param name="path"></param>
        public void ReadMatrixFromFile(string path)
        {
            int newRows = 0;
            int newCols = 0;
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                string str;
                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                    if (newRows == 0)
                    {
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i] == ' ' || i == str.Length - 1)
                            {
                                newCols += 1;
                            }
                        }
                    }
                    newRows += 1;
                }
            }
            Array = new double[newRows, newCols];
            Rows = newRows;
            Cols = newCols;
            newRows = 0;
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                string str;
                string str2 = "";
                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                    newCols = 0;
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] != ' ')
                        {
                            str2 += str[i];
                        }
                        if (str[i] == ' ' || i == str.Length - 1)
                        {
                            Array[newRows, newCols] = Convert.ToDouble(str2);
                            str2 = "";
                            newCols += 1;
                        }
                    }
                    newRows += 1;
                }
            }
        }
        /// <summary>
        /// Generation of random values for matrix with maximum value.
        /// </summary>
        /// <param name="maxvalue"></param>
        public void GenerateRandomMatrix(int max)
        {
            var rnd = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Array[i, j] = rnd.Next(max) + rnd.NextDouble(); 
                }
            }
        }
        /// <summary>
        /// Fill all elements of matrix with same value.
        /// </summary>
        /// <param name="value"></param>
        public void FillMatrixWithValue(int value)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Array[i, j] = value;
                }
            }
        }
        public override string ToString()
        {
            string str = "";
            str += $"rows = {Rows}; cols = {Cols};\n";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    str += $"{Array[i, j]} ";
                }
                str += "\n";
            }
            return str;
        }
        public override bool Equals(object obj)
        {
            if ((obj as MatrixRW).Rows != Rows || (obj as MatrixRW).Cols != Cols)
            {
                return false;
            }
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                   if (Array[i, j] != (obj as MatrixRW).Array[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            double sumElements = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    sumElements += Array[i, j];
                }
            }
            return Convert.ToInt32(sumElements); 
        }
        /// <summary>
        /// Multiply matrix to value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MatrixRW MultiplyMatrixToValue(double value)
        {
            var resultMatrix = new MatrixRW(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    resultMatrix.Array[i,j] = Array[i,j] * value;
                }
            }
            return resultMatrix;
        }
        /// <summary>
        /// Sum of two matrixes if they are compound with same sizes. Otherwise return empty matrix.
        /// </summary>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        public MatrixRW SumMatrix(MatrixRW matrix2)
        {
            if (matrix2.Rows!=Rows || matrix2.Cols != Cols)
            {
                return new MatrixRW();
            }
            else
            {
                var resultMatrix = new MatrixRW(Rows, Cols);
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        resultMatrix.Array[i, j] = Array[i, j] + matrix2.Array[i, j];
                    }
                }
                return resultMatrix; 
            }  
        }
        /// <summary>
        /// Get new matrix without i-th row и j-th col.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
    }
}