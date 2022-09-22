using System.ComponentModel.DataAnnotations.Schema;

namespace MySupermarket.API.Context
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("user")]
    public class User : BaseEntity
    {
        [Column("account")]
        public string Account { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("password")]
        public string Password { get; set; }

    }
}
