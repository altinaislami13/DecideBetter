using DecideWise.Data;
using DecideWise.Services;
using DecideWise.UI;
using DecideWise.Models;

var repository = new FileRepository ("data.json");
var service = new DecisionService(repository);
var ui = new ConsoleUI(service);

ui.Start();