#region Info

// -----------------------------------------------------------------------
// ProductData.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------

#endregion

#region

using System;
using UnityEngine;
using UnityEngine.Serialization;

#endregion

namespace BT {
    [Serializable]
    public class ProductData {
        #region Serialized Fields

        [FormerlySerializedAs("amount")] [SerializeField] private int quantity;
        [SerializeField] private ProductSo type;

        #endregion

        public ProductData(ProductSo type, int quantity) {
            this.type = type;
            this.quantity = quantity;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public ProductSo Type => type;
    }
}