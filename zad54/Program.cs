/* Задача 54 Задайте двумерный массив. Напишите программу, которая упорядочит
по убыванию элементы каждой строки двумерного массива.
Например, задан массив
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив
7 4 2 1
9 5 3 2
8 4 4 2
*/

//Метод провеки на валидность вводимых элементов размерности матрицы
int GetNumber(string message)
{
    int result = 0;
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out result) && result > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Ввели не размер массива. Введите размер ммассива");
        }
    }
    return result;
}

//Метод заполнения матрицы случайными числами
int[,] GetMatrix(int row, int column)
{
    int[,] matrix = new int[row, column];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(0, 20);
        }
    }
    return matrix;
}

//Метод вывода матрицы на экран
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write("{0,4:0.#}", matrix[i, j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

//Метод расположения элементов массива по убыванию (минимакс)
int[,] SortMatrixToDecrease(int[,] matrix)
{
    int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
    int[] array = new int[matrix.GetLength(0)*matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            array[j]=matrix[i,j];
        }
        Array.Sort(array);
        Array.Reverse(array);
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            newMatrix[i,k]=array[k];
        }
    }
    return newMatrix;
}


int m = GetNumber(" Введите размер матрицы [i, ]= ");
int n = GetNumber(" Введите размер матрицы [ ,j] = ");
int[,] myMatrix = GetMatrix(m, n);
Console.WriteLine("Случайная матрица");
PrintMatrix(myMatrix);
Console.WriteLine("Отсортированная матрица по строкам по убыванию");
PrintMatrix(SortMatrixToDecrease(myMatrix));