using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Do;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Debt> Debts { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<RegularCustomer> RegularCustomers { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-S6K9TIS;Initial Catalog=debts_system;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__B611CB7DC5FAAA13");

            entity.ToTable("customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customerId");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerName");
        });

        modelBuilder.Entity<Debt>(entity =>
        {
            entity.HasKey(e => e.DebtsId).HasName("PK__debts__A8B8A7A2150106E6");

            entity.ToTable("debts");

            entity.Property(e => e.DebtsId).HasColumnName("debtsId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IsPaid).HasColumnName("isPaid");
            entity.Property(e => e.Notes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.PaymentType).HasColumnName("paymentType");
            entity.Property(e => e.SaleId).HasColumnName("saleId");
            entity.Property(e => e.SumOfDebts).HasColumnName("sumOfDebts");

            //entity.HasOne(d => d.Customer).WithMany(p => p.Debts)
            //    .HasForeignKey(d => d.CustomerId)
            //    .HasConstraintName("FK__debts__customerI__4222D4EF");

            //entity.HasOne(d => d.PaymentTypeNavigation).WithMany(p => p.Debts)
            //    .HasForeignKey(d => d.PaymentType)
            //    .HasConstraintName("FK__debts__paymentTy__440B1D61");

            entity.HasOne(d => d.Sale).WithMany(p => p.Debts)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__debts__saleId__4316F928");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.PaymentCode).HasName("PK__paymentT__B5D907FA7BC5B257");

            entity.ToTable("paymentType");

            entity.Property(e => e.PaymentCode).HasColumnName("paymentCode");
            entity.Property(e => e.TypeOfpayment)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("typeOfpayment");
        });

        modelBuilder.Entity<RegularCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__regularC__B611CB7DC61E679F");

            entity.ToTable("regularCustomer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customerId");
            entity.Property(e => e.Activy).HasColumnName("activy");
            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.DefaultPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("defaultPhone");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fax");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("homePhone");
            entity.Property(e => e.Mail)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mail");

            entity.HasOne(d => d.Customer).WithOne(p => p.RegularCustomer)
                .HasForeignKey<RegularCustomer>(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__regularCu__custo__3D5E1FD2");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__sales__FAE8F4F5DFE88E78");

            entity.ToTable("sales");

            entity.Property(e => e.SaleId)
                .ValueGeneratedNever()
                .HasColumnName("saleId");
            entity.Property(e => e.EventTime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("eventTime");
            entity.Property(e => e.SaleName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("saleName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
