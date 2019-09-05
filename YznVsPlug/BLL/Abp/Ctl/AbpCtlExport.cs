using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpCtlExport : AbpCtlBaseItem
    {
        private const string tpl = @"

        /// <summary>
        /// 导出列表
        /// </summary>
        /// <returns></returns>
        [HttpGet(""export"")]
        public async Task<IActionResult> Export$name$s([FromServices]IFilesService filesService, [FromQuery]Get$name$sInput input) {
            var result = await $_name$Service.Export$name$s(input);
            var fileName = _localizer[""$name$""].Value + "".xlsx"";
            return Ok(ResponseBody.From<string>(await filesService.SaveToExcelAsync(result, fileName)));
        }
";

        public AbpCtlExport(string modelName) : base(modelName)
        {
            _tpl = tpl;
            _dtos.Add($"Export{modelName}Output");
        }

        public override IAbpAppItem ToAppItem()
        {
            return new AbpAppExport(Name);
        }
    }
}