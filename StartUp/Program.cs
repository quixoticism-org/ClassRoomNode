using Application;
using Database;
using IdentityService;
using RestfulApi;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

#region Drivens

builder.Services.AddDatabaseServices(configuration);
builder.Services.AddIdentityServiceServices(configuration);

#endregion

builder.Services.AddApplicationServices();

#region Drivings

builder.Services.AddRestfulApiServices(configuration);

#endregion

var app = builder.Build();

app.UseRestfulApiConfigurations();

app.Run();

// # Required connection configs for Kafka producer, consumer, and admin
// bootstrap.servers=pkc-4j8dq.southeastasia.azure.confluent.cloud:9092
// security.protocol=SASL_SSL
// sasl.mechanisms=PLAIN
// sasl.username=2MHIIDX4PYNVGXX5
// sasl.password=KS5FlSs2a5+7pS9WiEng2A98ZwCmRISGPrdbqpjUv7eI04dRJUSGP25mByQ3bQx8
//
// # Best practice for higher availability in librdkafka clients prior to 1.7
// session.timeout.ms=45000