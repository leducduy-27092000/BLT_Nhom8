using BTL_Nhom8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Nhom8.Dto
{
    public class CustomerDto
    {
        public string Customer_Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public CustomerDto() { }

        public CustomerDto(Account acc)
        {
            this.Customer_Name = acc.Customer_Name;
            this.Address = acc.Address;
            this.Telephone = acc.Telephone;
            this.Email = acc.Email;
        }
    }
}