using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcOnlineTicari_Otomasyon.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoicePen> InvoicePens { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesAct> SalesActs { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }

    }
}