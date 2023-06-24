using Tnk23Game.extra;

namespace Tnk23Test.components
{
    /// <summary>
    /// The NotifiableComponentTest class is responsible for testing the functionality of the NotifiableComponent interface.
    /// </summary>
    [TestClass]
    public class NotifiableComponentTest
    {
        /// <summary>
        /// The TestComponent class is a test implementation of the NotifiableComponent interface.
        /// </summary>
        private class TestComponent : INotifiableComponent
        {
            private string _receivedMessage;

            public void Update()
            {
                // Empty or necessary implementation for specific tests
            }


            public void Receive<X>(IMessage<X> x)
            {
                _receivedMessage = x.GetMessage().ToString();
            }

            public string GetReceivedMessage() => _receivedMessage;
            
        }

        /// <summary>
        /// Test case for the Receive() method.
        /// It verifies that the method sets the received message correctly.
        /// </summary>
        [TestMethod]
        public void TestReceive()
        {
            // Prepare test data
            TestComponent _component = new TestComponent();
            IMessage<int> _message = new TestMessage<int>(42); // Using TestMessage

            // Perform the test
            _component.Receive(_message);

            // Verify the results
            Assert.AreEqual("42", _component.GetReceivedMessage());
        }

        /// <summary>
        /// The TestMessage class is a test implementation of the Message interface.
        /// It is used for testing purposes.
        /// </summary>
        /// <typeparam name="X">the type of the message</typeparam>
        private class TestMessage<X> : IMessage<X>
        {
            private readonly X _message;

            public TestMessage(X mex)
            {
                _message = mex;
            }

            public X GetMessage() => _message;
        }
    }
}
