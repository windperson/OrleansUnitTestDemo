using System.Threading.Tasks;
using HelloWorld.Interfaces.HelloWorld.Interfaces;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Grains
{
    public class HelloGrain : Orleans.Grain, IHello
    {
        private readonly ILogger<HelloGrain> _logger;

        public HelloGrain(ILogger<HelloGrain> logger)
        {
            _logger = logger;
        }
        public Task<string> SayHello(string greeting)
        {
            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
            _logger.LogInformation($"SayHello message received: greeting = '{greeting}'");
            return Task.FromResult($"You said: '{greeting}', I say: Hello!");            
        }
    }
}