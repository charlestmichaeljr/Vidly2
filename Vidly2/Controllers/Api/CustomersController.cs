using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDTO>);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
            //return Mapper.Map<Customer,CustomerDTO> (customer);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            var customer = Mapper.Map<CustomerDTO,Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto) ;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}