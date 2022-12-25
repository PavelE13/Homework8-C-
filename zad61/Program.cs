/* Задача 61: Вывести первые N строк треугольника Паскаля. Сделать вывод в 
виде равнобедренного треугольника. Задачка со звездочкой
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
            Console.WriteLine("Ввели не количество рядов. Введите натуральное число!");
        }
    }
    return result;
}

//Заполнение треугольника
int[,] FeelTrianglePascal(int row)
{
    int[,] matrixTrianglePascal = new int[row, row];
    for (int i = 0; i < row; i++)
    {
        matrixTrianglePascal [i, 0]=1;
        matrixTrianglePascal [i, i]=1;
    }
    for (int i = 2; i < row; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            matrixTrianglePascal[i,j]=matrixTrianglePascal[i-1,j-1]+matrixTrianglePascal[i-1,j];
        }
    }
    return matrixTrianglePascal;
}

//Метод вывода матрицы(треугольника) на экран
void PrintMatrix(int[,] matrixTrianglePascal)
{
    Console.WriteLine("\n\n\n");
    for (int i = 0; i < matrixTrianglePascal.GetLength(0); i++)
    {
        for (int j = 0; j < matrixTrianglePascal.GetLength(1); j++)
        {
            if(matrixTrianglePascal[i,j]!=0)
            Console.Write("{0,5:0.##}", matrixTrianglePascal[i, j]);
        }
        Console.WriteLine();
    } 
    Console.WriteLine("\n");
}

/*//Корректировка вывода треугольика
void BestPrintMatrix (int[,] matrixTrianglePascal)
{
    int dist=10;
    int fixDistance=matrixTrianglePascal.GetLength(0)*dist;
    for (int i = 0; i < matrixTrianglePascal.GetLength(0); i++)
    {
        for (int j = 0; j <= i; j++)
        {
            Console.SetCursorPosition(fixDistance,i+1);
            if(matrixTrianglePascal[i,j]!=0) Console.Write("*");
            fixDistance+=dist*2;
        }
        fixDistance=dist*matrixTrianglePascal.GetLength(0) - dist*(i+1);
        Console.WriteLine();
    }
}*/

int n = GetNumber(" Введите количество рядов треугольника Паскаля= ");
int[,] myTrianglePascal=FeelTrianglePascal(n);
PrintMatrix(myTrianglePascal);
//BestPrintMatrix(myTrianglePascal);