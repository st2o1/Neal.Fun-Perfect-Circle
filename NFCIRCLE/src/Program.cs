using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int  x, int y);

    [DllImport("user32.dll")]
    static extern short GetAsyncKeyState(int vKey);

    static void Main(string[] args)
    {
        Console.WriteLine("press 9");
        ConsoleKeyInfo kinf;
        do
        {
            kinf = Console.ReadKey();
            if(kinf.Key == ConsoleKey.D9)
            {
                Docircle();
            }
        } while (kinf.Key != ConsoleKey.Escape);
    }
    static void Docircle()
    {
        // Press F11 on the N.F website and zoom all the way down so it puts you at 30%(zoom) so the dot is as much in the middle as possible.
        const int cX = 960; // adjusted for 1920px wide (just adjust it to half of your monitor's wide px)
        const double cY = 534.5; // adjusted for 1080px high !! IMPORTANT : you need to configure it from your screen's and browsers dimention , since I don't know them all this is mine.
        const int radius = 300; // you can change radius if you want.

        double angle = 0;

        const double inc = 0.02;
        const int sleepml = 1;

        while(GetAsyncKeyState((int)ConsoleKey.Escape) == 0)
        {
            int x = (int)(cX + radius * Math.Cos(angle));
            int y = (int)(cY + radius * Math.Sin(angle));

            SetCursorPos(x, y);

            angle += inc;

            if(angle >= 2 * Math.PI)
                angle -= 2 * Math.PI;

            Thread.Sleep(sleepml);
        }
    }
}