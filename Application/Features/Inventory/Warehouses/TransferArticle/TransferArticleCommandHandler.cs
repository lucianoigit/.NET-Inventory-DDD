using Application.Abstractions.data;
using Application.Abstractions.Messaging;
using Domain.SharedKernel.Primitives;
using Domain.Warehouses;
using Domain.Warehouses.Articles;
using Domain.Warehouses.Articles.ValueObjects;
using Domain.Warehouses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Inventory.Warehouses.TransferArticle
{
    public sealed class TransferArticleCommandHandler : ICommandHandler<TransferArticleCommand>
    {
       
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly TransferService _transferService;


        public TransferArticleCommandHandler(
     
            IWarehouseRepository warehouseRepository,
            IUnitOfWork unitOfWork)
        {

            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }

        public IWarehouseRepository Get_warehouseRepository()
        {
            return _warehouseRepository;
        }

        public async Task<Result> Handle(TransferArticleCommand command, CancellationToken cancellationToken)
        {

            var quantity = command.quantity;

            var articleCode = new ArticleCode(command.articleCode);
            
            var originWarehouseId = new WareHouseId(command.originWarehouseId);

            var destinationWarehouseId = new WareHouseId(command.destinationWarehouseId); 

            var originWarehouse = await _warehouseRepository.GetByIdAsync(originWarehouseId);

            if (originWarehouse is null) return Result.Failure(Error.Validation("Warehouse.NotFound", "The requested warehouse was not found.")); // debo modificar el error

            var destinationWarehouse = await _warehouseRepository.GetByIdAsync(destinationWarehouseId);

            if (destinationWarehouse is null) return Result.Failure(Error.Validation("Warehouse.NotFound", "The requested warehouse was not found.")); ; // debo modificar el error

            originWarehouse.DecreaseArticleByCode(articleCode, quantity);

            destinationWarehouse.IncrementArticleByCode(articleCode, quantity);

            _warehouseRepository.Update(originWarehouse);

            _warehouseRepository.Update(destinationWarehouse);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
    //Paso 1: llamar al wharehouse que envia.
    //Paso 2: preguntar si ese warehouse tiene el articulo
    //Paso 3: si lo tiene, preguntar si esta disponible en la cantidad necesaria
    //Paso 4: preguntar si el warehouse que recibe tiene el articulo, si lo tiene aumentar la cantidad, y si no, crearlo con esa cantidad
    //Paso 5: guardar en repositorio ambos estados actualizados de los warehouses
   
}
