#region Info
// -----------------------------------------------------------------------
// FactorySo.cs
// 
// Felix Jung 06.06.2023
// -----------------------------------------------------------------------
#endregion
#region
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#endregion

namespace BT.Scripts.production {
  [CreateAssetMenu(fileName = "new_factory", menuName = "Production/Factory",
                   order = 0)]
  public class FactorySo : ProductSo {

    [SerializeField] private ProductData[] ingredients;
    [SerializeField] private ProductData[] results;

    public ProductData[] Ingredients => ingredients;
    public ProductData[] Results => results;

    public bool TryProduce(List<ProductData> inputIngredients,
                           out List<ProductData> outputResults) {
      outputResults = null;

      if (!AreIngredientsSufficient(inputIngredients)) { return false; }

      outputResults = results
          .Select(result => new ProductData(result.type, result.amount))
          .ToList();

      //copy results into outputResults
      return true;
    }

    public void ConsumeIngredients(ref List<ProductData> inputIngredients) {
      foreach (var ingredient in Ingredients) {
        var foundIngredient
            = inputIngredients.Find(data => data.type == ingredient.type);

        foundIngredient.amount -= ingredient.amount;
      }
    }

    private bool AreIngredientsSufficient(List<ProductData> inputIngredients) {

      foreach (var ingredient in Ingredients) {
        var foundIngredient
            = inputIngredients.Find(data => data.type == ingredient.type);


        if (foundIngredient is null ||
            foundIngredient.amount < ingredient.amount) { return false; }
      }

      return true;
    }
  }
}
