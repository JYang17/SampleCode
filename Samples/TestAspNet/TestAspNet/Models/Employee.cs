using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TestAspNet.Models
{
    public class Employee
    {
        [StringLength(15)]
        public string Name { get; set; }

        [Key]
        public int EmployeeId { get; set; }

        [StringLength(6)]
        public string Sex { get; set; }
    }

    /// <summary>
    /// represents the Entity Framework employee database context, which handles fetching, storing, and updating Movie class instances in a database
    /// </summary>
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}