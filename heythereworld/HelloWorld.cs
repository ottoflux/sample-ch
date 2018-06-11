using System;

namespace heythereworld
{
    /// <summary>
    /// Hello world. - abstract framework to pump out Hello World to where it
    ///  belongs.
    /// </summary>
    public abstract class HelloWorld
    {
        // because we don't need random strings floating around code.
        const String HELLO_WORLD = "Hello World";

        abstract public void SayIt();

        // so we're all using the same text, this could be pulled from a resx
        public String GetHello
        {
            get
            {
                return HELLO_WORLD;
            }
        }
    }

    /// <summary>
    /// Output destination. Hopefully reducing ambiguity eventually.
    /// Yes, I could totally put this in another file.
    /// </summary>
    public enum OutputDestination
    {
        Console,
        View,
        HTML
    }

    /// <summary>
    /// Write Hello to the console/screen
    /// </summary>
    public class HelloWorldConsole : HelloWorld
    {
        public override void SayIt()
        {
            //say it.
            Console.WriteLine(this.GetHello);
        }
    }
}
