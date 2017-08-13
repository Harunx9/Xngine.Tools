using Xngine.Tools.Commons.Xml;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Xml.Spritesheet
{
    public abstract class SpritesheetTestBase : AAATest
    {
        protected IXmlSerializer serializer;
        protected const string SERIALIZED_XML_SPRITESHEET =
    "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
    "<spritesheet>\r\n" +
    "  <item name=\"Anim_1\" x=\"0\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
    "  <item name=\"Anim_2\" x=\"0\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
    "  <item name=\"Anim_3\" x=\"50\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
    "  <item name=\"Anim_4\" x=\"50\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
    "</spritesheet>";
    }
}
