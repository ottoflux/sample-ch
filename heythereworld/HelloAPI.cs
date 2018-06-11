using System;
using Microsoft.Extensions.Configuration;

namespace heythereworld
{
    public class HelloAPI
    {
        // config
        private static IConfiguration _configuration { get; set; }
        // default to console
        private static OutputDestination _output = OutputDestination.Console;

        public HelloAPI()
        {
            // get config
            // also, in reality handle exception processing where we can
            // but it's never a terrible idea to fail completely if
            // all assumptions can't be made correctly for default behavior.

            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("helloConfig.json", true);
            _configuration = builder.Build();

            // will default to console if bad value
            OutputDestination configDest;
            Enum.TryParse<OutputDestination>($"{_configuration["outputFormat"]}", out configDest);

            _output = configDest;

        }

        /// <summary>
        /// Gets or sets the output destination
        /// </summary>
        /// <value>The output destination.</value>
        public OutputDestination Output
        {
            get {
                return _output;
            }
            set{
                _output = value;
            }
        }

        /// <summary>
        /// Write the Hello to current set Output
        ///  DEFAULTS to console, uses config or setter.
        /// </summary>
        public void WriteHello()
        {
            // So, I debated about this a bit and instead of analysis paralysis
            //  I'm just writing it this way for now. In reality I'd ask a few more
            //  questions like "Do we want this one API to be able to write to 
            //  multiple destinations?" or "Do we want to allow modifications to
            //  calls so we can specify a DIV, or element, etc. or would we just
            //  want to have the View/Controller handle that in those cases." 
            //  Mostly because in the case of writing a value it is going to be
            //  a question of where should the work happen. Ideally we could do
            //  more to this, make objects disposable, etc. I don't like to make
            //  assumptions in code and if I do have to make them I want to make
            //  something configurable. I was told to do this fairly quickly so
            //  instead I'm just picking some things versus the debate.
            switch(_output)
            {
                case OutputDestination.Console:
                    var sayHello = new HelloWorldConsole();
                    sayHello.SayIt();
                    break;
                default:
                    // what to do?
                    break;
            }
        }
    }
}
