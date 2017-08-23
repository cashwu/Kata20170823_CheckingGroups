using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170823_CheckingGroups
{
    [TestClass]
    public class CheckingGroupsTests
    {
        [TestMethod]
        public void input_L_brackets_R_brackets_should_return_true()
        {
            CheckGroupsShouldBeTrue("()");
        }

        [TestMethod]
        public void input_L_brackets_L_curly_brackets_should_return_false()
        {
            CheckGroupsShouldBeFalse("({");
        }

        [TestMethod]
        public void input_L_square_brackets_R_square_brackets_should_return_true()
        {
            CheckGroupsShouldBeTrue("[]");
        }

        [TestMethod]
        public void input_L_curly_brackets_R_curly_brackets_should_return_true()
        {
            CheckGroupsShouldBeTrue("{}");
        }

        [TestMethod]
        public void input_L_brackets_L_curly_brackets_R_curly_brackets_R_brackets_should_return_true()
        {
            CheckGroupsShouldBeTrue("({})");
        }

        [TestMethod]
        public void input_L_curly_brackets_L_brackets_R_curly_brackets_R_brackets_should_return_false()
        {
            CheckGroupsShouldBeFalse("{(})");
        }

        [TestMethod]
        public void input_L_brackets_L_square_brackets_R_curly_brackets_R_brackets_should_return_false()
        {
            CheckGroupsShouldBeFalse("([})");
        }

        private static void CheckGroupsShouldBeFalse(string input)
        {
            var groups = new Groups();
            var actual = groups.Check(input);
            Assert.IsFalse(actual);
        }

        private static void CheckGroupsShouldBeTrue(string input)
        {
            var groups = new Groups();
            var actual = groups.Check(input);
            Assert.IsTrue(actual);
        }
    }

    public class Groups
    {
        public bool Check(string input)
        {
            while (true)
            {
                if (CheckFirstAndLast(input))
                {
                    if (input.Length == 2)
                    {
                        return true;
                    }

                    input = input.Substring(1, input.Length - 2);
                    continue;
                }

                return false;
            }
        }

        private static bool CheckFirstAndLast(string input)
        {
            var dic = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            return dic[input.First()] == input.Last();
        }
    }
}
