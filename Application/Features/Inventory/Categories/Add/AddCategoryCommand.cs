using Application.Abstractions.Messaging;

namespace Application.Features.Inventory.Categories.Add;

public sealed record AddCategoryCommand(string CategoryName): ICommand;

