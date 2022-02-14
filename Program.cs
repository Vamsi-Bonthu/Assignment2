/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Initializing variables low & high to first and last index of the aaray
                int low = 0;
                int high = nums.Length - 1;
                int x = -1;
                //while loop to run through entire array
                while (low <= high)
                {                           
                    //assigning mid array index number to variable half
                    int half = (low + high) / 2;          
                    //if mid index array value equals the target return the mid index value
                    if (nums[half] == target) 
                        return half; 
                    //if target is less than mid index value new high becomes the half of array length
                    //subtracted by one
                    else if (nums[half] > target)
                    {           
                        high = half - 1;
                        x = half;
                    }
                    else
                    //else if target is greater than mid index value new high becomes the half of array length
                    //added by one
                    {
                        low = half + 1;
                        x = half + 1;
                    }
                }
                return x;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                //coverting all letters in the string to lower case
                paragraph = paragraph.ToLower();
                //replacing fullstop in the string with space
                paragraph = paragraph.Replace('.', ' ');
                //replacing coma in the string with space
                paragraph = paragraph.Replace(',', ' ');
                //removing all leading and trailing white space characters in the string
                paragraph = paragraph.Trim();
                Console.WriteLine("paragraph");
                //split paragraph string seperated by a spaces
                string[] snap = paragraph.Split(' ');
                //creating a dictionary
                Dictionary<string, int> dictnry = new Dictionary<string, int>();
                //looping through out the length of the string
                for (int k = 0; k < snap.Length; k++)
                {
                    //checking whether split string euqals the key in the dictionary
                    if (dictnry.ContainsKey(snap[k]))
                    {
                        dictnry[snap[k]]++;
                    }
                    else
                    {
                        dictnry.Add(snap[k], 1);
                    }
                    //looping through out the length of the banned string
                    for (int l = 0; l < banned.Length; l++)
                    {
                        //checking whether split string equals the banned string
                        if (snap[l] == banned[l])
                        {
                            //if found equal then eliminate the split string used
                            dictnry.Remove(snap[l]);
                        }
                    }
                }
                int st = 0;
                string trgt = "";
                foreach (KeyValuePair<string, int> pvk in dictnry)
                {
                    if (st < pvk.Value)
                    {
                        st = pvk.Value;
                        trgt = pvk.Key;
                    }
                }
                return trgt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //creating a dictionary favoured number
                Dictionary<int, int> favornum = new Dictionary<int, int>();  
                //looping throughout the length of the input array
                for (int k = 0; k < arr.Length; k++)
                {
                    //checking whether the array element exists in the dictionary
                    if (favornum.ContainsKey(arr[k]))
                    {
                        favornum[arr[k]]++;
                    }
                    else
                        favornum.Add(arr[k], 1);
                }
                var ary = favornum.Keys.ToList();
                int trgt = -1;
                //looping through entire array to check for the favoured number
                foreach (var i in ary)
                {
                    if (favornum[i] == i)
                    {
                        trgt = (Math.Max(trgt, i));
                    }
                }
                //returning the most frequency number equalling its value in the array
                return trgt;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //initializing variables m, n with zero
                int m = 0;
                int n = 0;
                //initializing a boolean varaible of length equal to secret string length
                bool[] use = new bool[secret.Length];
                //creating a dictionary ary
                Dictionary<char, int> ary = new Dictionary<char, int>();
                //looping throughout the length of string secret
                for (int x = 0; x < secret.Length; x++)
                {
                    //checking if secret string is equal to guess string
                    if (secret[x] == guess[x])
                    {
                        m++;
                        use[x] = true;
                    }
                    else
                    {
                        use[x] = false;
                    }
                    //if the input array contains the key equals the secret string
                    if (ary.ContainsKey(secret[x]))
                    {
                        ary[secret[x]] = ary[secret[x]] + 1;
                    }
                    else
                    {
                        ary[secret[x]] = 1;
                    }
                }
                //looping through entire length of the guess word string
                for (int y = 0; y < guess.Length; y++)
                {
                    if (use[y]) continue;
                    //if input array and key contains the guess string
                    if (ary.ContainsKey(guess[y]) && ary[guess[y]] > 0)
                    {
                        n++;
                        ary[guess[y]] = ary[guess[y]] - 1;
                    }
                }
                //merge the bulls and cows length with alphabets A & B to from xAyB
                string trgt = m + "A" + n + "B";

                return trgt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //initializing variable span to length of the input string
                int span = s.Length;
                //creating a list trgt
                List<int> trgt = new List<int>();
                //initializing an array with lenth 26
                int[] web = new int[26];
                //looping through entire length of input string backwards
                for (int x = span - 1; x >= 0; x--)
                {
                    //checking whether length of input string equals to 97
                    if (web[s[x] - 97] == 0)
                    {
                        web[s[x] - 97] = x;
                    }
                }
                int indctr = 0;
                //while condition whether initialized variable indctr less than the input string
                while (indctr < span)
                {
                    int small = indctr;
                    int big = web[s[indctr] - 97];
                    int lead = big - small + 1;
                    //looping from the beginning to the end of each letter appearing in atmost one part of the input string
                    for (int y = small; y <= big; y++)
                    {
                        if (web[s[y] - 97] > big)
                        {
                            big = web[s[y] - 97];
                            //lead value equals the length of each letter appears in atmost one part
                            lead = big - small + 1;
                        }

                    }
                    trgt.Add(lead);
                    indctr = big + 1;
                }
                return trgt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //initializing rule and pixel length integer variables
                int rule = 1;
                int intl_wrd_pxl = 0;
                //looping throughout the length of the input string
                for (int m = 0; m < s.Length; m++)
                {
                    //determining the ascii value and finding the index for the same of the input int array widths
                    int k = s[m] - 97;
                    //determining whether input line overflow
                    if (intl_wrd_pxl + widths[k] <= 100)
                    {
                        //if not present then fill the input line pixel value
                        intl_wrd_pxl = intl_wrd_pxl + widths[k];   
                    }
                    else
                    {
                        //initializing curreny pixel to 0
                        intl_wrd_pxl = 0;                         
                        //adding the width
                        intl_wrd_pxl = intl_wrd_pxl + widths[k];    
                        rule++;                                 
                    }
                }
                //list creation to match the target format
                List<int> trgt = new List<int>();                
                trgt.Add(rule);
                trgt.Add(intl_wrd_pxl);
                return trgt;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //determining and assigning the input string length to integer variable size
                int size = bulls_string10.Length;
                Stack<char> dis = new Stack<char>();
                //looping throughout the entire length of input string
                for (int m = 0; m < size; m++)
                {
                    //checking the characters of the input string
                    if (bulls_string10[m] == '[' || bulls_string10[m] == '(' || bulls_string10[m] == '{')
                    {
                        dis.Push(bulls_string10[m]);
                    }
                    //checking the characters of the input string
                    if (bulls_string10[m] == ']' || bulls_string10[m] == '}' || bulls_string10[m] == ')')
                    {
                        if (dis.Count <= 0)
                        {
                            return false;
                        }
                    }
                    //determing whether input string is in correct format of character closing
                    if (bulls_string10[m] == ']')
                    {
                        if (dis.Peek() == '[')
                        {
                            dis.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (bulls_string10[m] == ')')
                    {
                        if (dis.Peek() == '(')
                        {
                            dis.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (bulls_string10[m] == '}')
                    {
                        if (dis.Peek() == '{')
                        {
                            dis.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                //if characters closing in input string are correct returning true
                return true;
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //initializing the string morescode for all the alphabets
                string[] morsecode = new string[] { "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-.." };
                HashSet<string> trgt = new HashSet<string>();
                //determining number of input words
                int size = words.Length;
                //looping throughout the length of the words
                for (int m = 0; m < size; m++)
                {
                    var bldstr = new StringBuilder();
                    //checking for each characters in the input words provided
                    foreach (var ch in words[m])
                    {
                        //determing the morse code tranformations for each character in the words
                        bldstr.Append(morsecode[ch - 'a']);
                    }
                    trgt.Add(bldstr.ToString());
                }
                //returning the count of different number combinations possible
                return trgt.Count();
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
