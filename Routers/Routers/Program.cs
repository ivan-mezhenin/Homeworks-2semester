// <copyright file="Program.cs" company="ivan-mezhenin">
// Copyright (c) ivan-mezhenin. All rights reserved.
// </copyright>

using Routers;

Console.WriteLine("Routers. Write dotnet run -- FileToRead FileToWrite");

try
{
    var graph = new Graph(args[0]);
    var answerGraph = graph.SearchMaxSpanningTree();
    answerGraph.WriteGraphToFile(args[1]);
}
catch (PassingNullGraphException exception)
{
    Console.WriteLine(exception);
    return 1;
}
catch (GraphIsNotConnectedException exception)
{
    Console.WriteLine(exception);
    return 1;
}
catch (FormatException exception)
{
    Console.WriteLine(exception);
    return 1;
}
catch (FileNotFoundException exception)
{
    Console.WriteLine(exception);
    return 1;
}
catch (EdgeAlreadyExistException exception)
{
    Console.WriteLine(exception);
    return 1;
}

return 0;