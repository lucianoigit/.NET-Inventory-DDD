using Application.Abstractions.data;
using Application.Abstractions.Messaging;
using Domain.Categories;
using Domain.SharedKernel.Primitives;

namespace Application.Features.Inventory.Categories.Add
{
    public sealed class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddCategoryCommandHandler (ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle (AddCategoryCommand command, CancellationToken cancellationToken) 
        {
            var category = Category.Create(command.CategoryName);
            
            _categoryRepository.Add(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
