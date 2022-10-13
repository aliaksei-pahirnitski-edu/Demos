// This Demo shows how with the help of Mayuki Cocona a console app could look like an API
// It uses dependency injection, parsing of command line arguments and options,
// commands and subcommands are like to endpoints / controllers
// see https://github.com/mayuki/Cocona
// it has also light version without DI (with custom implementation of DI)
// Cocona can be comapred with McMaster command line utils https://github.com/natemcmaster/CommandLineUtils
using Cocona;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, Demo starting...");
var coconaBuilder = CoconaApp.CreateBuilder();
// coconaBuilder.Services.AddTransient

var coconaApp = coconaBuilder.Build();

// note 1: run with demo-command-opt --help
//    and: sample1 --age 32 --name Jim
// note 2: If type name in camel style like demoCommand it is inside converted to demo-command
coconaApp
    .AddCommand("demo-command-opt", (string name, int age) => Console.WriteLine($"Here lives {age} years old {name} "))
    .WithDescription("Simplest command registration in minimal API style as options")
    .WithAliases("demo-options", "sample1");

// run: demo-command-args --help
//    : demo-args Peter 22
coconaApp
    .AddCommand("demo-command-args", ([Argument]string name, [Argument]int age) => Console.WriteLine($"There lives {age} years old {name} "))
    .WithDescription("Simplest command registration in minimal API style as arguments")
    .WithAliases("demo-args");


// run: demo-mix --help
// demo-mix -r "c:/temp" "d:/temp"
// demo-mix "c:/temp" "d:/temp" --limit 8
coconaApp
    .AddCommand("demo-mix", ([Argument] string from, [Option('r')]bool replace, [Argument] string to, int? limit)
        => Console.WriteLine($"Copying from [{from}] to [{to}] with replace: {replace} and limit: {limit}"))
    .WithDescription("Demo mixing args and opts");

coconaApp.AddSubCommand("demo-command3", sub =>
{
    sub.AddCommand("say-hi", ([Argument] string name) => Console.WriteLine($"Welcome {name}"))
    .WithDescription("Demo of subcommand");
});

coconaApp.Run();

Console.WriteLine("Bye, Demo ended...");
