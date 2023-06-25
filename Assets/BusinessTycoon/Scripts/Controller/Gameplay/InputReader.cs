#region Info
// -----------------------------------------------------------------------
// InputReader.cs
// 
// Felix Jung 21.06.2023
// -----------------------------------------------------------------------
#endregion
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace BT.BusinessTycoon.Scripts.Controller.Gameplay {
  [CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader",
      order = 0)]
  public class InputReader : ScriptableObject, GameInput.IUIActions {
    // Assign delegate{} to events to initialise them with an empty delegate
    //so we can skip the null check when we  use them

    // UI
    public event UnityAction MenuMouseMoveEvent = delegate { };
    public event UnityAction MenuConfirmEvent = delegate { };
    public event UnityAction MenuCancelEvent = delegate { };
    private GameInput gameInput;
    private void OnEnable() {
      if (gameInput == null) {
        gameInput = new GameInput();
        gameInput.UI.SetCallbacks(this);
      }
      EnableUIInput();
    }
    private void OnDisable() {
      DisableAllInput();
    }
    private void EnableUIInput() { gameInput.UI.Enable(); }
    private void DisableUIInput() { gameInput.UI.Disable(); }
    private void DisableAllInput() {
      DisableUIInput();

    }
    public void OnNavigate(InputAction.CallbackContext context) {
      if (context.phase == InputActionPhase.Performed)
        MenuMouseMoveEvent.Invoke();
    }
    public void OnSubmit(InputAction.CallbackContext context) {
      if (context.phase == InputActionPhase.Performed)
        MenuConfirmEvent.Invoke();
    }
    public void OnCancel(InputAction.CallbackContext context) {
      if (context.phase == InputActionPhase.Performed) MenuCancelEvent.Invoke();
    }
    public void OnPoint(InputAction.CallbackContext context) {
      throw new NotImplementedException();
    }
    public void OnClick(InputAction.CallbackContext context) {
      if (context.phase == InputActionPhase.Performed)
        MenuConfirmEvent.Invoke();
    }
    public void OnScrollWheel(InputAction.CallbackContext context) {
      throw new NotImplementedException();
    }
    public void OnMiddleClick(InputAction.CallbackContext context) {
      throw new NotImplementedException();
    }
    public void OnRightClick(InputAction.CallbackContext context) {
      throw new NotImplementedException();
    }
    public void OnTrackedDevicePosition(InputAction.CallbackContext context) {
      throw new NotImplementedException();
    }
    public void
        OnTrackedDeviceOrientation(InputAction.CallbackContext context) {
      throw new NotImplementedException();
    }
  }
}
