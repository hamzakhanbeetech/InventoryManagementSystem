import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Product } from 'src/app/modals/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  products: Product[] = [];
  product: Product = new Product(0, '', '', '', 0, 0, 0, 0);
  productForm!: FormGroup;
  currentPage: number;
  pageSize: number;
  totalPages!: number;
  totalProducts!: number;
  pageSizeOptions = [1,2,5,10,30,50,100]
  editingProduct! : Product | null

  constructor( private fb: FormBuilder, private productService: ProductService) {
    this.currentPage = 1;
    this.pageSize = 10;

    this.productForm = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      purchasePrice: [0, [Validators.required]],
      salePrice: [0, [Validators.required]],
      currentStock: [0, [Validators.required]],
    });
  }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getProductsForDashboard(this.currentPage, this.pageSize).subscribe((data) => {
      this.products = data.products;
      this.totalPages = data.totalPages;
      this.totalProducts = data.totalProducts;
    });
  }

  onPageChange(page: number) {
    this.currentPage = page;
    this.loadProducts();
  }

  getPaginationArray(totalPages: number): number[] {
    return Array.from({ length: totalPages }, (_, i) => i + 1);
  }

  changePageSize(e:any){
    this.pageSize = e.target.value
    this.currentPage = 1
    this.loadProducts();
  }

  saveProduct() {
    if (this.productForm.valid) {
      const newProduct: Product = this.productForm.value as Product;

      this.productService.createProduct(newProduct).subscribe(() => {
        alert("Successfully Added New Product")
        this.productForm.reset();
        this.loadProducts();
      }, err => {        
        alert("Error Whil Added New Product")
      });
    }
  }
  editProduct(product: Product) {
    // Implement the logic to open an edit form or dialog.
    // For this example, let's assume you have a variable to track the edited product.
    this.editingProduct = { ...product };
  }
  
  saveEditedProduct() {
    // Make an HTTP request to update the product.
    if(this.editingProduct == null){
      return
    }
    this.productService.updateProduct(this.editingProduct.productID, this.editingProduct).subscribe(() => {
      // Product updated successfully; reload the product list.
      this.loadProducts();
      // Reset the editingProduct variable or close the edit form/dialog.
      this.editingProduct = null;
    });
  }

  deleteProduct(product: Product) {
    
    this.productService.deleteProduct(product.productID).subscribe(() => {
      // Product deleted successfully; reload the product list
      this.loadProducts();
    });
  }

}
