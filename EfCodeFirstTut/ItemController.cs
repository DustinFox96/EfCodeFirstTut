using EfCodeFirstTut.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstTut {
   public class ItemController {
        private readonly AppDbContext _context;

        public async Task<IEnumerable<Item>> GetAll() {
            return await _context.items.ToArrayAsync();
        }

        public async Task<Item> GetByPk(int id) {
            return await _context.items.FindAsync();
        }

        public async Task<Item> Create(Item item) {
            if (item == null) {
                throw new Exception("Item cannot be null");
            }
            if (item.Id != 0) {
                throw new Exception("Item Id must be zero");
            }
            _context.items.Add(item);
            var rowsAffect = await _context.SaveChangesAsync();// it's important to remember to do SaveChanges 
            if (rowsAffect != 1) {
                throw new Exception("Create failed!");
            }
            return item;
        }

        public async Task<Item> Change(Item item) {
            if (item == null) {
                throw new Exception("Item cannot be null");
            }
            if (item.Id <= 0) {
                throw new Exception("Id must be greater than zero");
            }
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffect = await _context.SaveChangesAsync();
            if (rowsAffect != 1) {
                throw new Exception("Changed failed");
            }
            return item;
        }

        public async Task<Item> Remove(int id) {
            var item = _context.items.Find(id);
            if (item == null) {
                return null;
            }
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("remove failed");
            }
            return item;
        }




        public ItemController() {
            _context = new AppDbContext();
        }

    }


}

