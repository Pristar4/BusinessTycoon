#region Info

// -----------------------------------------------------------------------
// PlayerManager.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using UnityEngine;

#endregion

namespace BT.Managers {
    public class PlayerManager : MonoBehaviour, IManager {
        public static PlayerManager Instance { get; }
        public Company PlayerCompany { get; private set; }

        #region IManager Members

        public void Initialize() {
            // Intentionally left blank
        }

        #endregion

        public Company GetPlayerCompany() {
            return PlayerCompany;
        }

        public void Initialize(Company startup) {
            PlayerCompany = startup;
        }
    }
}