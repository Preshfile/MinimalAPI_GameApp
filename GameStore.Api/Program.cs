using GameStore.Api.Endpoints;
using GameStore.Api.Repositories;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepo>(); 

var app = builder.Build(); 

app.MapGamesEndpoints(); 

app.Run();

