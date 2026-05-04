using Health_App.Common.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_App.Models
{
    public class Friends : IEntity
    {
        public Guid id { get; set; }
        public Guid userId { get; set; }
        public Guid friendId { get; set; }

        [ForeignKey("userId")]
        public User user { get; set; }

        [ForeignKey("friendId")]
        public User friend { get; set; }
    }
}
