using DataAcquisitionSystemModbusProtocol.DataAccess.DataAccess.Context;
using DataAcquisitionSystemModbusProtocol.GrpcProtos;
using Domain.Entities.Devices;
using Domain.Entities.RedModbuss;
using Domain.Entities.Samples;
using Domain.Entities.Type;
using Domain.Entities.Units;
using Domain.Entities.Variables;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;

namespace DataAcquisitionSystemModbusProtocol.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para conectar");
Console.ReadKey();

Console.WriteLine("Creating channel and client");
var httpHandler = new HttpClientHandler();
httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
var channel = GrpcChannel.ForAddress("http://localhost:5051", new GrpcChannelOptions { HttpHandler = httpHandler });
if (channel is null)
{
    Console.WriteLine("Cannot connect");
    channel.Dispose();
    return;
}

var client = new DataAcquisitionSystemModbusProtocol.GrpcProtos.AnalogicVariable.AnalogicVariableClient(channel);

Console.WriteLine("Presione una tecla para crear una variable analogica");
Console.ReadKey();
var createResponse = client.CreateAnalogicVariable(new GrpcProtos.CreateAnalogicVariableRequest()
{
    Name = "analogicvariable",
    VariableType = (GrpcProtos.VariableType)GrpcProtos.VariableType.ControlAction
});

if (createResponse is null)
{
    Console.WriteLine("Cannot create analogic variable");
    channel.Dispose();
    return;
}
else
{
    Console.WriteLine($"Creación exitosa.");
}

Console.WriteLine("Presione una tecla para obtener todas las variables analogicas");
Console.ReadKey();
var getResponse = client.GetAllAnalogicVariables(new Google.Protobuf.WellKnownTypes.Empty());
if (getResponse.Items is null)
{
    Console.WriteLine("Cannot get variables");
    channel.Dispose();
    return;
}
else
{
    Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} variables");
}

Console.WriteLine($"Presione una tecla para obtener la variable con Id {createResponse.Id}");
Console.ReadKey();
var getByIdResponse = client.GetAnalogicVariable(new GrpcProtos.GetRequest() { Id = createResponse.Id.ToString() });
if (getByIdResponse is null)
{
    Console.WriteLine("Cannot get variable");
    channel.Dispose();
    return;
}
else
{
    Console.WriteLine($"Obtención exitosa de la variable {getByIdResponse.AnalogicVariable.Name}");
}

Console.WriteLine("Presione una tecla para modificar la variable");
Console.ReadKey();
createResponse.SamplingPeriod = createResponse.SamplingPeriod;
client.UpdateAnalogicVariable(createResponse);

var updatedGetResponse = client.GetAnalogicVariable(new GetRequest() { Id = createResponse.Id });
if (updatedGetResponse is not null &&
    updatedGetResponse.KindCase == NullableAnalogicVariableDTO.KindOneofCase.AnalogicVariable &&
    updatedGetResponse.AnalogicVariable.SamplingPeriod == createResponse.SamplingPeriod)
{
    Console.WriteLine($"Modificación exitosa.");
}

Console.WriteLine("Presione una tecla para eliminar la variable");
Console.ReadKey();

client.DeleteAnalogicVariable(new DeleteRequest() { Id = createResponse.Id });
var deletedGetResponse = client.GetAnalogicVariable(new GetRequest() { Id = createResponse.Id });
if (deletedGetResponse is null ||
    deletedGetResponse.KindCase != NullableAnalogicVariableDTO.KindOneofCase.AnalogicVariable)
{
    Console.WriteLine($"Eliminación exitosa.");
}


channel.Dispose();
        }
    }
}
