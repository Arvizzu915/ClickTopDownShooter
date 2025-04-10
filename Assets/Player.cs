//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Player.inputactions
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

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""InLevel"",
            ""id"": ""bf8f8de7-8735-45bf-a212-b428ca1f1fcc"",
            ""actions"": [
                {
                    ""name"": ""TrackMouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e8c6cd4f-02c0-4d2c-8c14-04b011ce164a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c5d5f007-576d-4d68-b356-6f64b8380b74"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TrackMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InLevel
        m_InLevel = asset.FindActionMap("InLevel", throwIfNotFound: true);
        m_InLevel_TrackMouse = m_InLevel.FindAction("TrackMouse", throwIfNotFound: true);
    }

    ~@Controls()
    {
        UnityEngine.Debug.Assert(!m_InLevel.enabled, "This will cause a leak and performance issues, Controls.InLevel.Disable() has not been called.");
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

    // InLevel
    private readonly InputActionMap m_InLevel;
    private List<IInLevelActions> m_InLevelActionsCallbackInterfaces = new List<IInLevelActions>();
    private readonly InputAction m_InLevel_TrackMouse;
    public struct InLevelActions
    {
        private @Controls m_Wrapper;
        public InLevelActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TrackMouse => m_Wrapper.m_InLevel_TrackMouse;
        public InputActionMap Get() { return m_Wrapper.m_InLevel; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InLevelActions set) { return set.Get(); }
        public void AddCallbacks(IInLevelActions instance)
        {
            if (instance == null || m_Wrapper.m_InLevelActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InLevelActionsCallbackInterfaces.Add(instance);
            @TrackMouse.started += instance.OnTrackMouse;
            @TrackMouse.performed += instance.OnTrackMouse;
            @TrackMouse.canceled += instance.OnTrackMouse;
        }

        private void UnregisterCallbacks(IInLevelActions instance)
        {
            @TrackMouse.started -= instance.OnTrackMouse;
            @TrackMouse.performed -= instance.OnTrackMouse;
            @TrackMouse.canceled -= instance.OnTrackMouse;
        }

        public void RemoveCallbacks(IInLevelActions instance)
        {
            if (m_Wrapper.m_InLevelActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInLevelActions instance)
        {
            foreach (var item in m_Wrapper.m_InLevelActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InLevelActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InLevelActions @InLevel => new InLevelActions(this);
    public interface IInLevelActions
    {
        void OnTrackMouse(InputAction.CallbackContext context);
    }
}
