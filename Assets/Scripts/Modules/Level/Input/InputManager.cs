using UnityEngine;
using Modules.Level.Input;

namespace Modules.Level
{
    public class InputManager
    {
        public enum MovementDirection
        {
            Idle = 0,

            Up = 8,
            RightUp = 12,
            Right = 4,
            RightDown = 6,
            Down = 2,
            LeftDown = 3,
            Left = 1,
            LeftUp = 9
        }

        // dependencies
        private IMovementInput _hud;

        // own members
        private IMovementInput _keyboardManager;

        public InputManager(IMovementInput hud)
        {
            // resolve dependencies
            _hud = hud;

            // prepare own members
            _keyboardManager = new KeyboardManager();
        }

        public void OuterUpdate()
        {
            bool isUpButtonPressed = _hud.IsUpButtonPressed || _keyboardManager.IsUpButtonPressed;
            bool isLeftButtonPressed = _hud.IsLeftButtonPressed || _keyboardManager.IsLeftButtonPressed;
            bool isRightButtonPressed = _hud.IsRightButtonPressed || _keyboardManager.IsRightButtonPressed;
            bool isDownButtonPressed = _hud.IsDownButtonPressed || _keyboardManager.IsDownButtonPressed;

            // sanity check
            if (isUpButtonPressed && isDownButtonPressed)
            {
                isUpButtonPressed = false;
                isDownButtonPressed = false;
            }

            if (isLeftButtonPressed && isRightButtonPressed)
            {
                isLeftButtonPressed = false;
                isRightButtonPressed = false;
            }

            // determine direction
            MovementDirection direction = (MovementDirection)
                            (2 * 2 * 2 * (isUpButtonPressed ? 1 : 0)
                            + 2 * 2 * (isRightButtonPressed ? 1 : 0)
                            + 2 * (isDownButtonPressed ? 1 : 0)
                            + (isLeftButtonPressed ? 1 : 0));

            if (direction != MovementDirection.Idle)
            {
                // create command
                CreateMovementByDirection(direction);
            }
        }

        private void CreateMovementByDirection(MovementDirection direction)
        {
            switch (direction)
            {
                case MovementDirection.Up:
                    // create up movement command
                    Debug.Log("Move Up");
                    break;

                case MovementDirection.RightUp:
                    // create right-up movement command
                    Debug.Log("Move Right Up");
                    break;

                case MovementDirection.Right:
                    // create right movement command
                    Debug.Log("Move Right");
                    break;

                case MovementDirection.RightDown:
                    // create right-down movement command
                    Debug.Log("Move Right Down");
                    break;

                case MovementDirection.Down:
                    // create down movement command
                    Debug.Log("Move Down");
                    break;

                case MovementDirection.LeftDown:
                    // create left-down movement command
                    Debug.Log("Move Left Down");
                    break;

                case MovementDirection.Left:
                    // create left movement command
                    Debug.Log("Move Left");
                    break;

                case MovementDirection.LeftUp:
                    // create left-up movement command
                    Debug.Log("Move Left Up");
                    break;
            }
        }
    }
}
