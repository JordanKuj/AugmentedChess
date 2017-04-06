using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Chess.BoardWatch.Models;

namespace Chess.BoardWatch.Tools
{
    public class Bindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ICfgTool<MasterCfg>>().To<CfgUtility>();
            Bind<IGlyphTools>().To<GlyphTools>().InSingletonScope();
            //Bind<SettingsForm>().To<SettingsForm>();
        }
    }
}
