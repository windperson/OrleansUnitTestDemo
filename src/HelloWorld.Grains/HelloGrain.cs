using System.Threading.Tasks;
using HelloWorld.Interfaces.HelloWorld.Interfaces;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Grains
{
    public class HelloGrain : Orleans.Grain, IHello
    {
        private readonly ILogger<HelloGrain> _logger;
        private bool _isHelloed = false;

        public HelloGrain(ILogger<HelloGrain> logger)
        {
            _logger = logger;
        }

        public Task<string> SayHello(string greeting)
        {
            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
            _logger.LogInformation($"SayHello message received: greeting = '{greeting}'");
            var ret = $"You said: '{greeting}', I say: Hello!";
            _isHelloed = true;
            return Task.FromResult(ret);
        }

        public Task<bool> IsHelloed()
        {
            return Task.FromResult(_isHelloed);
        }
    }
}