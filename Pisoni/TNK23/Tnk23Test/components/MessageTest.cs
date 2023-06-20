using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tnk23Game.extra;

namespace Tnk23Test.components
{

    /// <summary>
    /// The MessageTest class is responsible for testing the functionality of the Message interface.
    /// </summary>
    [TestClass]
    public class MessageTest
    {
        /// <summary>
        /// Test case for the getMessage() method.
        /// It verifies that the method returns the correct message.
        /// </summary>
        [TestMethod]
        public void TestGetMessage()
        {
            IMessage<string> message = new IMessage<string>
            {
                GetMessage = () => "Hello World!"
            };
            Assert.AreEqual("Hello World!", message.GetMessage());
        }
    }
}