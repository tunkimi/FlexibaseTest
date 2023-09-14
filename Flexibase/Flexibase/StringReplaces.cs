

using System.Text;

namespace Flexibase
{
    public class StringReplaces
    {
        static void Main(string[] args)
        {
            var a = CollectReplaces(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, //коллекция чисел, с которыми будут проводиться пребразования
                new Dictionary<int, string> { //словарь замен <делитель, слово>
                    [3] = "fizz",
                    [5] = "buzz"
                    }, null);
            Console.WriteLine($"ex1:\n{PrintObjectResult(a)}\n\n");
            var b = CollectReplaces(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 },
                new Dictionary<int, string>
                {
                    [3] = "fizz",
                    [5] = "buzz",
                    [4] = "muzz",
                    [7] = "guzz"
                }, null);
            Console.WriteLine($"ex2:\n{PrintObjectResult(b)}\n\n");

            var c = CollectReplaces(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 },
                new Dictionary<int, string>
                {
                    [3] = "fizz",
                    [5] = "buzz",
                    [4] = "muzz",
                    [7] = "guzz"
                }, 
                new Dictionary<int[], string>//словарь перекрытий (замены с более высоким приоритетом) + замена по двум делителям
                {
                    [new int[] { 3, 5 }] = "good-boy",
                    [new int[] {3}] = "dog",
                    [new int[] {5}] = "cat"
                });
            Console.WriteLine($"ex3:\n{PrintObjectResult(c)}\n\n");
        }
        public static string PrintObjectResult(List<object> b)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in b)
                sb.Append(item.ToString()).Append(", ");
            return sb.Remove(sb.Length-2,2).ToString();
        }

        public struct Divs
        {
            public int num;
            public int[] divs;
        }

        public static List<object> CollectReplaces(List<int> list, Dictionary<int, string> replases, Dictionary<int[], string>? overlapases)
        {
            List<Divs> divs = new List<Divs>();
            for(int i = 0; i < list.Count; i++)
            {
                divs.Add(GetActualDividers(list[i], replases.Keys.ToArray()));
            }
            List<object> result = new List<object>();

            for (int i = 0; i < list.Count; i++)
            {
                if (divs[i].divs.Length == 0)
                {
                    result.Add(divs[i].num);
                    continue;
                }
                result.Add(ReplacingbyDividers(divs[i].divs, replases, overlapases));

            }
            return result;
        }

        public static string ReplacingbyDividers(int[] divs, Dictionary<int, string> replaces, Dictionary<int[], string>? overlapases)
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < divs.Length;i++)
            {
                if (overlapases != null) 
                {
                    var replased = false;
                    var keysarr = overlapases.Keys.Where(a => a.Contains(divs[i])).ToArray();
                    if (keysarr.Count() != 0)
                    {

                        foreach (var keys in keysarr)
                        {
                            var overlape = true;
                            foreach (var key in keys)
                                if (!divs.Contains(key))
                                    overlape = false;
                            if (overlape)
                            {
                                foreach (var key in keys)
                                    divs[Array.IndexOf(divs, key)] = 0;
                                sb.Append("-").Append(overlapases[keys]);
                                replased = true;
                                break;
                            }
                        }
                        if(!replased)
                            sb.Append("-").Append(replaces[divs[i]]);
                    }
                    else if(divs[i]!=0)
                        sb.Append("-").Append(replaces[divs[i]]);
                }
                else
                    sb.Append("-").Append(replaces[divs[i]]);
            }
            return sb.Remove(0,1).ToString();
        }

        public static Divs GetActualDividers(int num, int[] dividers)
        {
            Divs divs = new Divs() { num = num, divs = new int[0] };
            var temp = new List<int>();
            for(int i = 0; i < dividers.Length; i++)
            {
                if (num % dividers[i] == 0)
                    temp.Add(dividers[i]);
            }
            divs.divs = temp.ToArray();
            return divs;
        }
    }
}