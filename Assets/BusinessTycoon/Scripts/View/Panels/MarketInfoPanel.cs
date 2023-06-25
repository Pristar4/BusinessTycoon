#region Info
// -----------------------------------------------------------------------
// MarketInfoPanel.cs
// 
// Felix Jung 20.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System.Collections.Generic;
using BT.Scripts.Controller.Gameplay;
using BT.Scripts.Controller.Managers;
using BT.Scripts.Models;
using UnityEngine;
#endregion

namespace BT.Scripts.View.Panels {
  public class MarketInfoPanel : BasePanel {
    #region Serialized Fields
    [SerializeField]
    private GameObject productInfoPrefab;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private List<ProductInfo> productInfos = new();
    #endregion

    private static MarketManager GetMarketManager
      => ManagerProvider.Current.MarketManager;

    #region IPanel Members
    public override void Initialize(PanelData data = null) {
      // Intentionally left blank
    }
    public override void UpdatePanel() {
      // clear previous products
      foreach (var productInfo in productInfos) Destroy(productInfo.gameObject);
      productInfos.Clear();

      // Add new products
      foreach (var product in GetMarketManager.Products) {
        var newProductInfoObject = Instantiate(productInfoPrefab, content);
        var newProductInfo
            = newProductInfoObject.GetComponent<ProductInfo>();
        newProductInfo.productName.text = product.name;
        newProductInfo.contractsAppear.text
            = $"<size=50%>Contracts appear at {product.ContractsAppear}</size>";
        newProductInfo.priceRange.text
            = $"$ {product.PriceRange.x} - {product.PriceRange.y} <size=50%>Price range</size>";
        newProductInfo.middlePrice.text
            = $"$ {product.MiddlePrice} <size=50%>Middle price</size>";
        newProductInfo.productDemand.text
            = $"{product.productDemand} <size=50%>Product demand</size>";
        newProductInfo.contracts.text
            = $"{product.contracts} <size=50%>Contracts</size>";
        newProductInfo.growthInPricePerQuarter.text
            = $"$ {product.growthInPricePerQuarter} <size=50%>Growth in price per quarter</size>";
        newProductInfo.growthPerQuarter.text
            = $"{product.growthPerQuarter} <size=50%>Growth per quarter</size>";


        productInfos.Add(newProductInfo);
      }

    }
    #endregion
  }
}
