using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using Chess.BoardWatch.Models;
using Chess.BoardWatch.UI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BoardWatch.Tools
{



    public class BoardWatchService
    {
        public readonly BoardTools _bt;//; = new BoardTools();
        VideoCaptureDevice stream;
        private readonly IGlyphTools _gt;
        Task ProcessingImage;

        public event Action<UnmanagedImage> NewRawFrame;
        public event Action<ChannelData> NewBlueData;
        public event Action<ChannelData> NewRedFrame;
        private readonly MonikerSelector _selectorDilg;

        public BoardWatchService(IGlyphTools gt, BoardTools bt, MonikerSelector selectorDilg)
        {
            _gt = gt;
            _bt = bt;
            _selectorDilg = selectorDilg;
            Initalize();
        }
        private bool Stopped = false;
        internal void Stop()
        {
            Stopped = true;
            stream.Stop();
            stream.NewFrame -= Stream_NewFrame;
        }

        private void Initalize()
        {
            stream = new VideoCaptureDevice();
            FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            int deviceChoice;
            _selectorDilg.SetDevices(devices);
            if (_selectorDilg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                deviceChoice = _selectorDilg.Choice;
            else
                throw new Exception();


            stream = new VideoCaptureDevice(devices[deviceChoice].MonikerString);
            var c = new VideoCapabilities[stream.VideoCapabilities.Length];
            var capabilities = new List<VideoCapabilities>(c);
            stream.VideoCapabilities.CopyTo(c, 0);
            var vidres = c[0];
            stream.VideoResolution = vidres;
            stream.NewFrame += Stream_NewFrame;
            stream.Start();
        }
        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            NewRawFrame?.Invoke(UnmanagedImage.FromManagedImage(eventArgs.Frame));
            if (!Stopped && (ProcessingImage == null || ProcessingImage.IsCompleted))
                ProcessingImage = ProcessImage((Bitmap)eventArgs.Frame.Clone());
        }

        private async Task ProcessImage(Bitmap origional)
        {
            await _gt.ProcessImage(origional);
            if (!Stopped)
            {
                NewBlueData?.Invoke(new ChannelData(_gt.BImage, _gt.edgeB, _gt.threshB, _gt.Bblobs));
                NewRedFrame?.Invoke(new ChannelData(_gt.RImage, _gt.edgeR, _gt.threshR, _gt.Rblobs));
                _bt.UpdateCurrentState(_gt.Bblobs, _gt.Rblobs, new Rectangle(0, 0, origional.Width, origional.Height));
            }
        }
    }

    public class ChannelData
    {
        public ChannelData(UnmanagedImage maskImage, UnmanagedImage edgeImage, UnmanagedImage thresImag, IList<BlobData> blobData)
        {
            MaskImage = maskImage;
            EdgeImage = edgeImage;
            ThresImage = thresImag;
            BlobData = blobData;
        }
        public UnmanagedImage MaskImage { get; }
        public UnmanagedImage EdgeImage { get; }
        public UnmanagedImage ThresImage { get; }
        public IList<BlobData> BlobData { get; }
    }
}
