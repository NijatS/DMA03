﻿using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
	public class Product :BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public ProductCategory Category { get; set; }
		public Restaurant Restaurant { get; set; }

		public override string ToString()
		{
			return $"ID: {Id}  Name: {Name}, Category: {Category}, Price: ${Price}, Restaurant name: {Restaurant.Name}";
		}
	}
}
