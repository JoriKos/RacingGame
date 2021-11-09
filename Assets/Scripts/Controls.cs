// GENERATED AUTOMATICALLY FROM 'Assets/Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""5a26d2ec-7146-4346-802a-c4e858509eb5"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""ae09c15f-21b5-4eac-b0d2-c1d80e927833"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""7020a48e-efaf-4b54-99ac-599a4168e68c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""f5803211-2640-49a8-bfb0-0e83156c945e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""9530508c-3aa3-4827-8bb7-d2c4e63b7dda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drift"",
                    ""type"": ""Button"",
                    ""id"": ""6cbe7f55-4634-479b-bb6b-2fe4d81c3e5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c44662e8-a33c-4034-b756-0eec04b4d225"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": ""Hold(duration=0.1,pressPoint=0.8)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11f5c598-32a0-4f5e-b634-a14cc508af1e"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e57d0b3-85b3-4d81-88d5-c3f3aa316bf5"",
                    ""path"": ""<XInputController>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b085c377-97ac-4f65-b088-3a7961eb15b4"",
                    ""path"": ""<XInputController>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b80ae83a-5527-4f42-abbf-8f4bebd7854f"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Forward = m_Gameplay.FindAction("Forward", throwIfNotFound: true);
        m_Gameplay_Backward = m_Gameplay.FindAction("Backward", throwIfNotFound: true);
        m_Gameplay_TurnRight = m_Gameplay.FindAction("TurnRight", throwIfNotFound: true);
        m_Gameplay_TurnLeft = m_Gameplay.FindAction("TurnLeft", throwIfNotFound: true);
        m_Gameplay_Drift = m_Gameplay.FindAction("Drift", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Forward;
    private readonly InputAction m_Gameplay_Backward;
    private readonly InputAction m_Gameplay_TurnRight;
    private readonly InputAction m_Gameplay_TurnLeft;
    private readonly InputAction m_Gameplay_Drift;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Gameplay_Forward;
        public InputAction @Backward => m_Wrapper.m_Gameplay_Backward;
        public InputAction @TurnRight => m_Wrapper.m_Gameplay_TurnRight;
        public InputAction @TurnLeft => m_Wrapper.m_Gameplay_TurnLeft;
        public InputAction @Drift => m_Wrapper.m_Gameplay_Drift;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackward;
                @TurnRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurnRight;
                @TurnRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurnRight;
                @TurnRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurnRight;
                @TurnLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurnLeft;
                @Drift.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrift;
                @Drift.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrift;
                @Drift.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrift;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @TurnRight.started += instance.OnTurnRight;
                @TurnRight.performed += instance.OnTurnRight;
                @TurnRight.canceled += instance.OnTurnRight;
                @TurnLeft.started += instance.OnTurnLeft;
                @TurnLeft.performed += instance.OnTurnLeft;
                @TurnLeft.canceled += instance.OnTurnLeft;
                @Drift.started += instance.OnDrift;
                @Drift.performed += instance.OnDrift;
                @Drift.canceled += instance.OnDrift;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnDrift(InputAction.CallbackContext context);
    }
}
