using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

//-----------------------------------------------------------------------
// Smart question. It known ansewer, and can check it.
public class Question
{
    private Guid id;
    private string questionText;
    private int rightAnswer;

    public Question()
    {
        questionText = "";
        rightAnswer = 0;
        id = Guid.NewGuid();
    }

    public Question(string question, int answer)
    {
        id = Guid.NewGuid();
        questionText = question;
        rightAnswer = answer;
    }

    public bool IsCorrectAnswer(int userAnswer)
    {
        return userAnswer == rightAnswer;
    }

    public Guid Id
    {
        get
        {
            return id;
        }
    }

    public override string ToString()
    {
        return questionText;
    }
}

// --------------------------------------------------------------
// Question collection
// include or inheritanse ? 
public class Questions : IEnumerable<Question>
{
    private List<Question> questions;

    public Questions()
    {
        questions = new List<Question>();
    }

    // Implementing an enumerator
    // https://dotnetcodr.com/2017/11/15/implementing-an-enumerator-for-a-custom-object-in-net-c-3/
    //https://metanit.com/sharp/tutorial/4.12.php
    public IEnumerator<Question> GetEnumerator()
    {
        foreach (Question q in questions)
        {
            yield return q;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(string question, int answer)
    {
        questions.Add(new Question(question, answer));
    }
    public void LoadFromFile(string fileName)
    {
        // https://stackoverflow.com/questions/5282999/reading-csv-file-and-storing-values-into-an-array
        using (var reader = new StreamReader(fileName))
        {
            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(';');
                Add(values[0], Int32.Parse(values[1]));
            }
        }
    }

    public void Shuffle()
    {
        // https://stackoverflow.com/questions/5383498/shuffle-rearrange-randomly-a-liststring
        Random rnd = new Random();
        questions = questions.OrderBy(c => rnd.Next()).ToList<Question>();
    }

}