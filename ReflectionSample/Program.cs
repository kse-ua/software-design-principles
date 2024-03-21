var a = 8;

foreach (var i in GetSampleEnumaerable())
{
    Console.WriteLine("foreach");

    Console.WriteLine(i);
}

List<int> GetSampleList()
{
    var result = new List<int>();
    
    // code
    result.Add(1);
    result.Add(2);
    result.Add(4);
    result.Add(78);

    return result;
}

IEnumerable<int> GetSampleEnumaerable()
{
    yield break;
    Console.WriteLine("e1");
    yield return 1;
    Console.WriteLine("e2");
    yield return 2;
    Console.WriteLine("e3");
    yield return 4;
    Console.WriteLine("e4");
    yield return 78;
}