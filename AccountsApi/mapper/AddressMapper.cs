using System;
using AccountsApi.Model;
using AccountsApi.Repository;
using AutoMapper;

namespace AccountsApi.mapper
{
    public class AddressMapper : Profile
    {
        public AddressMapper()
        {
            CreateMap<AddressValueObject, Address>()
                .ReverseMap();
        }
    }
}
