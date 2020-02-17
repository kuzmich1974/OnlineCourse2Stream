using System;

namespace geniy_idiot_my_ver_ConsoleApp2
{
    class Program
    {
        public Program()
        {
        }

        static string func_klientName()
        {
            Console.WriteLine("Введите Ваше имя, пожалуйста:");
            string klientName = Console.ReadLine();
            return klientName;
        }
        
        static int func_randomQuestion(int questionVolume = 5)
        {
            Random sluchChislo = new Random();
            int sluchIndex = sluchChislo.Next(0, questionVolume = 5);
            return sluchIndex;
        }

        static string func_for_klietnAswerGramm()
        {
            int cntOfTrying = 0;
            string klientAnswer;
            
            while (cntOfTrying <= 10)
            {
                klientAnswer = Console.ReadLine();
                string klientAnswerTest = klientAnswer;
                string[] Answ = klientAnswerTest.Split(' ');
                for (int a = 0; a < Answ.Length; a++)
                {
                    char test = Convert.ToChar(Answ[a]);
                    if (test < '0' || test > '9')
                    {
                        cntOfTrying++;
                        Console.WriteLine("Будте, внимательнее!!! Ответ состоит только из цифр!");
                    }
                }
            }
            if (cntOfTrying == 10)
            {
                Console.WriteLine("Вы полный идиот! Отойдите!");
            }
                     
            return klientAnswer;
        }


        static void Main(string[] args)
        {
            int questionVolume = 5;
            int chisloDiagnosov = 6;
            int cntRightAnswer = 0;
            int sluchayvopros = 0;
            
            
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

            string[] diag = new string[chisloDiagnosov];
            diag[0] = "Идиот";
            diag[1] = "Кретин";
            diag[2] = "Дурак";
            diag[3] = "Нормальный";
            diag[4] = "Талант";
            diag[5] = "Гений";

            string klientName = func_klientName();

            for (int i = 0; i < questionVolume; i++)
            {
                    for (int e = 0; e < questionVolume; e++)
                    {
                        sluchayvopros = func_randomQuestion(questionVolume);

                        if (usedAnswers[sluchayvopros] == 0)
                        {
                            usedAnswers[sluchayvopros] = 1;
                            break;
                        }

                    }

                    Console.WriteLine("Вопрос №: " + (i + 1) + " " + questions[sluchayvopros]);

                    string userAnswer = func_for_klietnAswerGramm();
                    userAnswer = Convert.ToInt32(userAnswer);
                    
                    int rightAnswer = answers[sluchayvopros];
                    if (userAnswer == rightAnswer)
                    {
                        cntRightAnswer++;
                    }

            }
        
            Console.WriteLine("Число правильных ответов: " + cntRightAnswer);
            Console.WriteLine(klientName+" Вы: " + diag[cntRightAnswer]);

            Console.ReadKey();
        }

        
    }
}