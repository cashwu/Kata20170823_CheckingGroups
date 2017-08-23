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

        [TestMethod]
        public void input_random_1_should_return_true()
        {
            CheckGroupsShouldBeTrue("[[]()]");
        }

        [TestMethod]
        public void input_random_2_should_return_true()
        {
            CheckGroupsShouldBeFalse("{)[}");
        }

        [TestMethod]
        public void input_random_3_should_return_true()
        {
            CheckGroupsShouldBeTrue("{[{}[]()[]{}{}{}{}{}{}()()()()()()()()]{{{[[[((()))]]]}}}}(())[[]]{{}}[][][][][][][]({[]})");
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
            var prevString = "";
            while (input.Length != prevString.Length)
            {
                prevString = input;
                input = input.Replace("[]", "").Replace("()", "").Replace("{}", "");
            }

            return input.Length == 0;
        }
    }
}
