using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CBSMonitoring.Models;
using CBSMonitoring.Model;

namespace CBSMonitoring.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<OrgMonitoring> OrgMonitorings { get; set; }
        public DbSet<MonitoringForm> MonitoringForms { get; set; }
        public DbSet<FormItem> FormItems { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<FileModel> FileModels { get; set; }
        public DbSet<QualificationImprovedEmployee> QIEmployees { get; set; }
        public DbSet<Form1_1> Form1_1s { get; set; }   //1.1                                    
        public DbSet<Form1_2> Form1_2s { get; set; } //1.2
        public DbSet<Form1_3> Form1_3s { get; set; } //1.3
        public DbSet<Form1_4> Form1_4s { get; set; } //1.4
        public DbSet<Form1_5> Form1_5s { get; set; } //1.5
        public DbSet<Form2_1> Form2_1s { get; set; }  //2.1
        public DbSet<Form2_2> Form2_2s { get; set; } //2.2
        public DbSet<Form2_3> Form2_3s { get; set; }  //2.3
        public DbSet<Form2_4> Form2_4s { get; set; } //2.4
        public DbSet<Form2_5> Form2_5s { get; set; }  //2.5
        public DbSet<Form2_6> Form2_6s { get; set; } //2.6
        public DbSet<Form2_7> Form2_7s { get; set; }  //2.7
        public DbSet<Form2_8> Form2_8s { get; set; } //2.8
        public DbSet<Form2_9> Form2_9s { get; set; }  //2.9
        public DbSet<Form2_10> Form2_10s { get; set; }    //2.10
        public DbSet<Form2_11> Form2_11s { get; set; }    //2.11
        public DbSet<Form2_12> Form2_12s { get; set; } //2.12
        public DbSet<Form2_13> Form2_13s { get; set; }  //2.13
        public DbSet<Form2_14> Form2_14s { get; set; } //2.14
        public DbSet<Form2_15> Form2_15s { get; set; }  //2.15
        public DbSet<Form2_16> Form2_16s { get; set; } //2.16
        public DbSet<Form2_17> Form2_17s { get; set; } //2.17
        public DbSet<Form2_18> Form2_18s { get; set; } //2.17
        public DbSet<Form3_1> Form3_1s { get; set; } //3.1
        public DbSet<Form3_2> Form3_2s { get; set; } //3.2
        public DbSet<Form3_3> Form3_3s { get; set; } //3.3
        public DbSet<Form3_4> Form3_4s { get; set; } //3.4
        public DbSet<Form3_5> Form3_5s { get; set; }
        public DbSet<Form3_6> Form3_6s { get; set; }
        public DbSet<Form3_7> Form3_7s { get; set; }
        public DbSet<Form3_8> Form3_8s { get; set; }
        public DbSet<Form3_9> Form3_9s { get; set; }
        public DbSet<Form3_10> Form3_10s { get; set; }
        public DbSet<Form3_11> Form3_11s { get; set; }
        public DbSet<Form3_12> Form3_12s { get; set; }
        public DbSet<Form3_13> Form3_13s { get; set; }

    }
}
