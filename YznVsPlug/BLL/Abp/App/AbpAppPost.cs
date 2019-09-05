using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpAppPost : AbpAppBaseItem
    {
        private const string tpl = @"

        public void Create$name$(Post$name$Input input) {
            var $lname$ = _mapper.Map<$name$>(input);
            $_name$Manager.Create($lname$);
        }
";

        public AbpAppPost(string modelName) : base(modelName)
        {
            _tpl = tpl;
            _tplInterface = "void Create$name$(Post$name$Input input);";
        }
    }
}