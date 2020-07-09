﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoCar.Data
{
    public class CustomerData : EntityData<Customer>
    {
        public Customer Get(int customerId)
        {
            SocarEntities context = CreateContext();
            return context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
        }

        public List<Customer> Search(int? customerId, int? age, string cellNumber, int? lisence)
        {
            SocarEntities context = CreateContext();

            var query = from x in context.Customers
                        select x;

            if (customerId.HasValue)
                query = query.Where(x => x.CustomerId == customerId);

            if (age.HasValue)
                query = query.Where(x => x.Age == age);

            if (string.IsNullOrEmpty(cellNumber) == false)
                query = query.Where(x => x.CellNumber.Contains(cellNumber));

            if (lisence.HasValue)
                query = query.Where(x => x.LisenceCode == lisence);


            return query.ToList();

        }
    }
}
