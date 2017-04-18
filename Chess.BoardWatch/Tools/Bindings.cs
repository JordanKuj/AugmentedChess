using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Chess.BoardWatch.Models;
using Chess.BoardWatch.UI.Forms;
using Chess.BoardWatch.Factories;

namespace Chess.BoardWatch.Tools
{
    public class Bindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<MonikerSelector>().ToSelf();
            Bind<ICfgTool<MasterCfg>>().To<CfgUtility>();
            Bind<IGlyphTools>().To<GlyphTools>().InSingletonScope();
            Bind<BoardTools>().ToSelf().InSingletonScope();
            Bind<BoardWatchService>().ToSelf().InSingletonScope();
            Bind<SettingsForm>().To<SettingsForm>();
            Bind<BoardView>().ToSelf();
            Bind<Form1>().ToSelf();

            Bind<IFactory<MonikerSelector>>().To<CamSelectorFactory>();
            Bind<IFactory<SettingsForm>>().To<SettingsViewFactory>();
            Bind<IFactory<BoardView>>().To<BoardViewFactory>();
            Bind<IFactory<Form1>>().To<Form1ViewFactory>();

        }
    }
}
