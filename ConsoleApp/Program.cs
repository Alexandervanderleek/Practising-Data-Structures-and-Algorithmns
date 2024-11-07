using DataAlgos;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security;
using System.Security.AccessControl;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static DataAlgos.LinkingLists;

namespace DataAlgos
{
    class ArrayAndStringManipulator
    {
        //find number closest to 0, return largest if same difference i.e -1 and 1 returns 1
        public int FindClosestNumber(int[] nums)
        {
            int best = int.MaxValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (Math.Abs(nums[i]) < Math.Abs(best))
                {
                    best = nums[i];
                }
                else if (Math.Abs(nums[i]) == Math.Abs(best))
                {
                    best = Math.Max(best, nums[i]);
                }
            }

            return best;

        }

        // public string MergeAlternately(string word1, string word2)
        // {
        //     //StringBuilder res = new StringBuilder();
        //     int i = 0, j = 0;
        //     while (i < word1.Length && j < word2.Length)
        //     {
        //         res.Append(word1[i]).Append(word2[j]);
        //         i++;
        //         j++;
        //     }

        //     while (i < word1.Length)
        //     {
        //         res.Append(word1[i]);
        //         i++;
        //     }

        //     while (j < word2.Length)
        //     {
        //         res.Append(word2[j]);
        //         j++;
        //     }

        //     return res.ToString();
        // }

        public int RomanToInt(string s)
        {
            Dictionary<char, int> romanDigits = new()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            var result = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (romanDigits[s[i]] < romanDigits[s[i + 1]])
                    result -= romanDigits[s[i]];
                else
                    result += romanDigits[s[i]];
            }

