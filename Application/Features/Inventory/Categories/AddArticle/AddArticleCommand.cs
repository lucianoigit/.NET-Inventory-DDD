using Application.Abstractions.Messaging;

namespace Application.Features.Inventory.Categories.AddArticle;

public sealed record AddArticleCommand(Guid ArticleId, Guid CategoryId) : ICommand;
