

static string Reverse(string word)
{
    int index = 1;
    for (int i = word.Length; i > 0; i--)
    {
        word[i] = word[index];
        index++;
    }
    return word;
}
string word = "hey";
Reverse(word);