            return result + romanDigits[s[s.Length - 1]];
        }

        public bool IsSubsequence(string s, string t)
        {

            foreach (char c in s)
            {
                if (t.Contains(c))
                {

                    t = t.Substring(t.IndexOf(c) + 1, t.Length - (t.IndexOf(c) + 1));
                    continue;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

        public int MaxProfit(int[] prices)
        {
            int currentMaxProfit = 0;
            int lowestSharePrice = prices[0];


            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > lowestSharePrice)
                {
                    currentMaxProfit = Math.Max(prices[i] - lowestSharePrice, currentMaxProfit);
                } else {
                    lowestSharePrice = prices[i];
                }
            }

            return currentMaxProfit;

        }

        public string LongestCommonPrefix(string[] strs)
        {
            string longestMatch = strs[0];

            for (int i = 1; i < strs.Length; i++)
            {
                int min = Math.Min(strs[i].Length, longestMatch.Length);

                if (min == 0)
                {
                    return "";
                }

                for (int j = 0; j < min; j++)
                {

                    if (longestMatch[j] != strs[i][j])
                    {

                        longestMatch = longestMatch.Substring(0, j);


                        if (longestMatch == "")
                        {
                            return "";
                        }
                        break;
                    } else if (min == j + 1)
                    {
                        longestMatch = longestMatch.Substring(0, min);
                    }
                }

            }

            return longestMatch;

        }

        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> result = new List<string>();
            if (nums.Length == 0) return result;

            int start = nums[0];

            for (int i = 1; i <= nums.Length; i++)
            {
                // Check if the current number is not consecutive
                if (i == nums.Length || nums[i] != nums[i - 1] + 1)
                {
                    if (start == nums[i - 1])
                    {
                        result.Add(start.ToString());
                    }
                    else
                    {
                        result.Add(start + "->" + nums[i - 1]);
                    }
                    // Update the start to the current number
                    if (i < nums.Length)
                    {
                        start = nums[i];
                    }
                }
            }

            return result;

        }

        public int[] ProductExceptSelf(int[] nums) {

            int[] outputForward = new int[nums.Length];
            int[] outputBakward = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++) {
                if (i == 0) {
                    outputBakward[nums.Length - (i + 1)] = nums[nums.Length - (i + 1)];
                    outputForward[i] = nums[i];
                } else {
                    outputForward[i] = outputForward[i - 1] * nums[i];
                    outputBakward[nums.Length - (i + 1)] = nums[nums.Length - (i + 1)] * outputBakward[nums.Length - (i)];
                }
            }

            nums[0] = outputBakward[1];
            nums[nums.Length - 1] = outputForward[nums.Length - 2];

            for (int x = 1; x < nums.Length - 1; x++) {
                nums[x] = outputForward[x - 1] * outputBakward[x + 1];
            }

            return nums;

        }

        public int[][] Merge(int[][] intervals) {


            Array.Sort(intervals, (x, y) => x[0] - y[0]);

            List<int[]> result = new List<int[]>();

            result.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; i++) {
                int length = result.Count - 1;
                if (result[length][1] >= intervals[i][0]) {
                    result[length][1] = Math.Max(intervals[i][1], result[length][1]);
                } else {
                    result.Add(intervals[i]);
                }
            }

            return result.ToArray();

        }

        public IList<int> SpiralOrder(int[][] matrix) {

            int xLength = matrix[0].Length;
            int yLength = matrix.Length;

            List<int> results = new List<int>();

            int posX = 0;
            int posY = 0;

            char movement = 'R';

            for (int i = 0; i < xLength * yLength; i++) {
                switch (movement) {
                    case 'R':
                        results.Add(matrix[posY][posX]);
                        matrix[posY][posX] = 101;
                        posX++;
                        if (posX >= xLength || matrix[posY][posX] == 101) {
                            posY++;
                            posX--;
                            movement = 'D';
                        }
                        break;
                    case 'D':
                        results.Add(matrix[posY][posX]);
                        matrix[posY][posX] = 101;
                        posY++;
                        if (posY >= yLength || matrix[posY][posX] == 101) {
                            posX--;
                            movement = 'L';
                            posY--;
                        }
                        break;
                    case 'L':
                        results.Add(matrix[posY][posX]);
                        matrix[posY][posX] = 101;
                        posX--;
                        if (posX < 0 || matrix[posY][posX] == 101) {
                            posX++;
                            posY--;
                            movement = 'U';
                        }
                        break;
                    case 'U':
                        results.Add(matrix[posY][posX]);
                        matrix[posY][posX] = 101;
                        posY--;
                        if (posY < 0 || matrix[posY][posX] == 101) {
                            posY++;
                            posX++;
                            movement = 'R';
                        }
                        break;
                }
            }
            return results;
        }

        public void Rotate(int[][] matrix) {
            // First, transpose the matrix
            Transpose(matrix);

            // Then, reverse each row to get the rotated matrix
            ReverseRows(matrix);
        }

        private void Transpose(int[][] matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    // Swap the elements at (i, j) and (j, i)
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        private void ReverseRows(int[][] matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                // Reverse each row
                Array.Reverse(matrix[i]);
            }
        }

    }

    class DictionaryAndSets {
        public int NumJewelsInStones(string jewels, string stones) {

            var set = jewels.ToHashSet();
            int output = 0;

            foreach (char x in stones) {
                if (set.Contains(x)) {
                    output++;
                }
            }

            return output;

        }

        public bool ContainsDuplicate(int[] nums) {

            HashSet<int> mySet = nums.ToHashSet<int>();

            return mySet.Count != mySet.Count;
        }

        public bool CanConstruct(string ransomNote, string magazine) {

            List<char> mag = [.. magazine];

            foreach (char letter in ransomNote) {
                if (!mag.Remove(letter)) {
                    return false;
                }
            }

            return true;
        }

        public bool IsAnagram(string s, string t) {

            int[] lettersInt = new int[27];

            foreach (char x in s) {
                lettersInt[x - 'a']++;
            }

            foreach (char x in t) {
                lettersInt[x - 'a']--;
            }

            return lettersInt.All(x => x == 0);
        }

        public int MaxNumberOfBalloons(string text) {

            Dictionary<char, int> balloon = new Dictionary<char, int>{
                { 'b', 0 },
                { 'a', 0 },
                { 'l', 0 },
                { 'o', 0 },
                {'n', 0},
            };

            foreach (char letter in text) {
                if (balloon.ContainsKey(letter)) {
                    balloon[letter]++;
                }
            }

            balloon['l'] /= 2;
            balloon['o'] /= 2;

            //Console.WriteLine(balloon.Values.Min());





            return balloon.Values.Min();
        }

        public int[] TwoSum(int[] nums, int target) {

            Dictionary<int, int> numMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++) {
                int complement = target - nums[i];

                if (numMap.ContainsKey(complement)) {
                    return new int[] { numMap[complement], i };
                }
                // storing the number as key and index as value as number will be the first to be found
                numMap[nums[i]] = i;
            }

            return [0, 0];

        }

        public bool IsValidSudoku(char[][] board) {

            Dictionary<char, int>[] boards = [[], [], []];

            Dictionary<char, int> row = [];

            Dictionary<char, int> col = [];

            //three conditions
            //1. Row numbers 1-9 not rep, 2. Col numbers 1-9 no rep, 3. 3x3 numbers 1-9 no rep
            for (int y = 0; y < 9; y++) {
                for (int x = 0; x < 9; x++) {
                    if (board[y][x] != '.') {
                        if (!boards[x / 3].TryAdd(board[y][x], 1)) {
                            return false;
                        }
                        if (!row.TryAdd(board[y][x], 1)) {
                            return false;
                        }

                    }
                    if (board[x][y] != '.') {
                        if (!col.TryAdd(board[x][y], 1)) {
                            return false;
                        }
                    }
                }

                col.Clear();
                row.Clear();
                if (y == 2 || y == 5) {
                    boards[0].Clear();
                    boards[1].Clear();
                    boards[2].Clear();
                }
            }

            return true;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs) {


            HashSet<string> seen = new HashSet<string>();

            Dictionary<string, IList<string>> myDict = new Dictionary<string, IList<string>>();

            foreach (string str in strs) {

                char[] charArray = str.ToCharArray();
                Array.Sort(charArray);
                string current = new string(charArray);

                //Console.WriteLine(current);

                //string current = string.Join("",str.ToList().Order());

                if (myDict.ContainsKey(current)) {
                    myDict[current].Add(str);
                }
                else {
                    myDict[current] = new List<string> { str };
                }

            }


            return myDict.Values.ToList();

        }

        public int MajorityElement(int[] nums) {

            Dictionary<int, int> myDict = new Dictionary<int, int>();

            foreach (int i in nums) {
                if (myDict.ContainsKey(i)) {
                    myDict[i]++;
                } else {
                    myDict[i] = 1;
                }
            }

            return myDict.MaxBy(kvp => kvp.Value).Key;
        }

        public int LongestConsecutive(int[] nums) {

            HashSet<int> myInts = nums.ToHashSet();
            int longestSeq = 0;

            foreach (int num in nums) {
                int currentNumber = num;
                if (myInts.Remove(currentNumber)) {
                    int currentRun = 1;
                    // Console.WriteLine("removed "+currentNumber);
                    currentNumber -= 1;
                    // Console.WriteLine("Next_"+currentNumber);
                    while (myInts.Remove(currentNumber)) {
                        // Console.WriteLine("removed "+currentNumber);
                        currentNumber -= 1;
                        currentRun++;
                    }
                    currentNumber = num;
                    currentNumber += 1;
                    // Console.WriteLine("Next_"+currentNumber);
                    while (myInts.Remove(currentNumber)) {
                        // Console.WriteLine("removed "+currentNumber);
                        currentNumber += 1;
                        currentRun++;
                    }
                    longestSeq = Math.Max(currentRun, longestSeq);
                }

            }

            return longestSeq;
        }

    }

    class TwoPointers {
        public int[] SortedSquares(int[] nums) {

            int pointerEnd = nums.Length - 1;
            int pointerStart = 0;

            int[] results = new int[nums.Length];

            while (pointerEnd >= pointerStart) {

                if (Math.Abs(nums[pointerEnd]) >= Math.Abs(nums[pointerStart])) {
                    results[(nums.Length - 1) - (pointerStart + (nums.Length - 1) - pointerEnd)] = (int)Math.Pow(nums[pointerEnd], 2);
                    pointerEnd--;
                } else {
                    results[(nums.Length - 1) - (pointerStart + (nums.Length - 1) - pointerEnd)] = (int)Math.Pow(nums[pointerStart], 2);
                    pointerStart++;
                }


            }
            return results;
        }

        public void ReverseString(char[] s) {
            int start = 0;
            int end = s.Length - 1;

            while (start < end) {
                (s[start], s[end]) = (s[end], s[start]);
                start++;
                end--;
            }

            Console.WriteLine(string.Join("", s));

        }

        public int[] TwoSum(int[] numbers, int target) {

            int start = 0;
            int end = numbers.Length - 1;


            while (start < end) {
                if (numbers[start] + numbers[end] == target) {
                    return [start + 1, end + 1];
                }
                if (numbers[start] + numbers[end] > target) {
                    end--;
                } else if (numbers[start] + numbers[end] < target) {
                    start++;
                }
            }

            return [];

        }

        public bool IsPalindrome(string s) {
            int start = 0;
            int end = s.Length - 1;

            while (start < end) {
                if (!char.IsAsciiLetterOrDigit(s[start])) {
                    start++;
                    continue;


                }
                if (!char.IsAsciiLetterOrDigit(s[end])) {
                    end--;
                    continue;
                }

                if (char.ToLower(s[start]) == char.ToLower(s[end])) {
                    start++;
                    end--;
                    continue;
                } else {
                    return false;
                }

            }
            return true;
        }

        public IList<IList<int>> ThreeSum(int[] nums) {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length == 0)
                return result;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1])
                    continue;
                int start = i + 1;
                int end = nums.Length - 1;
                while (start < end)
                {
                    int sum = nums[i] + nums[end] + nums[start];
                    if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[start], nums[end] });
                        while (start < end && nums[end] == nums[end - 1]) end--;
                        while (start < end && nums[start] == nums[start + 1]) start++;
                    }
                    if (sum < 0)
                        start++;
                    else
                        end--;
                }
            }

            return result;
        }

        public int MaxArea(int[] height) {
            int l = 0;
            int h = height.Length - 1;
            int o = 0;
            while (l < h) {
                o = Math.Max(o, Math.Min(height[l], height[h]) * (h - l));
                if (height[l] < height[h])
                    l++;
                else
                    h--;
            }

            return o;

        }

        public int Trap(int[] height) {

            int endPointer = height.Length - 1;
            int startPointer = 0;

            int max = 0;
            int previousHeight = 0;
            int total = 0;

            while (startPointer <= endPointer) {

                //Console.WriteLine(height[startPointer] +" vs " + height[endPointer]);

                if (Math.Min(height[startPointer], height[endPointer]) > previousHeight) {
                    max = Math.Min(height[startPointer], height[endPointer]) * (endPointer - startPointer + 1);
                    total += max;
                    //Console.WriteLine("overlap "+previousHeight*(endPointer-startPointer+1));
                    total -= previousHeight * (endPointer - startPointer + 1);

                    previousHeight = Math.Min(height[startPointer], height[endPointer]);

                    //Console.WriteLine(max);
                }


                if (height[startPointer] > height[endPointer]) {
                    total -= Math.Min(height[endPointer], previousHeight);
                    //Console.WriteLine("Remove "+Math.Min(height[endPointer],previousHeight));
                    endPointer--;
                } else {
                    total -= Math.Min(height[startPointer], previousHeight);
                    //Console.WriteLine("Remove "+Math.Min(height[startPointer],previousHeight));
                    startPointer++;
                }


            }



            return total;
        }

    }

    class Stacks {
        public object CalPoints(string[] operations) {

            Stack<int> stack = new Stack<int>();


            foreach (string operation in operations) {
                switch (operation) {
                    case "+":
                        if (stack.TryPop(out int outer)) {
                            if (stack.TryPeek(out int inner)) {
                                stack.Push(outer);
                                stack.Push(outer + inner);
                            }
                        }
                        break;
                    case "D":
                        if (stack.TryPeek(out int stackTop)) {
                            stack.Push(stackTop * 2);
                        }
                        break;
                    case "C":
                        stack.TryPop(out int stackTop2);
                        break;
                    default:
                        stack.Push(int.Parse(operation));
                        break;
                }
            }

            return stack.Aggregate(0, (x, y) => x + y);
        }

        public bool IsValid(string s) {

            Stack<char> bracketStack = new Stack<char>();

            Dictionary<char, char> pairs = new Dictionary<char, char>(){
                {'[',']'},
                {'{','}'},
                {'(',')'}
            };

            foreach (char c in s) {
                if (c == '[' || c == '{' || c == '(') {
                    bracketStack.Push(pairs[c]);
                } else {
                    if (bracketStack.TryPeek(out char value)) {
                        if (c == value) {
                            bracketStack.Pop();
                        } else {
                            return false;
                        }
                    } else {
                        return false;
                    }
                }
            }

            return bracketStack.Count == 0;
        }

        public int EvalRPN(string[] tokens) {


            int ApplyOperation(string operation, Stack<int> stack) {
                int valueFirst = stack.Pop();
                int valueSecond = stack.Pop();
                switch (operation) {
                    case "+":
                        stack.Push(valueSecond + valueFirst);
                        break;
                    case "*":
                        stack.Push(valueSecond * valueFirst);
                        break;
                    case "/":
                        stack.Push(valueSecond / valueFirst);
                        break;
                    case "-":
                        stack.Push(valueSecond - valueFirst);
                        break;
                }

                return 1;
            }

            Stack<int> operationStack = new Stack<int>();

            foreach (string s in tokens) {
                switch (s) {
                    case "+":
                        ApplyOperation("+", operationStack);
                        break;
                    case "*":
                        ApplyOperation("*", operationStack);
                        break;
                    case "/":
                        ApplyOperation("/", operationStack);
                        break;
                    case "-":
                        ApplyOperation("-", operationStack);
                        break;
                    default:
                        operationStack.Push(int.Parse(s));
                        break;

                }
            }


            return operationStack.Pop();
        }

        public int[] DailyTemperatures(int[] temperatures) {
            Stack<int> tempStack = new Stack<int>();
            Stack<int> indexStack = new Stack<int>();

            int[] beforeTempGreaterIndex = new int[temperatures.Length];
            int perma = 0;

            for (int i = 0; i < temperatures.Length; i++) {

                int count = 0;
                if (tempStack.TryPeek(out int value)) {
                    while (temperatures[i] > tempStack.Peek()) {
                        tempStack.Pop();
                        int myindex = indexStack.Pop();
                        count++;
                        beforeTempGreaterIndex[myindex] = i - myindex;
                        if (tempStack.Count == 0) break;
                    }

                    if (tempStack.Count != 0) {
                        perma += count;
                    } else {
                        perma = 0;
                    }
                }
                tempStack.Push(temperatures[i]);
                indexStack.Push(i);
            }

            return beforeTempGreaterIndex;


        }

        public class MinStack {

            List<int> temperatures;
            Stack<int> ourMin;

            public MinStack() {
                temperatures = new List<int>();
                ourMin = new Stack<int>();
                ourMin.Push(int.MaxValue);
            }

            public void Push(int val) {
                if (val <= ourMin.Peek()) {
                    ourMin.Push(val);
                }
                temperatures.Add(val);
                //Console.WriteLine(string.Join(",",temperatures));
            }

            public void Pop() {
                if (temperatures.Last() <= ourMin.Peek()) {
                    ourMin.Pop();
                }
                temperatures.RemoveAt(temperatures.Count - 1);
                //Console.WriteLine(string.Join(",",temperatures));
            }

            public int Top() {
                return temperatures.Last();
            }

            public int GetMin() {
                return ourMin.Peek();
            }
        }

        public void TestSet() {
            MinStack ms = new MinStack();

            ms.Push(-2);

            ms.Push(0);

            ms.Push(-3);

            Console.WriteLine(ms.GetMin());

            ms.Pop();

            Console.WriteLine(ms.Top());

            Console.WriteLine(ms.GetMin());


        }

    }

    class LinkingLists {

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }

        public class ListNode2 {

            public int val;
            public ListNode2 next;

            public ListNode2(int x) {
                val = x;
                next = null;
            }
        }

        // Definition for a Node.
        public class Node {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val) {
                val = _val;
                next = null;
                random = null;
            }
        }

        public ListNode DeleteDuplicates(ListNode head) {

            if (head == null || head.next == null) {
                return head;
            }

            ListNode current = head;

            while (current != null && current.next != null) {
                if (current.val == current.next.val) {
                    current.next = current.next.next;
                } else {
                    current = current.next;
                }
            }

            return head;

        }

        public ListNode ReverseList(ListNode head) {


            ListNode prev = null;
            ListNode current = head;
            ListNode next = null;

            while (current != null)
            {
                //e.g make 2 to hold // make 3
                next = current.next;

                //asign current.next = prev null// 2->1 (from last)
                current.next = prev;

                //make = 1, set to our current 2->1
                prev = current;

                //current = 2, i.e current 2 -> point to null; // set to 3-4,
                current = next;

                Console.WriteLine("n " + next.val);
                Console.WriteLine("p " + prev.val);
                Console.WriteLine("c " + current.val);
            }

            return prev;
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2) {

            ListNode finalList = new ListNode();
            ListNode refernce = finalList;

            if (list1 == null || list2 == null) {
                return list1 ?? list2;
            }


            while (list1 != null && list2 != null) {

                if (list1.val < list2.val) {
                    refernce.next = list1;
                    list1 = list1.next;
                } else {
                    refernce.next = list2;
                    list2 = list2.next;
                }
                refernce = refernce.next;
            }

            refernce.next = list1 ?? list2;

            return finalList.next;
        }

        public bool HasCycle(ListNode2 head) {
            ListNode2 slower = head;
            ListNode2 faster = head;
            while (faster != null && faster.next != null) {
                slower = slower.next;
                faster = faster.next.next;
                if (slower == faster) return true;
            }
            return false;
        }

        public ListNode MiddleNode(ListNode head) {

            var slow = head;
            var fast = head;

            // even : e.g. 10 => fast 1 3 5 7 9 null
            //                   slow 1 2 3 4 5 6 return slow pointer

            // odd : e.g. 5 => fast 1 3 5  
            //                 slow 1 2 3 return slow pointer

            // one node : 1 => return slow pointer 

            // two nodes : 1 2 fast : 1 null | slow : 1 2 return 2 (second middle) (same as even)

            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;

        }

        public ListNode RemoveNthFromEnd(ListNode head, int n) {

            ListNode cur = head;

            for (int i = 0; i < n; i++) {
                cur = cur.next;
            }

            head = new(0, head);
            ListNode target = head;

            while (cur != null) {
                cur = cur.next;
                target = target.next;
            }

            target.next = target.next.next;
            return head.next;
        }

        Dictionary<Node, Node> clone = new Dictionary<Node, Node>();

        public bool IsCloneExist(Node node)
        {
            if (node == null || clone.ContainsKey(node)) return true;

            clone.Add(node, new Node(node.val));
            return false;
        }

        public void MakeClone(Node node)
        {
            if (IsCloneExist(node)) return;

            MakeClone(node.next);

            if (node.next != null) clone[node].next = clone[node.next];
            else clone[node].next = null;

            if (node.random != null) clone[node].random = clone[node.random];
            else clone[node].random = null;
        }

        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            MakeClone(head);

            return clone[head];
        }

    }

    public class BS {
        public int Search(int[] nums, int target) {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right) {
                int mid = (left + right) / 2;
                if (nums[mid] == target) {
                    return mid;
                }
                if (nums[mid] > target) {
                    //cut off cause we have already seen it.
                    right = mid - 1;
                }
                else {
                    //same as above
                    left = mid + 1;
                }
            }

            return -1;
        }

        public int SearchInsert(int[] nums, int target) {

            int left = 0, right = nums.Length - 1;

            while (left <= right) {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target) {
                    return mid; // Target found
                } else if (nums[mid] < target) {
                    left = mid + 1; // Search in the right half
                } else {
                    right = mid - 1; // Search in the left half
                }
            }

            return left; // If target not found, return insertion position

        }

        public bool IsBadVersion(int version) {
            return version >= 2 ? true : false;
        }

        public int FirstBadVersion(int n) {


            int left = 1;
            int right = n;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        public bool IsPerfectSquare(int num) {
            if (num < 2) return true;
            long left = 2, right = num / 2;
            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                long squared = mid * mid;
                if (squared == num)
                {
                    return true;
                }
                else if (squared > num)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return false;
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            int innerLength = matrix[0].Length;
            int l = 0;
            int r = (innerLength * matrix.Length) - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                //Console.WriteLine(mid);


                int midVal = (matrix[mid / innerLength][mid % innerLength]);

                //Console.WriteLine($"[{outerArrayIndex}][{innerArrayIndex}]");

                if (midVal == target)
                {
                    return true;
                }
                else if (midVal < target)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }



            return false;
        }

        public int FindMin(int[] nums)
        {
            if (nums[0] <= nums[nums.Length - 1]) return nums[0];
            if (nums.Length == 2) return Math.Min(nums[0], nums[1]);

            int l = 0;
            int r = nums.Length - 1;

            //Console.WriteLine(string.Join(" ", nums));



            while (l < r)
            {
                int mid = l + (r - l) / 2;

                //Console.WriteLine(nums[mid]);
                //Console.WriteLine(nums[r]);
                //Console.WriteLine(nums[l]);
                //Console.WriteLine("---");
                if (nums[mid] > nums[r])
                {
                    //Console.WriteLine("L = mid");
                    l = mid + 1;
                }
                else
                {
                    //Console.WriteLine("R = mid");
                    r = mid;
                }

            }

            //Console.WriteLine($"mid is {mid}");



            return nums[l];
        }

        public int SearchM(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[low] <= nums[mid])
                {
                    if (nums[low] <= target && target < nums[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && target <= nums[high])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }

            return -1;
        }


        //Function to determin time to go through piles
        public long determineTime(int[] piles, int consumption)
        {

            long timeTaken = 0;

            for (int i = 0; i < piles.Length; i++)
            {
                timeTaken += (int)Math.Ceiling(((double)piles[i] / (double)consumption));

            }

            return timeTaken;
        }
        //Function returning min consumption per hour to eat all piles within hours h, each consumption considered per hours
        public int MinEatingSpeed(int[] piles, int h)
        {



            //initial plan get min & max options from piles to consider and binary sort those
            //Decide direction based on less than or greater than target h
            //to evaluate have to iterate piles within binary sort.
            int l = 1;
            int r = piles.Max();

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                Console.WriteLine("Mid value is " + mid);
                long timeTaken = determineTime(piles, mid);
                Console.WriteLine(mid);
                Console.WriteLine(l);
                Console.WriteLine(r);
                Console.WriteLine(timeTaken);

                if (timeTaken <= h)
                {
                    Console.WriteLine('r');
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }

            }

            Console.WriteLine(l);
            Console.WriteLine(r);

            return l;

        }

    }

    public class SlidingWindow
    {
        public double FindMaxAverage(int[] nums, int k)
        {

            int total = 0;

            for (int i = 0; i < k; i++)
            {
                total += nums[i];
            }

            double bestAverage = (Double)total / k;
            //Console.WriteLine(bestAverage);

            for (int x = k; x < nums.Length; x++)
            {
                total += nums[x];
                total -= nums[x - k];

                bestAverage = Math.Max(bestAverage, (Double)total / k);
            }

            return bestAverage;
        }

        public int LongestOnes(int[] nums, int k)
        {

            int l = 0;

            int maxLength = 0;

            //remove items from our thing until under k limit

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 1)
                {
                    if (k > 0)
                    {
                        k--;

                    }
                    else
                    {
                        k--;
                        while (k < 0)
                        {
                            if (nums[l] == 0)
                            {
                                k++;
                            }
                            l++;
                        }
                    }
                }
                //Console.WriteLine(k);
                //Console.WriteLine("Current length is  " + (r - l+1));
                //Console.WriteLine("R " + r);
                //Console.WriteLine("L " + l);
                maxLength = Math.Max(maxLength, (i - l + 1));
            }

            //Console.WriteLine(maxLength);

            return maxLength;
        }

        public int LengthOfLongestSubstring(string s)
        {
            HashSet<char> currentLetters = new HashSet<char>();

            int l = 0;
            int maxLength = 0;

            for (int i = 0; i < s.Length; i++)
            {

                if (!currentLetters.Contains(s[i]))
                {
                    currentLetters.Add(s[i]);
                }
                else
                {
                    while (currentLetters.Contains(s[i]))
                    {
                        currentLetters.Remove(s[l]);
                        l++;
                    }
                    Console.WriteLine(currentLetters.Count);
                    currentLetters.Add(s[i]);

                }
                Console.WriteLine("Left is " + l);
                Console.WriteLine("Right is " + i);

                Console.WriteLine(currentLetters.Count);

                maxLength = Math.Max(currentLetters.Count, maxLength);

            }
            return maxLength;
        }

        public int CharacterReplacement(string s, int k)
        {

            int i = 0, j = 0;
            int max = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (j = 0; j < s.Length; j++)
            {
                if (!map.ContainsKey(s[j]))
                {
                    map.Add(s[j], 1);
                }
                else
                {
                    map[s[j]] += 1;
                }
                max = Math.Max(max, map[s[j]]);
                while ((j - i + 1) - max > k)
                {
                    map[s[i]] -= 1;
                    i++;
                }
            }
            return j - i;
        }

        public int MinSubArrayLen(int target, int[] nums)
        {

            int l = 0;
            int currentTotal = 0;

            int minVal = nums.Length + 1;

            Console.WriteLine(string.Join(",", nums));

            for (int i = 0; i < nums.Length; i++)
            {
                currentTotal += nums[i];


                while (currentTotal >= target)
                {
                    minVal = Math.Min(minVal, i - l + 1);

                    currentTotal -= nums[l];
                    l++;
                }

            }
            return minVal > nums.Length ? 0 : minVal;
        }


        public bool MatchStr(int[] s1, int[] s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckInclusion(string s1, string s2)
        {
            HashSet<char> uniqueChar = new HashSet<char>(s1);


            int l = 0;

            int[] og = new int[27];
            int[] dup = new int[27];

            foreach (char c in s1)
            {
                int index = (int)c % 32;
                og[index] += 1;

            }



            for (int i = 0; i < s2.Length; i++)
            {

                //Console.WriteLine("Considering " + s2[i]);

                if (uniqueChar.Contains(s2[i]))
                {

                    //Console.WriteLine("in");
                    //Console.WriteLine(i);
                    //Console.WriteLine(l);

                    //Console.WriteLine((int)s2[i] % 32);
                    dup[(int)s2[i] % 32]++;
                    Console.WriteLine(string.Join(",", dup));

                    //Console.WriteLine(dup[(int)s2[i] % 32]);

                    if (i - l + 1 == s1.Length)
                    {
                        Console.WriteLine("lenght mathc");

                        //if (dup.Max() == 0)
                        //{
                        //    //Console.WriteLine("all good");
                        //    return true;
                        //}

                        //while (dup.Min() <= -1)
                        //{
                        //    //Console.WriteLine("while");

                        //    dup[(int)s2[l] % 32]++;
                        //    l++;
                        //}

                        if (MatchStr(dup, og)) {
                            return true;
                        }

                        dup[(int)s2[l] % 32]--;
                        Console.WriteLine(string.Join(",", dup));
                        l++;

                    }
                }
                else
                {
                    //og.CopyTo(dup, 0);
                    dup = new int[27];
                    l = i + 1;
                }


            }


            return false;
        }


        public class Node {

            public Node? Next { get; set; }
            public string Value { get; set; }

            public Node(string value, Node next = null)
            {
                this.Value = value;
                this.Next = next;
            }

        }


        public void BackToFront(Node node)
        {
            if (node.Next == null)
            {
                Console.WriteLine(node.Value);
                return;
            }
            BackToFront(node.Next);
            Console.WriteLine(node.Value);
        }


        public void reverseRecursive()
        {
            Node node1 = new Node("alex");
            Node node2 = new Node("ben");
            Node node3 = new Node("John");

            node1.Next = node2;
            node2.Next = node3;

            BackToFront(node1);

        }


    }

    public class FunWithTrees
    {
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode? left { get; set; }
            public TreeNode? right { get; set; }

            public TreeNode(int value, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = value;
            }

        }

        public int DFS(TreeNode node, int height)
        {
            height += 1;

            Console.WriteLine(node.val);
            Console.WriteLine("Current height " + height);

            int left = 0;
            int right = 0;
            if (node.left != null || node.right != null)
            {
                if (node.left != null)
                {
                    left = DFS(node.left, height);
                }
                if (node.right != null)
                {
                    right = DFS(node.right, height);
                }
                return Math.Max(left, right);
            }
            else
            {
                return height;
            }


        }

        public int DFSBalaned(TreeNode node)
        {
            if (node == null) return 0;

            int left = DFSBalaned(node.left);
            if (left == -1) return -1;

            int right = DFSBalaned(node.right);
            if (right == -1) return -1;


            if (Math.Abs(left - right) > 1)
            {
                return -1;
            }

            return Math.Max(left, right) + 1;

        }

        public bool DFS2(TreeNode node, TreeNode node2)
        {

            Console.WriteLine(node.val);
            Console.WriteLine(node2.val);

            if (node.val != node2.val) return false;

            bool left = true;
            bool right = true;

            if (node2.left != null || node.left != null)
            {
                if (node2.left == null || node.left == null) return false;
                Console.WriteLine("Lets go left");
                left = DFS2(node.left, node2.left);
            }

            if (node2.right != null || node.right != null)
            {
                if (node2.right == null || node.right == null) return false;
                Console.WriteLine("Lets go left");
                right = DFS2(node.right, node2.right);
            }

            return left && right;
        }

        public bool DFS3(TreeNode node, TreeNode node2)
        {

            if (node == null || node2 == null) return node == node2;

            return node.val == node2.val && DFS3(node.left, node2.right) && DFS3(node2.left, node.right);


        }

        public Tuple<int, int> DFSNew(TreeNode node)
        {
            if (node == null)
            {
                return Tuple.Create(0, 0);
            }

            var leftResult = DFSNew(node.left);
            var rightResult = DFSNew(node.right);

            int height = 1 + Math.Max(leftResult.Item1, rightResult.Item1);
            int diameter = Math.Max(leftResult.Item2, rightResult.Item2);

            //if height is greater then make diameter = height
            diameter = Math.Max(diameter, leftResult.Item1 + rightResult.Item1);

            return Tuple.Create(height, diameter);
        }

        public TreeNode InvertTree(TreeNode root)
        {

            if (root == null) return null;

            //DFS(root);

            return root;


        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            return DFS(root, 0);
        }

        public bool IsBalanced(TreeNode root)
        {
            return DFSBalaned(root) != -1;
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            Tuple<int, int> result = DFSNew(root);
            return result.Item2;
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null) return (p == null && q == null);
            return DFS2(p, q);
        }

        public bool IsSymmetric(TreeNode root)
        {
            return DFS3(root.left, root.right);
        }

        public bool TraverseSum(TreeNode node, int sum)
        {

            if (node.left == null || node.right == null)
            {
                if (node.left == null && node.right != null)
                {
                    return TraverseSum(node.right, sum - node.val);
                }

                if (node.right == null && node.left != null)
                {
                    return TraverseSum(node.left, sum - node.val);
                }
            }

            if (node.left != null && node.right != null)
            {
                return TraverseSum(node.left, sum - node.val) || TraverseSum(node.right, sum - node.val);
            }

            return sum - node.val == 0;

        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            return TraverseSum(root, targetSum);

        }

        public bool Same(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null)
                return true;
            if (root == null)
                return false;
            if (subRoot == null)
                return false;
            if (root.val != subRoot.val)
                return false;

            return Same(root.left, subRoot.left) && Same(root.right, subRoot.right);
        }

        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (Same(root, subRoot))
                return true;

            if (root == null)
                return false;

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;
                List<int> level = new List<int>();

                for (int i = 0; i < count; i++)
                {
                    TreeNode cur = queue.Dequeue();
                    level.Add(cur.val);

                    if (cur.left != null)
                    {
                        queue.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        queue.Enqueue(cur.right);
                    }
                }

                result.Add(level);
            }

            return result;


        }



        public int KthSmallest(TreeNode root, int k)
        {
            int i = 0;
            int solution = 0;


            void DFS(TreeNode root)
            {

                if (root == null) return;

                DFS(root.left);

                Console.WriteLine("Increment " + i);

                i++;

                if (i == k) solution = root.val;

                Console.WriteLine("Right");

                DFS(root.right);
            }

            DFS(root);
            return solution;

        }

        public int GetMinimumDifference(TreeNode root)
        {

            List<int> items = new List<int>();

            void TraverseTree(TreeNode root)
            {
                if (root == null) return;

                TraverseTree(root.left);
                items.Add(root.val);
                TraverseTree(root.right);
            }

            TraverseTree(root);

            int min = int.MaxValue;

            for (int i = 0; i < items.Count - 1; i++)
            {
                min = Math.Min(min, Math.Abs(items[i] - items[i + 1]));
            }

            return min;


        }


        public bool TraversalMinMax(TreeNode root, long min, long max)
        {

            Console.WriteLine("retuning");

            if (root == null) return true;

            Console.WriteLine(root.val);
            Console.WriteLine(max);
            Console.WriteLine(min);

            if (root.val >= max || root.val <= min) return false;

            return TraversalMinMax(root.left, min, root.val) && TraversalMinMax(root.right, root.val, max);
        }

        public bool IsValidBST(TreeNode root)
        {
            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.MaxValue);
            long min = int.MinValue;
            long max = int.MaxValue;
            if (root == null) return true;
            if (root.left == null && root.right == null) return true;
            return TraversalMinMax(root, min - 1, max + 1);
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            //if both are greater than then go right
            if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor(root.right, p, q);
            //if both are les than then go left
            else if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor(root.left, p, q);
            else
                //otherwise must be current
                return root;
        }

        public class TrieNode
        {
            public TrieNode?[] Child;
            public bool WordEnd;
            public TrieNode()
            {
                Child = new TrieNode?[26];
                WordEnd = false;
            }
        }

        public class Trie
        {

            private TrieNode root;
            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {
                var current = root;

                foreach (char ch in word)
                {
                    var index = ch - 'a';
                    if (current.Child[index] == null)
                    {
                        current.Child[index] = new TrieNode();
                    }

                    current = current.Child[index];
                }

                current.WordEnd = true;
            }

            public bool Search(string word)
            {
                var current = root;

                foreach (char ch in word)
                {
                    var index = ch - 'a';

                    if (current.Child[index] == null)
                        return false;

                    current = current.Child[index];
                }

                return current.WordEnd;
            }

            public bool StartsWith(string prefix)
            {
                var current = root;

                foreach (char ch in prefix)
                {
                    var index = ch - 'a';

                    if (current.Child[index] == null)
                        return false;

                    current = current.Child[index];
                }

                return true;
            }
        }

    }

    public class HeapStuff
    {
        public int LastStoneWeight(int[] stones)
        {

            PriorityQueue<int, int> stoneQ = new PriorityQueue<int, int>(
                stones.Select(x => (x, x)),
                Comparer<int>.Create((a, b) => b.CompareTo(a)));

            while (stoneQ.Count >= 1)
            {
                int stone1 = stoneQ.Dequeue();
                int stone2 = stoneQ.Dequeue();

                if (stone1 != stone2)
                {
                    stoneQ.Enqueue(Math.Abs(stone1 - stone2), Math.Abs(stone1 - stone2));
                }
            }

            if (stoneQ.Count == 0) return 0;

            int result = stoneQ.Dequeue();

            Console.WriteLine(result);
            return result;

        }

        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> values = new PriorityQueue<int, int>(
                nums.Select(x => (x, x)),
                Comparer<int>.Create((a, b) => b.CompareTo(a))
                );


            while (k > 1)
            {
                values.Dequeue();
                k--;
            }


            return values.Peek();

        }

        public int[] TopKFrequent(int[] nums, int k)
        {

            //int[] retuned = new int[k];


            //Dictionary<int,int> myFreq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());            

            //PriorityQueue<int, int> values = new PriorityQueue<int, int>(myFreq.Select((x)=>(x.Key,x.Value)), Comparer<int>.Create((a,b)=>b.CompareTo(a))); 

            //for(int i = 0 ; i < k; i++)
            //{
            //    retuned[i] = values.Dequeue();
            //}


            //return retuned;

            // Step 1: Count the frequency of each element using a dictionary
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num]++;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }

            // Step 2: Use a Min-Heap (PriorityQueue) to keep the top k frequent elements
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

            foreach (var entry in frequencyMap)
            {
                minHeap.Enqueue(entry.Key, entry.Value); // Enqueue element with its frequency as priority

                // If heap size exceeds k, remove the element with the smallest frequency
                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            // Step 3: Extract the k most frequent elements from the heap
            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = minHeap.Dequeue();
            }

            return result;
        }


        public int[][] KClosest(int[][] points, int k)
        {
            var priorityQueue = new PriorityQueue<int[], int>(new ClosestOriginComparer());
            int[][] result = new int[k][];

            for (int i = 0; i < points.Length; i++)
            {
                priorityQueue.Enqueue(points[i], points[i][0] * points[i][0] + points[i][1] * points[i][1]);
                if (priorityQueue.Count > k)
                {
                    priorityQueue.Dequeue();
                }
            }

            for (int i = 0; i < k; i++)
                result[i] = priorityQueue.Dequeue();

            return result;
        }

        private class ClosestOriginComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x < y) return 1;
                else if (x > y) return -1;
                else return 0;
            }
        }

        public class ListNode {
        
            public int val;
            public ListNode? next;

            public ListNode(int value = 0, ListNode nextNode = null)
            {
                this.val = value;
                this.next = nextNode;
            }


        }
        

        public ListNode MergeKLists(ListNode[] lists)
        {
            var pq = new PriorityQueue<ListNode, int>();

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    pq.Enqueue(lists[i], lists[i].val);
                }
            }

            //just fulled it up

            ListNode root = new ListNode(0, null);
            var current = root;

            //Created something call root that is empty

            //while we have items in the q
            while (pq.Count > 0)
            {
                //dequeue the min
                var node = pq.Dequeue();
                
                //if no more items in the min heap linked list
                if (node.next != null)
                {
                    //add the next item in linked list
                    //so if it is still the min go to front
                    pq.Enqueue(node.next, node.next.val);
                }

                //add next to be the current node popped
                current.next = new ListNode(node.val, null);
                //make current = current.next
                current = current.next;
            }

            return root.next;

        }


    }

    public class RecursiveBacktrack
    {
        public IList<IList<int>> Subsets(int[] nums)
        {

            IList<int> sol = new List<int>();
            List<IList<int>> result = new List<IList<int>>();



            void RecusiveBackTracker(int num)
            {

                if (num == nums.Length)
                {
                    //
                    //sConsole.WriteLine(string.Join(",", sol));
                    result.Add(new List<int>(sol));
                    //Console.WriteLine(string.Join(",", result));
                    return;
                }

                //dont add;
                RecusiveBackTracker(num + 1);

                //add
                sol.Add(nums[num]);
                RecusiveBackTracker(num + 1);
                sol.RemoveAt(sol.Count - 1);

            }

            RecusiveBackTracker(0);

            Console.WriteLine(result.Count);


            return result;


        }

        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();
            HashSet<int> solution = new HashSet<int>();



            void Permutations(int num)
            {
                //Console.WriteLine(num);
                //at end of the line
                if (num == 0)
                {
                    Console.WriteLine($"Adding this list {string.Join(",", solution.ToList())}");
                    //Console.ReadLine();
                    results.Add(solution.ToList());
                    return;
                }

                //spawn each new call
                for (int i = 0; i < nums.Length; i++)
                {
                    if (solution.Contains(nums[i])) continue;



                    solution.Add(nums[i]);
                    Console.WriteLine($"Adding {nums[i]}");
                    //Console.ReadLine();

                    Permutations(num - 1);
                    solution.Remove(nums[i]);
                    Console.WriteLine($"Removing {nums[i]}");
                    //Console.ReadLine();
                }
            }



            Permutations(nums.Length);

            return results;


        }


        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> results = new List<IList<int>>();
            List<int> solution = new List<int>();


            void Combinations(int n, int k, int start) {

                if (k == 0)
                {
                    //Console.WriteLine("lett add");
                    results.Add(solution.ToList());
                    Console.WriteLine(string.Join(",", solution));
                    return;
                }


                for (int i = start; i <= n; i++)
                {
                    solution.Add(i);
                    //Console.WriteLine($"Adding {i}");
                    Combinations(n, k - 1, i + 1);
                    //Console.WriteLine($"Removing {i}");
                    solution.Remove(i);
                }

            }


            Combinations(n, k, 1);

            foreach (IList<int> item in results)
            {
                Console.WriteLine(string.Join(",", item));
            }


            return results;

        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> resutls = new List<IList<int>>();
            IList<int> solution = new List<int>();

            void Traverse(int target, int index)
            {
                if (target == 0)
                {
                    resutls.Add(solution.ToList());
                    return;
                }

                if (target < 0) return;

                for (int i = index; i < candidates.Length; i++)
                {
                    solution.Add(candidates[i]);
                    //Console.WriteLine($"Add {candidates[i]}");
                    Traverse(target - candidates[i], i);
                    solution.RemoveAt(solution.Count - 1);
                    //Console.WriteLine($"Remove {candidates[i]}");
                }

            }

            Traverse(target, 0);


            return resutls;


        }

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> results = new List<string>();
            List<char> solution = new List<char>();

            Dictionary<char, char[]> dictonary = new Dictionary<char, char[]>(){
                { '2', new char[]{ 'a','b','c' } },
                { '3', new char[]{ 'd','e','f' } },
                { '4', new char[]{ 'g','h','i' } },
                { '5', new char[]{ 'j','k','l' } },
                { '6', new char[]{ 'm','n','o' } },
                { '7', new char[]{ 'p','q','r','s' } },
                { '8', new char[]{ 't','u','v' } },
                { '9', new char[]{ 'w','x','y','z' } },
            };


            if (digits == "") return [];
            

            void Combination(int index)
            {
                

                if (index == digits.Length)
                {
                    //Console.WriteLine("a possible solution -> "+ string.Join("",solution));
                    if (solution.Count() == digits.Length)
                    {
                        results.Add(string.Join("", solution));
                    }
                    return;
                }

                //Console.WriteLine("A new call");

                

                    foreach (char x in dictonary[digits[index]])
                    {
                        //Console.WriteLine(x);
                        solution.Add(x);
                        Combination(index+1);
                        //Console.WriteLine($"Removing ${x}");
                        solution.RemoveAt(solution.Count - 1);
                        
                    }
                

            }

            Combination(0);

            return results;
        
        }

        public IList<string> GenerateParenthesis(int n)
        {
            List<string> results = [];

            void BackTracker(int open, int close, string current)
            {
                //simple base case for if the length is matched 
                if(current.Length == 2 * n)
                {
                    results.Add(current);
                    return;
                }


                
               
                //fill out all the open (((

                //close them all out )))

                //revert back to previous call ((

                //close less than open (() & then we know open < so call (()()) ect.ect


                if (open < n)
                {
                    //Console.WriteLine($"Open less n {current+"("}");
                    BackTracker(open + 1, close, current + "(");
                }

                
                if(close < open)
                {
                    //Console.WriteLine($"Close less open {current + ")"}");
                    BackTracker(open, close+1,current + ")");
                }

                

            }

            BackTracker(0, 0, "");


            return results;



        }

        public bool Exist(char[][] board, string word)
        {
            // Get the dimensions of the board (m = number of rows, n = number of columns)
            int m = board.Length, n = board[0].Length;

            // Create a 2D boolean array to track visited cells during backtracking
            bool[,] visited = new bool[m, n];

            // Initialize the length tracker for the word and a flag to store the result
            int len = 0;
            bool ans = false;

            // Iterate through each cell of the board as the starting point
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Start backtracking from this cell (i, j)
                    backtrack(i, j);

                    // If the word is found, return true immediately
                    if (ans) return ans;
                }
            }

            // If no solution is found after checking all cells, return false
            return ans;

            // Backtracking helper function to explore possible paths
            void backtrack(int r, int c)
            {
                // If the word has already been found, stop further recursion
                if (ans) return;

                // Check if the current cell (r, c) is out of bounds or already visited
                if (r < 0 || r >= m || c < 0 || c >= n || visited[r, c]) return;

                // If the current board character does not match the expected character in the word, return
                if (board[r][c] != word[len]) return;

                // Increment the length tracker as we've matched another character
                len++;

                // If we've matched all characters in the word, mark the result as true and return
                if (len == word.Length)
                {
                    ans = true;
                    return;
                }

                // Mark the current cell as visited
                visited[r, c] = true;

                // Explore the 4 possible directions (down, up, right, left)
                backtrack(r + 1, c); // Move down
                backtrack(r - 1, c); // Move up
                backtrack(r, c + 1); // Move right
                backtrack(r, c - 1); // Move left

                // Backtrack: unmark the current cell as visited (to allow other potential paths)
                visited[r, c] = false;

                // Decrement the length tracker as we backtrack to try other paths
                len--;
            }
        }

    }

    public class GraphStuff
    {

        //direceted convert adjancy matrix
        public void ConvertAdjancyMatrix(int[][] input)
        {
            int n = 8;
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int[] values = Enumerable.Repeat(0, n).ToArray();
                matrix[i] = values;
            }

            foreach (int[] indicies in input) {
                matrix[indicies[0]][indicies[1]] = 1;

                //undirected
                //symmetric matrix
                //matrix[indicies[1]][indicies[0]]
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(",", matrix[i]));
            }

        }

        public Dictionary<int, List<int>> ConvertAdjancyList(int[][] input)
        {

            Dictionary<int, List<int>> myDict = new Dictionary<int, List<int>>();



            foreach (int[] indicies in input)
            {

                if (myDict.ContainsKey(indicies[0]))
                {
                    myDict[indicies[0]].Add(indicies[1]);
                }
                else
                {
                    myDict[indicies[0]] = new List<int>() { indicies[1] };
                }

                //undirected
                //symmetric matrix
                //matrix[indicies[1]][indicies[0]]
            }

            //foreach(List<int> val in myDict.Values)
            //{
            //    Console.WriteLine(string.Join(",",val));
            //}

            return myDict;

        }

        public void DFSwRecursion(int[][] input)
        {
            Dictionary<int, List<int>> keyValuePairs = ConvertAdjancyList(input);

            HashSet<int> visited = new HashSet<int>();

            void recursiveDfs(int node)
            {
                Console.WriteLine(node);

                if (!keyValuePairs.ContainsKey(node)) return;

                foreach (int val in keyValuePairs[node]) {
                    if (!visited.Contains(val))
                    {
                        visited.Add(val);
                        recursiveDfs(val);
                    }
                }
            }

            recursiveDfs(0);


        }

        public void DFSwStack(int[][] input)
        {
            Dictionary<int, List<int>> keyValuePairs = ConvertAdjancyList(input);

            HashSet<int> visited = new HashSet<int>();

            Stack<int> stack = new Stack<int>(new List<int>() { });

            stack.Push(0);
            visited.Add(0);

            Console.WriteLine($"about to start {stack.Count()}");




            while (stack.Count > 0)
            {
                Console.WriteLine("while");
                int current = stack.Pop();
                Console.WriteLine($"Current - {current}");

                // Ensure the current node exists in the adjacency list
                if (!keyValuePairs.ContainsKey(current))
                {
                    Console.WriteLine($"Node {current} has no neighbors.");
                    continue; // If no neighbors, move on to the next node
                }

                foreach (int val in keyValuePairs[current])
                {
                    if (!visited.Contains(val))
                    {
                        visited.Add(val);
                        stack.Push(val);
                    }
                }
            }
        }

        public void BFSsearch(int[][] input)
        {
            Dictionary<int, List<int>> keyValuePairs = ConvertAdjancyList(input);

            HashSet<int> visited = new HashSet<int>();

            Queue<int> myq = new Queue<int>();

            myq.Enqueue(0);
            visited.Add(0);

            Console.WriteLine($"about to start {myq.Count()}");

            while (myq.Count > 0)
            {
                Console.WriteLine("while");
                int current = myq.Dequeue();
                Console.WriteLine($"Current - {current}");

                // Ensure the current node exists in the adjacency list
                if (!keyValuePairs.ContainsKey(current))
                {
                    Console.WriteLine($"Node {current} has no neighbors.");
                    continue; // If no neighbors, move on to the next node
                }

                foreach (int val in keyValuePairs[current])
                {
                    if (!visited.Contains(val))
                    {
                        visited.Add(val);
                        myq.Enqueue(val);
                    }
                }
            }
        }

        public class Node{

            string value { get; set; }
            public List<Node> others;

            public Node(string nodeVal)
            {
                this.value = nodeVal;
            }

            public override string ToString()
            {
                return $"my node value is {this.value}";
            }

            public void DisplayConnections()
            {
                Console.WriteLine($"This is node is connected to {string.Join(",",this.others)}");
            }

        }

        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            if (n == 1 || source == destination)
            {
                return true;
            }

            var edgeMap = new Dictionary<int, ICollection<int>>();

            foreach (var edge in edges)
            {
                AddEdgeToMap(edgeMap, edge[0], edge[1]);
                AddEdgeToMap(edgeMap, edge[1], edge[0]);
            }

            foreach(KeyValuePair<int, ICollection<int>> x in edgeMap)
            {
                Console.WriteLine($"{x.Key}:{string.Join(",",x.Value)}");
            }


            var visitedVertices = new HashSet<int>();

            return IsPath(visitedVertices, edgeMap, source, destination);
        }

        private void AddEdgeToMap(IDictionary<int, ICollection<int>> edgeMap, int key, int value)
        {
            if (edgeMap.ContainsKey(key))
            {
                edgeMap[key].Add(value);
                return;
            }

            edgeMap.Add(key, new List<int>() { value });
        }

        private bool IsPath(HashSet<int> visitedVertices, IDictionary<int, ICollection<int>> edgeMap, int source, int destination)
        {
            Console.WriteLine(source);

            if (visitedVertices.Contains(source))
            {
                return false;
            }

            visitedVertices.Add(source);

            if (edgeMap[source].Contains(destination))
            {
                return true;
            }

            foreach (var vertex in edgeMap[source])
            {
                if (IsPath(visitedVertices, edgeMap, vertex, destination))
                {
                    return true;
                }
            }

            return false;

        }

        public int NumIslands(char[][] grid)
        {

            int islandCount = 0;
           


            void DFSRecursiveSearch(char[][] grid, int x, int y)
            {
                //Console.WriteLine($"{y}{x}");
                //Console.WriteLine($"{grid[y][x]}");

                if (grid[y][x] == '1') {
                    grid[y][x] = '2';

                    //left

                    if (x > 0) DFSRecursiveSearch(grid, x - 1, y);

                    //right

                    if (x < grid[0].Length - 1) DFSRecursiveSearch(grid, x + 1, y);

                    //down

                    if (y < grid.Length - 1) DFSRecursiveSearch(grid, x, y + 1);

                    //up

                    if (y > 0) DFSRecursiveSearch(grid, x, y - 1);

                }

                

            }

            //loop through the grid
            for (int y = 0; y< grid.Length; y++) 
            { 
                for(int x = 0; x < grid[0].Length; x++)
                {
                    //if detect land need to dfs through all the possible extensions, marking as seen as we go
                    if (grid[y][x] == '1')
                    {
                        DFSRecursiveSearch(grid, x, y);   
                        //post traversal increment our island count
                        islandCount++;
                    }
                }
            }

            return islandCount;

        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxSize = 0;

            int DFSRecursiveSearch(int[][] grid, int x, int y)
            {

                if (grid[y][x] == 1)
                {
                    grid[y][x] = 2;

                    int size = 0;

                    //left

                    if (x > 0) size += DFSRecursiveSearch(grid, x - 1, y);

                    //right

                    if (x < grid[0].Length - 1) size += DFSRecursiveSearch(grid, x + 1, y);

                    //down

                    if (y < grid.Length - 1) size += DFSRecursiveSearch(grid, x, y + 1);

                    //up

                    if (y > 0) size += DFSRecursiveSearch(grid, x, y - 1);

                    return 1 + size;

                }

                return 0;
            }

            //loop through the grid
            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[0].Length; x++)
                {
                    //if detect land need to dfs through all the possible extensions, marking as seen as we go
                    if (grid[y][x] == 1)
                    {
                        maxSize = Math.Max(DFSRecursiveSearch(grid, x, y), maxSize);
                    }
                }
            }

            return maxSize;
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Adjacency list graph representation
            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            // Populate the graph
            foreach (var pre in prerequisites)
            {
                graph[pre[0]].Add(pre[1]);
            }

            // Visited arrays
            // need two to determine if we have a genuine cycle (current) or just e again
            bool[] visited = new bool[numCourses];
            bool[] recStack = new bool[numCourses];  // Recursion stack

            // Helper function to perform DFS
            bool dfs(int course)
            {
                Console.WriteLine(course);
                Console.WriteLine($"visted -> {string.Join(",",visited)}");
                Console.WriteLine($"recStack -> {string.Join(",", recStack)}");
                if (recStack[course]) return false;  // cycle detected
                if (visited[course]) return true;  // already processed node

                // Mark the course as visited and add to recursion stack
                visited[course] = true;
                recStack[course] = true;

                // Visit all the neighbors
                foreach (int neighbor in graph[course])
                {
                    if (!dfs(neighbor)) return false;
                }

                // Backtrack
                recStack[course] = false;
                return true;
            }

            // Perform DFS from each course
            for (int i = 0; i < numCourses; i++)
            {
                if (!visited[i])
                {
                    if (!dfs(i)) return false;
                }
            }

            return true;  // No cycles detected, possible to finish all courses
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<int>[] adjList = new List<int>[numCourses];

            for (int i = 0; i < numCourses; i++) 
            {
                adjList[i] = new List<int>();
            }

            foreach(var preq in prerequisites) 
            {
                adjList[preq[0]].Add(preq[1]);
            }

            bool[] vistedCourse = new bool[numCourses];
            bool[] pathVisted = new bool[numCourses];

            Stack<int> courseStack = new Stack<int>();

            bool recusiveThing(int course)
            {
                if (pathVisted[course]) return false;

                if (vistedCourse[course]) return true;

                vistedCourse[course] = true;
                pathVisted[course] = true; 


                foreach(int x in adjList[course])
                {
                    if (!recusiveThing(x))
                    {
                        return false;
                    }
                }

                pathVisted[course] = false;
                courseStack.Push(course);
                
                return true;
            }



            for(int i = 0;i < numCourses; i++)
            {
                if (!recusiveThing(i))
                {
                    return [];
                }
            }

            int [] result = courseStack.Reverse().ToArray();

            return result;


        }


        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            //solution uses a bfs implementation and intersection
            //works backwards so from edges in and check to see if the intersection has things

            Queue<(int,int)> pacificQ = new Queue<(int,int)>();
            Queue<(int, int)> atlanticQ = new Queue<(int, int)>();

            HashSet<(int, int)> pacificSeen = new HashSet<(int, int)>();
            HashSet<(int, int)> atlanticSeen = new HashSet<(int, int)>();

            int m = heights.Length;
            int n = heights[0].Length;

            for (int j = 0; j < n; j++)
            {
                pacificQ.Enqueue((0, j));
                pacificSeen.Add((0, j));
                atlanticQ.Enqueue((m - 1, j));
                atlanticSeen.Add((m - 1, j));
            }

            for (int i = 0; i < m; i++)
            {
                pacificQ.Enqueue((i, 0));
                pacificSeen.Add((i, 0));
                atlanticQ.Enqueue((i, n - 1));
                atlanticSeen.Add((i, n - 1));
            }

            void CheckCoords(Queue<(int,int)> q, HashSet<(int, int)> seen)
            {
                while (q.Count > 0) 
                { 
                    var  x = q.Dequeue();
                    int i = x.Item1;
                    int j = x.Item2;

                    foreach(var val in new (int,int)[] { (0, 1), (1, 0), (-1, 0), (0, -1) })
                    {
                        int r = i + val.Item1;
                        int c = j + val.Item2;
                        if (0 <= r && r < m && 0 <= c && c < n && heights[r][c] >= heights[i][j] && !seen.Contains((r, c)))
                        {
                            seen.Add((r, c));
                            q.Enqueue((r, c));
                        }
                        {

                        }
                    } 
                }
            }

            CheckCoords(pacificQ, pacificSeen);
            CheckCoords(atlanticQ, atlanticSeen);

            return pacificSeen.Intersect(atlanticSeen)
                .Select(coord => (IList<int>)new List<int> { coord.Item1, coord.Item2}).ToList();

            

        }

        public class Node2
        {
            public int val;
            public IList<Node2> neighbors;

            public Node2()
            {
                val = 0;
                neighbors = new List<Node2>();
            }

            public Node2(int _val)
            {
                val = _val;
                neighbors = new List<Node2>();
            }

            public Node2(int _val, List<Node2> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public Node2 CloneGraph(Node2 node)
        {
            if (node == null) return node;

            Dictionary<Node2, Node2> map = new Dictionary<Node2, Node2>() { { node, new Node2(node.val) } };

            dfs(node, map);

            return map[node];

            void dfs(Node2 node, Dictionary<Node2, Node2> map)
            {
                if (node == null)
                {
                    return;
                }

                foreach(Node2 val in node.neighbors)
                {
                    if (!map.ContainsKey(val))
                    {
                        map.Add(val, new Node2(val.val));
                        dfs(val, map);
                    }

                    //add neighbor's copy to node's copy
                    map[node].neighbors.Add(map[val]);
                }
            }

        }

        public int OrangesRotting(int[][] grid)
        {
            Queue<(int,int,int)> q = new Queue<(int,int,int)> ();

            HashSet<(int, int)> visted = new HashSet<(int, int)>();

            int n = grid.Length;
            int m = grid[0].Length;


            int freshCount = 0;
            int minTimeTaken = 0;

            for (int i = 0; i < n; i++) 
            { 
                for(int j = 0; j < m; j++)
                {
                    //found something rotten
                    if (grid[m][n] == 2)
                    {
                        q.Enqueue((m, n,0));
                        visted.Add((i, j));
                    }else if(grid[m][n] == 1)
                    {
                        freshCount++;
                    }
                }
            }



            int[] dirctions = { 0, 1, 0, -1, 0 };

            while (q.Count > 0)
            {
                (int, int, int) current = q.Dequeue();

                minTimeTaken = Math.Max(minTimeTaken, current.Item3);

                //go through directions
                for(int i = 0; i < 4; i++)
                {
                    int newRowValue = current.Item1 + dirctions[i];
                    int newColValue = current.Item2 + dirctions[i+1];

                    if (newRowValue>=0 && newColValue>=0 && newColValue < m && newRowValue < n && grid[newRowValue][newColValue] == 1 && !visted.Contains((newRowValue,newColValue)))
                    {
                        visted.Add((newRowValue, newColValue));
                        q.Enqueue((newRowValue, newColValue, current.Item3+1 ));
                        freshCount--; 
                    }

                }
            
            }

            return freshCount == 0 ? minTimeTaken : -1;
        }

        //make use of MST
        //make use of prims algo
        //wihth n have n-1 edges
        public int MinCostConnectPoints(int[][] points)
        {
            int n = points.Length;
            int totalCost = 0;
            bool[] visited = new bool[n];
            int[] minCostToConnect = new int[n];
            Array.Fill(minCostToConnect, int.MaxValue);
            minCostToConnect[0] = 0;

            PriorityQueue<(int cost, int pointIndex), int> minHeap = new PriorityQueue<(int, int), int>();
            minHeap.Enqueue((0, 0), 0); // Starting from point 0 with cost 0
                                        //can get to node 0 in cost of 0, cost represented by the prior
                                        //enque the first node point 0,0

            while (minHeap.Count > 0)
            {
                var (cost, point) = minHeap.Dequeue();

                // Skip if already visited
                if (visited[point]) continue;

                // Add cost and mark as visited
                visited[point] = true;
                totalCost += cost;

                // Update neighbors
                for (int i = 0; i < n; i++)
                {
                    if (!visited[i])
                    {
                        int newCost = Math.Abs(points[point][0] - points[i][0]) + Math.Abs(points[point][1] - points[i][1]);

                        if (newCost < minCostToConnect[i])
                        {
                            minCostToConnect[i] = newCost;
                            minHeap.Enqueue((newCost, i), newCost);
                        }
                    }
                }
            }

            return totalCost;


        }

        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            // Step 1: Build graph representation
            var graph = new Dictionary<int, List<int[]>>();
            foreach (var time in times)
            {
                int from = time[0], to = time[1], t = time[2];
                if (!graph.TryGetValue(from, out var neighbors))
                    graph[from] = neighbors = new List<int[]>();
                neighbors.Add(new int[] { to, t });
            }

            // Step 2: Priority queue and minTime dictionary
            var minHeap = new PriorityQueue<(int, int), int>();
            minHeap.Enqueue((k, 0), 0);
            var minTime = new Dictionary<int, int>();

            // Step 3: Dijkstra's algorithm
            while (minHeap.Count > 0)
            {
                var (node, time) = minHeap.Dequeue();
                if (minTime.ContainsKey(node)) continue;

                minTime[node] = time;
                if (minTime.Count == n) return time; // Early exit if all nodes are visited

                if (graph.TryGetValue(node, out var neighbors))
                {
                    foreach (var neighbor in neighbors)
                    {
                        int nextNode = neighbor[0], travelTime = neighbor[1];
                        if (!minTime.ContainsKey(nextNode))
                        {
                            minHeap.Enqueue((nextNode, time + travelTime), time + travelTime);
                        }
                    }
                }
            }

            // Step 4: Check if all nodes are reachable
            return minTime.Count == n ? minTime.Values.Max() : -1;

        }

    }

    public class DynamicPrograming
    {

        //e.g f(3) called multiple times, why not keep these results
        public int FibNaiveRecursiveApproach(int i)
        {
            if(i==0) return 0;
            if(i == 1) return 1;

            return FibNaiveRecursiveApproach(i-1) + FibNaiveRecursiveApproach(i-2);
        }


        public int FibTopDown(int n)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>() { { 0, 0 }, { 1, 1} };

            int helper(int x)
            {
                if (memo.ContainsKey(x))
                {
                    return memo[x];
                }
                else
                {
                    memo[x] = helper(x-1)+helper(x-2);
                    return memo[x];
                }
            }


            return helper(n);
        }

        public int BottomUpFib(int n)
        {
            if(n==0) return 0;
            if(n==1) return 1; 

            int[] values = new int[n+1];

            values[0] = 0;
            values[1] = 1;

            for(int i = 2; i< n+1; i++)
            {
                values[i] = values[i-1] + values[i-2];
            }

            return values[n];


        }

        public int RecursiveStairsCounter(int stairs)
        {
            if(stairs == 0) return 1;
            if (stairs < 0) return 0;

            return RecursiveStairsCounter(stairs-1) + RecursiveStairsCounter(stairs-2);

        }

        public int RecursiveStairsCounterTopDown(int stairs)
        {
            Dictionary<int,int> memo = new Dictionary<int, int>() { { 0, 1} };

            int helper(int n)
            {
                if(n<0) return 0;
                if(memo.ContainsKey(n)) return memo[n];

                memo[n] = helper(n-2) + helper(n-1);
                return memo[n];
            }

            return helper(stairs);

        }

        public int MinClimbStairs(int[] costIndex)
        {
            int Helper(int index)
            {
                if(index>=costIndex.Length) return 0;
                if (index == costIndex.Length - 1) return costIndex[index];

                return costIndex[index] + Math.Min(Helper(index + 2), Helper(index + 1));
            }

            return Math.Min(Helper(0),Helper(1));

        }

        public int MinClimbStairsDP(int[] costIndex)
        {

            var oneStep = 0 ;
            var twoStep = 0;

            for(int i = 2; i<costIndex.Length+1; i++)
            {
                var temp = oneStep;

                oneStep = Math.Min(oneStep+ costIndex[i-1], twoStep + costIndex[i-2]);

                twoStep = temp;

            }

            return oneStep;

        }

        public int Rob(int[] nums)
        {
            int pastpast = 0;
            int past = nums[0];

            for(int i = 1; i<nums.Length; i++)
            {
                int t = past;
                past = Math.Max(past, pastpast + nums[i]);
                pastpast = t;
            }

            return past;
        }

        public int UniquePathsRecursive(int m, int n)
        {

            int total = 0;

            void Helper(int mCurrent, int nCurrent)
            {

                if (mCurrent == m && nCurrent == n)
                {
                    total++;
                }


                if (mCurrent > m || nCurrent > n)
                {
                    return;
                }


                Console.WriteLine($"m={mCurrent},n={nCurrent}");


               Helper(mCurrent + 1 , nCurrent);
               Helper(mCurrent, nCurrent + 1);

                return;
                
            }

            Helper(1, 1);
            

            return total;

        
        }

        public int UniquePaths(int m, int n)
        {
            int[,] dp  = new int[m + 1, n + 1];
            
            //assign to get to of first to 1
            dp[1, 0] = 1;
            
            //start a block inward so 1,1 and then move to limit
            for(int r = 1; r <= m; r++)
            {
                for(int c = 1; c <= n; c++)
                {
                    //previous to get to
                    dp[r, c] = dp[r - 1, c] + dp[r, c - 1];
                }
            }

            //return the value we wanted
            return dp[m, n];
        }

        //kadanes algo
        public int MaxSubArray(int[] nums)
        {
            int currentMaxSubArray = nums[0];
            int currentSubArray = nums[0];
        
            for(int i = 1; i < nums.Length; i++)
            {

                if (nums[i] > currentSubArray + nums[i])
                {
                    currentSubArray = nums[i];
                }
                else
                {
                    currentSubArray += nums[i];
                }

                if(currentSubArray > currentMaxSubArray)
                {
                    currentMaxSubArray = currentSubArray;
                }

            }

            return currentMaxSubArray;
        
        }

        public bool CanJump(int[] nums)
        {
            //set last to nearest true
            int nearestTrue = nums.Length - 1;

            for(int i = nums.Length - 2; i >= 0; i--)
            {
                //checking to see if we can jump and assign nearest true value
                if(i + nums[i] >= nearestTrue)
                {
                    nearestTrue = i;
                }
            }

            //if we are at 0 then know its possible
            return nearestTrue==0;
        }


        public int CoinChange(int[] coins, int amount)
        {
            //effectively fill up an array up to the amount of the coins required to get to a position
            //when filling up we take the minimum to currently get here or w/ the new coin i.e 1+ last pos
            if (coins == null)
                return -1;
            int n = coins.Length;
            if (n == 0)
                return -1;

            int[] dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;
            foreach (var coin in coins)
            {
                for (int i = coin; i <= amount; i++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];


        }

        public int LengthOfLIS(int[] nums)
        {
            int[] arr = Enumerable.Repeat(1, nums.Length).ToArray();


            //double for loop basically start at e.g
            //[10,9,2,5,3,7,101,18] 10 and go thru array
            // if we are greater than then add 
            // finally return the max value so in this case when
            // starting at 2

            for (int i = 1; i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        arr[i] = Math.Max(arr[i], arr[j] + 1);
                    }
                }
            }

            return arr.Max();
        }


