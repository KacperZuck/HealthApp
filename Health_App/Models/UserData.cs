using Health_App.Common.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_App.Models
{
    public class UserData : IEntity
    {
        public Guid id { get; set; }
        public Guid user_id { get; set; }
        public string name { get; set; }
        public int mesurment  { get; set; }
        public DateTime created_at {  get; set; }

        [ForeignKey("user_id")]
        public User user { get; set; }
    }
}
