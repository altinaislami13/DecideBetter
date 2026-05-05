using DecideWise.Data;
using DecideWise.Services;
using DecideWise.UI;
using System;

Console.WriteLine("Hello World");

Console.Title = "DecideWise - Intelligent Decision Support System";
Console.OutputEncoding = System.Text.Encoding.UTF8;

var repository = new FileRepository("data.json");
var service = new DecisionService(repository);
var ui = new ConsoleUI(service);

ui.Start();