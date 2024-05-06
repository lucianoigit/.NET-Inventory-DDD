using Application.Abstractions.data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using Domain.Warehouses;

namespace Application.Features.Inventory.Categories.AddArticle;

public sealed class AddArticleCommandHandler : ICommandHandler<AddArticleCommand>
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddArticleCommandHandler(
        IWarehouseRepository warehouseRepository,
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork)
    {
        _warehouseRepository = warehouseRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }
}
