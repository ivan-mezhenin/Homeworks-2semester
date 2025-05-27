namespace BWT;

/// <summary>
/// tests for BWT.
/// </summary>
public class Test
{
    /// <summary>
    /// complete all tests.
    /// </summary>
    /// <returns>true if all tests were completed.</returns>
    public static bool TestsComplete()
    {
        bool[] testsResults =
        [
            Test1(),
            Test2(),
            Test3(),
            Test4(),
            Test5(),
            Test6(),
        ];

        for (var i = 0; i < testsResults.Length; ++i)
        {
            if (!testsResults[i])
            {
                Console.WriteLine($"Test {i + 1} is failed");
                return false;
            }
        }

        return true;
    }

    private static bool Test1()
    => BWt.Transform("abacaba") == ("bcabaaa", 3);

    private static bool Test2()
    => BWt.Transform("абракадабра") == ("рдакраааабб", 3);

    private static bool Test3()
    => BWt.Transform("hahaha") == ("hhhaaa", 4);

    private static bool Test4()
    => BWt.ReverseTransform("bcabaaa", 3) == "abacaba";

    private static bool Test5()
    => BWt.ReverseTransform("вина", 3) == "иван";

    private static bool Test6()
    => BWt.ReverseTransform("nnbaaa", 4) == "banana";
}
