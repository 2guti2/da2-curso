using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObligatorioDA2.Domain.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void IsPasswordValid_Successful()
        {
            var user = new User
            {
                Username = "john_doe",
                Password = "123456"
            };

            Assert.IsTrue(user.IsPasswordValid("123456"));
        }

        [TestMethod]
        public void IsPasswordValid_Failed()
        {
            var user = new User
            {
                Username = "john_doe",
                Password = "123456"
            };

            Assert.IsFalse(user.IsPasswordValid("1234"));
        }
    }
}
