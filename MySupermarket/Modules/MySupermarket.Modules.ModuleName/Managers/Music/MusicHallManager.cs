using MySupermarket.Core.Mvvm;
using MySupermarket.Core.Vo;
using MySupermarket.Modules.ModuleName.Service.Music;
using MySupermarket.Services.Interfaces.ViewModelInterfaces.Music;
using NAudio.Dsp;
using NAudio.Wave;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySupermarket.Modules.ModuleName.Managers.Music
{
    public class MusicHallManager : RegionViewModelBase, IMusicHallService
    {

        #region 属性
        public static MusicInfoVo SelectMusic { get; private set; }


        #endregion

        public const string WAVDirPath = @"C:\Users\TQ\Desktop\wav";

        private readonly IMusicInfoService service;

        public MusicHallManager(IRegionManager regionManager, IMusicInfoService service) : base(regionManager)
        {
            this.service = service;
        }

        public async Task<ObservableCollection<MusicInfoVo>> GetAllMusic()
        {
            ObservableCollection<MusicInfoVo> musicInfoVos = new ObservableCollection<MusicInfoVo>();
            var result = await service.GetAllAsync(new MySupermarket.Common.Parameter.QueryParameter());

            foreach (var item in result.Result.Items)
            {
                musicInfoVos.Add(new MusicInfoVo()
                {
                    SongName = item.SongName,
                    SingerName = item.SingerName,
                    SongAlbum = item.SongAlbum,
                    SongTime = item.SongTime
                });
            }

            return musicInfoVos;
        }

        public object CreateMusic()
        {
            ObservableCollection<MusicInfoVo> musicInfoVos = new ObservableCollection<MusicInfoVo>()
            {
                new MusicInfoVo()
                {
                    SingerName = "TQtong",
                    SongName = "哈哈哈",
                    SongAlbum = "Something",
                    SongTime = "3:40"
                },
            };

            return musicInfoVos;
        }

        public async Task<string> Play(object obj)
        {
            SelectMusic = (MusicInfoVo)obj;

            var result = await service.GetFirstOfDefaultAsync(SelectMusic.SongName);

            Mp3FileReader mp3File = new Mp3FileReader(result.Result.SongPath);
            //WaveFileWriter.CreateWaveFile(Path.Combine(WAVDirPath, $"{result.Result.SongName}.wav"), mp3File);//.mp3转换成.wav格式
            //FileInfo WavePath = new FileInfo(Path.Combine(WAVDirPath, $"{result.Result.SongName}.wav"));//读取wav文件
            WasapiLoopbackCapture cap = new WasapiLoopbackCapture();
            cap.DataAvailable += (s, args) =>
            {
                float[] samples = Enumerable
                                      .Range(0, args.BytesRecorded / 4)
                                      .Select(i => BitConverter.ToSingle(args.Buffer, i * 4))
                                      .ToArray();   // 获取采样

                int log = (int)Math.Ceiling(Math.Log(samples.Length, 2));
                float[] filledSamples = new float[(int)Math.Pow(2, log)];
                Array.Copy(samples, filledSamples, samples.Length);   // 填充数据

                int sampleRate = (s as WasapiLoopbackCapture).WaveFormat.SampleRate;    // 获取采样率
                Complex[] complexSrc = filledSamples.Select(v => new Complex() { X = v }).ToArray();  // 转换为复数
                FastFourierTransform.FFT(false, log, complexSrc);     // 进行傅里叶变换
                double[] result = complexSrc.Select(v => Math.Sqrt(v.X * v.X + v.Y * v.Y)).ToArray();    // 取得结果
            };

            return result.Result.SongPath;

        }
    }
}
