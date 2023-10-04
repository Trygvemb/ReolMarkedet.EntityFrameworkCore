using System;
using AutoMapper;
using RM.API.Dto;
using RM.Domain.Entities;

namespace RM.API.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
            CreateMap<ShelfTenant, ShelfTenantDto>();
			CreateMap<ShelfTenantDto, ShelfTenant>();
			CreateMap<Barcode, BarcodeDto>();
			CreateMap<BarcodeDto, Barcode>();
			CreateMap<Sale, SaleDto>();
			CreateMap<SaleDto, Sale>();
			CreateMap<Payout, PayoutDto>();
			CreateMap<PayoutDto, Payout>();
		}
	}
}

