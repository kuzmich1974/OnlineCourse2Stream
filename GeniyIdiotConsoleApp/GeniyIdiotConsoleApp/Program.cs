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

            string name = UserNameValidation();
            
            Console.WriteLine("{0}Очень приятно " + name + ". Предлагаю сыграть со мной в игру." +
                "{0}Ваша задача ответить на несколько несложных вопросов, а после я выведу диагноз, насколько вы... кхм... дееспособны." +
                "{0}Итак, как только будете готовы, нажмите любую клавишу, чтобы продолжить.", Environment.NewLine);

            Console.ReadKey(true);

            for (int i = 0; i < countQuestions; i++)
            {
                Console.WriteLine("\nВопрос " + (i + 1));

                int randomQuestionIndex = GetRandomQuestionIndex(questions.Count);

                Console.WriteLine(questions[randomQuestionIndex]);

                int userAnswer = UserAnswerValidation();

                int rightAnswer = answers[randomQuestionIndex];

                if (userAnswer == rightAnswer) countRightAnswers++;

                DeleteAskedQestion(questions, answers, randomQuestionIndex);
            }

            int points = GetPoints(countQuestions, countRightAnswers);

            Console.WriteLine("{0}" + name + ", вы справились. Ваши результаты:" +
                "{0}Правильных ответов: " + countRightAnswers + " из " + countQuestions +
                "{0}Набранных баллов: " + points +
                "{0}Ваш диагноз: " + GetDiagnose(points), Environment.NewLine);

            Console.WriteLine("{0}" + name + ", не хотите ли пройти тест ещё раз?" +
                "{0}Нажмите кнопку 'Y' если да, любую другую - если нет.", Environment.NewLine);

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

        static string UserNameValidation()
        {
            string name;

            while (string.IsNullOrEmpty(name = Console.ReadLine()))
            {
                Console.WriteLine("Вы ввели пустую строку. Попробуйте ещё раз:");
            }

            return name.Substring(0, 1).ToUpper() + (name.Length > 1 ? name.Substring(1).ToLower() : "");
        }

        static int GetRandomQuestionIndex(int x)
        {
            Random random = new Random();
            return random.Next(x);
        }

        static int UserAnswerValidation()
        {
            int inputNumber;

            while (!int.TryParse(Console.ReadLine(), out inputNumber))
            {
                Console.WriteLine("Некоректный формат ответа, попробуйте ещё раз:");
            }

            return inputNumber;
        }

        static void DeleteAskedQestion(List<string> questions, List<int> answers, int randomQuestionIndex)
        {
            answers.RemoveAt(randomQuestionIndex);
            questions.RemoveAt(randomQuestionIndex);
        }

        static string GetDiagnose(int points)
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