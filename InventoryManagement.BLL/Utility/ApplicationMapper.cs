using AutoMapper;
using InventoryManagement.BLL.DTOs;
using InventoryManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.BLL.Utility
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<SaleProduct, SalesProductDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Sale.Store.Name))
                .ForMember(dest=> dest.CreatedAt, opt => opt.MapFrom(src => src.Sale.CreatedAt))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.Product.Price))
                .ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();

            CreateMap<RemainigProductDTO, StoreProduct>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => new Product { Name = src.ProductName }))
                .ForMember(dest => dest.Store, opt => opt.MapFrom(src => new Store { Name = src.StoreName }))
                .ReverseMap();
        }
    }
}
