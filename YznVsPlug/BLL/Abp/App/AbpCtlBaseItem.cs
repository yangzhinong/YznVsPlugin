using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YznVsPlug.Utils;

namespace YznVsPlug.BLL
{
    internal abstract class AbpAppBaseItem : IAbpAppItem
    {
        public AbpAppBaseItem(string modelName)
        {
            _lname = modelName.ToFirstLettleLcase();
            _underLineName = modelName.ToUnderLineStringcase();
            _name = modelName.ToFirstLettleUpcase();
        }

        private string _lname;
        private string _name;
        private string _underLineName;
        public string LName { get => _lname; }
        public string UnderLineName { get => _underLineName; }
        public string Name { get => _name; }
        protected string _tpl;
        protected string _tplInterface;

        public virtual string GetText()
        {
            return _tpl.Replace("$name$", Name)
                      .Replace("$_name$", UnderLineName)
                      .Replace("$lname$", LName);
        }

        public virtual string GetInterfaceText()
        {
            return _tplInterface.Replace("$name$", Name)
                                  .Replace("$_name$", UnderLineName)
                                  .Replace("$lname$", LName);
        }
    }
}