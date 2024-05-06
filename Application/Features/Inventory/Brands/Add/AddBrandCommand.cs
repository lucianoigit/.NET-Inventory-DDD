using Application.Abstractions.Messaging;

namespace Application.Features.Inventory.Brands.Add;

public sealed record AddBrandCommand(string BrandName) : ICommand;
