using System;
using System.Collections.Generic;

namespace ShoppingList.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserSurname { get; set; }

    public string UserEmail { get; set; } = null!;

    public string? Password { get; set; }

    public string? RePassword { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
