#region Info
// -----------------------------------------------------------------------
// Offer.cs
// 
// Felix Jung 25.06.2023
// -----------------------------------------------------------------------
#endregion
namespace BT.Scripts.Models {
  public class Offer {
    public Company company;
    public bool isSold;
    public decimal price;
    public ProductData product;
    public int quantity;
    public int soldQuantity; // TODO: Remove this
    public Offer(Company company, ProductData product, int quantity,
                 decimal price, int soldQuantity = 0, bool isSold = false) {
      this.company = company;
      this.product = product;
      this.quantity = quantity;
      this.price = price;
      this.soldQuantity = soldQuantity;
      this.isSold = isSold;
    }
    public string GetOfferDetails() {
      return "Company: " + company.CompanyName + " Product: " +
             product.Type.name
             + " Quantity: " + quantity + " Price: " + price;
    }
    public void Sell(int quantityToBuy) {
      soldQuantity = quantityToBuy;
      isSold = true;
      quantity -= quantityToBuy;
    }
  }
}
