using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpAppGet : AbpAppBaseItem
    {
        private const string tpl = @"

        public async Task<Page<Get$name$sOutput>> Get$name$s(Get$name$sInput input, PageRequest page) {
            var query = Query(input);
            var count = await query.CountAsync();
            var result = await query.PageAndOrderBy(page).ToListAsync();
            return new Page<Get$name$sOutput>(page, count, _mapper.Map<List<Get$name$sOutput>>(result));
        }

        public IQueryable<$name$> Query(Get$name$sInput input) {
            var result = $_name$Repository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Code), r => r.Code.Contains(input.Code))
                .WhereIf(!string.IsNullOrEmpty(input.Name), r => r.Name.Contains(input.Name));
            return result;
        }
";

        public AbpAppGet(string modelName) : base(modelName)
        {
            _tpl = tpl;
            _tplInterface = "Task<Page<Get$name$sOutput>> Get$name$s(Get$name$sInput input, PageRequest page);";
        }
    }
}