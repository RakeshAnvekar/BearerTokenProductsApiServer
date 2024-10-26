﻿namespace ProductsApi.Models.Product;

public class Product
{
    public int? Id { get; set; }
    public string? ProductName { get; set; }=string.Empty;
    public decimal? Price { get; set; }
    public string? CategoryType { get; set; } = string.Empty;
}