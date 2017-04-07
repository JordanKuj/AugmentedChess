using Chess.BoardWatch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chess.BoardWatch.Tools
{
    public interface ICfgTool<T> where T : class, new()
    {
        void WriteCfg(T cfg);
        T ReadCfg();
    }


    public class CfgUtility : CfgBase<MasterCfg>
    {
        public CfgUtility()
        {
            FileName = "Cfg.xml";
        }
    }

    public abstract class CfgBase<T> : ICfgTool<T> where T : class, new()
    {
        protected string FileName;

        public void WriteCfg(T cfg)
        {
            var ser = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(FileName, FileMode.Create))
            {
                ser.Serialize(stream, cfg);
            }
        }
        public T ReadCfg()
        {
            if (!File.Exists(FileName))
            {
                WriteCfg(new T());
            }

            T obj;
            var ser = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(FileName, FileMode.Open))
            {
                obj = (T)ser.Deserialize(stream);
            }
            return obj;
        }
    }
}
