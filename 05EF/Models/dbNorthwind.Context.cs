﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _05EF.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class 北風Entities : DbContext
    {
        public 北風Entities()
            : base("name=北風Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<供應商> 供應商 { get; set; }
        public virtual DbSet<客戶> 客戶 { get; set; }
        public virtual DbSet<訂貨主檔> 訂貨主檔 { get; set; }
        public virtual DbSet<訂貨明細> 訂貨明細 { get; set; }
        public virtual DbSet<員工> 員工 { get; set; }
        public virtual DbSet<產品資料> 產品資料 { get; set; }
        public virtual DbSet<產品類別> 產品類別 { get; set; }
        public virtual DbSet<貨運公司> 貨運公司 { get; set; }
    }
}
