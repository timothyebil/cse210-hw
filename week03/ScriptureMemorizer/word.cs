public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() => _isHidden = true;

    public bool IsHidden() => _isHidden;

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replace letters with underscores, keeping punctuation if desired
            return new string('_', _text.Length);
        }
        return _text;
    }
}
