using Domain.Entities.Devices;
using Domain.Entities.RedModbuss;
using Domain.Entities.Units;
using Domain.Entities.Variables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Devices;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Variables;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.RedModbuss;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Units;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.FluentConfigurations.Samples;
using Domain.Entities.Samples;

namespace DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context
{
    /// <summary>
    /// Define la estructura de la base de datos de la aplicacion
    /// </summary>
    public class ApplicationContext : DbContext
    {
        #region Tables

        /// <summary>
        /// Tabla de variables
        /// </summary>
        public DbSet<Variable> Variables { get; set; }
        /// <summary>
        /// Tabla de dispositivos
        /// </summary>
        public DbSet<Device> Devices { get; set; }
        /// <summary>
        /// Tabla de la red Modbus
        /// </summary>
        public DbSet<RedModbus> RedModbuss { get; set; }
        /// <summary>
        /// Tabla de Unidades
        /// </summary>
        public DbSet<Unit> Units { get; set; }
        /// <summary>
        /// Tabla de muestras
        /// </summary>
        public DbSet<Sample> Samples { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        public ApplicationContext() { }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión.</param>
        public ApplicationContext(string connectionString) : base(GetOptions(connectionString)) { }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>
        /// </summary>
        /// <param name="options"></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DeviceEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new ModbusMasterEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ModbusSlaveEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VariableEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new DigitalVariableEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnalogicVariableEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RedModbusEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new UnitEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new SampleEntityTypeConfiguration());

        }

        #region Helpers

        private static DbContextOptions GetOptions(string connectionString)

        {
            return new DbContextOptionsBuilder().UseSqlite(connectionString).Options;
        }

        #endregion
    }

    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optioneBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            try
            {
                var connectionString = "DataSource = DataAcquisitionSystemModbusProtocolDB.sqlite";
                optioneBuilder.UseSqlite(connectionString);
            }
            catch (Exception)
            {
                //ver excepcion
                throw;
            }

            return new ApplicationContext(optioneBuilder.Options);
        }
    }
}
