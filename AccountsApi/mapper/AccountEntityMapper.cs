using System;
using AutoMapper;

namespace AccountsApi.mapper
{
    public class AccountEntityMapper : Profile
    {
        public AccountEntityMapper()
        {
            CreateMap<AccountEntity, AccountModel>()
                .ReverseMap();
        }
    }
}
