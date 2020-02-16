using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenIdiConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Рабочая ветка. Не путать с master!
            int countQuestions = 5; 
            string[] questions = GetQuestions(countQuestions); 
            int[] answers = GetAnswers(countQuestions); 
            List<int> indexOrder = GetRandomOrder(countQuestions);
            int countRightAnswers = 0; 


            for (int i = 0; i < countQuestions; i++)
            {

                Console.WriteLine("Вопрос № " + (i + 1));
                int randomQuestionIndex = indexOrder[i]; 
                Console.WriteLine(questions[randomQuestionIndex]);
                int usAnswer = СheckUserAnswer();
                int rightAnswer = answers[randomQuestionIndex]; 
                if (usAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
            }
            string[] diagnoses = GetDiagnoses(countQuestions + 1);           
            Console.WriteLine("Ваш диагноз: " + diagnoses[countRightAnswers]);

        }
        static string[] GetQuestions(int countQuestions) 
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно надо распилить на 10 частей. Сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут для трёх уколов?";
            questions[4] = "Пять свечей горело, дву потухли. Сколько свечей осталось?";
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
        static string[] GetDiagnoses(int countQuestions) 
        {
            string[] diagnoses = new string[countQuestions + 1];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";
            return diagnoses;
        }
        static List<int> GetRandomOrder(int countQuestions)
        {
            List<int> digits = (new int[] { }).ToList();
            for (int i = 0; i < countQuestions; i++)
            {
                digits.Add(i);
            }
            List<int> randomIndex = (new List<int>(countQuestions) { });
            int digit;

            Random rnd = new Random();
            for (int i = 0; i < countQuestions; i++)
            {
                digit = digits[rnd.Next(digits.Count)];
                digits.Remove(digit);
                randomIndex.Add(digit);
            }
            return randomIndex;
        }
        static int СheckUserAnswer()
        {
            int userAnswer;
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out userAnswer);
            if (result == true)
                return userAnswer;
            else
                Console.WriteLine("Некорректный формат ответа. Попробуйте ответить еще раз.");
                return СheckUserAnswer();
        }     

    }
}
