List<string> words = new List<string>() { "AQUARIUM", "TURTLE", "CALENDAR",
"SMOOTHIE", "BEARD", "STRESSFUL", "ACADEMIC", "STRENGTH", "OFFICIAL",
"CONTINUUM", "VAMPIRIC", "PERPETUAL", "SMALLTALK", "GIGANTIC", "FAHRENHEIT",
"FINGERNAIL", "PSYCHOTIC", "FEARFUL", "COURAGEOUS", "WHEEL", "CONCATENATE",
"SPINNER", "SNOWFLAKE", "COURTESY", "PUNCTUATION", "FAREWELL", "HOUSEHOLD",
"SEPARATOR", "CONDITION", "METAPHYSICS", "ESSENTIAL", "DISTOPIAN",
"CAREFUL", "REFRIDGERATOR", "SENSITIVE", "COUNTER", "HAPPINESS",
"EXCELLENT", "BEAUTIFUL", "ADVENTURE", "DELICIOUS", "SERENITY", "SYMPHONY",
"WONDERFUL", "PARADISE", "BRILLIANT", "EXTRAVAGANZA", "PHENOMENAL",
"INCREDIBLE", "NECESSITY", "CELEBRATION", "OPPORTUNITY", "ENVIRONMENT",
"IMPRESSIVE", "RELIABILITY", "SATISFACTION", "EXTRAORDINARY", "REVOLUTIONARY",
"UNFORGETTABLE", "DEMONSTRATIVE", "SPONTANEITY", "COMMUNICATION", "COLLABORATION",
"INDEPENDENCE", "PRODUCTIVITY", "IMAGINATION", "EXTRAVAGANTLY", "UNDERSTANDING",
"COMMUNICATION", "UNBELIEVABLE", "REVOLUTIONARY", "CHARACTERISTICS",
"INDEPENDENTLY", "EXTRAORDINARY", "ENTERTAINMENT", "OPPORTUNITIES","ORGANIZATIONALLY",
"DETERMINATION", "CONSTITUTIONAL", "UNDERSTANDING", "COMMUNICATION", "INFRASTRUCTURE",
"ENVIRONMENTAL", "COLLABORATION", "COMPLICATIONS", "DEMONSTRATION", "ACCOMPLISHMENT",
"DISAPPOINTMENT", "INCONVENIENCE", "UNPREDICTABLE", "CIRCUMSTANTIAL", 
"INCOMPREHENSION", "MISUNDERSTANDING", "UNCONTROLLABLE", "DIFFERENTIATION", 
"UNINTENTIONALLY", "CONFRONTATIONAL", "MISCOMMUNICATION", "UNQUESTIONINGLY",
"INSTITUTIONALIZE", "CONCENTRATIONIST", "ACKNOWLEDGEMENT", "CORRESPONDENCES", 
"DISAPPOINTMENT", "UNQUESTIONABLE", "TRANSPORTATION", "CHARACTERISTIC", 
"INTERNATIONAL", "REVOLUTIONARY", "ACCOMMODATION", "DETERMINATION", "CONSERVATIONIST",
"MISUNDERSTOOD", "COMMUNICATION", "INTERCONNECTEDNESS", "SYZYGY", "JACQUARD", 
"BUZZWORD", "MYSTIQUE", "ZEPHYRUS", "QUICKSIX", "BROUHAHA", "ZEITGEIST", "QUIXOTIC", 
"BANJOIST", "HYPHENIC", "WEEKDAY", "JETLAG", "HUBBUB", "GOBSTOP", "FLUFFY", "WIZARD", 
"ZIPPY" };

int lives = 5;
var currentWord = TakeRandomWordFromList(words);

List<char> alreadyGuessed = new List<char>();

