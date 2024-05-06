using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models.BaseModel
{
	public abstract class BaseEntity
	{
		public readonly int Id;
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		private static int _count;
        public BaseEntity()
        {
			_count++;
			Id = _count;
        }
    }
}
