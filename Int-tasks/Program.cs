using Int_tasks;
using System.Collections.Generic;
public class Program
{
    static void Main(string[] args)
    {

        //RemoveDuplicates();                               /*--Remove Duplicates only -- IP:{12, 5, 5, 22}  -- OP:{12,5,22}*/

        //removeduplicatenumbers();                         /*--Remove Duplicates and Original value -- IP:{12, 5, 5, 22}  -- OP:{12,22}*/

        //GetCharCount("GUNAGUNAGUNA".ToCharArray());       /*--Get Charector Count -- IP:{G,G,A}  -- OP:G=2 A=1*/

        //findminmax();                                     /*--Find Max and Min value --IP:{1,45,78,34} --OP:MAx:78,Min:1 */

        //findthirdlargest();                               /*--Find Third Largest nuber on given array*/

        //AddEvenAscDesc();             /* --Add Index is ASC order Even index is Descending order Asc,Desc,Asc,Desc --IP: {45,1,2,78,34}   --OP:{1,78,2,45,34}*/

        //removeDuplicateChar("Guunnnnnaaaaa");             /*Remove Duplicate charectors form given string.*/

        //FindNonRepeatingString("Guunnnaasa");             /*Find Non Repeating String IP:Guunasaa  OP:Gns*/

        //reverseWords("Guna".ToCharArray());               /*Reverse Given Charectors*/

        //FindDuplicateWordCount();                         /*Find Duplicate Word Count*/    

        //ChessBoardPattern();                              /*Create ChessBoard BluePrint*/

        //forech_parallelforech();
        //int[] arr = { 2, 3, 5, 7, 10, 15, 20 };int target = 15;
        //binarySearch(arr, 1, arr.Length - 1, target);                 /*Find given Value Index*/

        //int[] request = { 5, 4, 8, 2, 1, 6, 7, 9, 3, 10 };
        //bubbleSort(request);                                          /*Bubble Sort algorithm for sorting*/

        //Linq objLinqquery = new Linq();
        /*get standard based count*/
        //objLinqquery.getstandardcount();
        /*List out the student name based on Standards*/
        //objLinqquery.getstudentdetails();


        Console.ReadLine();
    }

    static void RemoveDuplicates()
    {
        int[] request = { 12, 5, 5, 22, 9, 5, 78, 1, 9, 7, 1 };
        int[] response = new int[request.Length];
        int index = 0;
        for(int i=0; i < request.Length; i++)
        {
            if (!response.Any(x => x == request[i]))
            {
                response[index] = request[i];
                index++;
            }
        }
        Array.Resize(ref response,index);
        printArray(response);
    }

