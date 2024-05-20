using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Enums;
using Trendyol.Core.Models;
using Trendyol.Data.Repositories.Implementations;
using Trendyol.Data.Repositories.Interfaces;
using Trendyol.Service.Services.Interfaces;

namespace Trendyol.Service.Services.Implementations
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly ICustomerRepository _customerRepository;
		private readonly IOrderProductRepository _orderProductRepository;
		private readonly IProductRepository _productRepository;
        public OrderService()
        {
			_orderRepository = new OrderRepository();
			_customerRepository = new CustomerRepository();
			_orderProductRepository = new OrderProductRepository();
			_productRepository = new ProductRepository();
        }
        public void Add()
		{
            Console.WriteLine("Add customer Id:");
			int.TryParse(Console.ReadLine(), out int id);
			Customer customer = _customerRepository.GetById(id);


			Order order = new Order();
			order.Customer = customer;
			order.Status = (OrderStatus)5;
			order.CreatedDate = DateTime.Now;
			bool isContinue = true;
			while (isContinue)
			{
                Console.WriteLine("Add product Id you want to add to the order:");
				int.TryParse(Console.ReadLine(), out int productId);
				Product product = _productRepository.GetById(productId);
				if(product != null) {
					Console.WriteLine("Enter the count:");
					int.TryParse(Console.ReadLine(), out int count);
					if (count<=product.Stock)
					{
						OrderProduct orderProduct = new OrderProduct()
						{
							Product = product,
							Count = count,
							Order = order,
							CreatedDate = DateTime.Now
						};
						order.OrderProducts.Add(orderProduct);
						_orderProductRepository.Add(orderProduct);

						product.Stock -= count;
						product.UpdatedDate = DateTime.Now;
						_productRepository.Update(product);
					}
				}
                Console.WriteLine("Do you want to continue? y / n");
				char.TryParse(Console.ReadLine(), out char answer);
                if (answer != 'y')
				{
					isContinue = false;
				}
            } 
			_orderRepository.Add(order);
        }

		public void ChangeStatus()
		{
			Console.WriteLine("Enter the id of the order you want to change: ");
			int.TryParse(Console.ReadLine(), out int orderId);
			Order order = _orderRepository.GetById(orderId);
			if (order != null)
			{
				var orderEnums = Enum.GetValues(typeof(OrderStatus));
				foreach (var orderEnum in orderEnums)
				{
					Console.WriteLine((int)orderEnum + " " + orderEnum);
				}
                Console.WriteLine("Enter status number: ");
				int.TryParse(Console.ReadLine(), out int number);
				order.Status = (OrderStatus)number;
				order.UpdatedDate = DateTime.Now;
				_orderRepository.Update(order);
			}            
        }

		public void Delete()
		{
            Console.WriteLine("Enter id of the order you want to delete:");
			int.TryParse(Console.ReadLine(), out int id);
			
			Order order = _orderRepository.GetById(id);

            foreach (var orderProduct in order.OrderProducts)
            {
				Product product = orderProduct.Product;
				product.Stock += orderProduct.Count;
				product.UpdatedDate = DateTime.Now;
				_productRepository.Update(product);
				_orderProductRepository.Delete(orderProduct.Id);
            }
            _orderRepository.Delete(id);
		}

		public void Get()
		{
			Console.WriteLine("Enter id of the order you want to get:");
			int.TryParse(Console.ReadLine(), out int id);

			Order order = _orderRepository.GetById(id);
			OrderDetail(order);
        }

		public void GetAll()
		{
            Console.WriteLine("ENter customer id:");
			int.TryParse(Console.ReadLine(), out int customerId);

			var customerOrders = _orderRepository.GetAll().Where(x=>x.Customer.Id==customerId).ToList();

            foreach (var customerOrder in customerOrders)
            {
				OrderDetail(customerOrder);
            }
        }

		public void Update()
		{
            Console.WriteLine("Enter the id of order you want to update:");

        }

		private void OrderDetail(Order order)
		{
			Console.WriteLine("Customer name: " + order.Customer.Name);

			foreach (var orderProduct in order.OrderProducts)
			{
				Console.WriteLine(orderProduct.Product.Name + " : " + orderProduct.Count + "Total Price: " + orderProduct.Count * orderProduct.Product.Price);
			}
			double totalPrice = order.OrderProducts.Sum(x => x.Product.Price * x.Count);
			Console.WriteLine("Orders' total price: " + totalPrice);
		}
	}
}
