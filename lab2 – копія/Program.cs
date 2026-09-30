using System;

class Computer
{
    private string _cpu;
    private int _ramGB;
    private int _storageGB;

    public string CPU
    {
        get { return _cpu; }
        set { _cpu = value; }
    }

    public int RAMGB
    {
        get { return _ramGB; }
        set
        {
            if (value > 0)
                _ramGB = value;
            else
                Console.WriteLine("RAM повинна бути більше 0.");
        }
    }

    public int StorageGB
    {
        get { return _storageGB; }
        set
        {
            if (value > 0)
                _storageGB = value;
            else
                Console.WriteLine("Обсяг пам'яті повинен бути більше 0.");
        }
    }

    public Computer() : this("Intel i5", 8, 256)
    {
        Console.WriteLine("Викликано конструктор за замовчуванням.");
    }

    public Computer(string cpu, int ram, int storage)
    {
        CPU = cpu;
        RAMGB = ram;
        StorageGB = storage;

        Console.WriteLine("Викликано параметризований конструктор.");
    }

    public void RunBenchmark()
    {
        Console.WriteLine($"Запуск тесту продуктивності для {CPU}...");
        Console.WriteLine($"RAM: {RAMGB} GB, Storage: {StorageGB} GB");
    }

    ~Computer()
    {
        Console.WriteLine($"Об'єкт Computer з CPU {CPU} знищено.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Створення об'єктів ===");

        Computer computer1 = new Computer();

        Computer computer2 = new Computer(
            "Intel Core i7-12700H",
            16,
            512
        );

        Computer computer3 = new Computer(
            "AMD Ryzen 5 7600",
            32,
            1000
        );

        Console.WriteLine();

        Console.WriteLine("=== Тестування комп'ютерів ===");

        computer1.RunBenchmark();
        Console.WriteLine();

        computer2.RunBenchmark();
        Console.WriteLine();

        computer3.RunBenchmark();

        Console.WriteLine();
        Console.WriteLine("=== Завершення Main ===");

        computer1 = null;
        computer2 = null;
        computer3 = null;

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Збирач сміття завершив роботу.");
    }
}