//--------------------------------------------------------------------
// Create the game, play the game and return result.
public class GeniusIdiotGame
{
    private Questions questions;
    private int countRightAnswers;

    public GeniusIdiotGame(string fileName)
    {
        questions = new Questions();
        questions.LoadFromFile(fileName);
        countRightAnswers = 0;
    }
    public void ShuffleQuestions()
    {
        questions.Shuffle(); 
    }

    // !!!! GameUserUI must be a param (for constructor?) or callback function !!!
    public void Play()
    {
        int answerIndex = 0;
        foreach (var q in questions)
        {
            if (q.IsCorrectAnswer(GameUserUI.GetUserInput(++answerIndex, q.ToString())))
                ++countRightAnswers;
        }
    }

    public int Diagnose
    {
        get
        {
            return countRightAnswers;
        }
    }

}
