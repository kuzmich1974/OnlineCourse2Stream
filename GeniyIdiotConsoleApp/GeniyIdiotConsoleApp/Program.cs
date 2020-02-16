/*
 *  Genius-Idiot game. v 0.2.1
 *  Konstantin Drygin
 *  11.02.2020
 */


class Program
{
    static void Main(string[] args)
    {

        string questionsFileName = (args.Length > 0) ? args[0] : "geniusIdiotGameQuestions.txt";

        //var appName = System.AppDomain.CurrentDomain.FriendlyName;

        GameUserUI.StartPrompt();

        GeniusIdiotGame game = new GeniusIdiotGame(questionsFileName);

        do
        {
            game.ShuffleQuestions();
            game.Play();

            GameUserUI.ShowDiagnose(game.Diagnose);
        }
        while (GameUserUI.QuitPrompt());
    }
}
