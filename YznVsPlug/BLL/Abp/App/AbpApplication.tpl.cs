using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    partial class AbpApplication
    {
        private const string tpl = @"
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
$usingDto$
$usingManager$
using $root.name.space$.Models;
$using$

using IObjectMapper = Abp.ObjectMapping.IObjectMapper;

namespace $app.nameSapce$ {
    internal class $name$Service : $baseClass$, I$name$Service {
        private readonly I$name$Manager _$lname$Manager;
        private readonly IStringLocalizer<$name$Service> _localizer;
        private readonly IObjectMapper _mapper;
        private readonly IRepository<Company, Guid> _companyRepository;
        private readonly IRepository<$name$, Guid> $_name$Repository;
        public $name$Service(I$name$Manager $lname$Manager,
                              IObjectMapper mapper,
                              IStringLocalizer<$name$Service> localizer,
                              IRepository<$name$, Guid> $lname$Repository,
                              IRepository<Company, Guid> companyRepository) {
            _$lname$Manager = $lname$Manager;
            _mapper = mapper;
            $_name$Repository = $lname$Repository;
            _companyRepository = companyRepository;
            _localizer=localizer;
        }
        $items$
    }
}

";

        private const string tplInterface = @"
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using $app.nameSapce$.Dto;
using System.Linq;
using Abp.Extensions;
$using$

namespace $app.nameSapce$ {
    public interface I$name$Service {
$items$
    }
}
";

        private const string tplDto = @"
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using $root.name.space$.Dto;
$using$

namespace $dto.name.space$ {
    public class $dtoname$ {
        $some.sample.code$
    }
}
";

        private const string tplGetInputDtoSampleCode = @"
        private string _code;
        public string Code { get => _code; set => _code = value?.Trim()?.ToUpper(); }
        private string _name;
        public string Name { get => _name; set => _name = value?.Trim(); }
        public List<BaseDataStatus> Status { get; set; }
";
    }
}