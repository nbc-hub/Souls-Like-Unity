//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""a42de4d4-07c9-4a41-ad9b-60d2655d891a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a985bedf-6fc5-4e78-8d99-75269e1de7f2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dbd93790-6901-4908-8546-37d6866728c9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""551baf68-4d6a-4ef9-aff0-4db9d639db4f"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0850145b-066e-45cb-a218-9c3f4c8e1c6f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b269ea29-240d-4d15-86be-e1ccd36bf28a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3709064a-2657-40ab-a627-d287db7f544f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c4318b78-f686-42e4-bed3-e8be82d012b5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8dbd8ac8-16d1-4475-9617-b065fb37ef3e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player Action"",
            ""id"": ""023f8b67-257c-43f0-8749-9cf5c935f1da"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""72962a00-836b-444c-8072-943f66c38089"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""fe087119-79c4-4005-93ea-a3004902f8d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CriticalAttack"",
                    ""type"": ""Button"",
                    ""id"": ""f7e1acab-8ad6-400b-b5c3-e7954af8bc5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""33100002-cf85-40ee-a0d6-7abf2b9425ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""01f1eff3-d290-4322-aa5b-ce053f47347f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""ef97e217-6cf3-47b5-a4ff-0526457e68fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""82ae9782-0377-4606-a941-9144ff4c5afb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""342a79af-d7db-42cf-8886-d2c58d934783"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockOnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""ac0676f4-46c8-4c84-a20d-283b4689d312"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockOnRight"",
                    ""type"": ""Button"",
                    ""id"": ""121ad5c5-c658-4962-8db6-8fb604819f02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""8984759f-8eb3-4148-8140-5dad5448d179"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LT"",
                    ""type"": ""Button"",
                    ""id"": ""e290f5d8-3b79-4372-a0ca-d1c7ce8be0aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LB"",
                    ""type"": ""Button"",
                    ""id"": ""3b66a1e4-d2dd-4c60-8d32-4b92c1f0f5a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""775aac0c-5966-4aeb-b7b2-4d57e5770e34"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9321ada7-1885-4b5b-9ebd-af21b2d98c04"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8023e28f-afdb-4b12-ae5e-013359402baf"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2ccb9bc-1055-46ec-85a5-2858112ffce4"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b2fc156-74c1-4e6c-8af3-9062b8850b8d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26271ac8-b199-423a-b8c8-2c7bf9d28451"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f99e803-de7f-4acc-93d7-1f10179db1aa"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cc1b406-da8c-4c39-8db6-51ba8a518bb4"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd445e8f-f0f7-4ab7-b791-ec09cdcc3ed0"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e0f4760-34e1-4b14-a1de-f1a9c8446d67"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0e196da-af31-4daa-b093-6c4ee25845b2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CriticalAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1974ae64-2f65-4d01-b3ba-f1f6e710302f"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f16dddb0-67b9-4b81-a461-be7ce8a5a208"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard Arrows"",
            ""id"": ""e2f5ee7b-6a78-4b71-84d2-41fb15734637"",
            ""actions"": [
                {
                    ""name"": ""Up_Arrow"",
                    ""type"": ""Button"",
                    ""id"": ""02f94b64-97af-4f41-8449-fb6e3800f2be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down_Arrow"",
                    ""type"": ""Button"",
                    ""id"": ""ee613cda-0ab0-41fd-b792-177f6bdae020"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left_Arrow"",
                    ""type"": ""Button"",
                    ""id"": ""1e13f6b5-2820-4713-a8ce-b67ce408b610"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rigth_Arrow"",
                    ""type"": ""Button"",
                    ""id"": ""36aec6dc-4210-4b4b-b78c-1f0662576931"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3972f63e-a8e9-4426-9377-92fcda7fd902"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up_Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a5850a8-0c80-4ad9-a4e9-e5f83a6b6676"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down_Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7afceca-5d37-4c38-b607-b83e69e53de1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left_Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c81c563e-2b36-42f7-a089-380d08b51171"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rigth_Arrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
        // Player Action
        m_PlayerAction = asset.FindActionMap("Player Action", throwIfNotFound: true);
        m_PlayerAction_Roll = m_PlayerAction.FindAction("Roll", throwIfNotFound: true);
        m_PlayerAction_RB = m_PlayerAction.FindAction("RB", throwIfNotFound: true);
        m_PlayerAction_CriticalAttack = m_PlayerAction.FindAction("CriticalAttack", throwIfNotFound: true);
        m_PlayerAction_RT = m_PlayerAction.FindAction("RT", throwIfNotFound: true);
        m_PlayerAction_Enter = m_PlayerAction.FindAction("Enter", throwIfNotFound: true);
        m_PlayerAction_Space = m_PlayerAction.FindAction("Space", throwIfNotFound: true);
        m_PlayerAction_Inventory = m_PlayerAction.FindAction("Inventory", throwIfNotFound: true);
        m_PlayerAction_LockOn = m_PlayerAction.FindAction("LockOn", throwIfNotFound: true);
        m_PlayerAction_LockOnLeft = m_PlayerAction.FindAction("LockOnLeft", throwIfNotFound: true);
        m_PlayerAction_LockOnRight = m_PlayerAction.FindAction("LockOnRight", throwIfNotFound: true);
        m_PlayerAction_Y = m_PlayerAction.FindAction("Y", throwIfNotFound: true);
        m_PlayerAction_LT = m_PlayerAction.FindAction("LT", throwIfNotFound: true);
        m_PlayerAction_LB = m_PlayerAction.FindAction("LB", throwIfNotFound: true);
        // Keyboard Arrows
        m_KeyboardArrows = asset.FindActionMap("Keyboard Arrows", throwIfNotFound: true);
        m_KeyboardArrows_Up_Arrow = m_KeyboardArrows.FindAction("Up_Arrow", throwIfNotFound: true);
        m_KeyboardArrows_Down_Arrow = m_KeyboardArrows.FindAction("Down_Arrow", throwIfNotFound: true);
        m_KeyboardArrows_Left_Arrow = m_KeyboardArrows.FindAction("Left_Arrow", throwIfNotFound: true);
        m_KeyboardArrows_Rigth_Arrow = m_KeyboardArrows.FindAction("Rigth_Arrow", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Camera;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Player Action
    private readonly InputActionMap m_PlayerAction;
    private IPlayerActionActions m_PlayerActionActionsCallbackInterface;
    private readonly InputAction m_PlayerAction_Roll;
    private readonly InputAction m_PlayerAction_RB;
    private readonly InputAction m_PlayerAction_CriticalAttack;
    private readonly InputAction m_PlayerAction_RT;
    private readonly InputAction m_PlayerAction_Enter;
    private readonly InputAction m_PlayerAction_Space;
    private readonly InputAction m_PlayerAction_Inventory;
    private readonly InputAction m_PlayerAction_LockOn;
    private readonly InputAction m_PlayerAction_LockOnLeft;
    private readonly InputAction m_PlayerAction_LockOnRight;
    private readonly InputAction m_PlayerAction_Y;
    private readonly InputAction m_PlayerAction_LT;
    private readonly InputAction m_PlayerAction_LB;
    public struct PlayerActionActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_PlayerAction_Roll;
        public InputAction @RB => m_Wrapper.m_PlayerAction_RB;
        public InputAction @CriticalAttack => m_Wrapper.m_PlayerAction_CriticalAttack;
        public InputAction @RT => m_Wrapper.m_PlayerAction_RT;
        public InputAction @Enter => m_Wrapper.m_PlayerAction_Enter;
        public InputAction @Space => m_Wrapper.m_PlayerAction_Space;
        public InputAction @Inventory => m_Wrapper.m_PlayerAction_Inventory;
        public InputAction @LockOn => m_Wrapper.m_PlayerAction_LockOn;
        public InputAction @LockOnLeft => m_Wrapper.m_PlayerAction_LockOnLeft;
        public InputAction @LockOnRight => m_Wrapper.m_PlayerAction_LockOnRight;
        public InputAction @Y => m_Wrapper.m_PlayerAction_Y;
        public InputAction @LT => m_Wrapper.m_PlayerAction_LT;
        public InputAction @LB => m_Wrapper.m_PlayerAction_LB;
        public InputActionMap Get() { return m_Wrapper.m_PlayerAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionActions instance)
        {
            if (m_Wrapper.m_PlayerActionActionsCallbackInterface != null)
            {
                @Roll.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRoll;
                @RB.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRB;
                @CriticalAttack.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnCriticalAttack;
                @CriticalAttack.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnCriticalAttack;
                @CriticalAttack.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnCriticalAttack;
                @RT.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnRT;
                @Enter.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnEnter;
                @Space.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnSpace;
                @Inventory.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnInventory;
                @LockOn.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLockOn;
                @LockOnLeft.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLockOnLeft;
                @LockOnLeft.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLockOnLeft;
                @LockOnLeft.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLockOnLeft;
                @LockOnRight.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLockOnRight;
                @LockOnRight.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLockOnRight;
                @LockOnRight.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLockOnRight;
                @Y.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnY;
                @LT.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLT;
                @LT.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLT;
                @LT.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLT;
                @LB.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLB;
                @LB.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLB;
                @LB.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnLB;
            }
            m_Wrapper.m_PlayerActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @CriticalAttack.started += instance.OnCriticalAttack;
                @CriticalAttack.performed += instance.OnCriticalAttack;
                @CriticalAttack.canceled += instance.OnCriticalAttack;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @LockOnLeft.started += instance.OnLockOnLeft;
                @LockOnLeft.performed += instance.OnLockOnLeft;
                @LockOnLeft.canceled += instance.OnLockOnLeft;
                @LockOnRight.started += instance.OnLockOnRight;
                @LockOnRight.performed += instance.OnLockOnRight;
                @LockOnRight.canceled += instance.OnLockOnRight;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
                @LT.started += instance.OnLT;
                @LT.performed += instance.OnLT;
                @LT.canceled += instance.OnLT;
                @LB.started += instance.OnLB;
                @LB.performed += instance.OnLB;
                @LB.canceled += instance.OnLB;
            }
        }
    }
    public PlayerActionActions @PlayerAction => new PlayerActionActions(this);

    // Keyboard Arrows
    private readonly InputActionMap m_KeyboardArrows;
    private IKeyboardArrowsActions m_KeyboardArrowsActionsCallbackInterface;
    private readonly InputAction m_KeyboardArrows_Up_Arrow;
    private readonly InputAction m_KeyboardArrows_Down_Arrow;
    private readonly InputAction m_KeyboardArrows_Left_Arrow;
    private readonly InputAction m_KeyboardArrows_Rigth_Arrow;
    public struct KeyboardArrowsActions
    {
        private @PlayerControls m_Wrapper;
        public KeyboardArrowsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up_Arrow => m_Wrapper.m_KeyboardArrows_Up_Arrow;
        public InputAction @Down_Arrow => m_Wrapper.m_KeyboardArrows_Down_Arrow;
        public InputAction @Left_Arrow => m_Wrapper.m_KeyboardArrows_Left_Arrow;
        public InputAction @Rigth_Arrow => m_Wrapper.m_KeyboardArrows_Rigth_Arrow;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardArrows; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardArrowsActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardArrowsActions instance)
        {
            if (m_Wrapper.m_KeyboardArrowsActionsCallbackInterface != null)
            {
                @Up_Arrow.started -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnUp_Arrow;
                @Up_Arrow.performed -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnUp_Arrow;
                @Up_Arrow.canceled -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnUp_Arrow;
                @Down_Arrow.started -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnDown_Arrow;
                @Down_Arrow.performed -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnDown_Arrow;
                @Down_Arrow.canceled -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnDown_Arrow;
                @Left_Arrow.started -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnLeft_Arrow;
                @Left_Arrow.performed -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnLeft_Arrow;
                @Left_Arrow.canceled -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnLeft_Arrow;
                @Rigth_Arrow.started -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnRigth_Arrow;
                @Rigth_Arrow.performed -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnRigth_Arrow;
                @Rigth_Arrow.canceled -= m_Wrapper.m_KeyboardArrowsActionsCallbackInterface.OnRigth_Arrow;
            }
            m_Wrapper.m_KeyboardArrowsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up_Arrow.started += instance.OnUp_Arrow;
                @Up_Arrow.performed += instance.OnUp_Arrow;
                @Up_Arrow.canceled += instance.OnUp_Arrow;
                @Down_Arrow.started += instance.OnDown_Arrow;
                @Down_Arrow.performed += instance.OnDown_Arrow;
                @Down_Arrow.canceled += instance.OnDown_Arrow;
                @Left_Arrow.started += instance.OnLeft_Arrow;
                @Left_Arrow.performed += instance.OnLeft_Arrow;
                @Left_Arrow.canceled += instance.OnLeft_Arrow;
                @Rigth_Arrow.started += instance.OnRigth_Arrow;
                @Rigth_Arrow.performed += instance.OnRigth_Arrow;
                @Rigth_Arrow.canceled += instance.OnRigth_Arrow;
            }
        }
    }
    public KeyboardArrowsActions @KeyboardArrows => new KeyboardArrowsActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface IPlayerActionActions
    {
        void OnRoll(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnCriticalAttack(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnLockOnLeft(InputAction.CallbackContext context);
        void OnLockOnRight(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnLT(InputAction.CallbackContext context);
        void OnLB(InputAction.CallbackContext context);
    }
    public interface IKeyboardArrowsActions
    {
        void OnUp_Arrow(InputAction.CallbackContext context);
        void OnDown_Arrow(InputAction.CallbackContext context);
        void OnLeft_Arrow(InputAction.CallbackContext context);
        void OnRigth_Arrow(InputAction.CallbackContext context);
    }
}
