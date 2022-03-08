using System;
using System.Collections.Generic;
using System.Linq;
using Mapster;
using Stock.Application.Contracts;
using Stock.Application.Service.Interfaces;
using Stock.Domain.Interfaces;
using Stock.Domain.Entities;

namespace Stock.Application.Services
{
    /// <summary>
    /// Устанавливает условия для корректного маппинга из сущности в DTO
    /// </summary>
    internal class CustomMapping
    {
        /// <summary>
        /// Устанваливает условия для корректного маппинга совйтсва Author из сущности
        /// в совйтсва AuthorName и AuthorUsername в DTO
        /// </summary>
        public void SetCustomAuthorMapping()
        {
            TypeAdapterConfig.GlobalSettings.AllowImplicitDestinationInheritance = true;

            TypeAdapterConfig<Product, ProductDto>.NewConfig()
                .Map(dest => dest.AuthorName, source => source.ProductAuthor.Name)
                .Map(dest => dest.AuthorUsername, source => source.ProductAuthor.Username);
        }
    }
}
