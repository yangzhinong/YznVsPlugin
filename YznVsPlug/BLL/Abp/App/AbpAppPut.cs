using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpAppPut : AbpAppBaseItem
    {
        private const string tpl = @"

        public void Update$name$(Guid id, Put$name$Input input) {
            var $lname$ = $_name$Repository.FirstOrDefault(x => x.Id == id &&
                                                                         x.Status == BaseDataStatus.生效);
            if ($lname$ == null) {
                throw new ValidationException(_localizer[""$name$NotFound""].Value);
            }
            //$lname$.DbUpdateConcurrencyCheck(input.RowVersion);
            _mapper.Map(input, $lname$);
            _$lname$Manager.Update($lname$);
        }
";

        public AbpAppPut(string modelName) : base(modelName)
        {
            _tpl = tpl;
            _tplInterface = "void Update$name$(Guid id, Put$name$Input input);";
        }
    }
}