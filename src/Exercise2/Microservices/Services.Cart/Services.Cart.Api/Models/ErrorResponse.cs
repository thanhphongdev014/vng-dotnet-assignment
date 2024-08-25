﻿namespace Services.Cart.Api.Models;

public class ErrorResponse
{
    public string Title { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}
