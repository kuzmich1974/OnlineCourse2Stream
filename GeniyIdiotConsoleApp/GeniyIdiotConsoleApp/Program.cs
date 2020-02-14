﻿using System;
using System.IO;

namespace GeniyIdiotConsoleApp
{
    class Program
    {
        static string filePath = "statistic.txt";
        static string fio;
        //Диагнозы
        static string[] diagnoses = new string[] 
        {
            "Идиот",
            "Кретин",
            "Дурак",
            "Нормальный",
            "Талант",
            "Гений"
        };
        //Вопросы и ответы
        static (string question, int answer)[] questionsAndAnswers = new(string question, int answer)[]
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

        static void Main(string[] args)
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

        static void RunTest()
        {
            int countRightAnswers = 0;
            int remainAnswers = questionsAndAnswers.Length;

            for (int i = 0; i < questionsAndAnswers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Вопрос N" + (i + 1));
                Console.ResetColor();

                int randomIndex = GetRandomIndex(remainAnswers);
                Console.WriteLine(questionsAndAnswers[randomIndex].question);
                int userAnswer = GetInputAnswerDigitFormat();
                int rightAnswer = questionsAndAnswers[randomIndex].answer;
                if (userAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
                SwapArrayElements(questionsAndAnswers, randomIndex, remainAnswers - 1);
                remainAnswers--;
            }
            string diagnose = GetDiagnose(countRightAnswers);
            WriteDiagnose(diagnose, countRightAnswers);
            SaveDiagnose(fio, countRightAnswers, diagnose);
        }

        static void AskAboutShowStatistic()
        {
            Console.WriteLine("Показать статистику? Да - Y, нет - N");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch(keyInfo.Key)
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
                Console.WriteLine("| ФИО                                 | Число верных ответов | Диагноз    |");
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

        static void StartInitialize()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("----------------   Тест \"Гений - Идиот\"   ------------------");
            Console.WriteLine("------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Введите ФИО:");
            fio = Console.ReadLine();
            DrawSplitter();
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

        static int GetInputAnswerDigitFormat()
        {
            bool stringIsNumber = false;
            int inputNumber = 0;
            while (!stringIsNumber)
            {
                stringIsNumber = int.TryParse(Console.ReadLine(), out inputNumber);
                if (!stringIsNumber)
                {
                    Console.WriteLine("Ответ должен быть целым числом! \nПопробуйте ответить ещё раз:");
                }
            }
            return inputNumber;
        }

        static string GetDiagnose(int countRightAnswers)
        {
            double diagnosePercentRange = 100.0 / (diagnoses.Length - 1);
            double userPercentScore = 100.0 * countRightAnswers / questionsAndAnswers.Length;
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
                sw.Write("| {0, -35} ", fio);
                sw.Write("| {0, -20} ", countRightAnswers);
                sw.WriteLine("| {0, -10} |", diagnose);
            }
        }

        static int GetRandomIndex (int countQuestions)
        {
            Random random = new Random();
            return random.Next(0, countQuestions);
        }

        static void SwapArrayElements<T> (T[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}