using System.ComponentModel.DataAnnotations;

namespace FirstCoreAppDemo.Models
{
    public class MaterialEntity
    {
        public int Id { get; set; }

        [StringLength(6), Required]
        public string Code { get; set; }

        [StringLength(128), Required]
        public string FullCode { get; set; }

        [StringLength(256), Required]
        public string Name { get; set; }

        [StringLength(256), Required]
        public string FullName { get; set; }

        [Required]
        public Unit Unit { get; set; }

        public int? PId { get; set; }

        /// <summary>
        /// 是否为条目，而不是分类
        /// </summary>
        public bool IsItem
        {
            get
            {
                return Code.Length == FullCode.Length && string.Equals(Code, FullCode);
            }
        }
    }
}
