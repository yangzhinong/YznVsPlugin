using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    public partial class AbpManager
    {
        private const string tplInterface = @"
using System;
using System.Collections.Generic;
using System.Text;
using $root.name.space$.Models;

namespace $manager.name.space$ {
    public interface I$name$Manager {
        void Create($name$ $lname$);
        void Update($name$ $lname$);
        void Abandon($name$ $lname$);
    }
}
";

        private const string tpl = @"
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Repositories;
using Microsoft.Extensions.Localization;
using $manager.name.space$;
using $root.name.space$.Models;
$using$

namespace  $manager.name.space$ {
    internal class $name$Manager : $baseClass$, I$name$Manager {
        private readonly IStringLocalizer<$name$Manager> _localizer;
        private readonly IRepository<$name$, Guid> _$lname$Repository;
        private readonly ICompanyManager _companyManager;
        private readonly ICodeGenerator _codeGenerator;

        public $name$Manager(IRepository<$name$, Guid> $lname$Repository,
            ICodeGenerator codeGenerator,
            IStringLocalizer<$name$Manager> localizer, ICompanyManager companyManager) {
            _$lname$Repository = $lname$Repository;
            _localizer = localizer;
            _companyManager = companyManager;
            _codeGenerator=codeGenerator;
        }

        public void Abandon($name$ $lname$) {
            $lname$.Status = BaseDataStatus.作废;
            $lname$.AbandonerId = SdtSession.UserId;
            $lname$.AbandonerName = SdtSession.Name;
            $lname$.AbandonTime = DateTime.Now;
        }

        public void Create($name$ $lname$) {
            $lname$.Status = BaseDataStatus.生效;
            //$lname$.Code = _codeGenerator.Generate(""$name$"", $lname$.DealerCode);
            _$lname$Repository.Insert($lname$);
        }

        public void Update($name$ $lname$) {
        }
    }
}
";
    }
}