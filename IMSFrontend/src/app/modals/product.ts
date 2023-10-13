export class Product {
    productID: number;
    sku: string;
    name: string;
    description: string;
    quantity: number;
    purchasePrice: number;
    salePrice: number;
    currentStock: number;
  
    constructor(
      productID: number,
      sku: string,
      name: string,
      description: string,
      quantity: number,
      purchasePrice: number,
      salePrice: number,
      currentStock: number
    ) {
      this.productID = productID;
      this.sku = sku;
      this.name = name;
      this.description = description;
      this.quantity = quantity;
      this.purchasePrice = purchasePrice;
      this.salePrice = salePrice;
      this.currentStock = currentStock;
    }
  }
  