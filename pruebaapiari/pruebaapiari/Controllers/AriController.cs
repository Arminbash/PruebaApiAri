using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace pruebaapiari.Controllers
{
    public class WorkOrder
    {
        public WorkOrder() { }
        public WorkOrder(int workOrderId, string userId, string clientNumber, string actorIdCard, string actorFullName, string actorPhone, string actorEmail, string actorAddress, string actorSecondaryAddress, string jobOrderNumber, DateTime jobOrderApplicationDate, string jobOrderPath, string jobOrderCycle, string jobOrderProperty, string jobOrderTome, string jobOrderFolio, int jobOrderCorrelative, int jobOrderNumberOfVisits, string jobOrderAgencyGenericCatalog, string jobOrderBrigadeGenericCatalog, string jobOrderClassificationGenericCatalog, string jobOrderTypeGenericCatalog, string jobOrderStatusGenericCatalog, string jobOrderReport, DateTime jobOrderCreateDate, string waterMeterMark, string waterMeterModel, string waterMeterDiameter, string waterMeterUnitMeasureGenericCatalog, Boolean waterMeterIsSpecial, decimal hisJobOrderReadingOne, decimal hisJobOrderReadingTwo)
        {
            WorkOrderId=workOrderId;
            UserId=userId;
            this.clientNumber=clientNumber;
            this.actorIdCard=actorIdCard;
            this.actorFullName=actorFullName;
            this.actorPhone=actorPhone;
            this.actorEmail=actorEmail;
            this.actorAddress=actorAddress;
            this.actorSecondaryAddress=actorSecondaryAddress;
            this.jobOrderNumber=jobOrderNumber;
            this.jobOrderApplicationDate=jobOrderApplicationDate;
            this.jobOrderPath=jobOrderPath;
            this.jobOrderCycle=jobOrderCycle;
            this.jobOrderProperty=jobOrderProperty;
            this.jobOrderTome=jobOrderTome;
            this.jobOrderFolio=jobOrderFolio;
            this.jobOrderCorrelative=jobOrderCorrelative;
            this.jobOrderNumberOfVisits=jobOrderNumberOfVisits;
            this.jobOrderAgencyGenericCatalog=jobOrderAgencyGenericCatalog;
            this.jobOrderBrigadeGenericCatalog=jobOrderBrigadeGenericCatalog;
            this.jobOrderClassificationGenericCatalog=jobOrderClassificationGenericCatalog;
            this.jobOrderTypeGenericCatalog=jobOrderTypeGenericCatalog;
            this.jobOrderStatusGenericCatalog=jobOrderStatusGenericCatalog;
            this.jobOrderReport=jobOrderReport;
            this.jobOrderCreateDate=jobOrderCreateDate;
            this.waterMeterMark=waterMeterMark;
            this.waterMeterModel=waterMeterModel;
            this.waterMeterDiameter=waterMeterDiameter;
            this.waterMeterUnitMeasureGenericCatalog=waterMeterUnitMeasureGenericCatalog;
            this.waterMeterIsSpecial=waterMeterIsSpecial;
            this.hisJobOrderReadingOne=hisJobOrderReadingOne;
            this.hisJobOrderReadingTwo=hisJobOrderReadingTwo;
        }

        [Key]
        public int WorkOrderId { get; set; }
        public string UserId { get; set; }
        public string clientNumber { get; set; }
        public string actorIdCard { get; set; }
        public string actorFullName { get; set; }
        public string actorPhone { get; set; }
        public string actorEmail { get; set; }
        public string actorAddress { get; set; }
        public string actorSecondaryAddress { get; set; }
        public string jobOrderNumber { get; set; }
        public DateTime jobOrderApplicationDate { get; set; }
        public string jobOrderPath { get; set; }
        public string jobOrderCycle { get; set; }
        public string jobOrderProperty { get; set; }
        public string jobOrderTome { get; set; }
        public string jobOrderFolio { get; set; }
        public int jobOrderCorrelative { get; set; }
        public int jobOrderNumberOfVisits { get; set; }
        public string jobOrderAgencyGenericCatalog { get; set; }
        public string jobOrderBrigadeGenericCatalog { get; set; }
        public string jobOrderClassificationGenericCatalog { get; set; }
        public string jobOrderTypeGenericCatalog { get; set; }
        public string jobOrderStatusGenericCatalog { get; set; }
        public string jobOrderReport { get; set; }
        public DateTime jobOrderCreateDate { get; set; }
        public string waterMeterMark { get; set; }
        public string waterMeterModel { get; set; }
        public string waterMeterDiameter { get; set; }
        public string waterMeterUnitMeasureGenericCatalog { get; set; }
        public Boolean waterMeterIsSpecial { get; set; }
        public decimal hisJobOrderReadingOne { get; set; }
        public decimal hisJobOrderReadingTwo { get; set; }
    }

    public class SQLiteContext : DbContext
    {
        public DbSet<WorkOrder> WorkOrders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=AriTracker.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<WorkOrder>().ToTable("WorkOrder", "dbo");
            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.HasKey(e => e.WorkOrderId);
                entity.Property(e => e.jobOrderApplicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.jobOrderCreateDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            base.OnModelCreating(modelBuilder);
        }
    }


    [ApiController]
    [Route("[controller]")]
    public class AriController : ControllerBase
    {
        private readonly ILogger<AriController> _logger;

        public AriController(ILogger<AriController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ListAriRequest Get(string userId)
        {
            using (var dbContext = new SQLiteContext())
            {
                return new ListAriRequest(dbContext.WorkOrders.Where(x => x.UserId == userId).ToList());
            }
        }

        [HttpPost]
        public Boolean Post(WorkOrder request)
        {
            using (var dbContext = new SQLiteContext())
            {
                try
                {
                    dbContext.WorkOrders.Add(request);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
    public class ListAriRequest
    {
        public ListAriRequest(List<WorkOrder> request) 
        {
            orders = request;
        }
        public List<WorkOrder> orders { get; set; }
    }

}
