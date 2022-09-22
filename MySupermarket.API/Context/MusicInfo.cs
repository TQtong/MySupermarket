using System.ComponentModel.DataAnnotations.Schema;

namespace MySupermarket.API.Context
{
    /// <summary>
    /// 歌曲信息表
    /// </summary>
    [Table("musicinfo")]
    public class MusicInfo : BaseEntity
    {
        [Column("songname")]
        public string SongName { get; set; }

        [Column("singername")]
        public string SingerName { get; set; }

        [Column("songalbum")]
        public string SongAlbum { get; set; }

        [Column("songtime")]
        public string SongTime { get; set; }

        [Column("singpath")]
        public string SingPath { get; set; }
    }
}
