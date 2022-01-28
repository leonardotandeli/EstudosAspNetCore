using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data {
    public class SeedingService {
        private SalesWebMVCContext _context;
        public SeedingService(SalesWebMVCContext context) {
            _context = context;
        }
        public void Seed() {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) {
                return; // DB Seeded
            }
            Department d1 = new Department(122, "Computers");
            Department d2 = new Department(33, "Eletronics");
            Department d3 = new Department(34, "Fashion");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", 1000.0, new DateTime(1998, 4, 21), d1);
            Seller s2 = new Seller(2, "Maria Dunca", "maria@gmail.com", 1200.0, new DateTime(1999, 2, 11), d2);
            Seller s3 = new Seller(3, "Ruby Amish", "ruby@gmail.com", 1200.0, new DateTime(1999, 2, 11), d3);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2020, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2020, 09, 25), 12000.0, SaleStatus.Billed, s1);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2021, 09, 25), 1000.0, SaleStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1, s2, s3);
            _context.SalesRecord.AddRange(r1, r2, r3);
            _context.SaveChanges();
        }
    }
}
