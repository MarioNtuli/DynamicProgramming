using System;
using System.Collections.Generic;

namespace DynamicPrograming
{
    class Program
    {
        private static List<List<string>> results = null;
        private static List<string> combination = new List<string>();
        static void Main(string[] args)
        {
            var memo = new Dictionary<string, int>();
            string[] strings = { "purp","ur","le","p","purpl"};
            var data = allConstruct("purple", strings);
        }
        public static long fib(int n, ref Dictionary<int, long> memo)
        {
            if (memo.ContainsKey(n)) {
                return memo[n];
             };
            if (n <= 2)
            {
                return 1;
            }
            else
            {
                memo[n] = fib(n - 1,ref memo) + fib(n - 2,ref memo);
            }
            return memo[n];

        }
        public static long gridTraveller(int row , int column, ref Dictionary<KeyValuePair<int,int>, long> memo)
        {
            if (memo.ContainsKey(new KeyValuePair<int, int>(row,column)))
            {
                return memo[new KeyValuePair<int, int>(row, column)];
            };
            if (row == 0 || column == 0)
            {
                return 0;
            }else if(row == 1 && column == 1)
            {
                return 1;
            }
            else
            {
                memo[new KeyValuePair<int, int>(row, column)] = gridTraveller(row - 1, column , ref memo) + 
                    gridTraveller(row , column - 1, ref memo);
            }
            return memo[new KeyValuePair<int, int>(row, column)];
        }
        public static List<int> howSum(int targetSum, int[] numbers,ref Dictionary<int, List<int>> memo)
        {
            List<int> values = null;
            if (targetSum == 0) 
            {
                return new List<int>(); ;
            }
            if (targetSum < 0)
            {
                return null;
            }
            if (memo.ContainsKey(targetSum))
            {
                return memo[targetSum];
            }
            foreach (var item in numbers)
            {
                values = howSum(targetSum - item, numbers, ref memo);
                if (values != null)
                {
                    values.Add(item);
                    memo[targetSum] = values;
                    return memo[targetSum];
                }
            }
            memo[targetSum] = null;
            return null;
        }
        public static bool canConstruct(string targetString, string[] wordBank, ref Dictionary<string,bool> memo)
        {
            if (memo.ContainsKey(targetString))
            {
                return memo[targetString];
            }
            if (String.IsNullOrEmpty(targetString))
            {
                return true;
            }
            foreach (var item in wordBank)
            {
                char[] MyChar = item.ToCharArray();
                if (targetString.StartsWith(item))
                {
                    
                    var node = targetString.TrimStart(MyChar);
                    if(canConstruct(node, wordBank,ref memo)== true)
                    {
                        memo[targetString] = true;
                        return memo[targetString];
                    }
                }
                
            }
            return false;
        }
        public static bool StartsWithAny( string source, IEnumerable<string> strings)
        {
            foreach (var valueToCheck in strings)
            {
                if (source.StartsWith(valueToCheck))
                {
                    return true;
                }
            }

            return false;
        }
        public static int countConstruct(string targetString, string[] wordBank, ref Dictionary<string, int> memo)
        {
            int count = 0;
            if (memo.ContainsKey(targetString))
            {
                return memo[targetString];
            }
            if (String.IsNullOrEmpty(targetString))
            {
                return 1;
            }
            foreach (var item in wordBank)
            {
                var MyChar = item.ToCharArray();
                if (targetString.StartsWith(item))
                {
                    count += countConstruct(targetString.TrimStart(MyChar), wordBank, ref memo);
                    memo[targetString] = count;
                }
            }
            memo[targetString] = count;
            return count;
        }
        public static List<List<string>> allConstruct(string targetString, string[] wordBank)
        {
            
            
            if (String.IsNullOrEmpty(targetString))
            {
                combination = new List<string>();
                return new List<List<string>>();
            }
            foreach (var item in wordBank)
            {
                var MyChar = item.ToCharArray();
                if (targetString.StartsWith(item))
                {
                    if(combination != null)
                    {
                        combination.Add(item);
                        results = allConstruct(targetString.TrimStart(MyChar), wordBank);
                        results.Add(combination);
                    }
                    
                }
            }
            return results;
        }

    }
}
