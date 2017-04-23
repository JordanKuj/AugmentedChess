using Chess.BoardWatch.UI.Forms;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch.Factories
{
    public interface IFactory<T> where T : class
    {
        T GetInstance();
    }

    public class CamSelectorFactory : IFactory<MonikerSelector>
    {
        public MonikerSelector GetInstance()
        {
            return new MonikerSelector();
        }
    }

    public class SettingsViewFactory : IFactory<SettingsForm>
    {

        private readonly IKernel _kernal;
        public SettingsViewFactory(IKernel kernal)
        {
            _kernal = kernal;
        }

        public SettingsForm GetInstance()
        {
            return _kernal.Get<SettingsForm>();
        }
    }

    public class BoardViewFactory : IFactory<BoardView>
    {

        private readonly IKernel _kernal;
        public BoardViewFactory(IKernel kernal)
        {
            _kernal = kernal;
        }

        public BoardView GetInstance()
        {
            return _kernal.Get<BoardView>();
        }
    }
    public class Form1ViewFactory : IFactory<Form1>
    {
        private readonly IKernel _kernal;
        public Form1ViewFactory(IKernel kernal)
        {
            _kernal = kernal;
        }

        public Form1 GetInstance()
        {
            return _kernal.Get<Form1>();
        }
    }

}
