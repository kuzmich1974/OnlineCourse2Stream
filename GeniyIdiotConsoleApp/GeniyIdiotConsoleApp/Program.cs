using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше фамилию, имя и отчество");
            string[] initials = Console.ReadLine().Split(' ');
            Console.WriteLine();
            int countQuestions = 5;
            List<string> questions = GetQuestions(countQuestions);
            int[] answers = GetAnswers(countQuestions);
            string[] diagnoses = GetDiagnoses(6);
            int countRightAnswer = 0;

            for (int index = 0; index < countQuestions; index++)
            {
                Console.WriteLine("Вопрос №" + (index + 1) + ":");
                int randomQuestionIndex = GetRandomQuestionIndex(countQuestions);
                Console.WriteLine(questions[randomQuestionIndex]);
                questions.RemoveAt(randomQuestionIndex);

                int userAnswer = Convert.ToInt32(Console.ReadLine());
                int rightAnswer = answers[randomQuestionIndex];

                if (userAnswer == rightAnswer)
                {
                    countRightAnswer++;
                }
            }

            Console.WriteLine("\n" + initials[1] + " " + initials[2] + ", ваш диагноз: " + diagnoses[countRightAnswer]);
        }

        static List<string> GetQuestions(int countQuestions)
        {
            var questions = new List<string>(countQuestions)
            {
                [0] = "Сколько будет два плюс два умноженные на два?",
                [1] = "Бревно нужно распилить на десять частей, сколько надо сделать распилов?",
                [2] = "На 2 руках 10 пальцев. Сколько пальцев на 5 руках?",
                [3] = "Укол делают каждые пол часа, сколько нужно минут для трех уколов?",
                [4] = "Пять свечей горело, две потухли. Сколько свечей осталось?"
            };
            return questions;
        }

        static int[] GetAnswers(int countQuestions)
        {
            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        static string[] GetDiagnoses(int countDiagnoses)
        {
            string[] diagnoses = new string[countDiagnoses];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";

            return diagnoses;
        }

        static int GetRandomQuestionIndex(int countQuestions)
        {
            Random random = new Random();
            return random.Next(0, countQuestions);
        }
    }
}
