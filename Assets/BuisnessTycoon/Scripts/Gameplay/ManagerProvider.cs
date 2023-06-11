using System;
using UnityEngine;

namespace BT.Scripts.Gameplay {
  public class ManagerProvider {

    #region Lazy Singelton
    //https://csharpindepth.com/Articles/Singleton

    private static readonly Lazy<ManagerProvider> lazy =
        new Lazy<ManagerProvider>(() => new ManagerProvider());

    public static ManagerProvider Current => lazy.Value;
    #endregion

    private MarketManager marketManager;
    public MarketManager MarketManager =>
        TryGetAndCacheObjectOfType(ref marketManager);
        
    public static T TryGetAndCacheObjectOfType<T>(ref T cache) where T : MonoBehaviour {
      try {
        if ( cache.gameObject == null ) {
          cache = null;
        }
      }
      catch ( Exception e ) {
        Console.WriteLine(e);
        cache = null;
      }
                
      return cache ??= GetObjectOfType<T>();
    }
        
    public static T GetObjectOfType<T>() where T : UnityEngine.Object {
      var obj = UnityEngine.Object.FindObjectOfType<T>();
      if ( obj is null ) {
        Debug.LogWarning($"{typeof(T)} not Found, but was requested from GetObjectOfType");
      }
      return obj;
    }
  }
}
