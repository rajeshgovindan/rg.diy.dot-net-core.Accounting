using System;
using AutoMapper;
using AccountsApi.Model;
using AccountsApi.Repository;

namespace AccountsApi.mapper
{
    public class CustomerEntityMapper : Profile
    {
        public CustomerEntityMapper()
        {
            CreateMap<CustomerEntity, CustomerModel>()
                .ReverseMap();
        }
    }
}
