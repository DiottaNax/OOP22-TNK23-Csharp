using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace it.unibo.Tnk23Test.components
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
            Message message = new Message()
            {
            GetMessage = () => "Hello World!"
            };
            Assert.AreEqual("Hello World!", message.GetMessage());
        }
    }
}