//        Initialize lis as an empty list.
//        Process the first element, 10:
//        Since lis is empty, append 10.
//        lis becomes: [10]

//    Process the second element, 9:
//        Use binary search to find the position where 9 should go in lis.
//        Binary search returns position 0, indicating that 9 should replace 10.
//        Replace 10 with 9.
//        lis becomes: [9]

//    Process the third element, 2:
//        Binary search finds that 2 should replace 9 at position 0.
//        Replace 9 with 2.
//        lis becomes: [2]

//    Process the fourth element, 5:
//        Binary search finds that 5 should be placed at position 1 in lis(after 2).
//        Append 5 to lis.
//        lis becomes: [2, 5]

//    Process the fifth element, 3:
//        Binary search finds that 3 should replace 5 at position 1.
//        Replace 5 with 3.
//        lis becomes: [2, 3]

//    Process the sixth element, 7:
//        Binary search finds that 7 should be placed at position 2 in lis (after 3).
//        Append 7 to lis.
//        lis becomes: [2, 3, 7]

//    Process the seventh element, 101:
//        Binary search finds that 101 should be placed at position 3 in lis (after 7).
//        Append 101 to lis.
//        lis becomes: [2, 3, 7, 101]

//    Process the eighth element, 18:
//        Binary search finds that 18 should replace 101 at position 3.
//        Replace 101 with 18.
//        lis becomes: [2, 3, 7, 18]