while (lives != 0)
{
    Console.Clear();
    if (DrawHangmanWord(currentWord, alreadyGuessed) == 0) break;
    DrawHangmanASCII(lives);
    Console.Write("Guess a letter:");
    var currentGuess = char.Parse(Console.ReadLine().ToUpper());
    if (!IsValidCharacter(currentGuess))
    {
        Console.WriteLine("Invalid input, press any key to guess again:");
        Console.ReadLine();
        continue;
    }

    if (IsLetterAlreadyGuessed(alreadyGuessed, currentGuess))
    {
        Console.WriteLine("You already tried that one. Press any key to guess again:");
        Console.ReadLine();
        continue;
    }

    else if (IsLetterPartOfWord(currentWord, currentGuess))
    {
        alreadyGuessed.Add(currentGuess);
        continue;
    }
    else { lives--; }
}
if (DrawHangmanWord(currentWord, alreadyGuessed) == 0)
{
    Console.Clear();
    DrawHangmanWord(currentWord, alreadyGuessed);
    Console.WriteLine();
    Console.WriteLine("You win!");
    Console.WriteLine("Press any key to end.");
    Console.ReadLine();
}
else if (lives == 0)
{
    Console.Clear();
    DrawHangmanWord(currentWord, alreadyGuessed);
    DrawHangmanASCII(lives);
    Console.WriteLine();
    Console.WriteLine($"You've been hanged. The word was {currentWord}.");
    Console.WriteLine("Press any key to end.");
    Console.ReadLine();
}
static int DrawHangmanWord(string word, List<char> guessed)
{
    var counterOfNonGuessedWords = 0;
    Console.WriteLine("HANGMAN CLASSIC ver. 1.02");
    Console.WriteLine();
    Console.Write(word[0]);
    for (int i = 1; i < word.Length - 1; i++)
    {
        if (guessed.Contains(word[i])) { Console.Write(" " + word[i]); }
        else
        {
            counterOfNonGuessedWords++;
            Console.Write(" _");
        }
    }
    var lastChar = word[word.Length - 1];
    Console.Write(" " + lastChar);
    Console.WriteLine();
    return counterOfNonGuessedWords;
}

static bool IsLetterAlreadyGuessed(List<char> chars, char c)
{
    if (chars.Contains(c))
    {
        return true;
    }
    else
    {
        chars.Add(c);
    }
    return false;
}
static bool IsLetterPartOfWord(string word, char letter)
{
    for (int i = 1; i < word.Length - 1; i++)
    {
        var iteratedLetter = word[i];
        if (letter == iteratedLetter)
        {
            return true;
        }
    }
    return false;
}

static string TakeRandomWordFromList(List<string> words)
{
    Random random = new Random();
    int randomIndex = random.Next(0, words.Count);
    return words[randomIndex];
}

static void DrawHangmanASCII(int lives)
{
    switch (lives)
    {
        case 0:
            Console.WriteLine(@"     ------------   ");
            Console.WriteLine(@"       |        |   ");
            Console.WriteLine(@"       0        |   ");
            Console.WriteLine(@"      /|\       |   ");
            Console.WriteLine(@"       |        |   ");
            Console.WriteLine(@"      / \       |   ");
            Console.WriteLine(@" ---YOU LOSE!----   ");
            break;

        case 1:
            Console.WriteLine(@"     ------------   ");
            Console.WriteLine(@"       |        |   ");
            Console.WriteLine(@"       0        |   ");
            Console.WriteLine(@"      /|\       |   ");
            Console.WriteLine(@"       |        |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@" ----------------   ");
            break;

        case 2:
            Console.WriteLine(@"     ------------   ");
            Console.WriteLine(@"       |        |   ");
            Console.WriteLine(@"       0        |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@" ----------------   ");
            break;

        case 3:
            Console.WriteLine(@"     ------------   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@" ----------------   ");
            break;

        case 4:
            Console.WriteLine(@"                    ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@"                |   ");
            Console.WriteLine(@" ----------------   ");
            break;

        case 5:
            Console.WriteLine(@"                    ");
            Console.WriteLine(@"                    ");
            Console.WriteLine(@"                    ");
            Console.WriteLine(@"                    ");
            Console.WriteLine(@"                    ");
            Console.WriteLine(@"                    ");
            Console.WriteLine(@" ----------------   ");
            break;
    }
}
static bool IsValidCharacter(char ch)
{
    if (ch == 'a' || ch == 'b' || ch == 'c' || ch == 'd' ||
        ch == 'e' || ch == 'f' || ch == 'g' || ch == 'h' ||
        ch == 'i' || ch == 'j' || ch == 'k' || ch == 'l' ||
        ch == 'm' || ch == 'n' || ch == 'o' || ch == 'p' ||
        ch == 'r' || ch == 's' || ch == 't' || ch == 'q' ||
        ch == 'u' || ch == 'v' || ch == 'w' || ch == 'x' ||
        ch == 'y' || ch == 'z' || ch == 'A' || ch == 'B' ||
        ch == 'C' || ch == 'D' || ch == 'E' || ch == 'F' ||
        ch == 'G' || ch == 'H' || ch == 'I' || ch == 'J' ||
        ch == 'K' || ch == 'L' || ch == 'M' || ch == 'N' ||
        ch == 'O' || ch == 'P' || ch == 'Q' || ch == 'R' ||
        ch == 'S' || ch == 'T' || ch == 'U' || ch == 'V' ||
        ch == 'W' || ch == 'X' || ch == 'Y' || ch == 'Z') { return true; }
    return false;
}