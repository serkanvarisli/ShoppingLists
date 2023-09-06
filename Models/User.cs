using System;
using System.Collections.Generic;
using FluentMigrator.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models;

public partial class User
{
    public int UserId { get; set; }
    [Required(ErrorMessage = " Ad gereklidir.")]

    public string? UserName { get; set; }
    [Required(ErrorMessage = "Soyad gereklidir.")]

    public string? UserSurname { get; set; }
    [Required(ErrorMessage = "E posta gereklidir.")]

    public string UserEmail { get; set; } = null!;

    [Required(ErrorMessage = "Şifre alanı gereklidir.")]
    [MinLength(8, ErrorMessage = "Şifre en az 8 karakter içermelidir.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).*$", ErrorMessage = "Şifre en az bir büyük harf ve bir küçük harf içermelidir.")]
    public string? Password { get; set; }
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
    public string? RePassword { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
