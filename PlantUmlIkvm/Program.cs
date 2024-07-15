using java.io;
using net.sourceforge.plantuml;

namespace PlantUmlIkvm;

public class Program
{
    public static void Main(string[] args)
    {
        var uml = "@startuml\n";
        uml += "Bob -> Alice : hello\n";
        uml += "@enduml\n";

        var reader = new SourceStringReader(uml);
        var png = new ByteArrayOutputStream();
        reader.outputImage(png);

        var imageAsBytes = png.toByteArray();
        var imageAsBase64 = Convert.ToBase64String(imageAsBytes);

        System.Console.WriteLine(imageAsBase64);
        System.Console.ReadKey();
    }
}