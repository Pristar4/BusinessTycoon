#region Info
// -----------------------------------------------------------------------
// InputManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
using System;
using BT.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BT.Scripts.Managers {
  public class InputManager : MonoBehaviour, IManager, GameInput.IUIActions {
    // Define the events that will be fired by the InputManager
    public event Action<Vector2> OnNavigateEvent;
    public event Action OnSubmitEvent;
    public event Action OnCancelEvent;
    public event Action<Vector2> OnPointEvent;
    public event Action OnClickEvent;
    public event Action<Vector2> OnScrollWheelEvent;
    public event Action OnMiddleClickEvent;
    public event Action OnRightClickEvent;
    public event Action<Vector2> OnTrackedDevicePositionEvent;
    public event Action<Quaternion> OnTrackedDeviceOrientationEvent;
    private GameInput gameInput;
    public void Initialize() {
      // Nothing to do here
    }
    public void Awake() {
      gameInput = new GameInput();
    }
    private void OnEnable() {
      // Enable the UI actions map and set this object as the action map's delegate
      gameInput.UI.SetCallbacks(this);
      gameInput.UI.Enable();
    }
    private void OnDisable() {
      // Disable the UI actions map when this object is disabled
      gameInput.UI.Disable();
    }
    public void OnNavigate(InputAction.CallbackContext context) {
      OnNavigateEvent?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnSubmit(InputAction.CallbackContext context) {
      OnSubmitEvent?.Invoke();
    }
    public void OnCancel(InputAction.CallbackContext context) {
      OnCancelEvent?.Invoke();
    }
    public void OnPoint(InputAction.CallbackContext context) {
      OnPointEvent?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnClick(InputAction.CallbackContext context) {
      OnClickEvent?.Invoke();
    }
    public void OnScrollWheel(InputAction.CallbackContext context) {
      OnScrollWheelEvent?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnMiddleClick(InputAction.CallbackContext context) {
      OnMiddleClickEvent?.Invoke();
    }
    public void OnRightClick(InputAction.CallbackContext context) {
      OnRightClickEvent?.Invoke();
    }
    public void OnTrackedDevicePosition(InputAction.CallbackContext context) {
      OnTrackedDevicePositionEvent?.Invoke(context.ReadValue<Vector2>());
    }
    public void
        OnTrackedDeviceOrientation(InputAction.CallbackContext context) {
      OnTrackedDeviceOrientationEvent?.Invoke(context.ReadValue<Quaternion>());
    }
  }

}
