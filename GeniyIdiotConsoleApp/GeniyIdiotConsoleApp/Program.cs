using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

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
            Console.WriteLine("Нажмите любую клавишу для начала теста...");
            Console.ReadKey();
            DrawSplitter();
        }

        static List<(string question, int answer)> GetAnswersAndQuestions()
        {
            return new List<(string question, int answer)>
            {
                ("сколько будет два плюс два умноженное на два?",                          6 ),
                ("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?",    9 ),
                ("На двух руках 10 пальцев. Сколько пальцев на 5 руках?",                 25 ),
                ("Укол делают каждые пол-часа, сколько нужно минут для трёх уколов?",     60 ),
                ("Пять свечей горело, 2 потухли. Сколько свечей осталось?",                2 ),
                ("Одно яйцо варится 4 мин. Сколько минут надо варить 6 яиц?",              4 ),
                ("Сколько месяцев в году имеют 28 дней?",                                 12 ),
                ("У семерых братьев по сестре. Сколько всего сестёр?",                     1 )
            };
        }

        static void RunTest()
        {
            int countRightAnswers = 0;
            int countQuestions = questionsAndAnswers.Count;

            Timer timer = new Timer(10000);
            timer.AutoReset = false;
            timer.Elapsed += onTimeEvent;
            for (int i = 0; i < countQuestions; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Вопрос N" + (i + 1));
                Console.ResetColor();

                int randomIndex = GetRandomIndex(questionsAndAnswers.Count);
                Console.WriteLine(questionsAndAnswers[randomIndex].question);

                int rightAnswer = questionsAndAnswers[randomIndex].answer;

                timer.Start();
                
                int userAnswer = GetInputAnswerDigitFormat();

                if (userAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }

                questionsAndAnswers.RemoveAt(randomIndex);
            }
            string diagnose = GetDiagnose(countQuestions, countRightAnswers);
            WriteDiagnose(diagnose, countRightAnswers);
            SaveDiagnose(fio, countRightAnswers, diagnose);
        }

    static void onTimeEvent(Object source, ElapsedEventArgs e)
    {
        
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
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    DrawSplitter();
                }
            }
        }

        static void DrawSplitter()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        static int GetInputAnswerDigitFormat()
        {
            int inputNumber;
            while (!int.TryParse(Console.ReadLine(), out inputNumber))
            {
                Console.WriteLine("Ответ должен быть целым числом! \nПопробуйте ответить ещё раз:");
            }
            return inputNumber;
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

        static void WriteDiagnose(string diagnose, int countRightAnswers)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Число правильных ответов: " + countRightAnswers + ".");
            Console.WriteLine("Ваш диагноз: " + diagnose);
        }

        static void SaveDiagnose(string fio, int countRightAnswers, string diagnose)
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
