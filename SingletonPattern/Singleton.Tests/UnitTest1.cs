using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singleton.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsPolicySingleton()
        {
            Assert.AreSame(Policy.Instance, Policy.Instance);
        }
    }
}
