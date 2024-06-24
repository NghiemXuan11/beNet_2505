using System;
using System.Collections.Generic;

public class MyStack<T>
{
    private List<T> elements = new List<T>();

    // Thêm một phần tử vào đỉnh stack.
    public void Push(T item)
    {
        elements.Add(item);
    }

    // Lấy và xóa phần tử ở đỉnh stack.
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        T item = elements[elements.Count - 1];
        elements.RemoveAt(elements.Count - 1);
        return item;
    }

    // Lấy phần tử ở đỉnh stack nhưng không xóa.
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return elements[elements.Count - 1];
    }

    // Kiểm tra stack có rỗng không.
    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    // Hiển thị các phần tử trong stack.
    public void Show()
    {
        Console.WriteLine("Stack elements:");
        for (int i = elements.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(elements[i]);
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Select stack type: 1. int  2. string  3. double");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                RunStack<int>(ParseInt);
                break;
            case "2":
                RunStack<string>(x => x);
                break;
            case "3":
                RunStack<double>(ParseDouble);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }

    static void RunStack<T>(Func<string, T> parseFunction)
    {
        MyStack<T> stack = new MyStack<T>();
        string command;
        do
        {
            Console.WriteLine("Enter command (push, pop, peek, show, exit):");
            command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "push":
                    Console.WriteLine("Enter value:");
                    string inputValue = Console.ReadLine();
                    try
                    {
                        T value = parseFunction(inputValue);
                        stack.Push(value);
                        stack.Show();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid input: " + ex.Message);
                    }
                    break;
                case "pop":
                    try
                    {
                        T poppedValue = stack.Pop();
                        Console.WriteLine("Popped: " + poppedValue);
                        stack.Show();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;
                case "peek":
                    try
                    {
                        T peekedValue = stack.Peek();
                        Console.WriteLine("Peek: " + peekedValue);
                        stack.Show();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;
                case "show":
                    stack.Show();
                    break;
                case "exit":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        } while (command != "exit");
    }

    static int ParseInt(string input)
    {
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        throw new FormatException("Input is not a valid integer");
    }

    static double ParseDouble(string input)
    {
        if (double.TryParse(input, out double result))
        {
            return result;
        }
        throw new FormatException("Input is not a valid double");
    }
}
