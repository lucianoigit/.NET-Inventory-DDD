using Application.Abstractions.data;
using Application.Abstractions.Messaging;
using Domain.Brands;
using Domain.SharedKernel.Primitives;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Sources;

namespace Application.Features.Inventory.Brands.Add;

public sealed class AddBrandCommandHandler : ICommandHandler <AddBrandCommand>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AddBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
    {
        _brandRepository = brandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddBrandCommand command, CancellationToken cancellationToken)
    {
        var brand = Brand.Create(command.BrandName);

        _brandRepository.Add(brand);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
