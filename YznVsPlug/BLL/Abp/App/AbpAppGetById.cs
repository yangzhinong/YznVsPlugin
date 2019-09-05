using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpAppGetById : AbpAppBaseItem
    {
        private const string tpl = @"

        public Get$name$ByIdOutput Get$name$ById(Guid id) {
            var $lname$ = $_name$Repository.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<Get$name$ByIdOutput>($lname$);
        }
";

        public AbpAppGetById(string modelName) : base(modelName)
        {
            _tpl = tpl;
            _tplInterface = "Get$name$ByIdOutput Get$name$ById(Guid id);";
        }
    }
}