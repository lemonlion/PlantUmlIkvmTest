using java.io;
using net.sourceforge.plantuml;
using net.sourceforge.plantuml.klimt.sprite;

namespace PlantUmlIkvm;

public class Program
{
    public static void Main(string[] args)
    {
        var plantUml = @"
@startuml
Bob -> Alice : hello
@enduml
".Trim();

        var png = WriteImage(plantUml, format: FileFormat.PNG);
        System.Console.WriteLine($"The PlantUml image can be found at: {png.FilePath}");

        var svg = WriteImage(plantUml, format: FileFormat.SVG);
        System.Console.WriteLine($"The PlantUml image can be found at: {svg.FilePath}");

        var asciiArt = WriteImage(plantUml, format: FileFormat.ATXT);
        System.Console.WriteLine($"The PlantUml image can be found at: {asciiArt.FilePath}");

        System.Console.WriteLine();

        System.Console.WriteLine($"Here is the AsciiArt version: ");
        System.Console.WriteLine(asciiArt.StringResult);

        System.Console.WriteLine();

        System.Console.WriteLine($"Here is the base64 version of the PNG: ");
        System.Console.WriteLine(png.Base64);

        System.Console.WriteLine();

        System.Console.WriteLine($"Here is the base64 version of the SVG: ");
        System.Console.WriteLine(svg.Base64);

        System.Console.ReadKey();
    }

    private static (string FilePath, string Base64, string StringResult) WriteImage(string plantUml, FileFormat format)
    {
        var pngReader = new SourceStringReader(plantUml);
        var png = new ByteArrayOutputStream();
        pngReader.outputImage(png, new FileFormatOption(format));

        var imageAsBytes = png.toByteArray();
        var imageAsBase64 = Convert.ToBase64String(imageAsBytes);
        var filepath = Path.Combine(Directory.GetCurrentDirectory(), $"plantUmlIkvm{format.getFileSuffix()}");

        System.IO.File.WriteAllBytes(filepath, imageAsBytes);

        return (filepath, imageAsBase64, format == FileFormat.ATXT ? System.IO.File.ReadAllText(filepath) : imageAsBase64);
    }
}