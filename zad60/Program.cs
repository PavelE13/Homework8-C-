/* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных
чисел. Напишите программу, которая будет построчно выводить массив, добавляя
индексы каждого элемента.
Массив размером 2 x 2 x 2

66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

/*//Метод провеки на валидность вводимых элементов размерности матрицы
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
}*/

//Метод заполнения матрицы случайными числами
int[,,] GetMatrix(int row, int column, int depth)
{
    int[,,] matrix = new int[row, column, depth];
    Random rnd = new Random((int)DateTime.Now.Ticks);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                matrix[i, j, k] = rnd.Next(10, 100);
            }
        }
    }
    return matrix;
}

//Метод вывода матрицы на экран
void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write("{0,5:0.##}[{1},{2},{3}]", matrix[i, j, k], i, j, k );
            }
            Console.WriteLine();
        }
    }
}

//int m = GetNumber(" Введите размер матрицы [i, , ]= ");
//int n = GetNumber(" Введите размер матрицы [ ,j, ] = ");
//int p = GetNumber(" Введите размер матрицы [ , , k] = ");
int[,,] myMatrix = GetMatrix(2, 2, 2);
Console.WriteLine("3-х мерная матрица 2х2х2");
PrintMatrix(myMatrix);

