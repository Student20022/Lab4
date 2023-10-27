using System.Drawing;

public class TSMatrix
{
    public int[,] matrix;
    public int size;

    public TSMatrix()
    {
        size = 0;
        matrix = new int[size, size];
    }

    public TSMatrix(int size)
    {
        this.size = size;
        matrix = new int[size, size];
    }

    public TSMatrix(TSMatrix other)
    {
        size = other.size;
        matrix = other.matrix;
    }

    public void InputData()
    {
        // Введення даних
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                matrix[i, j] = int.Parse(Console.ReadLine());
    }

    public void OutputData()
    {
        // Виведення даних
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }

    public int FindMax()
    {
        // Знаходження максимального елемента
        int max = matrix[0, 0];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (matrix[i, j] > max)
                    max = matrix[i, j];
        return max;
    }

    public int FindMin()
    {
        // Знаходження мінімального елемента
        int min = matrix[0, 0];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];
        return min;
    }

    public int SumElements()
    {
        // Знаходження суми елементів
        int sum = 0;
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                sum += matrix[i, j];
        return sum;
    }

    public static TSMatrix operator +(TSMatrix a, TSMatrix b)
    {
        // Додавання матриць
        TSMatrix result = new TSMatrix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int j = 0; j < a.size; j++)
                result.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
        return result;
    }

    public static TSMatrix operator -(TSMatrix a, TSMatrix b)
    {
        // Віднімання матриць
        TSMatrix result = new TSMatrix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int j = 0; j < a.size; j++)
                result.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
        return result;
    }
}

public class TMSMatrix : TSMatrix
{
    public TMSMatrix() : base() { }

    public TMSMatrix(int size) : base(size) { }

    public TMSMatrix(TSMatrix other) : base(other) { }

    public void Transpose()
    {
        // Транспонування матриці
        for (int i = 0; i < size - 1; i++)
            for (int j = i + 1; j < size; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[j, i];
                matrix[j, i] = temp;
            }
    }

    public static TMSMatrix operator *(TMSMatrix a, TMSMatrix b)
    {
        // Множення матриць
        TMSMatrix result = new TMSMatrix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int k = 0; k < a.size; k++)
                for (int j = 0; j < a.size; j++)
                    result.matrix[i, k] += a.matrix[i, k] * b.matrix[k, k];
        return result;
    }

    public static TMSMatrix operator *(TMSMatrix a, int number)
    {
        // Множення матриці на число
        TMSMatrix result = new TMSMatrix(a.size);
        for (int i = 0; i < a.size; i++)
            for (int j = 0; j < a.size; j++)
                result.matrix[i, j] = a.matrix[i, j] * number;
        return result;
    }

    public int FindDeterminant()
    {
        // Знаходження визначника
        int det = 1;
        for (int i = 0; i < size; i++)
            det *= matrix[i, i];
        return det;
    }
}
class Program
{
    static void Main(string[] args)
    {
        TSMatrix matrix1 = new TSMatrix(3);
        matrix1.InputData();
        matrix1.OutputData();

        TMSMatrix matrix2 = new TMSMatrix(3);
        matrix2.InputData();
        matrix2.OutputData();
    }
}
