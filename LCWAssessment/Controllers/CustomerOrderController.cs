using LCWAssessment.Data.Services;
using LCWAssessment.Global.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LCWAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrder _customerOrder;

        public CustomerOrderController(ICustomerOrder customerOrder)
        {
            _customerOrder = customerOrder;
        }


        [HttpGet]
        [Route("GetCustomerOrders")]
        public Result<CustomerOrderResponse> GetCustomerOrder(int CustomerOrderId)
        {
            return _customerOrder.GetCustomerOrder(CustomerOrderId);
        }


        [HttpPost]
        [Route("AddCustomerOrder")]
        public Result<int> CustomerOrderAdd(CustomerOrderAddRequest customerOrderAddRequest)
        {
            return _customerOrder.AddCustomerOrder(customerOrderAddRequest);   
        }


        [HttpPost]
        [Route("UpdateCustomerOrder")]
        public Result<bool> CustomerOrderUpdate(CustomerOrderUpdateRequest customerOrderUpdateRequest)
        {
            return _customerOrder.UpdateCustomerOrder(customerOrderUpdateRequest);
        }

        [HttpDelete]
        [Route("DeleteCustomerOrder")]
        public Result<bool> CustomerOrderDelete(int orderNumber)
        {
            return _customerOrder.DeleteCustomerOrder(orderNumber);
        }




    }
}
