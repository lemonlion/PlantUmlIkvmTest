using System.Reflection;
using com.plantuml.api.cheerpj;
using com.plantuml.api.cheerpj.v1;
using java.io;
using net.sourceforge.plantuml;
using net.sourceforge.plantuml.api;
using net.sourceforge.plantuml.security;
using net.sourceforge.plantuml.sequencediagram;
using sun.misc;
using sun.net.www.content.image;

namespace PlantUmlIkvm;

public class Program
{
    public static void Main(string[] args)
    {
        var uml = "@startuml\n";
        uml += "Bob -> Alice : hello\n";
        uml += "@enduml\n";
        var reader = new net.sourceforge.plantuml.SourceStringReader(uml);
        OutputStream png = new Base64OutputStream();
        var desc = reader.outputImage(png).getDescription();
    }
}