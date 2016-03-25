using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marauder.DAL.Models;

namespace Marauder.BLL.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<CartViewModel> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
