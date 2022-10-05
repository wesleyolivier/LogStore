using HungryPizza.MinhaApi.Bussiness.Implementacoes;
using HungryPizza.MinhaApi.Bussiness.Implementacoes.Validacao;
using HungryPizza.MinhaApi.Bussiness.Interfaces;
using HungryPizza.MinhaApi.Bussiness.Interfaces.Validacao;
using HungryPizza.MinhaApi.Context;
using HungryPizza.MinhaApi.Data.Implementacoes;
using HungryPizza.MinhaApi.Data.Interfaces;
using HungryPizza.MinhaApi.Servicos.Implementacoes;
using HungryPizza.MinhaApi.Servicos.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Banco de Dados
builder.Services.AddDbContext<MeuAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MinhaConexao")));//

//Fachada
builder.Services.AddTransient<IFachada, Fachada>();

//Repositórios
builder.Services.AddTransient<IPedidoRepositorio, PedidoRepositorio>();
builder.Services.AddTransient<IPizzaRepositorio, PizzaRepositorio>();
builder.Services.AddTransient<IPizzaSaborRepositorio, PizzaSaborRepositorio>();
builder.Services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddTransient<ISaborRepositorio, SaborRepositorio>();

//Validadores
builder.Services.AddTransient<IValidacaoQuantidadePizza, ValidacaoQuantidadePizza>();
builder.Services.AddTransient<IValidacaoQuantidadeSabores, ValidacaoQuantidadeSabores>();
builder.Services.AddTransient<IValidacaoCredenciais, ValidacaoCredenciais>();
builder.Services.AddTransient<IValidacaoClienteSolicitante, ValidacaoClienteSolicitante>();
builder.Services.AddTransient<IValidacaoDisponibilidadeSabores, ValidacaoDisponibilidadeSabores>();

//Servicos
builder.Services.AddTransient<IClienteServico, ClienteServico>();
builder.Services.AddTransient<IPedidoServico, PedidoServico>();
builder.Services.AddTransient<IPizzaServico, PizzaServico>();
builder.Services.AddTransient<ISaborServico, SaborServico>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
