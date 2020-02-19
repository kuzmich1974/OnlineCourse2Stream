using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GeniyIdiotConsoleApp
{
    class Program
    {
        static string filePath = "statistic.txt";
        static string fio;
        static List<(string question, int answer)> questionsAndAnswers;

        static string[] diagnoses = new string[]
        {
            "Идиот",
            "Кретин",
            "Дурак",
            "Нормальный",
            "Талант",
            "Гений"
        };

        static void Main()
        {
            bool repeatTest = true;

            while (repeatTest)
            {
                StartInitialize();
                RunTest();
                AskAboutRepeatTest();
                repeatTest = AgainOrFinish();
            }
            AskAboutShowStatistic();
            Console.WriteLine("Тест окончен. Для выхода из программы нажмите любую клавишу.");
            Console.ReadKey();
        }

        static void StartInitialize()
        {
            questionsAndAnswers = GetAnswersAndQuestions();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("----------------   Тест \"Гений - Идиот\"   ------------------");
            Console.WriteLine("------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Введите ФИО:");
            fio = Console.ReadLine();
            ShowRulesOfAnswer();
            Console.WriteLine("У вас будет по 10 секунд для ответа на каждый вопрос.\nНажмите любую клавишу для начала теста...");
            Console.ReadKey();
            DrawSplitter();
        }

        static void ShowRulesOfAnswer() => Console.WriteLine("\nОтвет должен быть целым числом!\nИспользуйте только цифры и клавишу Enter для ввода ответа.");

        static void DrawSplitter() => Console.WriteLine("---------------------------------------------------------------------------");

        static List<(string question, int answer)> GetAnswersAndQuestions()
        {
            return new List<(string question, int answer)>
            {
                ("Сколько будет два плюс два умноженное на два?",                                     6 ),
                ("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?",               9 ),
                ("На двух руках 10 пальцев. Сколько пальцев на 5 руках?",                            25 ),
                ("Укол делают каждые пол-часа, сколько нужно минут для трёх уколов?",                60 ),
                ("Пять свечей горело, 2 потухли. Сколько свечей осталось?",                           2 ),
                ("Одно яйцо варится 4 мин. Сколько минут надо варить 6 яиц?",                         4 ),
                ("Сколько месяцев в году имеют 28 дней?",                                            12 ),
                ("У семерых братьев по сестре. Сколько всего сестёр?",                                1 ),
                ("У фермера было 17 овец. Все, кроме 10 умерли. Сколько овец осталось у фермера?",   10 ),
                ("Сколько яиц можно съесть натощак?",                                                 1 )
            };
        }

        static void RunTest()
        {
            int countRightAnswers = 0;
            int countQuestions = questionsAndAnswers.Count;
            int i = 0;
            while (i < countQuestions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Вопрос N" + (i + 1));
                Console.ResetColor();

                int randomIndex = GetRandomIndex(questionsAndAnswers.Count);
                Console.WriteLine(questionsAndAnswers[randomIndex].question);
                int rightAnswer = questionsAndAnswers[randomIndex].answer;

                string UserAnswer = "";
                bool answerReceived = false;
                bool timeIsOut = false;
                using (Timer timer = new Timer((object obj) => { Console.WriteLine("\nВремя вышло..."); timeIsOut = true; i++; }, null, 10000, Timeout.Infinite))
                {
                    while (!timeIsOut && !answerReceived)
                    {
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.Enter:
                                    Console.WriteLine();
                                    if (int.TryParse(UserAnswer, out int digitUserAnswer))
                                    {
                                        answerReceived = true;
                                        if (digitUserAnswer == rightAnswer)
                                        {
                                            countRightAnswers++;
                                        }
                                        i++;
                                        break;
                                    }
                                    else
                                    {
                                        UserAnswer = "";
                                        ShowRulesOfAnswer();
                                    }
                                    break;
                                case ConsoleKey.Backspace:
                                    if (UserAnswer.Length > 0)
                                    {
                                        Console.Write("\b \b");
                                        UserAnswer = UserAnswer.Remove(UserAnswer.Length - 1);
                                    }
                                    break;
                                default:
                                    if (char.IsDigit(keyInfo.KeyChar))
                                    {
                                        UserAnswer += keyInfo.KeyChar;
                                    }
                                    else
                                    {
                                        UserAnswer = "";
                                        ShowRulesOfAnswer();
                                    }
                                    break;
                            }
                        }
                    }
                }
                questionsAndAnswers.RemoveAt(randomIndex);
            }
            string diagnose = GetDiagnose(countQuestions, countRightAnswers);
            ShowDiagnose(diagnose, countRightAnswers);
            SaveDiagnoseToFile(fio, countRightAnswers, diagnose);
        }

        static void AskAboutRepeatTest()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            DrawSplitter();
            Console.WriteLine();
            Console.WriteLine("Пройти тест снова? Да - Y, Нет - N");
        }

        static bool AgainOrFinish()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                    default:
                        Console.WriteLine("Вы должны нажать клавишу Y если да и N если нет.");
                        break;
                }
            }
        }

        static void AskAboutShowStatistic()
        {
            Console.WriteLine("Показать статистику? Да - Y, нет - N");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Y:
                        ShowStatistic();
                        return;
                    case ConsoleKey.N:
                        Console.WriteLine("Конец теста");
                        Console.ResetColor();
                        return;
                    default:
                        Console.WriteLine("Вы должны нажать клавишу Y если да и N если нет.");
                        break;
                }
            }
        }

        static void ShowStatistic()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                Console.ResetColor();
                DrawSplitter();
                Console.WriteLine("| {0, -35} | {1, -20} | {2, -10} |", "ФИО", "Число верных ответов", "Диагноз");
                DrawSplitter();
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                    DrawSplitter();
                }
            }
        }

        static string GetDiagnose(int countQuestions, int countRightAnswers)
        {
            double diagnosePercentRange = 100.0 / (diagnoses.Length - 1);
            double userPercentScore = 100.0 * countRightAnswers / countQuestions;
            int diagnoseIndex = 0;
            for (int i = diagnoseIndex; i < diagnoses.Length; i++)
            {
                if (userPercentScore <= diagnosePercentRange * i)
                {
                    diagnoseIndex = i;
                    break;
                }
            }
            return diagnoses[diagnoseIndex];
        }

        static void ShowDiagnose(string diagnose, int countRightAnswers)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Число правильных ответов: " + countRightAnswers + ".");
            Console.WriteLine("Ваш диагноз: " + diagnose);
        }

        static void SaveDiagnoseToFile(string fio, int countRightAnswers, string diagnose)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("| {0, -35} | {1, -20} | {2, -10} |", fio, countRightAnswers, diagnose);
            }
        }

        static int GetRandomIndex(int countQuestions)
        {
            Random random = new Random();
            return random.Next(0, countQuestions);
        }
    }
}
