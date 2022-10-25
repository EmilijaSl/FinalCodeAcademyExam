var integers = new List<int> { 1, 2, 3, 4 };
var result = integers.Select(x => x == 1);
foreach (var i in result)
{
    Console.WriteLine(result);
}

