namespace Saas.Office.Auto.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AdminDbContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“AdminDbContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Saas.Office.Auto.DataAccess.AdminDbContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“AdminDbContext”
        //连接字符串。
        public AdminDbContext()
            : base("AdminDbContext")
        {
        }
        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。
        public virtual DbSet<TSysActions> TSysActions { get; set; }
        public virtual DbSet<TSysAreas> TSysAreas { get; set; }
        public virtual DbSet<TSysControllers> TSysControllers { get; set; }
        public virtual DbSet<TSysControllerSysActions> TSysControllerSysActions { get; set; }
        public virtual DbSet<TSysDepartments> TSysDepartments { get; set; }
        public virtual DbSet<TSysDepartmentSysUsers> TSysDepartmentSysUsers { get; set; }
        public virtual DbSet<TSysEnterprises> TSysEnterprises { get; set; }
        public virtual DbSet<TSysLoginHistoryLogs> TSysLoginHistoryLogs { get; set; }
        public virtual DbSet<TSysLogs> TSysLogs { get; set; }
        public virtual DbSet<TSysRoles> TSysRoles { get; set; }
        public virtual DbSet<TSysRoleSysControllerSysActions> TSysRoleSysControllerSysActions { get; set; }
        public virtual DbSet<TSysRoleSysUsers> TSysRoleSysUsers { get; set; }
        public virtual DbSet<TSysUserLogs> TSysUserLogs { get; set; }
        public virtual DbSet<TSysUsers> TSysUsers { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}