using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpAppExport : AbpAppBaseItem
    {
        private const string tpl = @"

        public async Task<List<Export$name$Output>> Export$name$s(Get$name$sInput input) {
            var $lname$s = _$lname$Repository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Code), p => p.Code.Contains(input.Code))
                .WhereIf(!string.IsNullOrWhiteSpace(input.Name), p => p.Name.Contains(input.Name));
            return _mapper.Map<List<Export$name$Output>>(await $lname$s.ToListAsync());
        }
";

        public AbpAppExport(string modelName) : base(modelName)
        {
            _tpl = tpl;
            _tplInterface = "Task<List<Export$name$Output>> Export$name$s(Get$name$sInput input);";
        }
    }
}