//Final Result

//The length of lis at the end is 4, which represents the length of the longest increasing subsequence.
        public int LengthOfLIS2(int[] nums)
        {
            List<int> lis = new List<int>();

            foreach (var num in nums)
            {
                int pos = lis.BinarySearch(num);
                if (pos < 0)
                    pos = ~pos;

                if (pos == lis.Count)
                    lis.Add(num);
                else
                    lis[pos] = num;
            }

            return lis.Count;
        }


//        After i = 2:

//calc = [
//  [0, 0, 0],
//  [0, 0, 0],
//  [1, 1, 0],
//  [0, 0, 0]
//]

//After i = 1:

//calc = [
//  [0, 0, 0],
//  [1, 1, 0],
//  [1, 1, 0],
//  [0, 0, 0]
//]

//After i = 0:

//calc = [
//  [2, 1, 0],
//  [1, 1, 0],
//  [1, 1, 0],
//  [0, 0, 0]
//]

        public int LongestCommonSubsequence(string text1, string text2)
        {
            int textOneLength = text1.Length;
            int textTwoLength = text2.Length; 

            int[,] calc = new int[textOneLength + 1, textTwoLength +1];

            for(int i = textOneLength - 1;  i >= 0; i--)
            {
                for(int x = textTwoLength - 1; x >= 0; x--)
                {
                    if (text1[i] == text2[x])
                    {
                        calc[i,x] = 1 + calc[i + 1,x + 1];
                    }
                    else
                    {
                        calc[i, x] = Math.Max(calc[i + 1, x], calc[i, x + 1]);
                    }
                }
            }

            return calc[0, 0];
        }

    }

}

