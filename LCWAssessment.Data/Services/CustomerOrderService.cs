using LCWAssessment.Data.EF;
using LCWAssessment.Global.Model;
using LCWAssessment.Global.Request;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCWAssessment.Data.Services
{
    public class CustomerOrderService : ICustomerOrder
    {
        private readonly LCWDbContext _customerOrderService;


        public CustomerOrderService(LCWDbContext customerOrderService)
        {
            _customerOrderService = customerOrderService;
        }


        public Result<CustomerOrderResponse> GetCustomerOrder(int customerOrderId)
        {
            using (_customerOrderService)
            {
                try
                {
                    if(_customerOrderService.CustomerOrders.FirstOrDefault(x=> x.OrderNumber == customerOrderId && x.Status == 1) == null)
                        return new Result<CustomerOrderResponse> { Data = null, IsSuccess = true, Message = "Order Not Found"};


                    var orderList = _customerOrderService.CustomerOrderDetails.Where(x => x.CustomerOrderId == customerOrderId && x.Status == 1).ToList();

                    CustomerOrderResponse response = new CustomerOrderResponse { CustomerOrderList = orderList };

                    return new Result<CustomerOrderResponse> { Data = response, IsSuccess = true, Message = "OrderInformation" };
                }
                catch (Exception ex)
                {
                    return new Result<CustomerOrderResponse> { Data = null, IsSuccess = false, Message = $"Unexpected Error Occurred {ex.Message}" };
                }

            }
        }
        public Result<int> AddCustomerOrder(CustomerOrderAddRequest customerOrder)
        {
            using (_customerOrderService)
            {
                try
                {
                    CustomerOrder customerOrderData = new CustomerOrder
                    {
                        CustomerId = customerOrder.CustomerId,
                        OrderStatus = 1,
                    };

                    _customerOrderService.CustomerOrders.Add(customerOrderData);

                    _customerOrderService.SaveChanges();

                    int id = customerOrderData.OrderNumber;

                    if(id > 0)
                    {
                        foreach (var item in customerOrder.OrderDetailList)
                        {
                            var request = new CustomerOrderDetail
                            {
                                CustomerOrderId = id,
                                Barcode = item.Barcode,
                                Price = item.Price,
                                Quantity = item.Quantity,  
                            };
                            _customerOrderService.CustomerOrderDetails.Add(request);
                        }

                        _customerOrderService.SaveChanges();


                        return new Result<int> { Data = id, IsSuccess = true, Message = "OrderAddition Process Successfully Ended"};
                    }

                    return new Result<int> { Data = -1 , IsSuccess = false , Message = "Added Process Failed"};
                }
                catch (Exception ex)
                {
                    return new Result<int> { Data = -1, IsSuccess = false, Message = $"Unexpected Service Error {ex.Message}"};
                }
            }          


        }
        public Result<bool> DeleteCustomerOrder(int customerOrderId)
        {
            using (_customerOrderService)
            {
                try
                {
                    var order = _customerOrderService.CustomerOrders.Find(customerOrderId);

                    if (order == null)
                        return  new Result<bool> { Data  = false , IsSuccess = false , Message = "Order Not Found"};

                    order.Status = 0; //DeletedStatus
                    order.UpdateDate = DateTime.Now;
                    order.UpdateUser = Environment.MachineName;

                    var result = _customerOrderService.SaveChanges();

                    if (result == 0)
                        return new Result<bool> { Data = true, IsSuccess = true, Message = "Deletion Failed"};

                    return new Result<bool> { Data = true, IsSuccess = true, Message = "Deletion Successfully Ended"};
                }
                catch (Exception ex)
                {
                    return new Result<bool> { Data = false, IsSuccess = false, Message = $"Unexpected Service Error {ex.Message}"};
                }
            }
        }
        public Result<bool> UpdateCustomerOrder(CustomerOrderUpdateRequest request)
        {
            using (_customerOrderService)
            {
                try
                {
                    var customer = _customerOrderService.Customers.Find(request.CustomerId);

                    if (customer == null)
                        return new Result<bool> { Data = false , IsSuccess = false , Message = "Customer Not Found"};
                    
                    if(customer.Address != request.CustomerAddress)
                    {
                        customer.Address = request.CustomerAddress;
                        customer.UpdateDate = DateTime.Now;
                        customer.UpdateUser = Environment.MachineName;
                    } 
                    
                    var orderDetails = _customerOrderService.CustomerOrderDetails.Where(x=> x.CustomerOrderId == request.CustomerOrderId).ToList();

                    if (orderDetails != null && orderDetails.Count > 0)
                        orderDetails.ForEach(x => x.Status = 0);


                    if(request.OrderDetailList != null && request.OrderDetailList.Count > 0)
                    {
                        List<CustomerOrderDetail> orderDetailList = new List<CustomerOrderDetail>();

                        foreach (var orderDetail in request.OrderDetailList)
                        {
                            orderDetailList.Add(new CustomerOrderDetail
                            {
                                CustomerOrderId = request.CustomerOrderId,
                                Price = orderDetail.Price,
                                Barcode = orderDetail.Barcode,
                                Quantity = orderDetail.Quantity,
                            });
                        }
                        _customerOrderService.CustomerOrderDetails.AddRange(orderDetailList);
                    }

                    var result = _customerOrderService.SaveChanges();

                    if (result == 0)
                        return new Result<bool> { Data = true, IsSuccess = true, Message = "Update Failed"};

                    return new Result<bool> { Data = true, IsSuccess = true, Message = "Update Successfully Ended"};

                }
                catch (Exception ex)
                {
                    return new Result<bool> { Data = false, IsSuccess = false, Message = $"CustomerOrderUpdate Failed {ex.Message}"};
                }
            }
        }             
    }
}
