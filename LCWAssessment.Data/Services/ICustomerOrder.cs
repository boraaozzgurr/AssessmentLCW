using LCWAssessment.Global.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace LCWAssessment.Data.Services
{
    public interface ICustomerOrder
    {
        Result<CustomerOrderResponse> GetCustomerOrder(int customerOrderId);
        Result<int> AddCustomerOrder(CustomerOrderAddRequest customerOrderAddRequest);
        Result<bool> UpdateCustomerOrder(CustomerOrderUpdateRequest customerOrderUpdateRequest);
        Result<bool> DeleteCustomerOrder(int customerOrderId);
    }
}
