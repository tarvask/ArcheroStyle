using System;

namespace Modules.Level.Input
{
    // Input.GetAxisRaw() is used here
    // to avoid having movement when opposite buttons are pressed together
    // (W + S returning Up or Down movement or A + D returning Left or Right movement)
    public class KeyboardManager : IMovementInput
    {
        public bool IsUpButtonPressed => UnityEngine.Input.GetAxisRaw("Vertical") > 0;
        public bool IsLeftButtonPressed => UnityEngine.Input.GetAxisRaw("Horizontal") < 0;
        public bool IsRightButtonPressed => UnityEngine.Input.GetAxisRaw("Horizontal") > 0;
        public bool IsDownButtonPressed => UnityEngine.Input.GetAxisRaw("Vertical") < 0;
    }
}
