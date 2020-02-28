using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Modules.Level.UI
{
    public class HUD : MonoBehaviour, Input.IMovementInput, Input.IChangeWeaponInput
    {
        // interface
        public bool IsUpButtonPressed { get; private set; }
        public bool IsLeftButtonPressed { get; private set; }
        public bool IsRightButtonPressed { get; private set; }
        public bool IsDownButtonPressed { get; private set; }

        public event Action<int> OnChangeWeaponButtonClicked;

        [Header("Movement buttons")]
        [SerializeField]
        private Button _upButton;

        [SerializeField]
        private Button _leftButton;

        [SerializeField]
        private Button _rightButton;

        [SerializeField]
        private Button _downButton;

        [Header("Weapon change buttons")]
        [SerializeField]
        private Button _previousWeaponButton;

        [SerializeField]
        private Button _nextWeaponButton;

        public void Init()
        {
            InitDirectionButton(_upButton, () => { IsUpButtonPressed = true; }, () => { IsUpButtonPressed = false; });
            InitDirectionButton(_leftButton, () => { IsLeftButtonPressed = true; }, () => { IsLeftButtonPressed = false; });
            InitDirectionButton(_rightButton, () => { IsRightButtonPressed = true; }, () => { IsRightButtonPressed = false; });
            InitDirectionButton(_downButton, () => { IsDownButtonPressed = true; }, () => { IsDownButtonPressed = false; });

            _previousWeaponButton.onClick.AddListener(() => OnChangeWeaponButtonClicked?.Invoke(-1));
            _nextWeaponButton.onClick.AddListener(() => OnChangeWeaponButtonClicked?.Invoke(1));
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
