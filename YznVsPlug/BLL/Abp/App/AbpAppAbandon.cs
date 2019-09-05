using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpAppAbandon : AbpAppBaseItem
    {
        private const string tpl = @"

        public void Abandon$name$(Guid id, RowVersionBody input) {
            var $lname$ = _$lname$Repository.GetAll()
                                            .FirstOrDefault(x => x.Id == id &&
                                                                 x.Status == BaseDataStatus.生效);
            if ($lname$ == null) {
                throw new ValidationException(_localizer[""$name$NotFound""].Value);
            }
            $lname$.DbUpdateConcurrencyCheck(input.RowVersion);
            _$lname$Manager.Abandon($lname$);
        }
";

        public AbpAppAbandon(string modelName) : base(modelName)
        {
            _tpl = tpl;
            _tplInterface = "void Abandon$name$(Guid id, RowVersionBody input);";
        }
    }
}