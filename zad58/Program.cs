/* Задача 58 Задайте две матрицы. Напишите программу, которая будет находить 
произведение двух матриц. Например, даны 2 матрицы
2 4  3 4
3 2  3 3
Результирующая матрица будет
18 16
21 18
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

//Метод вывода перемноженной матрицы на экран
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write("{0,-5:0.#}", matrix[i, j]);
        }
        Console.WriteLine();
    }
}

// Проверка размерности массива на квадратный массив (строки=столбцам)
bool CheckMatrix(int row, int column)
{
    int[,] matrix = new int[row, column];

    if (matrix.GetLength(0) == matrix.GetLength(1))
    {
        return true;
    }
    else
    {
        return false;
    }
}
/*Метод перемножения квадратной матрицы 
M   {a1,b1} x {c1,d1}={a1*c1+b1*c2,a1*d1+b1*d2}
    {a2,b2}   {c2,d2} {a2*c1+b2*c2, a2*d1+b2*d2}
*/
int[,] MultiplyQuadroMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] multiplyMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            for (int k = 0; k < matrix2.GetLength(0); k++)
            {
                multiplyMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return multiplyMatrix;
}

int m = GetNumber(" Введите размер матрицы [i, ]= ");
int n = GetNumber(" Введите размер матрицы [ ,j] = ");
if (CheckMatrix(m, n))
{
    int[,] myMatrix1 = GetMatrix(m, n);
    /*int[,] myMatrix1 = {
    {2,4},
    {3,4}
    };
    int[,] myMatrix2 = {
    {3,2},
    {3,3}
    };*/
    int[,] myMatrix2 = GetMatrix(m, n);
    Console.WriteLine("Случайная матрица1");
    PrintMatrix(myMatrix1);
    Console.WriteLine("Случайная матрица2");
    PrintMatrix(myMatrix2);
    int[,] mutiplyMyMatrix = MultiplyQuadroMatrix(myMatrix1, myMatrix2);
    Console.WriteLine("Перемноженная матрица");
    PrintMatrix(mutiplyMyMatrix);
}
else
{
    Console.WriteLine("Матрицы разного размера. Перемножить их неьзя!");
}