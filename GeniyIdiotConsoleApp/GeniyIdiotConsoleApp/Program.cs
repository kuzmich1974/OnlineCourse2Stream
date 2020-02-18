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
            List<string> result = new List<string>();
            int count = 0;
            while (count == 0)
            {
                Console.WriteLine("Введите ваше фамилию, имя и отчество");
                string[] initials = Console.ReadLine().Split(' ');
                Console.WriteLine();
                int countQuestions = 5;
                List<string> questions = GetQuestions();
                List<int> answers = GetAnswers();
                int countRightAnswer = 0;

                for (int index = 0; index < countQuestions; index++)
                {
                    Console.WriteLine("Вопрос №" + (index + 1) + ":");
                    int CountQuestionsInList = questions.Count;
                    int randomQuestionIndex = GetRandomQuestionIndex(CountQuestionsInList);
                    string randomQuestion = questions[randomQuestionIndex];

                    int userAnswer = GetUserAnswer(randomQuestion);
                    int rightAnswer = answers[randomQuestionIndex];

                    questions.RemoveAt(randomQuestionIndex);
                    answers.RemoveAt(randomQuestionIndex);

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswer++;
                    }
                }

                string diagnos = GetDiagnos(countRightAnswer, countQuestions);

                Console.WriteLine("\n" + initials[1] + " " + initials[2] + ", ваш диагноз: " + diagnos + "\n");
                result.Add("\n" + initials[0] + " " + initials[1] + " " + initials[2] + ". Правильных ответов: "  + countRightAnswer  + ". Диагноз: " + diagnos + "\n");
   
                string answerOnReplay = GetAnswerOnReplay();

                if (answerOnReplay == "нет")
                {
                    count++;
                    string answerOnResult = GetAnswerOnResult();
                    if (answerOnResult == "да")
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            Console.WriteLine(result[i]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("***************************************************\n");
                }
            }

        }

        static List<string> GetQuestions()
        {
            var questions = new List<string>
            {
                "Сколько будет два плюс два умноженные на два?",
                "Бревно нужно распилить на десять частей, сколько надо сделать распилов?",
                "На 2 руках 10 пальцев. Сколько пальцев на 5 руках?",
                "Укол делают каждые пол часа, сколько нужно минут для трех уколов?",
                "Пять свечей горело, две потухли. Сколько свечей осталось?"
            };
            return questions;
        }

        static List<int> GetAnswers()
        {
            var answers = new List<int> { 6, 9, 25, 60, 2 };
            return answers;
        }

        static string GetDiagnos(float countRightAnswer, float countQuestions)
        {
            string diagnos = "";
            float percentRightAnswers = countRightAnswer / countQuestions * 100;
            if (percentRightAnswers <= 17 && percentRightAnswers > 0) { diagnos = "Идиот"; }
            if (percentRightAnswers <= 34 && percentRightAnswers > 17) { diagnos = "Кретин"; }
            if (percentRightAnswers <= 50 && percentRightAnswers > 34) { diagnos = "Дурак"; }
            if (percentRightAnswers <= 67 && percentRightAnswers > 50) { diagnos = "Нормальный"; }
            if (percentRightAnswers <= 83 && percentRightAnswers > 67) { diagnos = "Талант"; }
            if (percentRightAnswers <= 100 && percentRightAnswers > 83) { diagnos = "Гений"; }

            return diagnos;
        }

        static int GetRandomQuestionIndex(int CountQuestionsInList)
        {
            Random random = new Random();
            return random.Next(0, CountQuestionsInList);
        }

        static int GetUserAnswer(string randomQuestion)
        {
            int userAnswer;
            do
                {
                    Console.WriteLine(randomQuestion);
                }
                while (!int.TryParse(Console.ReadLine(), out userAnswer));
            return userAnswer;
        }

        static string GetAnswerOnReplay()
        {
            string answerOnReplay;
            do
            {
                Console.WriteLine("\nХотите пройти тест снова?\n\nЕсли хотите, введите: да\nЕсли не хотите, введите: нет\n");
                answerOnReplay = Console.ReadLine();
            }
            while (answerOnReplay != "да" && answerOnReplay != "нет");
            return answerOnReplay;
        }

        static string GetAnswerOnResult()
        {
            string answerOnResult;
            do
            {
                Console.WriteLine("***************************************************");
                Console.WriteLine("\nХотите посмотреть результаты теста?\n\nЕсли хотите, введите: да\nЕсли не хотите, введите: нет\n");
                answerOnResult = Console.ReadLine();
                Console.WriteLine();
            }
            while (answerOnResult != "да" && answerOnResult != "нет");
            return answerOnResult;
        }

    }
}
