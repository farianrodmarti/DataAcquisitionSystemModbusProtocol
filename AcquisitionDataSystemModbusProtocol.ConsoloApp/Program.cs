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
            Console.WriteLine("Iniciando base de datos");

            // Borrando BD en caso de existir una antigua
            if (File.Exists("Data.sqlite"))
                File.Delete("Data.sqlite");

            // Definiendo string de conexión
            string connectionString = "Data Source = Data.sqlite";

            // Creando contexto a usar por repositorios
            ApplicationContext context = new ApplicationContext(connectionString);

            // Generando la Bd en caso de no existir
            context.Database.Migrate();

            // Creando entidades para probar BD
            //ModbusMaster modbusMaster = new ModbusMaster(Guid.NewGuid(), "maestro");
            //ModbusSlave modbusSlave = new ModbusSlave(Guid.NewGuid(), "esclavo");
            //AnalogicVariable analogicVariable = new AnalogicVariable(Guid.NewGuid(), "variable analogica", VariableType.ControlAction, "analogiccode");
            //DigitalVariable digitalVariable = new DigitalVariable(Guid.NewGuid(), "variable digital", VariableType.MeasurementValue, "digitalcode");

            //RedModbus redModbus = new RedModbus(Guid.NewGuid());
            //Sample sample = new Sample(2.2, DateTime.Now);

            // Almacenando entidades en BD
            //context.Devices.Add(modbusMaster);
            //context.SaveChanges();
            //context.RedModbuss.Add(redModbus);
            //context.SaveChanges();
            //context.Devices.Add(modbusSlave);
            //context.SaveChanges();

            Unit unit = new Unit(Guid.NewGuid(), UnitType.Discrete, "unitcode");
            context.Units.Add(unit);
            AnalogicVariable analogicVariable = new AnalogicVariable(Guid.NewGuid(), "variable analogica", VariableType.ControlAction, "analogiccode")
            {
                UnitId = unit.Id // Asignando la clave foránea a Unit
            };

            DigitalVariable digitalVariable = new DigitalVariable(Guid.NewGuid(), "variable digital", VariableType.MeasurementValue, "digitalcode")
            {
                UnitId = unit.Id // Asignando la clave foránea a Unit
            };
            context.Variables.Add(analogicVariable);
            context.Variables.Add(digitalVariable);

            Sample sample = new Sample(Guid.NewGuid() ,2.2, DateTime.Now)
            {
                VariableId = analogicVariable.Id
            };


            context.Samples.Add(sample);
            
            
            

            context.SaveChanges();

            // Obteniendo entidades relacionadas con muestras(samples)
            Variable? variableFromSample = context.Set<AnalogicVariable>().FirstOrDefault(x => x.Id == sample.VariableId);

            if (variableFromSample is null)
                Console.WriteLine("Variable no encontrada");
            else
                Console.WriteLine($"La muestra es de la variable {variableFromSample.Name}");

            // Eliminando entidades de la base de datos
            context.Variables.Remove(analogicVariable);
            context.SaveChanges();

            AnalogicVariable? deletedAnalogicVariable = context.Set<AnalogicVariable>().FirstOrDefault(x => x.Id == analogicVariable.Id);
            if (deletedAnalogicVariable is null)
                Console.WriteLine("Variable eliminada con éxito");
        }
    }
}
