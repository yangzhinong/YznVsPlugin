using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpCtlImport : AbpCtlBaseItem
    {
        private const string tpl = @"

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name=""file""></param>
        /// <param name=""filesService""></param>
        /// <param name=""excelService""></param>
        /// <returns></returns>
        [HttpPost(""warrantyType/import"")]
        public async Task<IActionResult> Import([FromForm(Name = ""file"")]IFormFile file, [FromServices] IFilesService filesService) {
            var partInfo = filesService.TakeExcelInfo<Import$name$Input>(file);
            await $_name$Service.ImportAsync(partInfo.ToDictionary(i => i.RowNumber));
            filesService.ThrowWhenHaveError(partInfo, file.FileName);
            return Ok(new { Message =  _localizer[""成功""].Value});
        }
";

        public AbpCtlImport(string modelName) : base(modelName)
        {
            _tpl = tpl;
            _dtos.Add($"Import{modelName}Input");
        }

        public override IAbpAppItem ToAppItem()
        {
            return new AbpAppImport(Name);
        }
    }
}