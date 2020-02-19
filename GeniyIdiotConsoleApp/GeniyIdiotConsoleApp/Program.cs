using System;
using System.Collections.Generic;

namespace GeniyIdiotConsoleApp
{
    class Program
    {
        const int CountQuestions = 5;

        static List<(string question, int answer)> questionAnswer;

        static List<(string question, int answer)> GetQuestionAnswer()
        {
            return new List<(string question, int answer)>
            {
                ("Сколько будет два плюс два  умноженное на два?", 6),
                ("Бревно нужно распилить на 10  частей, сколько надо сделать  распилов?", 9),
                ("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                ("Укол делают каждые полчаса,  сколько нужно минут для трех  уколов?", 90),
                ("Пять свечей горело, две  потухли. Сколько свечей  осталось?", 2)
            };
        }

        static string GetDiagnoses(int diagnosesNumber)
        {
            string[] diagnoses = new string[] { "Идиот", "Кретин", "Дурак", "Нормальный", "Талант", "Гений" };

            return diagnoses[diagnosesNumber];
        }

        static int GetRandomQuestionIndex(int countQuestions)
        {
            Random random = new Random();

            return random.Next(0, countQuestions);
        }

        static void Main(string[] args)
        {

            int countRightAnswer = 0;

            questionAnswer = GetQuestionAnswer();

            for (int i = 0; i < CountQuestions; i++)
            {

                int randomQuestionIndex = GetRandomQuestionIndex(CountQuestions);

                Console.WriteLine("Вопрос №" + (i + 1) + " (" + randomQuestionIndex + ")");
                Console.WriteLine(questionAnswer[randomQuestionIndex].question);
                Console.Write("Введите ваш ответ = ");

                int userAnswer = Convert.ToInt32(Console.ReadLine());

                if (userAnswer == questionAnswer[randomQuestionIndex].answer)
                {
                    countRightAnswer++;
                }
            }

            Console.WriteLine("Ваш диагноз:" + GetDiagnoses(countRightAnswer));

            Console.ReadKey();
        }


    }
}
