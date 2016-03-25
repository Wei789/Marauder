using Marauder.DAL.Models;
using System;

namespace Marauder.BLL.ViewModels
{
    public class CartViewModel
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Album Album { get; set; }
    }
}
