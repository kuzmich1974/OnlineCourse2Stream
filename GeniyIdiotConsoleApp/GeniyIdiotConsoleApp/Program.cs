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
            int countQuestions = 5;
            int numberForRepeat;
            
            do
            {
                List<string> questions = GetQuestions(countQuestions);
                List<int> answers = GetAnswers(countQuestions);
                List<int> indexOrder = GetRandomOrder(countQuestions);
                int countRightAnswers = 0;


                for (int i = 0; i < countQuestions; i++)
                {

                    Console.WriteLine("Вопрос № " + (i + 1));
                    int randomQuestionIndex = indexOrder[i];
                    Console.WriteLine(questions[randomQuestionIndex]);
                    int userAnswer = СheckUserAnswer();
                    int rightAnswer = answers[randomQuestionIndex];
                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                }
                int percentForDiagnoses = GetPercentOfRigthAnswers(countRightAnswers, countQuestions);
                List<string> diagnoses = GetDiagnoses(countQuestions + 1);
                Console.WriteLine("Ваш диагноз: " + diagnoses[percentForDiagnoses]);                
                Console.WriteLine("Если вы хотите пройти тест ещё раз - нажмите клавишу 1");
                Console.WriteLine("Для завершения тестирования - нажмите любую другую клавишу");
                string input = Console.ReadLine();
                int.TryParse(input, out numberForRepeat);
            }
            while (numberForRepeat == 1);
        }
        static List<string> GetQuestions(int countQuestions) 
        {
            List<string> questions = (new List<string>(countQuestions) { });
            questions.Add("Сколько будет два плюс два умноженное на два?");
            questions.Add("Бревно надо распилить на 10 частей. Сколько надо сделать распилов?");
            questions.Add("На двух руках 10 пальцев. Сколько пальцев на 5 руках?");
            questions.Add("Укол делают каждые полчаса. Сколько нужно минут для трёх уколов?");
            questions.Add("Пять свечей горело, дву потухли. Сколько свечей осталось?");
            return questions;
        }
        static List<int> GetAnswers(int countQuestions) 
        {
            List<int> answers = (new List<int>(countQuestions) { });
            answers.Add(6);
            answers.Add(9);
            answers.Add(25);
            answers.Add(60);
            answers.Add(2);
            return answers;
        }
        static List<string> GetDiagnoses(int countQuestions)
        {
            List<string> diagnoses = (new List<string>(countQuestions + 1) { });
            diagnoses.Add("Идиот");
            diagnoses.Add("Кретин");
            diagnoses.Add("Дурак");
            diagnoses.Add("Нормальный");
            diagnoses.Add("Талант");
            diagnoses.Add("Гений");
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
        static int GetPercentOfRigthAnswers (double countRightAnswers, double countQuestions)
        {
            double percentOfRightAnswers = ((countRightAnswers / countQuestions) * 100);
            int counterForDiagnoses = (Convert.ToInt32(percentOfRightAnswers) / 20);            
            return counterForDiagnoses;
        }
        

    }
}
