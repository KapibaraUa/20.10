using System;

namespace HomeworkOperators;

public class Matrix
{
    private int[,] _data;

    public int Rows
    {
        get { return _data.GetLength(0); }
    }

    public int Cols
    {
        get { return _data.GetLength(1); }
    }

    public Matrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
        {
            throw new ArgumentOutOfRangeException("Розміри матриці мають бути більшими за 0.");
        }
        _data = new int[rows, cols];
    }

    public Matrix(int[,] data)
    {
        if (data == null || data.GetLength(0) == 0 || data.GetLength(1) == 0)
        {
            throw new ArgumentException("Некоректний масив для матриці.");
        }

        int rows = data.GetLength(0);
        int cols = data.GetLength(1);
        _data = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                _data[i, j] = data[i, j];
            }
        }
    }

    public int this[int r, int c]
    {
        get
        {
            if (r < 0 || r >= _data.GetLength(0))
            {
                throw new Exception("Некоректний індекс рядка: " + r);
            }
            else if (c < 0 || c >= _data.GetLength(1))
            {
                throw new Exception("Некоректний індекс стовпця: " + c);
            }
            else
            {
                return _data[r, c];
            }
        }
        set
        {
            if (r < 0 || r >= _data.GetLength(0))
            {
                throw new Exception("Некоректний індекс рядка: " + r);
            }
            else if (c < 0 || c >= _data.GetLength(1))
            {
                throw new Exception("Некоректний індекс стовпця: " + c);
            }
            else
            {
                _data[r, c] = value;
            }
        }
    }

    public void FillRandom(int min = 1, int max = 10)
    {
        Random rand = new Random();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                _data[i, j] = rand.Next(min, max);
            }
        }
    }

    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
        {
            throw new Exception("Для додавання матриці повинні мати однакові розміри.");
        }

        Matrix result = new Matrix(m1.Rows, m1.Cols);
        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m1.Cols; j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }
        return result;
    }

    public static Matrix operator -(Matrix m1, Matrix m2)
    {
        if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
        {
            throw new Exception("Для віднімання матриці повинні мати однакові розміри.");
        }

        Matrix result = new Matrix(m1.Rows, m1.Cols);
        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m1.Cols; j++)
            {
                result[i, j] = m1[i, j] - m2[i, j];
            }
        }
        return result;
    }

    public static Matrix operator *(Matrix m, int number)
    {
        Matrix result = new Matrix(m.Rows, m.Cols);
        for (int i = 0; i < m.Rows; i++)
        {
            for (int j = 0; j < m.Cols; j++)
            {
                result[i, j] = m[i, j] * number;
            }
        }
        return result;
    }

    public static Matrix operator *(int number, Matrix m)
    {
        return m * number;
    }

    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        if (m1.Cols != m2.Rows)
        {
            throw new Exception("Кількість стовпців першої матриці повинна дорівнювати кількості рядків другої.");
        }

        Matrix result = new Matrix(m1.Rows, m2.Cols);
        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m2.Cols; j++)
            {
                int sum = 0;
                for (int k = 0; k < m1.Cols; k++)
                {
                    sum += m1[i, k] * m2[k, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }

    public static bool operator ==(Matrix? m1, Matrix? m2)
    {
        if (ReferenceEquals(m1, m2))
        {
            return true;
        }
        if (m1 is null || m2 is null)
        {
            return false;
        }
        if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
        {
            return false;
        }

        for (int i = 0; i < m1.Rows; i++)
        {
            for (int j = 0; j < m1.Cols; j++)
            {
                if (m1[i, j] != m2[i, j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator !=(Matrix? m1, Matrix? m2)
    {
        return !(m1 == m2);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Matrix other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Rows.GetHashCode() ^ Cols.GetHashCode();
    }

    public override string ToString()
    {
        string result = string.Empty;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                result += _data[i, j] + "\t";
            }
            result += "\n";
        }
        return result;
    }
}