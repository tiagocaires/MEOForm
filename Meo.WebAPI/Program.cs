using Meo.Data;
using Meo.Data.Repository;
using Meo.Data.Repository.Interface;
using Meo.Service.Business;
using Meo.Service.Interface;
using Meo.Service.ViewModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AnswerViewModel));

builder.Services.AddDbContext<MeoContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MeoContext")
    ?? throw new InvalidOperationException("Connection string 'MeoContext' not found.")));

builder.Services.AddScoped<IAnswerService, AnswerService>()
                .AddScoped<ICampaignService, CampaignService>()
                .AddScoped<IFormService, FormService>()
                .AddScoped<IPersonService, PersonService>()
                .AddScoped<IQuestionService, QuestionService>()

                .AddScoped<IAnswerRepository, AnswerRepository>()
                .AddScoped<ICampaignRepository, CampaignRepository>()
                .AddScoped<IFormRepository, FormRepository>()
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IQuestionRepository, QuestionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<MeoContext>();
        context.Database.EnsureCreated();
        DBMeoInitializer.Initialize(context);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
