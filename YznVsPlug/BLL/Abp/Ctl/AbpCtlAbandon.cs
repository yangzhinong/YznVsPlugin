using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpCtlAbandon : AbpCtlBaseItem
    {
        private const string tpl = @"

        [HttpPut(""{id}""/abandon)]
        public IActionResult Abandon$name$(Guid id, [FromBody] RowVersionBody input) {
            $_name$Service.Abandon$name$(id, input);
            return Ok(new { Message = _localizer[""成功""].Value });
        }
";

        public AbpCtlAbandon(string modelName) : base(modelName)
        {
            _tpl = tpl;
        }

        public override IAbpAppItem ToAppItem()
        {
            return new AbpAppAbandon(Name);
        }
    }
}