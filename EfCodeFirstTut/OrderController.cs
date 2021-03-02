using EfCodeFirstTut.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstTut {
   public class OrderController {
        private readonly AppDbContext _context;

        public async Task<IEnumerable<Order>> GetAll() {
            return await _context.orders.ToArrayAsync();
        }

        public async Task<Order> GetByPk(int id) {
            return await _context.orders.FindAsync();
        }

        public async Task<Order> Create(Order order) {
            if (order == null) {
                throw new Exception("Order cannot be null");
            }
            if (order.Id != 0) {
                throw new Exception("Order Id must be zero");
            }
            _context.orders.Add(order);
            var rowsAffect = await _context.SaveChangesAsync();// it's important to remember to do SaveChanges 
            if (rowsAffect != 1) {
                throw new Exception("Create failed!");
            }
            return order;
        }

        public async Task<Order> Change(Order order) {
            if (order == null) {
                throw new Exception("Order cannot be null");
            }
            if (order.Id <= 0) {
                throw new Exception("Id must be greater than zero");
            }
            _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffect = await _context.SaveChangesAsync();
            if (rowsAffect != 1) {
                throw new Exception("Changed failed");
            }
            return order;
        }

        public async Task<Order> Remove(int id) {
            var order = _context.orders.Find(id);
            if (order == null) {
                return null;
            }
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("remove failed");
            }
            return order;
        }




        public OrderController() {
            _context = new AppDbContext();
        }

    }
}
