namespace SecondLesson;

public static class Program
{
    public static void Main()
    {
        CommunicationWithUser a = new CommunicationWithUser();
        Vector b = new Vector(0, 0);
        Vector[] ArrayVector = new Vector[a.IntegerForUser("Сколько весторов надо?")];
        a.RecordArray(ArrayVector);
        while (true)
        {
            a.MessageToUser("Хочешь большой вектор? Да/Нет");
            if (Console.ReadLine() == "Да")
            {
                int x = a.IntegerForUser("Укажите номер вектора");
                int y = a.IntegerForUser("Укажите номер вектора");
                a.OutputDataVector(b.Sum(ArrayVector, x, y));
            }
            a.MessageToUser("Хочешь обрезать вектор? Да/Нет");
            if (Console.ReadLine() == "Да")
            {
                int x = a.IntegerForUser("Из какого будем вычетать?");
                int y = a.IntegerForUser("А какой будем вычетать?");
                a.OutputDataVector(b.Subtraction(ArrayVector, x, y));
            }
            a.MessageToUser("Продолжаем? Да/Нет");
            if (Console.ReadLine() == "Нет")
            {
                a.MessageToUser("Ну и пиздуй");
                return;
            }
        }


    }
}


public class Vector
{
    public int X { get; set; }

    public int Y { get; set; }


    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Vector Sum(Vector[] ArrayVectorOff, int a, int b)
    {
        Vector newVector = new Vector(ArrayVectorOff[a].X + ArrayVectorOff[b].X, ArrayVectorOff[a].Y + ArrayVectorOff[b].Y);
        return newVector;
    }
    public Vector Subtraction(Vector[] ArrayVectorOff, int a, int b)
    {
        Vector newVector = new Vector(ArrayVectorOff[a].X - ArrayVectorOff[b].X, ArrayVectorOff[a].Y - ArrayVectorOff[b].Y);
        return newVector;
    }

}


public class CommunicationWithUser
{
    Vector a;

    public void MessageToUser(string message)
    {
        Console.Write(message);
    }

    public void OutputDataVector(Vector OutputVector)
    {

        Console.WriteLine($"x:{OutputVector.X} y:{OutputVector.Y}");
    }

    public Vector RecordArray(Vector[] ArrayVectorOff)
    {
        for (int i = 0; i < ArrayVectorOff.Length; i++)
        {
            ArrayVectorOff[i] = VectorForUser();
        }
        return ArrayVectorOff[ArrayVectorOff.Length - 1];
    }
    public void conclusionArray(Vector[] ArrayVectorOff)
    {
        for (int i = 0; i < ArrayVectorOff.Length; i++)
        {
            OutputDataVector(ArrayVectorOff[i]);
        }
    }
    public int IntegerForUser(string message)
    {
        while (true)
        {
            MessageToUser(message);
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int value))
            {
                return value;
            }
        }
    }
    public Vector VectorForUser()
    {

        Vector Input = new Vector(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));

        return Input;
    }

}
