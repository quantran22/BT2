using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LTQL.Models
{
    public class LamTrinhQuanLyDBContext: DbContext
    {
        public LamTrinhQuanLyDBContext() : base("LamTrinhQuanLyDBContext")
        {
        }
//anh xa cac doi tuong vao trong database
        public DbSet<Student>  Students{ get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
//DESKTOP-PN40B58\SQLEXPRESS