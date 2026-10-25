
using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _scriptureReference;
    private List<Word> _wordList;

    public Scripture(Reference reference, string text)
    {
        _scriptureReference = reference;
        _wordList = new List<Word>();

        string[] separatedWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string item in separatedWords)
        {
            _wordList.Add(new Word(item));
        }
    }

    public string DisplayRenderedText()
    {
        List<string> displayedWords = new List<string>();

        foreach (Word currentWord in _wordList)
        {
            displayedWords.Add(currentWord.GetRenderedText());
        }

        return _scriptureReference.GetReference() + " " + string.Join(" ", displayedWords);
    }

    public void HideRandomWords()
    {
        List<Word> availableWords = new List<Word>();

        foreach (Word currentWord in _wordList)
        {
            if (!currentWord.IsHidden())
            {
                availableWords.Add(currentWord);
            }
        }

        int amountToHide = Math.Min(4, availableWords.Count);

        for (int index = 0; index < amountToHide; index++)
        {
            int chosenIndex = Random.Shared.Next(availableWords.Count);

            availableWords[chosenIndex].HideWord();
            availableWords.RemoveAt(chosenIndex);
        }
    }

    public int CountVisibleWords()
    {
        int visibleCount = 0;

        foreach (Word currentWord in _wordList)
        {
            if (!currentWord.IsHidden())
            {
                visibleCount++;
            }
        }

        return visibleCount;
    }

    public bool IsCompletelyHidden()
    {
        return CountVisibleWords() == 0;
    }
}
