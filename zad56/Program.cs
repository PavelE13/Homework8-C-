/* Задача 56 Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с 
наименьшей суммой элементов 1 строка
*/

//Метод провеки на валидность вводимых элементов размерности массива
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

//Метод заполнения массива случайными числами
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
            Console.Write("{0,-10:0.#}", matrix[i, j]);
        }
        Console.WriteLine();
    }
}

// Проверка размерности массива на прямоугольный массив
bool CheckMatrix(int row, int column)
{
    int[,] matrix = new int[row, column];

    if (matrix.GetLength(0) != matrix.GetLength(1))
    {
        return true;
    }
    else
    {
        return false;
    }
}
//Метод расчета суммы строк и определения наименьшей суммы строк
(int[], int) MinimalSumOfMatrix(int[,] matrix)
{
    int[] array = new int[matrix.GetLength(0)];
    int minRow = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i, j];
        }
        array[i] = sum;
    }
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] < array[minRow]) minRow = i;
    }
return (array, minRow + 1);
}

//Метод вывода маcсива с суммой строк на экран
void PrintArray(int[] array)
{
    Console.WriteLine("Cумма строк матрицы");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{i + 1}={array[i]} | ");
    }
    Console.WriteLine();
}

int m = GetNumber(" Введите размер матрицы [i, ]= ");
int n = GetNumber(" Введите размер матрицы [ ,j] = ");
if (CheckMatrix(m,n)) 
{int[,] myMatrix = GetMatrix(m, n);
Console.WriteLine("Случайная матрица");
PrintMatrix(myMatrix);
(int[] myArray, int myMinRow) = MinimalSumOfMatrix(myMatrix);
PrintArray(myArray);
Console.WriteLine($"Номер строки с наименьшей суммой элементов = {myMinRow}");
}
else
{
Console.WriteLine("Матрица не прямоугольная!Прерывание.");
}