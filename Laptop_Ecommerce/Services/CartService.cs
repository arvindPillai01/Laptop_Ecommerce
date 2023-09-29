using System.Collections.Generic;
using System.Linq;
using Laptop_Ecommerce.Models;


public class CartService
{
    private Dictionary<string, List<CartItemModel>> userCarts = new Dictionary<string, List<CartItemModel>>();

    public void AddToCart(CartItemModel item)
    {
        if (!userCarts.ContainsKey(item.UserId))
            userCarts[item.UserId] = new List<CartItemModel>();

        // Check if the item already exists in the cart for this user
        var existingItem = userCarts[item.UserId].FirstOrDefault(i => i.ProductId == item.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            userCarts[item.UserId].Add(item);
        }
    }

    public List<CartItemModel> GetCartItems(string userId)
    {
        if (userCarts.ContainsKey(userId))
            return userCarts[userId];

        return new List<CartItemModel>();
    }
}