using DataAcquisitionSystemModbusProtocol.Contracts;
using DataAcquisitionSystemModbusProtocol.Contracts.Devices;
using DataAcquisitionSystemModbusProtocol.Contracts.RedModbuss;
using DataAcquisitionSystemModbusProtocol.Contracts.Samples;
using DataAcquisitionSystemModbusProtocol.Contracts.Units;
using DataAcquisitionSystemModbusProtocol.Contracts.Variables;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Devices;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.RedModbuss;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Samples;
using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Repositories.Units;
using GrpcService1.Services;

namespace GrpcService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();

            builder.Services.AddSingleton("Data Source=Data.sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddScoped<ISampleRepository, SampleRepository>();
            builder.Services.AddScoped<IVariableRepository, VariableRepository>();
            builder.Services.AddScoped<IRedModbusRepository, RedModbussRepository>();
            builder.Services.AddScoped<IUnitRepository, UnitRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<SampleService>();
            app.MapGrpcService<DigitalVariableService>();
            app.MapGrpcService<AnalogicVariableService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();

        }
    }

}