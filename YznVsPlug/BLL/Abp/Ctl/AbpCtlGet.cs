using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YznVsPlug.Utils;

namespace YznVsPlug.BLL
{
    internal class AbpCtlGet : AbpCtlBaseItem, IAbpCtlItem
    {
        private const string tpl = @"
        [HttpGet]
        public async Task<IActionResult> Get$name$s([FromQuery]Get$name$sInput input, [FromQuery]PageRequest page) {
            if (string.IsNullOrWhiteSpace(page.SortField)) {
                page.SortField = nameof(Get$name$sOutput.Code);
                page.IsDesc = false;
            }
            return Ok(ResponseBody.From(await $_name$Service.Get$name$s(input, page)));
        }
";

        public AbpCtlGet(string modelName) : base(modelName)
        {
            _dtos.Add($"Get{Name}sOutput");
            _dtos.Add($"Get{Name}sInput");
            _tpl = tpl;
        }

        public override IAbpAppItem ToAppItem()
        {
            return new AbpAppGet(Name);
        }
    }
}