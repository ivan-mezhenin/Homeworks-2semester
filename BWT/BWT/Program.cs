using BWT;

if (!Test.TestsComplete())
{
    return;
}

Console.WriteLine("Write: '1 word' if you want transform word / '2 word position' - if you want reverse transform");

switch (args[0])
    {
    case "1":
        {
            var answer = BWt.Transform(args[1]);
            Console.WriteLine($"{answer.TransformWord}: {answer.Position}");
            break;
        }

    case "2":
        {
            var answer = BWt.ReverseTransform(args[1], Convert.ToInt32(args[2]));
            Console.WriteLine($"{answer}");
            break;
        }
    }
