using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpCtlGetById : AbpCtlBaseItem
    {
        private const string tpl = @"
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name=""id""></param>
        /// <returns></returns>
        [HttpGet(""{id}"")]
        public IActionResult Get$name$ById(Guid id) {
            return Ok(ResponseBody.From($_name$Service.Get$name$ById(id)));
        }
";

        public AbpCtlGetById(string modelName) : base(modelName)
        {
            _dtos.Add($"Get{Name}ByIdOutput");
            _tpl = tpl;
        }

        public override IAbpAppItem ToAppItem()
        {
            return new AbpAppGetById(Name);
        }
    }
}