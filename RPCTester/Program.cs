// See https://aka.ms/new-console-template for more information

using RPCHandler;
using Sijl;

Console.WriteLine("Hello, World!");
var t = new SijlHandler();
Console.WriteLine(t.Client.Register(new NewUserRequest()));
