
using System;

public class Word
{
    private string _wordText;
    private bool _hidden;

    public Word(string text)
    {
        _wordText = text;
        _hidden = false;
    }

    public void HideWord()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public string GetRenderedText()
    {
        if (_hidden)
        {
            return new string('_', _wordText.Length);
        }

        return _wordText;
    }
}
