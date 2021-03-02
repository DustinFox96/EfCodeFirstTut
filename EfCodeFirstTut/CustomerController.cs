using EfCodeFirstTut.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstTut {
    public class CustomerController {
        private readonly AppDbContext _context;

        public async Task<IEnumerable <Customer>> Getall() {
            return await _context.Customers.ToArrayAsync();
        }

        public async Task<Customer> GetByPk(int id) {
            return await _context.Customers.FindAsync(id);

        }

        public async Task<Customer> Create(Customer customer) {
                if(customer == null) {
                throw new Exception("customer cannot be null");
                }
                if(customer.Id != 0) {
                throw new Exception("Customer Id must be zero");
                }
            customer.Created = DateTime.Now;
            _context.Customers.Add(customer);
            var rowsAffect = await _context.SaveChangesAsync();// it's important to remember to do SaveChanges 
            if (rowsAffect != 1) {
                throw new Exception("Create failed!");
            }
            return customer;
        }

        public async Task<Customer> Change(Customer customer) {
            if(customer == null) {
                throw new Exception("Customer cannot be null");
            }
            if(customer.Id <= 0) {
                throw new Exception("Id must be greater than zero");
            }
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffect = await _context.SaveChangesAsync();
            if(rowsAffect != 1) {
                throw new Exception("Changed failed");
            }
            return customer;
        }

        public async Task<Customer> Remove(int id) {
            var customer = _context.Customers.Find(id);
            if(customer == null) {
                return null;
            }
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected != 1) {
                throw new Exception("remove failed");
            }
            return customer;
        }

        










            public CustomerController() {
            _context = new AppDbContext();
            }
    }
}
