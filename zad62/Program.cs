/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

//Метод заполнения матрицы по спирали - данные для цикла
int[,] GetMatrix(int row, int column)
{
    int[,] matrix = new int[row, column];
    int count = 1;
    int start = 0;
    int correctHorizontalAllig = column - 1;
    int correctVerticalAllig = row - 1;
    for (int i = start; i < column; i++)
    {
        matrix[start, i] = count++;
    }
    for (int j = start+1; j < row; j++)
    {
        matrix[j, correctHorizontalAllig] = count++;
    }
    for (int k = correctHorizontalAllig - 1; k >= start; k--)
    {
        matrix[correctHorizontalAllig, k] = count++;
    }
    for (int l = correctVerticalAllig - 1; l >= start+1; l--)
    {
        matrix[l, start] = count++;
    }
    for (int m = start+1; m < column-1; m++)
    {
        matrix[start+1, m] = count++;
    }
    for (int n = correctHorizontalAllig-1; n > start; n--)
    {
        matrix[correctHorizontalAllig-1, n] = count++;
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
            Console.Write("{0,5:0.##}", matrix[i, j]);
        }
        Console.WriteLine();
    }
}

int[,] myMatrix = GetMatrix(4, 4);
Console.WriteLine("2-х мерная матрица 4х4 заполненные спирально");
PrintMatrix(myMatrix);

