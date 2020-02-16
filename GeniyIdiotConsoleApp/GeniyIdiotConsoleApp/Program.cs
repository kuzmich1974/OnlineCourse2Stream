using System;
using System.Collections.Generic;

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

            string name = Console.ReadLine();

            Greeting(name);

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

            Console.WriteLine("\nНе знаю как вам эта новость " + name + ", но ваш диагноз: " + GetDiagnose(countRightAnswers));

            Comments(countRightAnswers);

            Console.ReadKey();
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

        static void Greeting(string name)
        {
            Console.WriteLine("\nОчень приятно " + name + ". Предлагаю сыграть со мной в игру." +
                "\nВаша задача ответить на несколько несложных вопросов, а после я выведу диагноз, насколько вы... кхм... дееспособны." +
                "\nИтак как только будете готовы, нажмите любую клавишу, чтобы продолжить.");
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

        static string GetDiagnose(int countRightAnswers)
        {
            string[] diagnoses = new string[6];

            diagnoses[0] = "Идиот.";
            diagnoses[1] = "Кретин.";
            diagnoses[2] = "Дурак.";
            diagnoses[3] = "Нормальный.";
            diagnoses[4] = "Талант.";
            diagnoses[5] = "Гений.";

            return diagnoses[countRightAnswers];
        }

        static void Comments(int countRightAnswers)
        {
            string[] comments = new string[6];

            comments[0] = "Мда... Что называется \"No comments.\"";
            comments[1] = "Не огорчайтесь - вам ещё есть куда падать.";
            comments[2] = "На самом деле вы не одиноки в этом, если подойдёте к зеркалу, то в нём увидите ещё одного.";
            comments[3] = "Ну это насчёт ваших умственных способностей, насчёт психического здоровья я не уверен.";
            comments[4] = "Вопросы были слишком простыми, не обольщайтесь.";
            comments[5] = "Я всего лишь программа, написанная не самым умелым индивидом. Так что не верьте моему мнению.";

            Console.WriteLine(comments[countRightAnswers]);
        }
    }
}