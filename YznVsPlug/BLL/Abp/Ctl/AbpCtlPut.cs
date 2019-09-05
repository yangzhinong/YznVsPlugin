using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpCtlPut : AbpCtlBaseItem
    {
        private const string tpl = @"
        /// <summary>
        /// 修改
        /// </summary>
        /// <param $name$=""id""></param>
        /// <param $name$=""input""></param>
        /// <returns></returns>
        [HttpPut(""{id}"")]
        public IActionResult Update$name$(Guid id, [FromBody] Put$name$Input input) {
            $_name$Service.Update$name$(id, input);
            return Ok(new { Message = _localizer[""修改成功""].Value });
        }
";

        public AbpCtlPut(string modelName) : base(modelName)
        {
            _dtos.Add($"Put{Name}Input");
            _tpl = tpl;
        }

        public override IAbpAppItem ToAppItem()
        {
            return new AbpAppPut(Name);
        }
    }
}