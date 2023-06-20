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

namespace BT.Scripts.Managers {
  public class InputManager : MonoBehaviour, IManager {
    #region IManager Members
    public void Initialize() { throw new NotImplementedException(); }
    #endregion

    // catch the ui presses and what button was pressed inputft from the user
  }
}
