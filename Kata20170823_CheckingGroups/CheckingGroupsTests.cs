using System;
using System.Collections.Generic;
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
            var dic = new Dictionary<char, char>
            {
                { '(', ')' }
            };

            return dic[input[0]] == input[1];
        }
    }
}
