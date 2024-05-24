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
        public async Task AddAsync()
		{
            Console.WriteLine("Add customer Id:");
			int.TryParse(Console.ReadLine(), out int id);
			Customer customer = await _customerRepository.GetByIdAsync(id);

			Order order = new Order();

			order.Customer = customer;
			order.Status = (OrderStatus)5;
			order.CreatedDate = DateTime.Now;

			await AddOrderProducts(order);

			await _orderRepository.AddAsync(order);
        }

		public async Task ChangeStatusAsync()
		{
			Console.WriteLine("Enter the id of the order you want to change: ");
			int.TryParse(Console.ReadLine(), out int orderId);
			Order order =await _orderRepository.GetByIdAsync(orderId);
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
				await _orderRepository.UpdateAsync(order);
			}            
        }

		public async Task DeleteAsync()
		{
            Console.WriteLine("Enter id of the order you want to delete:");
			int.TryParse(Console.ReadLine(), out int id);
			
			Order order = await _orderRepository.GetByIdAsync(id);

            foreach (var orderProduct in order.OrderProducts)
            {
				Product product = orderProduct.Product;
				product.Stock += orderProduct.Count;
				product.UpdatedDate = DateTime.Now;
				await _productRepository.UpdateAsync(product);
				await _orderProductRepository.DeleteAsync(orderProduct.Id);
            }
          await  _orderRepository.DeleteAsync(id);
		}

		public async Task GetAsync()
		{
			Console.WriteLine("Enter id of the order you want to get:");
			int.TryParse(Console.ReadLine(), out int id);

			Order order = await _orderRepository.GetByIdAsync(id);
			await OrderDetailAsync(order);
        }

		public async Task GetAllAsync()
		{
            Console.WriteLine("Enter customer id:");
			int.TryParse(Console.ReadLine(), out int customerId);

			var customerOrders = (await _orderRepository.GetAllAsync()).Where(x=>x.Customer.Id==customerId).ToList();

            foreach (var customerOrder in customerOrders)
            {
				await OrderDetailAsync(customerOrder);
            }
        }

		public async Task UpdateAsync()
		{
            Console.Write("Enter the id of order you want to update:");
			int.TryParse(Console.ReadLine(),out int id);	

			Order order = await _orderRepository.GetByIdAsync(id);
			if(order != null)
			{
				List<OrderProduct> oldOrderProducts = order.OrderProducts;
				foreach (var orderProduct in oldOrderProducts)
				{
					await _orderProductRepository.DeleteAsync(orderProduct.Id);
					Product product = orderProduct.Product;

					product.Stock += orderProduct.Count;
					await _productRepository.UpdateAsync(product);
				}
				order.OrderProducts = new List<OrderProduct>();
				await AddOrderProducts(order);

				await _orderRepository.UpdateAsync(order);
			}

        }

		private async Task OrderDetailAsync(Order order)
		{
			Console.WriteLine("Customer name: " + order.Customer.Name);

			foreach (var orderProduct in order.OrderProducts)
			{
				Console.WriteLine(orderProduct.Product.Name + " : " + orderProduct.Count + "Total Price: " + orderProduct.Count * orderProduct.Product.Price);
			}
			double totalPrice = order.OrderProducts.Sum(x => x.Product.Price * x.Count);
			Console.WriteLine("Orders' total price: " + totalPrice);
		}


		private async Task AddOrderProducts(Order order)
		{
			bool isContinue = true;
			while (isContinue)
			{
				Console.WriteLine("Add product Id you want to add to the order:");
				int.TryParse(Console.ReadLine(), out int productId);
				Product product = await _productRepository.GetByIdAsync(productId);
				if (product != null)
				{
					Console.WriteLine("Enter the count:");
					int.TryParse(Console.ReadLine(), out int count);
					if (count <= product.Stock)
					{
						OrderProduct orderProduct = new OrderProduct()
						{
							Product = product,
							Count = count,
							Order = order,
							CreatedDate = DateTime.Now
						};
						order.OrderProducts.Add(orderProduct);
						await _orderProductRepository.AddAsync(orderProduct);

						product.Stock -= count;
						product.UpdatedDate = DateTime.Now;
						await _productRepository.UpdateAsync(product);
					}
				}
				Console.WriteLine("Do you want to continue? y / n");
				char.TryParse(Console.ReadLine(), out char answer);
				if (answer != 'y')
				{
					isContinue = false;
				}
			}
		}
	}
}
