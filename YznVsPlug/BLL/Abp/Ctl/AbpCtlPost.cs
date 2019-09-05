using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpCtlPost : AbpCtlBaseItem
    {
        private const string tpl = @"
        /// <summary>
        /// 新增
        /// </summary>
        /// <param $name$=""input""></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert$name$([FromBody] Post$name$Input input)
        {
            $_name$Service.Create$name$(input);
            return Ok(new { Message = _localizer[""新增成功""].Value });
        }
";

        public AbpCtlPost(string modelName) : base(modelName)
        {
            _dtos.Add($"Post{Name}Input");
            _tpl = tpl;
        }

        public override IAbpAppItem ToAppItem()
        {
            return new AbpAppPost(Name);
        }
    }
}