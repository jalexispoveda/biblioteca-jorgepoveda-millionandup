using AutoMapper;
using Biblioteca.Core.DTO;
using Biblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Infraestructure.Mapper
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Autores, AutoresDTO>();
            CreateMap<AutoresDTO, Autores>();

            CreateMap<Libros, LibrosDTO>();
            CreateMap<LibrosDTO, Libros>();

            CreateMap<Editoriales, EditorialesDTO>();
            CreateMap<EditorialesDTO, Editoriales>();
        }
    }
}
