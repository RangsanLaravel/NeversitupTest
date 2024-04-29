namespace NeversitupTest.Unitest
{
    public class UnitTest1
    {
        [Theory(DisplayName = "Permutations")]
        [InlineData("a")]
        [InlineData("ab")]
        [InlineData("abc")]
        [InlineData("aabb")]
        public void Test1(string inputStr)
        {
            List<string> result = FindPermutations(inputStr);
            HashSet<string> dis = result.ToHashSet();
            result = dis.ToList();
            switch (inputStr)
            {
                case "a":
                    Assert.True(checkresult(result, new List<string> { "a" }));
                    break;
                case "ab":
                    Assert.True(checkresult(result,new List<string> { "ab","ba"}));
                    break;
                case "abc":
                    Assert.True(checkresult(result, new List<string> { "abc", "acb", "bac", "bca", "cab", "cba" }));
                    break;
                case "aabb":
                    Assert.True(checkresult(result, new List<string> { "aabb", "abab", "abba", "baab", "baba", "bbaa" }));
                    break;
                default:
                    Assert.True(false);
                    break;
            }
        }
        public bool checkresult(List<string> result,List<string> predict)
        {
            if (result.Count != predict.Count)
                return false;
            foreach (var item in result)
            {
                if(!predict.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }
        public List<string> FindPermutations(string inputStr)
        {
            List<string> permutations = new List<string>();
            GeneratePermutations("", inputStr, permutations);
            return permutations;
        }

        public void GeneratePermutations(string prefix, string remaining, List<string> permutations)
        {
            int n = remaining.Length;
            if (n == 0)
            {
                permutations.Add(prefix);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    GeneratePermutations(prefix + remaining[i], remaining.Substring(0, i) + remaining.Substring(i + 1), permutations);
                }
            }
        }

        [Fact(DisplayName = "odd int")]  
        public void Test2()
        {
            List<int[]> intarr = new List<int[]>
            {
                new int[]{7},
                new int[]{0},
                new int[]{1,1,2},
                new int[]{0,1,0,1,0},
                new int[]{1,2,2,3,3,3,4,3,3,3,2,2,1},
            };
            for (int i = 0; i < intarr.Count; i++)
            {
                var result = findOdd(intarr[i]);
                switch (i)
                {
                    case 0:
                        Assert.Equal(7,result);
                        break;
                    case 1:
                        Assert.Equal(0, result);
                        break;
                    case 2:
                        Assert.Equal(2, result);
                        break;
                    case 3:
                        Assert.Equal(0, result);
                        break;
                    case 4:
                        Assert.Equal(4, result);
                        break;
                    default:
                        break;
                }
                
            }
            
        }

        private int findOdd(int[] intarr)
        {
            HashSet<int> distinct = new HashSet<int>();
            int odd = 0;
            distinct = intarr.ToHashSet();
            foreach (int i in distinct)
            {
                var temp = intarr.Where(a => a.Equals(i)).Count();
                if (temp % 2 != 0)
                {
                    return i;
                }
            }
            return odd;
        }

        private static List<string> smiles = new List<string> { ":)",";)" ,":-)", ";-)",";~)", ":~)", ":D", ";D" , ":-D", ";-D" , ";~D", ":~D" };
        [Fact(DisplayName = "countSmileys")]
        public void Test3()
        {
            List<string[]> arrsmile = new List<string[]>();
            arrsmile.Add(new string[] { ":)", ";(", ";}", ":-D" });
            arrsmile.Add(new string[] { ";D", ":-(", ":-)", ";~)" });
            arrsmile.Add(new string[] { ";]", ":[", ";*", ":$", ";-D" });
            arrsmile.Add(new string[] { ":)", ";)", ":-)", ";-)", ";~)", ":~)", ":D", ";D", ":-D", ";-D", ";~D", ":~D" });

            for (var i = 0; i < arrsmile.Count; i++)
            {
                var result = checksmile(arrsmile[i].ToList());
                switch (i)
                {
                    case 0:
                        Assert.Equal(2, result);
                        break;
                    case 1:
                        Assert.Equal(3, result);
                        break;
                    case 2:
                        Assert.Equal(1, result);
                        break;
                    case 3:
                        Assert.Equal(12, result);
                        break;
                    default:
                        break;
                }

            }

        }
        private int checksmile(List<string> smile)
        {
            int numsmile = 0;
            if (smile.Count == 0) return 0;
            foreach (var item in smile)
            {
                if (smiles.Contains(item))
                {
                    numsmile++;
                }   
            }
            return numsmile;
        }
    }

}