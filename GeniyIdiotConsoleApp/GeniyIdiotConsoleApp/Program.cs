using System;
using System.Collections.Generic;
using System.IO;
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
            var countProgramCompletion = 0;
            while (countProgramCompletion == 0)
            { 
                string[] fullName = GetFullName(); 
                List<string> questions = GetQuestions();
                int countQuestions = questions.Count;
                List<int> answers = GetAnswers();
                var countRightAnswer = 0;

                for (var index = 0; index < countQuestions; index++)
                {
                    Console.WriteLine("Вопрос №" + (index + 1) + ":");
                    int randomQuestionIndex = GetRandomQuestionIndex(questions.Count);
                    string randomQuestion = questions[randomQuestionIndex];

                    int userAnswer = GetUserAnswer(randomQuestion);
                    int rightAnswer = answers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswer++;
                    }

                    questions.RemoveAt(randomQuestionIndex);
                    answers.RemoveAt(randomQuestionIndex);
                }

                string diagnose = GetDiagnose(countRightAnswer, countQuestions);

                Console.WriteLine("\n" + fullName[1] + " " + fullName[2] + ", ваш диагноз: " + diagnose + "\n");
                result.Add("\n" + fullName[0] + " " + fullName[1] + " " + fullName[2] + ". Правильных ответов: "  + countRightAnswer  + ". Диагноз: " + diagnose + "\n");
                WriteResult(result);


                string answerOnReplay = GetAnswerOnReplay();

                if (answerOnReplay == "нет")
                {
                    countProgramCompletion++;
                    string answerOnResult = GetAnswerOnResult();
                    if (answerOnResult == "да")
                    {
                        ReadResult();
                    }
                }
                else
                {
                    Console.WriteLine("***************************************************\n");
                }
            }

        }

        static string[] GetFullName ()
        {
            Console.WriteLine("Введите ваше фамилию, имя и отчество");
            string[] fullName = Console.ReadLine().Split(' ');
            Console.WriteLine();
            return fullName;
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

        static string GetDiagnose(int countRightAnswer, int countQuestions)
        {
            var diagnose = "";
            float percentRightAnswers = countRightAnswer * 100 / countQuestions;
            if (percentRightAnswers <= 17 && percentRightAnswers >= 0) { diagnose = "Идиот"; }
            if (percentRightAnswers <= 34 && percentRightAnswers > 17) { diagnose = "Кретин"; }
            if (percentRightAnswers <= 50 && percentRightAnswers > 34) { diagnose = "Дурак"; }
            if (percentRightAnswers <= 67 && percentRightAnswers > 50) { diagnose = "Нормальный"; }
            if (percentRightAnswers <= 83 && percentRightAnswers > 67) { diagnose = "Талант"; }
            if (percentRightAnswers <= 100 && percentRightAnswers > 83) { diagnose = "Гений"; }

            return diagnose;
        }

        static int GetRandomQuestionIndex(int countQuestionsInList)
        {
            Random random = new Random();
            return random.Next(0, countQuestionsInList);
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

        static void WriteResult (List<string>result)
        {
            string writePath = @"C:\Users\Demi\Desktop\Учеба\OnlineCourse2Stream\GeniyIdiotConsoleApp\results.txt";
            using (StreamWriter writeResult = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                for (var i = 0; i < result.Count; i++)
                {
                    writeResult.WriteLine(result[i]);
                }
            }
        }

        static void ReadResult ()
        {
            string path = @"C:\Users\Demi\Desktop\Учеба\OnlineCourse2Stream\GeniyIdiotConsoleApp\results.txt";
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line = null;
                do
                {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                }
                while (line != null);
            }
        }
    }
}
