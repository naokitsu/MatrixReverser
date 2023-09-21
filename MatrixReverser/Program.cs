/// <summary>
/// Лабараторная работа 1
/// Задание 1. 
/// В двумерном целочисленном массиве размером 4 строки, 5 столбцов поменяйте местами строки, 
/// симметричные относительно середины массива (вертикальной линии).
/// </summary>
class MatrixReverser
{
    /// <summary>
    /// Заполнить массив используя консольный ввод
    /// </summary>
    /// <param name="array">Массив для заполнения</param>
    /// <param name="width">Ширина</param>
    /// <param name="height">Высота</param>
    private static void fill_matrix(int[,] array, int width, int height)
    {
        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                string? line;
                var fail = false;
                do
                {
                    fail = false;
                    try
                    {
                        Console.WriteLine("Input the cell [{0}, {1}]: ", i, j);
                        line = Console.ReadLine();
                        array[j, i] = int.Parse(line);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("Value is too big/small, try again");
                        fail = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unable to parse the number, try again");
                        fail = true;
                    }
                } while (fail);
            }
        }
    }
    
    /// <summary>
    /// Заполнить массив используя случайными значениями
    /// </summary>
    /// <param name="array">Массив для заполнения</param>
    /// <param name="width">Ширина</param>
    /// <param name="height">Высота</param>
    /// <param name="min_random">Минимальное значение (-10 по умолчанию)</param>
    /// <param name="max_random">Максимально значение (10 по умолчанию)</param>
    private static void fill_random(int[,] array, int width, int height, int min_random = -10, int max_random = 10)
    {
        var rand = new Random();
        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                array[j, i] = Math.Abs(rand.Next())%(max_random - min_random) + min_random;
            }
        }
    }

    /// <summary>
    /// Напечатать таблицу в стандартный вывод
    /// </summary>
    /// <param name="array">Массив для вывода</param>
    /// <param name="width">Ширина</param>
    /// <param name="height">Высота</param>
    private static void print_matrix(int[,] array, int width, int height)
    {
        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                Console.Write("{0}\t", array[j, i]);
            }
            Console.Write('\n');
        }
    }
    
    /// <summary>
    /// В двумерном целочисленном массиве меняет местами строки, 
    /// симметричные относительно середины массива (вертикальной линии).
    /// </summary>
    /// <param name="array">Массив для реверсирования</param>
    /// <param name="width">Ширина</param>
    /// <param name="height">Высота</param>
    private static void reverse_matrix(int[,] array, int width, int height)
    {
        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width / 2; j++)
            {
                (array[j, i], array[width - 1 - j, i]) = (array[width - 1 - j, i], array[j, i]);
            }
        }
    }


    
    public static void Main(string[] args)
    {
        const int defaultHeight = 4;
        const int defaultWidth = 5;
        int height;
        int width;
        Console.WriteLine("Enter dimensions:\nHeight [<Enter> to use the default value: {0}]: ", defaultHeight);
        try
        {
            height = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            height = defaultHeight;
        }
        
        Console.WriteLine("Width: [<Enter> to use the default value: {0}]: ", defaultWidth);
        try
        {
            width = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            width = defaultWidth;
        }


        var array = new int[width, height];
        
        print_matrix(array, width, height);
        
        Console.WriteLine("Do you want to fill the matrix using random? [Y - Yes]");
        if (Console.ReadLine() == "Y")
        {
            fill_random(array, width, height);
        }
        else
        {
            fill_matrix(array, width, height);
        }
        
        Console.WriteLine("Matrix:");
        print_matrix(array, width, height);
        
        Console.WriteLine("Reversed:");
        reverse_matrix(array, width, height);
        print_matrix(array, width, height);

    }
}
