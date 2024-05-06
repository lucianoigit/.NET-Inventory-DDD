using Application.Abstractions.data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using Domain.Categories.ValueObjects;
using Domain.SharedKernel.Primitives;
using Domain.Supplier.ValueObjects;
using Domain.Warehouses;
using Domain.Warehouses.Articles;
using Domain.Warehouses.Articles.ValueObjects;
using Domain.Warehouses.ValueObjects;

namespace Application.Features.Inventory.Articles.Add;

public sealed class AddArticleCommandHandler : ICommandHandler<AddArticleCommand>
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddArticleCommandHandler(IWarehouseRepository warehouseRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _warehouseRepository = warehouseRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(AddArticleCommand command, CancellationToken cancellationToken) 
    {
        var warehouseId = new WareHouseId(command.WarehouseId);

        var warehouse = await _warehouseRepository.GetByIdAsync(warehouseId, cancellationToken);

        if (warehouse is null) return Result.Failure((Error.Validation("Warehouse.NotFound", "The requested warehouse was not found.")));

        var articleCode = new ArticleCode(command.ArticleCode);

        var categoryId = new CategoryId(command.CategoryId);

        var category = await _categoryRepository.GetByIdAsync(categoryId);

        if (category is null) return Result.Failure(CategoryErrors.CategoryNotFound);

        var supplierIds = command.SupplierIds?.Select(id => new SupplierId(id)).ToList();


        var article = Article.Create(
            articleCode,
            command.ArticleBarcode,
            command.UnitaryPrice,
            command.ArticleDescription,
            command.Stock,
            true,
            categoryId,
            supplierIds);


        warehouse.AddArticle(article);

        _warehouseRepository.Update(warehouse);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
