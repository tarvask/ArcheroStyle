using System;
using Modules.Level.Input;

namespace Modules.Level
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

    public class InputManager
    {
        // interface
        public event Action<MovementDirection> OnMovementInput;
        public event Action<int> OnChangeWeaponInput;

        // dependencies
        private IMovementInput _hudMovementInput;
        private IChangeWeaponInput _hudChangeWeaponInput;

        // own members
        private IMovementInput _keyboardManager;

        public InputManager(HUD hud)
        {
            // resolve dependencies
            _hudMovementInput = hud;
            _hudChangeWeaponInput = hud;

            // prepare own members
            _keyboardManager = new KeyboardManager();

            _hudChangeWeaponInput.OnChangeWeaponButtonClicked += (delta) => OnChangeWeaponInput?.Invoke(delta);
        }

        public void OuterUpdate()
        {
            CheckMovementInput();
        }

        private void CheckMovementInput()
        {
            bool isUpButtonPressed = _hudMovementInput.IsUpButtonPressed || _keyboardManager.IsUpButtonPressed;
            bool isLeftButtonPressed = _hudMovementInput.IsLeftButtonPressed || _keyboardManager.IsLeftButtonPressed;
            bool isRightButtonPressed = _hudMovementInput.IsRightButtonPressed || _keyboardManager.IsRightButtonPressed;
            bool isDownButtonPressed = _hudMovementInput.IsDownButtonPressed || _keyboardManager.IsDownButtonPressed;

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
                OnMovementInput?.Invoke(direction);
            }
        }
    }
}
