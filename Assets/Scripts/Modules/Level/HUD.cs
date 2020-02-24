using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Modules.Level
{
    public class HUD : MonoBehaviour, Input.IMovementInput
    {
        public bool IsUpButtonPressed { get; private set; }
        public bool IsLeftButtonPressed { get; private set; }
        public bool IsRightButtonPressed { get; private set; }
        public bool IsDownButtonPressed { get; private set; }

        [SerializeField]
        private Button _upButton;

        [SerializeField]
        private Button _leftButton;

        [SerializeField]
        private Button _rightButton;

        [SerializeField]
        private Button _downButton;

        public void Init()
        {
            InitDirectionButton(_upButton, () => { IsUpButtonPressed = true; }, () => { IsUpButtonPressed = false; });
            InitDirectionButton(_leftButton, () => { IsLeftButtonPressed = true; }, () => { IsLeftButtonPressed = false; });
            InitDirectionButton(_rightButton, () => { IsRightButtonPressed = true; }, () => { IsRightButtonPressed = false; });
            InitDirectionButton(_downButton, () => { IsDownButtonPressed = true; }, () => { IsDownButtonPressed = false; });
        }

        private void InitDirectionButton(Button directionButton, Action onDownAction, Action onUpAction)
        {
            EventTrigger directionButtonTrigger = directionButton.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry buttonDownTrigger = new EventTrigger.Entry();
            buttonDownTrigger.eventID = EventTriggerType.PointerDown;
            buttonDownTrigger.callback.AddListener((e) => onDownAction());
            directionButtonTrigger.triggers.Add(buttonDownTrigger);

            EventTrigger.Entry buttonUpTrigger = new EventTrigger.Entry();
            buttonUpTrigger.eventID = EventTriggerType.PointerUp;
            buttonUpTrigger.callback.AddListener((e) => onUpAction());
            directionButtonTrigger.triggers.Add(buttonUpTrigger);
        }
    }
}
