﻿using CBSMonitoring.Model;
using CBSMonitoring.Models;
using CBSMonitoring.Models.Forms;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CBSMonitoring.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<OrgMonitoring> OrgMonitoringReports { get; set; }
        public DbSet<QuestionBlock> QuestionBlocks { get; set; }
        public DbSet<FormSection> FormSections { get; set; }
        public DbSet<FormItem> FormItems { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<FileModel> FileModels { get; set; }
        public DbSet<QualificationImprovedEmployee> QIEmployees { get; set; }
        public DbSet<FormItemType> FormItemTypes { get; set; }
        public DbSet<TimelyExecutionOfPlan> TimelyExecutionOfPlans { get; set; }
        public DbSet<MonitoringIndicator> MonitoringIndicators { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Setting> Settings { get; set; }

        #region Form Sections
        public DbSet<Form1_1_1> Form1_1_1s { get; set; }   //1.1
        public DbSet<Form1_1_2> Form1_1_2s { get; set; }   //1.1 
        public DbSet<Form1_1_3> Form1_1_3s { get; set; }
        public DbSet<Form1_1_4> Form1_1_4s { get; set; }
        public DbSet<Form1_1_5> Form1_1_5s { get; set; }
        public DbSet<Form1_1_6> Form1_1_6s { get; set; }
        public DbSet<Form1_2_1> Form1_2_1s { get; set; }    //1.2
        public DbSet<Form1_3_1> Form1_3_1s { get; set; } //1.3
        public DbSet<Form1_4_1> Form1_4_1s { get; set; } //1.4
        public DbSet<Form1_4_2> Form1_4_2s { get; set; }
        public DbSet<Form1_4_3> Form1_4_3s { get; set; }
        public DbSet<Form1_4_4> Form1_4_4s { get; set; }
        public DbSet<Form1_5_1> Form1_5_1s { get; set; } //1.5
        public DbSet<Form1_5_2> Form1_5_2s { get; set; }
        public DbSet<Form1_5_3> Form1_5_3s { get; set; }
        public DbSet<Form2_1_1> Form2_1_1s { get; set; }  //2.1
        public DbSet<Form2_1_1> Form2_1_2s { get; set; }
        public DbSet<Form2_2_1> Form2_2_1s { get; set; } //2.2
        public DbSet<Form2_2_2> Form2_2_2s { get; set; } //2.2
        public DbSet<Form2_3_1> Form2_3_1s { get; set; }  //2.3
        public DbSet<Form2_3_2> Form2_3_2s { get; set; }
        public DbSet<Form2_3_3> Form2_3_3s { get; set; }
        public DbSet<Form2_3_4> Form2_3_4s { get; set; }
        public DbSet<Form2_4_1> Form2_4_1s { get; set; } //2.4
        public DbSet<Form2_4_2> Form2_4_2s { get; set; }
        public DbSet<Form2_4_3> Form2_4_3s { get; set; }
        public DbSet<Form2_5_1> Form2_5_1s { get; set; }  //2.5
        public DbSet<Form2_6_1> Form2_6_1s { get; set; } //2.6
        public DbSet<Form2_7_1> Form2_7_1s { get; set; }  //2.7
        public DbSet<Form2_8_1> Form2_8_1s { get; set; } //2.8
        public DbSet<Form2_9_1> Form2_9_1s { get; set; }  //2.9
        public DbSet<Form2_10_1> Form2_10_1s { get; set; }    //2.10
        public DbSet<Form2_11_1> Form2_11_1s { get; set; }    //2.11
        public DbSet<Form2_11_2> Form2_11_2s { get; set; }
        public DbSet<Form2_11_3> Form2_11_3s { get; set; }
        public DbSet<Form2_11_4> Form2_11_4s { get; set; }
        public DbSet<Form2_11_5> Form2_11_5s { get; set; }
        public DbSet<Form2_11_6> Form2_11_6s { get; set; }
        public DbSet<Form2_11_7> Form2_11_7s { get; set; }
        public DbSet<Form2_12_1> Form2_12_1s { get; set; } //2.12
        public DbSet<Form2_13_1> Form2_13_1s { get; set; }  //2.13
        public DbSet<Form2_14_1> Form2_14_1s { get; set; } //2.14
        public DbSet<Form2_15_1> Form2_15_1s { get; set; }  //2.15
        public DbSet<Form2_16_1> Form2_16_1s { get; set; } //2.16
        public DbSet<Form2_17_1> Form2_17_1s { get; set; } //2.17
        public DbSet<Form2_18_1> Form2_18_1s { get; set; } //2.17
        public DbSet<Form3_1_1> Form3_1_1s { get; set; } //3.1
        public DbSet<Form3_1_2> Form3_1_2s { get; set; }
        public DbSet<Form3_2_1> Form3_2_1s { get; set; } //3.2
        public DbSet<Form3_2_2> Form3_2_2s { get; set; }
        public DbSet<Form3_3_1> Form3_3_1s { get; set; } //3.3
        public DbSet<Form3_4_1> Form3_4_1s { get; set; } //3.4
        public DbSet<Form3_5_1> Form3_5_1s { get; set; }
        public DbSet<Form3_6_1> Form3_6_1s { get; set; }
        public DbSet<Form3_7_1> Form3_7_1s { get; set; }
        public DbSet<Form3_8_1> Form3_8_1s { get; set; }
        public DbSet<Form3_9_1> Form3_9_1s { get; set; }
        public DbSet<Form3_10_1> Form3_10_1s { get; set; }
        public DbSet<Form3_11_1> Form3_11_1s { get; set; }
        public DbSet<Form3_12_1> Form3_12_1s { get; set; }
        public DbSet<Form3_13_1> Form3_13_1s { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Setting>()
                .HasDiscriminator<string>("Setting")
                .HasValue<RankingSetting>("RankingSetting");

            builder.Entity<Setting>()
                .HasIndex(nameof(Setting.Id), "Setting")
                .IsUnique();

            builder.Entity<QuestionBlock>()
                .HasIndex(m => m.BlockNumber)
                .IsUnique();

            builder.Entity<QuestionBlock>()
                .HasMany(qblock => qblock.FormSections)
                .WithOne(section => section.QuestionBlock)
                .HasForeignKey(section => section.QuestionBlockId);
            
            builder.Entity<FormSection>()
                .HasMany(section => section.FormItems)
                .WithOne(item => item.FormSection)
                .HasForeignKey(item => item.FormSectionId);

            builder.Entity<MonitoringIndicator>()
                .HasMany(indicator => indicator.QuestionBlocks)
                .WithOne(block => block.MonitoringIndicator)
                .HasForeignKey(block => block.IdicatorId);

            builder.Entity<Form2_2_2>()
                .HasMany(a => a.TimelyExecutionOfPlans)
                .WithOne(b => b.OrgMonitoring)
                .HasForeignKey(b => b.OrgMonitoringId);

            builder.Entity<Form2_2_2>()
                .HasMany(a => a.FileModels)
                .WithOne(b => b.Form2_2_2)
                .HasForeignKey(b => b.Form2_2_2Id);

            builder.Entity<Form2_8_1>()
                .HasMany(a => a.QualificationImprovedEmployees)
                .WithOne(b => b.OrgMonitoring)
                .HasForeignKey(b => b.OrgMonitoringId);

            builder.Entity<QualificationImprovedEmployee>()
                .HasOne(a => a.Certificate)
                .WithOne()  // assuming one-to-one relationship
                .HasForeignKey<QualificationImprovedEmployee>(a => a.CertificateFileId);

            builder.Entity<Form1_1_1>()
                .HasOne(a => a.FileModel)
                .WithOne()
                .HasForeignKey<Form1_1_1>(a => a.File_1_1_1Id);

            builder.Entity<Form1_1_2>()
                .HasOne(a => a.FileModel)
                .WithOne()
                .HasForeignKey<Form1_1_2>(a => a.File_1_1_2Id);

            builder.Entity<Form1_1_3>()
                .HasOne(a => a.FileModel)
                .WithOne()
                .HasForeignKey<Form1_1_3>(a => a.File_1_1_3Id);

            builder.Entity<Form2_1_1>()
                .HasOne(a => a.FileModel)
                .WithOne()
                .HasForeignKey<Form2_1_1>(a => a.File_2_1_1Id);

            builder.Entity<Form2_1_2>()
                .HasOne(a => a.FileModel)
                .WithOne()
                .HasForeignKey<Form2_1_2>(a => a.File_2_1_2Id);

            builder.Entity<Form2_2_1>()
                .HasOne(a => a.FileModel)
                .WithOne()
                .HasForeignKey<Form2_2_1>(a => a.File_2_2_1Id);

            builder.Entity<Form2_3_1>()
                .HasOne(a => a.FileModel)
                .WithOne()
                .HasForeignKey<Form2_3_1>(a => a.File_2_3_1Id);

            builder.Entity<Form2_3_2>()
                .HasOne(a => a.FileModel)
                .WithOne()
                .HasForeignKey<Form2_3_2>(a => a.File_2_3_2Id);
        }

    }
}
