using EfCodeFirstTut.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstTut {
   public class OrderlineController {
        private readonly AppDbContext _context;

        public async Task<IEnumerable<Orderline>> GetAll() {
            return await _context.orderlines.ToArrayAsync();
        }

        public async Task<Orderline> GetByPk(int id) {
            return await _context.orderlines.FindAsync();
        }

        public async Task<Orderline> Create(Orderline orderline) {
            if (orderline == null) {
                throw new Exception("Orderline cannot be null");
            }
            if (orderline.Id != 0) {
                throw new Exception("Item Id must be zero");
            }
            _context.orderlines.Add(orderline);
            var rowsAffect = await _context.SaveChangesAsync();// it's important to remember to do SaveChanges 
            if (rowsAffect != 1) {
                throw new Exception("Create failed!");
            }
            return orderline;
        }

        public async Task<Orderline> Change(Orderline orderline) {
            if (orderline == null) {
                throw new Exception("Item cannot be null");
            }
            if (orderline.Id <= 0) {
                throw new Exception("Id must be greater than zero");
            }
            _context.Entry(orderline).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffect = await _context.SaveChangesAsync();
            if (rowsAffect != 1) {
                throw new Exception("Changed failed");
            }
            return orderline;
        }

        public async Task<Orderline> Remove(int id) {
            var orderline = _context.orderlines.Find(id);
            if (orderline == null) {
                return null;
            }
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("remove failed");
            }
            return orderline;
        }


        public OrderlineController() {
            _context = new AppDbContext();
        }
    }
}
