using System.ComponentModel.DataAnnotations;

namespace FirstCoreAppDemo.Models
{
    public class MaterialEntity : IMasterData
    {
        public int Id { get; set; }

        [StringLength(128), Required, Display(Name= "物料编码")]
        public string Code { get; set; }

        [StringLength(256), Required, Display(Name = "物料简称")]
        public string Name { get; set; }

        [StringLength(256), Required, Display(Name = "物料全称")]
        public string FullName { get; set; }

        [StringLength(128), Display(Name = "上级物料编码")]
        public string ParentCode { get; set; }
    }

    public interface IMasterData
    {
        string Code { get; set; }
        string ParentCode { get; set; }
    }
}
