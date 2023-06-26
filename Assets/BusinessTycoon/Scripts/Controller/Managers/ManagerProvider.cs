#region Info

// -----------------------------------------------------------------------
// ManagerProvider.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace BT.Managers {
    public class ManagerProvider {
        private InputManager inputManager;
        private MarketManager marketManager;
        private PanelManager panelManager;
        private PlayerManager playerManager;
        private TurnManager turnManager;

        public InputManager InputManager
            => TryGetAndCacheObjectOfType(ref inputManager);

        public MarketManager MarketManager
            => TryGetAndCacheObjectOfType(ref marketManager);

        public PlayerManager PlayerManager
            => TryGetAndCacheObjectOfType(ref playerManager);

        public PanelManager PanelManager
            => TryGetAndCacheObjectOfType(ref panelManager);

        public TurnManager TurnManager
            => TryGetAndCacheObjectOfType(ref turnManager);

        private static T TryGetAndCacheObjectOfType<T>(ref T cache)
                where T : MonoBehaviour {
            try {
                if (cache.gameObject == null) cache = null;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                cache = null;
            }

            return cache ??= GetObjectOfType<T>();
        }

        private static T GetObjectOfType<T>() where T : Object {
            var obj = Object.FindFirstObjectByType<T>();

            if (obj is null)
                Debug.LogWarning(
                        $"{typeof(T)} not Found, but was requested from GetObjectOfType");

            return obj;
        }

        #region Lazy Singelton

        //https://csharpindepth.com/Articles/Singleton
        private static readonly Lazy<ManagerProvider> Lazy = new(()
                                                                         => new
                                                                                 ManagerProvider());
        public static ManagerProvider Current => Lazy.Value;

        #endregion
    }
}