using System;

namespace Shop.Domain.DataAccess.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public DateTime CreationPost { get; set; }=DateTime.Now;
        public string Name { get; set; }

        public string Body { get; set; }
    }
}