using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using Domain.Entities.Devices;
using Domain.Entities.RedModbuss;
using Domain.Entities.Samples;
using Domain.Entities.Type;
using Domain.Entities.Units;
using Domain.Entities.Variables;
using Microsoft.EntityFrameworkCore;

namespace DataAcquisitionSystemModbusProtocol.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("f");

            //Borrando BD en caso de existir una antigua,
            // esto se hace pq para que este programa en particular
            // funcione correctamente, debe iniciar con la BD vacía.
            if (File.Exists("Data.sqlite"))
                File.Delete("Data.sqlite");

            // Definiendo string de conexión.
            string connectionString = "Data Source = Data.sqlite";

            // Creando contexto a usar por repositorios.
            ApplicationContext context = new ApplicationContext(connectionString);

            //Generando la Bd en caso de no existir
            if (!context.Database.CanConnect())
                context.Database.Migrate();

            // Creando entidades para probar BD.
            ModbusMaster modbusMaster = new ModbusMaster("maestro", Guid.NewGuid());
            ModbusSlave modbusSlave = new ModbusSlave("esclavo", Guid.NewGuid());
            AnalogicVariable analogicVariable = new AnalogicVariable("variable analogica", VariableType.ControlAction, "analogiccode", Guid.NewGuid());
            DigitalVariable digitalVariable = new DigitalVariable("variable digital", VariableType.MeasurementValue, "digitalcode", Guid.NewGuid());
            Unit unit = new Unit(UnitType.Discrete, "unitcode", Guid.NewGuid());
            RedModbus redModbus = new RedModbus(Guid.NewGuid());
            Sample sample = new Sample(2.2, DateTime.Now);
            
            

            // ***************Almacenando entidades en BD.
            context.Variables.Add(analogicVariable);
            context.Variables.Add(digitalVariable);
            context.Devices.Add(modbusMaster);
            context.Devices.Add(modbusSlave);
            context.RedModbuss.Add(redModbus);
            context.Units.Add(unit);
            context.Samples.Add(sample);


            // Es necesario guardar los cambios para que se actualice la BD.
            context.SaveChanges();

           

        }
    }
}