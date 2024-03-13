using System.Drawing;
using System.Drawing.Imaging;

Console.WriteLine();

Size size = new(1920, 1080);
Rectangle bounds = new Rectangle(Point.Empty, size);
using Bitmap screenShot = new Bitmap(bounds.Width, bounds.Height);
using Graphics graphics = Graphics.FromImage(screenShot);
graphics.CopyFromScreen(0, 0, 0, 0, size);

if (!Directory.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Step"))
    Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Step");
do
{
    Console.WriteLine("Press enter to take Screenshot or\n press Space for print filenames...\n");
    ConsoleKeyInfo info = Console.ReadKey(true);
    var files = Directory.GetFiles($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Step"); // Butun File-lari qaytarir.
    if (info.Key == ConsoleKey.Enter)
    {

        if (files.Length is 0)
            screenShot.Save($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Step\\screenshot.Png", ImageFormat.Png);
        else
            screenShot.Save($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Step\\screenshot({files.Length}).Png", ImageFormat.Png);
    }
    else if (info.Key == ConsoleKey.Spacebar)
    {
        if (files.Length == 0)
            Console.WriteLine("Folder is NULL");
        else
        {
        foreach (var file in files)
                Console.WriteLine(file);
        }

        Console.WriteLine();
    }
} while (true);


