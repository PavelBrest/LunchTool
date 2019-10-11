using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using LT.Core.Contracts.Places.Commands;
using LT.Core.Contracts.Places.Queries;

namespace LT.Core.Backend.Places.Mappings
{
    internal class PlaceMappings : Profile
    {
        public PlaceMappings()
        {
            CreateMap<CreatePlace, Place>();
            CreateMap<DeletePlace, Place>();
            CreateMap<UpdatePlace, Place>();
            CreateMap<Place, GetPlace>();
        }
    }
}
