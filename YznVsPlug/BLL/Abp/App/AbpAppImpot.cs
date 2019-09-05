using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    internal class AbpAppImport : AbpAppBaseItem
    {
        private const string tpl = @"

         public async Task ImportAsync(IReadOnlyDictionary<int, IRowInfo<Import$name$Input>> inputs) {
            foreach (var rowInfo in inputs.Values) {
            }
            await CurrentUnitOfWork.SaveChangesAsync();
        }
";

        public AbpAppImport(string modelName) : base(modelName)
        {
            _tpl = tpl;
            _tplInterface = "Task ImportAsync(IReadOnlyDictionary<int, IRowInfo<Import$name$Input>> inputs);";
        }
    }
}