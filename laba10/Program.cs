using System;
using System.IO;

class ФормировательФайлаДанных
{
    public ФормировательФайлаДанных()
    {
        СгенерироватьДанные();
    }

    private void СгенерироватьДанные()
    {
        Random random = new Random();
        int размер = random.Next(1, 2000); // Сгенерировать случайный размер вектора
        if (размер % 2 == 0)
        {
            размер += 1;
        }
        int i = random.Next(0, размер); // Сгенерировать случайный индекс i
        if (i % 2 == 0)
        {
            i += 1;
        }
        int j = random.Next(0, размер); // Сгенерировать случайный индекс j
        if (j % 2 == 0)
        {
            j += 1;
        }

        // Убедиться, что i и j различны
        while (i == j)
        {
            j = random.Next(0, размер);
            if (j % 2 == 0)
            {
                j += 1;
            }
        }

        int A = random.Next(-500, 500); // Сгенерировать случайное значение для A
        if (A % 2 == 0)
        {
            A += 1;
        }

        // Сгенерировать элементы вектора
        int[] элементы = new int[размер];
        for (int k = 0; k < размер; k++)
        {
            элементы[k] = random.Next(-500, 500);
        }

        // Записать данные в файл
        using (StreamWriter writer = new StreamWriter("Inlet.in"))
        {
            writer.WriteLine($"{размер} {i} {j} {A}");
            foreach (int элемент in элементы)
            {
                writer.WriteLine(элемент);
            }
        }
    }
}

class Вектор
{
    public int[] элементыа;
    public int[] элементы;
    public int i { get; private set; }
    public int j { get; private set; }
    public int A { get; private set; }

    public Вектор(string путьКФайлу)
    {
        string[] строки = File.ReadAllLines(путьКФайлу);
        int размер = int.Parse(строки[0].Split(' ')[0]);
        элементы = new int[размер];
        i = int.Parse(строки[0].Split(' ')[1]);
        j = int.Parse(строки[0].Split(' ')[2]);
        A = int.Parse(строки[0].Split(' ')[3]);
        for (int i = 0; i < размер; i++)
        {
            элементы[i] = int.Parse(строки[i + 1]);
        }
    }

    public void ПоменятьЭлементы(int i, int j)
    {
        if (i >= 0 && i < элементы.Length && j >= 0 && j < элементы.Length)
        {
            int временный = элементы[i];
            элементы[i] = элементы[j];
            элементы[j] = временный;
        }
    }

    public void ВывестиЭлементы()
    {
        foreach (int элемент in элементы)
        {
            Console.WriteLine(элемент);
        }
    }

    public void СоздатьНовыйВектор(int A)
    {
        List<int> элементыList = new List<int>();
        for (int k = 0; k < элементы.Length; k++)
        {
            if (элементы[k] <= A)
            {
                элементыList.Add(элементы[k]);
            }
        }
        элементыа = элементыList.ToArray();
    }

    public void ВывестиЭлементыА()
    {
        foreach (int элемент in элементыа)
        {
            Console.WriteLine(элемент);
        }
    }

    public void расчет()
    {
        int a = 0;
        for (int k = 0; k < элементы.Length; k++)
        {
            if (элементы[k] == 0)
            {
                a++;
            }
        }
        Console.WriteLine(a);
    }

    public void поиск()
    {
        int min = int.MaxValue;
        for (int k = 0; k < элементы.Length; k++)
        {
            if (элементы[k] < min)
            {
                min = элементы[k];
            }
        }
        Console.WriteLine(min);
    }
}


class Program
{
    static void Main(string[] args)
    {
        ФормировательФайлаДанных генераторФайлаДанных = new ФормировательФайлаДанных();
        Console.WriteLine("Файл 'Inlet.in' был сгенерирован.");

        Вектор вектор = new Вектор("Inlet.in");
        Console.WriteLine("Элементы вектора:");
        вектор.ВывестиЭлементы();

        Console.WriteLine("Меняем элементы вектора:");
        вектор.ПоменятьЭлементы(вектор.i, вектор.j);
        вектор.ВывестиЭлементы();

        Console.WriteLine("Новый вектор, значения элементов которого меньше A: ");
        вектор.СоздатьНовыйВектор(вектор.A);
        вектор.ВывестиЭлементыА();

        Console.WriteLine("Количество нулевых элементов:");
        вектор.расчет();

        Console.WriteLine("Минимальный элемент:");
        вектор.поиск();
    }
}
