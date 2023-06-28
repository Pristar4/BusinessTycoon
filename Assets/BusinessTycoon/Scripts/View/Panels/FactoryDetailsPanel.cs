using System.Collections.Generic;
using BT.Managers;
using BT.Molecules;
using UnityEngine;

namespace BT.Panels {
    public class FactoryDetailsPanel: BasePanel {
        
          #region Serialized Fields


        #endregion





        public override void UpdatePanel() {
        }

        public void SetFactory(FactoryData factory) {
            Debug.Log("FactoryDetailsPanel: SetFactory");
            Debug.Log(factory.Factory.FactoryName);
        }
    }
}