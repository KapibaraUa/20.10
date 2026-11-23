using System;

namespace HomeworkOperators;

public class Employee
{
    private string _name;
    private string _position;
    private decimal _salary;

    public string Name
    {
        get { return _name; }
        set
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentException("Ім'я не може бути порожнім.");
            }
            _name = value;
        }
    }

    public string Position
    {
        get { return _position; }
        set
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentException("Посада не може бути порожньою.");
            }
            _position = value;
        }
    }

    public decimal Salary
    {
        get { return _salary; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Зарплата не може бути від'ємною.");
            }
            _salary = value;
        }
    }

    public Employee()
    {
        _name = "Невідомо";
        _position = "Стажер";
        _salary = 0;
    }

    public Employee(string name, string position, decimal salary)
    {
        _name = string.Empty;
        _position = string.Empty;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public static Employee operator +(Employee emp, decimal amount)
    {
        decimal newSalary = emp.Salary + amount;
        if (newSalary < 0)
        {
            newSalary = 0;
        }
        return new Employee(emp.Name, emp.Position, newSalary);
    }

    public static Employee operator +(decimal amount, Employee emp)
    {
        return emp + amount;
    }

    public static Employee operator -(Employee emp, decimal amount)
    {
        decimal newSalary = emp.Salary - amount;
        if (newSalary < 0)
        {
            newSalary = 0;
        }
        return new Employee(emp.Name, emp.Position, newSalary);
    }

    public static Employee operator ++(Employee emp)
    {
        return new Employee(emp.Name, emp.Position, emp.Salary + 500);
    }

    public static Employee operator --(Employee emp)
    {
        decimal newSalary = emp.Salary - 500;
        if (newSalary < 0)
        {
            newSalary = 0;
        }
        return new Employee(emp.Name, emp.Position, newSalary);
    }

    public static bool operator ==(Employee? emp1, Employee? emp2)
    {
        if (ReferenceEquals(emp1, emp2))
        {
            return true;
        }
        if (emp1 is null || emp2 is null)
        {
            return false;
        }
        return emp1.Salary == emp2.Salary;
    }

    public static bool operator !=(Employee? emp1, Employee? emp2)
    {
        return !(emp1 == emp2);
    }

    public static bool operator >(Employee emp1, Employee emp2)
    {
        return emp1.Salary > emp2.Salary;
    }

    public static bool operator <(Employee emp1, Employee emp2)
    {
        return emp1.Salary < emp2.Salary;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Employee other)
        {
            return this.Salary == other.Salary;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Salary.GetHashCode();
    }

    public override string ToString()
    {
        return $"Співробітник: {Name}, Посада: {Position}, Зарплата: {Salary} грн";
    }
}