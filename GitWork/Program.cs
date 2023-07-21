using Newtonsoft.Json;

namespace GitWork;

public class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> list1 = new LinkedList<int>();
        list1.AddFirst(7);
        list1.AddFirst(3);
        list1.AddFirst(8);
        list1.AddFirst(5);
        foreach (int i in list1) Console.WriteLine(i);
        LinkedList<int> list2 = new();
        list2.AddFirst(6);
        list2.AddFirst(1);
        list2.AddFirst(8);
        foreach (int i in NewMethod(list1, list2))
        {
            Console.WriteLine(i);
        }
        //NewMethod(list1, list2);
        
    }
    
    private static LinkedList<int> NewMethod(LinkedList<int> list11, LinkedList<int> list22)
    {
        List<int> list1 = list11.ToList();
        List<int> list2 = list22.ToList();
       // list1.Reverse(); list2.Reverse();
        int r = 0;

        if (list1.Count > list2.Count)
        {
            for (int i = 0; i < list1.Count - list2.Count; i++)
            {
                list2.Add(0);
            }
        }
        else
        {
            for (int i = 0; i < list2.Count - list1.Count; i++)
            {
                list1.Add(0);
            }
        }
        LinkedList<int> list3 = new();
        
        //5 8 3 7 
        //8 1 6 0
        for (int i = 0; i < list1.Count; i++)
        {
            if (i == 0)
            {
                if (list1[i] + list2[i] >= 10)
                {
                    list3.AddFirst((list1[i] + list2[i]) % 10);
                    r = 1; continue;
                }
                else
                {
                    list3.AddFirst((list1[i] + list2[i])); continue;
                }
            }
            else
            {
                if (list1[i] + list2[i] + r >= 10)
                {
                    list3.AddFirst((list1[i] + list2[i] + r) % 10);
                    r = 1; continue;
                }
                else
                {
                    list3.AddFirst(list1[i] + list2[i] + r);
                    r = 0; continue;
                }
            }
            r = list1[i] + list2[i] / 10;
        }
        list3.Reverse();
        return list3;
    }
}