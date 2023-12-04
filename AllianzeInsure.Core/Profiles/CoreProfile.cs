using AllianzeInsure.Core.Commands;
using AllianzeInsure.Core.DTO;
using AllianzeInsure.Core.Queries;
using AllianzeInsure.Data.Entities;
using AutoMapper;

namespace AllianzeInsure.Core.Profiles
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<CreateInsurance.Command, CreateInsuranceDto>()
                   .ReverseMap();

            CreateMap<CreateProduct.Command, CreateProductDto>()
                   .ReverseMap();

            CreateMap<CreateVehicle.Command, CreateVehicleDto>()
                   .ReverseMap();


            CreateMap<Insurance, FetchInsurance.Result>()
                   .ReverseMap();

            CreateMap<Vehicle, VehicleResponse>()
                   .ReverseMap();

            CreateMap<Product, ProductResponse>()
                   .ReverseMap();

            CreateMap<Payment, PaymentResponse>()
                   .ReverseMap();
        }
    }
}