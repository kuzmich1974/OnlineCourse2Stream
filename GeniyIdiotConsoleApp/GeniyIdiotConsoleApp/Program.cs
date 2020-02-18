using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

namespace GenyiIdiotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> questions = GetQuestions();

            List<int> answers = GetAnswers();

            int countQuestions = questions.Count;

            int countRightAnswers = 0;

            Console.WriteLine("Здравствуйте! Представтесь, пожалуйста:");

            string name = NameValidation(Console.ReadLine());
            
            Console.WriteLine("\nОчень приятно " + name + ". Предлагаю сыграть со мной в игру." +
                              "\nВаша задача ответить на несколько несложных вопросов, а после я выведу диагноз, насколько вы... кхм... дееспособны." +
                              "\nИтак, как только будете готовы, нажмите любую клавишу, чтобы продолжить.");

            Console.ReadKey(true);

            for (int i = 0; i < countQuestions; i++)
            {
                Console.WriteLine("\nВопрос " + (i + 1));

                int randomQuestionIndex = GetRandomQuestionIndex(questions.Count);

                Console.WriteLine(questions[randomQuestionIndex]);

                int userAnswer = ValidationCheck(Console.ReadLine());

                int rightAnswer = answers[randomQuestionIndex];

                if (userAnswer == rightAnswer) countRightAnswers++;

                DeleteAskedQestion(questions, answers, randomQuestionIndex);

            }

            int points = GetPoints(countQuestions, countRightAnswers);

            Console.WriteLine("\n" + name + ", вы справились. Ваши результаты:" +
                "\nПравильных ответов: " + countRightAnswers + " из " + countQuestions +
                "\nНабранных баллов: " + points +
                "\nВаш диагноз: " + GetDiagnose(points));

            Console.WriteLine("\n" + name + ", не хотите ли пройти тест ещё раз?" +
                "\nНажмите кнопку 'Y' если да, любую другую - если нет.");

            WhetherToRestart(Console.ReadLine());
        }



        static List<string> GetQuestions()
        {
            List<string> questions = new List<string>();

            questions.Add("Сколько будет два плюс два  умноженное на два?");
            questions.Add("Бревно нужно распилить на 10  частей, сколько надо сделать  распилов?");
            questions.Add("На двух руках 10 пальцев. Сколько пальцев на 5 руках?");
            questions.Add("Укол делают каждые полчаса, сколько нужно минут для трех уколов?");
            questions.Add("Пять свечей горело, две  потухли. Сколько свечей  осталось?");

            return questions;
        }

        static List<int> GetAnswers()
        {
            List<int> answers = new List<int>();

            answers.Add(6);
            answers.Add(9);
            answers.Add(25);
            answers.Add(60);
            answers.Add(2);

            return answers;
        }

        static string NameValidation(string name)
        {
            while (true)
            {
                bool isSpace = string.IsNullOrWhiteSpace(name);

                if (!isSpace) return name;

                Console.WriteLine("Вы ввели пустую строку. Попробуйте ещё раз:");

                name = Console.ReadLine();
            }
        }

        static int GetRandomQuestionIndex(int x)
        {
            Random random = new Random();
            return random.Next(x);
        }

        static int ValidationCheck(string userAnswer)
        {
            while (true)
            {
                bool isNum = int.TryParse(userAnswer, out int num);

                if (isNum) return num;

                Console.WriteLine("Некоректный формат ответа, попробуйте ещё раз:");

                userAnswer = Console.ReadLine();
            }
        }

        static void DeleteAskedQestion(List<string> questions, List<int> answers, int randomQuestionIndex)
        {
            answers.RemoveAt(randomQuestionIndex);
            questions.RemoveAt(randomQuestionIndex);
        }

        static string GetDiagnose(int points)  // Теперь выводит по баллам
        {
            string[] diagnoses = new string[6];

            diagnoses[0] = "Идиот.";       // 0 - 19
            diagnoses[1] = "Кретин.";      // 20 - 39
            diagnoses[2] = "Дурак.";       // 40 - 59
            diagnoses[3] = "Нормальный.";  // 60 - 79
            diagnoses[4] = "Талант.";      // 80 - 99
            diagnoses[5] = "Гений.";       // 100 баллов

            int index = points / (100 / (diagnoses.Length - 1));

            return diagnoses[index];
        }

        static int GetPoints(int countQuestions, int countRightAnswers)  // Расчёт баллов
        {
            int points = countRightAnswers * 100 / countQuestions;

            return points;
        }

        static void WhetherToRestart(string YorN)  // Перезапуск программы
        {
            if (YorN == "Y" || YorN == "y") Process.Start(Assembly.GetExecutingAssembly().Location);            
            Environment.Exit(0);
        }
    }
}