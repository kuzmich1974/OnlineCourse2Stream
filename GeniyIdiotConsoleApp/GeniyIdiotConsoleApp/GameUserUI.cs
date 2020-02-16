using System;
// --------------------------------------------------------------------
// Game CLI UI
public class GameUserUI
{
    static string gamerName = "";
    static string[] Diagnoses = new string[] { "Идиот", "Кретин", "Дурак", "Нормальный", "Талант", "Гений" };

    public static bool QuitPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("Попробовать еще раз (Любая клавиша - Нет, Enter - Да) ? ");
        Console.WriteLine();
        return (Console.ReadKey(true).Key == ConsoleKey.Enter);
    }
    public static void StartPrompt()
    {
        Console.Write("Здравствуйте!  Введите свое имя: ");
        gamerName = Console.ReadLine();
        Console.WriteLine("Уважаемый {0}!  Ответьте пожалуйста на несколько вопросов.", gamerName);
        Console.WriteLine();
    }

    public static int GetUserInput(int questionID, string questionText)
    {
        Console.Write("Вопрос № {0} : {1} ", questionID, questionText);
        int userInput = 0;
        while (!Int32.TryParse(Console.ReadLine(), out userInput))
        {
            Console.Write("Ошибка! Введите числовое значение или Ctrl+C для выхода из программы: ");
        }
        return userInput;
    }

    public static void ShowResult(int rightAnswerCount)
    {
        Console.WriteLine();
        Console.WriteLine("Поздравляю {0} - Вы {1}!", gamerName, Diagnoses[rightAnswerCount]);
    }
}
