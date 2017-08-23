using System;
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
            return true;
        }
    }
}
