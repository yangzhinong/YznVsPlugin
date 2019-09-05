using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpAppDtoMapperProfile
    {
        private const string tpl = @"
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using $root.name.space$.Dto;
using $root.name.space$.Models;

namespace $dto.name.space$.$name$s.Dto {
    public class $name$Profile : Profile {
        public $name$Profile() {
            CreateMap<$name$, Get$name$ByIdOutput>();
            CreateMap<$name$, Get$name$sOutput>();
            CreateMap<Post$name$Input, $name$>();
            CreateMap<Put$name$Input, $name$>();
        }
    }
}
";

        public string GetText(string rootNameSpace, string subPath, string name)
        {
            var dtoNameSpace = rootNameSpace;
            if (!string.IsNullOrWhiteSpace(subPath))
            {
                dtoNameSpace = rootNameSpace + "." + subPath;
            }
            return tpl.Replace("$dto.name.space$", dtoNameSpace)
                      .Replace("$root.name.space$", rootNameSpace)
                      .Replace("$name$", name);
        }
    }
}