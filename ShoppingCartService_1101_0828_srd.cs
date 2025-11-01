// 代码生成时间: 2025-11-01 08:28:06
using System;
using System.Collections.Generic;
using System.Linq;

// ShoppingCartService.cs
// Represents a shopping cart service that manages products and quantities.
public class ShoppingCartService
{
# 添加错误处理
    private List<CartItem> cartItems;

    // Initializes a new instance of the ShoppingCartService class.
# NOTE: 重要实现细节
    public ShoppingCartService()
    {
        cartItems = new List<CartItem>();
    }
# 添加错误处理

    // Adds a product to the cart.
    // If the product already exists, its quantity is updated.
    public void AddProductToCart(Product product, int quantity)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (quantity <= 0) throw new ArgumentException("Quantity must be positive", nameof(quantity));

        var item = cartItems.FirstOrDefault(c => c.Product.Id == product.Id);

        if (item != null)
        {
            // Update existing product's quantity.
            item.Quantity += quantity;
        }
        else
        {
            // Add new product to the cart.
            cartItems.Add(new CartItem { Product = product, Quantity = quantity });
        }
    }

    // Removes a product from the cart.
    public void RemoveProductFromCart(int productId)
    {
        var item = cartItems.FirstOrDefault(c => c.Product.Id == productId);

        if (item != null)
# TODO: 优化性能
        {
            cartItems.Remove(item);
        }
        else
# 改进用户体验
        {
            throw new InvalidOperationException("Product not found in the cart");
        }
    }

    // Returns the total cost of all products in the cart.
    public decimal GetTotalCost()
    {
        return cartItems.Sum(item => item.Product.Price * item.Quantity);
    }

    // Represents a product in the cart.
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
# NOTE: 重要实现细节

    // Represents a product.
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
# 扩展功能模块
    }
}
