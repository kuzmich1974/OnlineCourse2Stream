using System;

namespace geniy_idiot_my_ver_ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int questionVolume = 5;
            int volumeDiagnose = 6;
            int cntRightAnswer = 0;
            int randomQuestion = 0;     
            //      MA ZA L ALKZ RNTCNFOLTNKODTE
            string[] questions = new string[questionVolume];
            questions[0] = "Сколько будет два плюс два умноженное на два";
            questions[1] = "Бревно нужно распилить на 10 частей, сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно минут для трёх уколов?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";

            int[] answers = new int[questionVolume];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 3;

            int[] usedAnswers = new int[questionVolume];
            usedAnswers[0] = 0;
            usedAnswers[1] = 0;
            usedAnswers[2] = 0;
            usedAnswers[3] = 0;
            usedAnswers[4] = 0;

            string[] diag = new string[volumeDiagnose];
            diag[0] = "Идиот";
            diag[1] = "Кретин";
            diag[2] = "Дурак";
            diag[3] = "Нормальный";
            diag[4] = "Талант";
            diag[5] = "Гений";

            string klientName = Func_KlientName();

            for (int i = 0; i < questionVolume; i++)
            {
                    for (int e = 0; e < questionVolume; e++)
                    {
                        randomQuestion = Func_GetRandomQuestion(questionVolume);

                        if (usedAnswers[randomQuestion] == 0)
                        {
                            usedAnswers[randomQuestion] = 1;
                            break;
                        }

                    }


                Console.WriteLine("Вопрос №: " + (i + 1) + " " + questions[randomQuestion]);

                int answer = Func_To_CheckGramm();

                int rightAnswer = answers[randomQuestion];

                    if (answer == rightAnswer)
                    {
                        cntRightAnswer++;
                    }

            }
        
            Console.WriteLine("Число правильных ответов: " + cntRightAnswer);
            Console.WriteLine(klientName+" Вы: " + diag[cntRightAnswer]);

            Console.ReadKey();
        }

        static string Func_KlientName()
        {
            Console.WriteLine("Введите Ваше имя, пожалуйста:");
            string klientName = Console.ReadLine();
            return klientName;
        }

        static int Func_GetRandomQuestion(int questionVolume)
        {
            Random randomNumber = new Random();
            int randomQuestion = randomNumber.Next(0, questionVolume);
            return randomQuestion;
        }

        static int Func_To_CheckGramm()
        {
            int number;
            int userAnswer = 0;
            bool result=false;
            while (result != true)
            { 
            string testedAnswer = Console.ReadLine();
            result = int.TryParse(testedAnswer, out number);
                 if (result != true)
                 {
                    Console.WriteLine("Будте, внимательнее!!! Ответ состоит только из цифр!");
                 }
                 else
                 {
                     userAnswer = number;
                     break;
                 }
            }
            return userAnswer;
        }
    }
}
