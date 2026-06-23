namespace WindowsDeveloperInterview.Interfaces;

public interface IBracketService
{
    bool IsBalanced(string input);
}

public interface ISortingService
{
    string[] SortAlphanumeric(string[] items);
    int SortDigitsDescending(int number);
}

public interface IAutocompleteService
{
    string[] Search(string search, string[] items, int maxResult);
}

public interface IRomanNumeralService
{
    string ToRoman(int number);
    int ToInt(string roman);
}

public interface ITribonacciService
{
    int[] GetSequence(int[] signature, int n);
}