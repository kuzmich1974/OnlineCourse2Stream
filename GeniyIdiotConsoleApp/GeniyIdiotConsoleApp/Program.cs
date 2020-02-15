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
            int countQuestions = 5; // количество вопросов и ответов
            string[] questions = GetQuestions(countQuestions); //массив вопросов через обращение к вопроснику
            int[] answers = GetAnswers(countQuestions); // массив ответов через обращение к пулу ответов 
            int[] digits = GetRandomOrder(countQuestions);// массив со случаным порядком индексов вопросов и ответов
            int countRightAnswers = 0; // счетчик правильных ответов


            for (int i = 0; i < countQuestions; i++)
            {

                Console.WriteLine("Вопрос № " + (i + 1));
                int randQuestInd = digits[i]; // рандомный индекс вопроса из массива вопросов
                Console.WriteLine(questions[randQuestInd]);
                int usAnswer = СheckUserAnswer();
                int rightAnswer = answers[randQuestInd]; //достаем ответ с тем же индексом что и вопрос 
                if (usAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
            }
            string[] diagnoses = GetDiagnoses(countQuestions + 1); // обращаемся к пулу диагнозов           
            Console.WriteLine("Ваш диагноз: " + diagnoses[countRightAnswers]);

        }
        static string[] GetQuestions(int countQuestions) //Создаём вопросник
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно надо распилить на 10 частей. Сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут для трёх уколов?";
            questions[4] = "Пять свечей горело, дву потухли. Сколько свечей осталось?";
            return questions;
        }
        static int[] GetAnswers(int countQuestions) //Создаём пул ответов
        {
            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }
        static string[] GetDiagnoses(int countQuestions) // Создаём пул диагнозов
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
        static int[] GetRandomOrder(int countQuestions)//создаем массив со случайным неповторяющимся порядком будущих индексов вопросов и ответов
        {
            List<int> digits = (new int[] { 0, 1, 2, 3, 4 }).ToList();
            int[] randInd = new int[countQuestions];
            int digit;

            Random rnd = new Random();
            for (int i = 0; i < countQuestions; i++)
            {
                digit = digits[rnd.Next(digits.Count)];
                digits.Remove(digit);
                randInd[i] = digit;
            }
            return randInd;
        }
        static int СheckUserAnswer()//Защита от некорректного ввода формата ответа
        {
            try
            {
                int usAnswer = Convert.ToInt32(Console.ReadLine());
                return usAnswer;
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректный ввод. Попробуйте ответить еще раз.");
                return СheckUserAnswer();
            }
        }

    }
}