    static void removeduplicatenumbers()
    {
        int[] arr = { 12, 5, 5, 22, 9, 5, 78, 1, 9, 7, 1 };
        int[] Result = new int[arr.Length];
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            bool isValid = true;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    isValid = false; break;
                }
            }

            if (isValid)
            {
                Result[index] = arr[i]; index++;
            }
        }                                           //result: {12,5,22,9,78,1,7,0,0,0} 
        Array.Resize(ref Result, index);            //result: {12,5,22,9,78,1,7} 

        //Array.Sort(Result);                                       //After in-Build Sorting : {1,5,7,9,12,22,78};
        //var _res=Result.OrderBy(x => x).Reverse().ToArray();      //After in-Build  with Reverse Sorting : {1,5,7,9,12,22,78} & {78,22,12,9,7,5,1};
        //var res = Result.OrderByDescending(x => x).ToArray();       //After in-Build Sorting : {78,22,12,9,7,5,1};
        int item = 0;
        for (int x = 0; x < Result.Length; x++)
        {
            for (int y = x + 1; y < Result.Length; y++)
            {
                if (Result[x] > Result[y])
                {
                    item = Result[x];
                    Result[x] = Result[y];
                    Result[y] = item;
                }
            }
        }           //After Sorting : {1,5,7,9,12,22,78}

        printArray(Result);
        //foreach (var i in Result) { Console.WriteLine(i); }

    }

    static void findminmax()
    {
        int[] request = { 12, 5, 5, 22, 56, 78, 1, 9, 7, 65 };
        int max = request[0];
        int min = request[0];
        for (int i = 0; i < request.Length; i++)
        {
            if (max < request[i])
            {
                max = request[i];
            }
            else if (min > request[i])
            {
                min = request[i];
            }
        }
        Console.WriteLine("Minimum :" + min.ToString() + "  Maximun:" + max.ToString());
        Console.ReadLine();
    }

    static void findthirdlargest()
    {
                                                    /* Using  In-Build function */
        //int[] req = array;
        //Array.Sort(req);
        //Console.WriteLine(req[req.Length - 2]+"\n");
                                                    /*without using in-build function*/
        int[] array = { 100, 2, 3, 24, 10, 40 };
        int firstHigh = array[0], secondHigh = 0, thirdHigh = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > firstHigh)
            {
                thirdHigh = secondHigh;
                secondHigh = firstHigh;
                firstHigh = array[i];
            }
            else if (array[i] > secondHigh)
            {
                thirdHigh = secondHigh;
                secondHigh = array[i];
            }
            else if (array[i] > thirdHigh)
            {
                thirdHigh = array[i];
            }
        }

        Console.WriteLine(thirdHigh);
    }

    static void AddEvenAscDesc()
    {
        int[] request = { 2, 4, 6, 1, 12, 67, 90, 54, 10, 3 };
        Array.Sort(request);
        int[] response = new int[request.Length];
        int j = 0;
        for (int i = 0; i < request.Length; i++)
        {
            if (i == 0 || i % 2 == 0)
            {
                response[i] = request[j]; j++;
            }
            else
            {
                response[i] = request[request.Length - j];
            }

        }

        Console.WriteLine("Given Array: ");
        printArray(request);
        Console.WriteLine("\nOutPut Array: ");
        foreach (var x in response) { Console.Write(x + " "); }
    }

    static void removeDuplicateChar(string myStr)
    {
        Console.WriteLine("Initial String: " + myStr);
        HashSet<char> unique = new HashSet<char>(myStr);
        Console.Write("New String after removing duplicates: ");
        foreach (char c in unique)
            Console.Write(c);
    }

    static void FindNonRepeatingString(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            bool result = false;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[i] == str[j] & i != j)
                {
                    result = true; break;
                }
            }
            if (!result)
            {
                Console.WriteLine(str[i]);
            }
        }
    }

    static void reverseWords(char[] lstTxt)
    {
        //for (int i = lstTxt.Length - 1; i >= 0; i--) { Console.Write(lstTxt[i]); }
        Console.Write("\n Reversed String:");
        for (int i = 1; i <= lstTxt.Length; i++) 
        {
            Console.Write(lstTxt[lstTxt.Length - i]);
        }
    }

    public static void GetCharCount(char[] req)
    {

        Dictionary<char, int> Result = new Dictionary<char, int>();
        for (int i = 0; i < req.Length; i++)
        {
            if (Result.ContainsKey(req[i]))
            {
                int value = Result[req[i]];
                Result[req[i]] = value + 1;
            }
            else
            {
                Result.Add(req[i], 1);
            }
        }

        foreach (var item in Result)
        {

            Console.WriteLine(item.Key + " Count is " + item.Value.ToString());
        }


    }

    static void FindDuplicateWordCount()
    {
        string[] lsttext = "guna test data for test".ToLower().Split(" ");
        try
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < lsttext.Length; i++)
            {
                if (result.ContainsKey(lsttext[i]))
                {
                    int value = result[lsttext[i]];
                    result[lsttext[i]] = value + 1;
                }
                else
                {
                    result.Add(lsttext[i], 1);
                }
            }
            //result.Where(x => x.Value > 1);
            foreach (var kvp in result.Where(x => x.Value > 1))
            {
                Console.WriteLine(kvp.Key + " Counts are " + kvp.Value);  // Print the Repeated word and its count  
            }
        }
        finally
        {
            GC.Collect();
        }

    }

    static void ChessBoardPattern()
    {
        int rows = 8;
        int cols = 8;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(((i + j) % 2 == 0) ? "X " : "  ");
            }
            Console.WriteLine();
        }
    }

    static void forech_parallelforech()
    {
        List<string> fruits = new List<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Bilberry");
        fruits.Add("Blackberry");
        fruits.Add("Blackcurrant");
        fruits.Add("Blueberry");
        fruits.Add("Cherry");
        fruits.Add("Coconut");
        fruits.Add("Cranberry");
        fruits.Add("Date");
        fruits.Add("Fig");
        fruits.Add("Grape");
        fruits.Add("Guava");
        fruits.Add("Jack-fruit");
        fruits.Add("Kiwi fruit");
        fruits.Add("Lemon");
        fruits.Add("Lime");
        fruits.Add("Lychee");
        fruits.Add("Mango");
        fruits.Add("Melon");
        fruits.Add("Olive");
        fruits.Add("Orange");
        fruits.Add("Papaya");
        fruits.Add("Plum");
        fruits.Add("Pineapple");
        fruits.Add("Pomegranate");

        Parallel.ForEach(fruits, fruit => { Console.WriteLine("Fruit Name: {0}", fruit); });

        Console.WriteLine("\n\n\n Foreach \n\n");
        foreach (var item in fruits)
        {
            Console.WriteLine("Fruit Name: " + item);
        }
    }

    static int binarySearch(int[] arr, int i, int l, int x)
    {
        /*arr=>Array,   i=starting index,   l=total array length,   x = Target value */

        if (l >= i)
        {
            int mid = i + (l - i) / 2;
            if (arr[mid] == x) { Console.WriteLine(mid); }
            if (arr[mid] > x) { return binarySearch(arr, i, mid - 1, x); }
            return binarySearch(arr, mid + 1, l, x);
        }
        return -1;
    }

    static void bubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                if (arr[i] > arr[j])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
        printArray(arr);
    }

    /* Prints the array */
    static void printArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; ++i) { Console.Write(arr[i] + " "); }
        Console.WriteLine();
    }

}

interface IG1 { void sampleMethod(); }

interface IG2 { void sampleMethod(); }

class sampleClass : IG1, IG2
{
    //Execution methord
    //IG1 obj = new sampleClass();
    //obj.sampleMethod();
    //IG2 obj1 = new sampleClass();
    //obj1.sampleMethod();

    public void sampleMethod()
    {
        Console.WriteLine("HelloWord");
    }
}