using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Model.Connection.SQLServer
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //Tên dbset phải giống hệt trong sqlserver
        public DbSet<QuyenModel> Quyen { get; set; }
        public DbSet<PhanquyenModel> PhanQuyen { get; set; }
        public DbSet<ChucnangModel> ChucNang { get; set; }
        public DbSet<QuyenSudungChucnangModel> QuyenSudungChucnang { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<QuyenSudungChucnangModel>().HasKey(i => new { i.quyen_id, i.chucnang_id });
        }
    }
}
