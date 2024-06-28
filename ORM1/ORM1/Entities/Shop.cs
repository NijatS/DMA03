using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Entities.BaseEntities;

namespace Trendyol.App.Entities
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
    }
}
