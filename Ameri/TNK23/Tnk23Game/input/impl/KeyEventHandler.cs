using Tnk23Game.Input.Api;

namespace Tnk23Game.Input.Impl
{
    /// <summary>
    /// The KeyEventHandler class handles key events and notifies KeyboardInputControllers.
    /// It allows adding and removing input controllers to receive key events.
    /// </summary>
    public class KeyEventHandler
    {
        private List<KeyboardInputController> inputControllers;

        /// <summary>
        /// Constructs a new KeyEventHandler object.
        /// Initializes the list of input controllers.
        /// </summary>
        public KeyEventHandler()
        {
            this.inputControllers = new List<KeyboardInputController>();
        }

        /// <summary>
        /// Notifies all registered input controllers about a key pressed event.
        /// </summary>
        /// <param name="e">The KeyEvent representing the key pressed event.</param>
        public void OnKeyPressed(int e)
        {
            inputControllers.ForEach(c => c.SetOnKeyPressed(e));
        }

        /// <summary>
        /// Notifies all registered input controllers about a key released event.
        /// </summary>
        /// <param name="e">The KeyEvent representing the key released event.</param>
        public void OnKeyReleased(int e)
        {
            inputControllers.ForEach(c => c.SetOnKeyReleased(e));
        }

        /// <summary>
        /// Adds an input controller to the list of registered input controllers.
        /// </summary>
        /// <param name="k">The KeyboardInputController to be added.</param>
        public void AddInputController(KeyboardInputController k)
        {
            this.inputControllers.Add(k);
        }

        /// <summary>
        /// Removes an input controller from the list of registered input controllers.
        /// </summary>
        /// <param name="k">The KeyboardInputController to be removed.</param>
        public void RemoveInputController(KeyboardInputController k)
        {
            this.inputControllers.Remove(k);
        }
    }
}
