﻿using Domain.Warehouses.Articles;
using System;

namespace Domain.Warehouses
{
    public sealed class TransferService
    {
        public void TransferArticles(
            Article originArticle,
            Article destinationArticle,
   
            int quantity)
        {
            if (originArticle.Stock >= quantity)
            {
                originArticle.RemoveStock(quantity);
                destinationArticle.AddStock(quantity);
            }
            else
            {
                throw new InvalidOperationException("No hay suficientes productos en el inventario de origen para transferir.");
            }
        }
    }
}