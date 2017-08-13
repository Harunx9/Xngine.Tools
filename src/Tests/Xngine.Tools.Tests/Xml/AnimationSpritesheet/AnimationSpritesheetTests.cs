using Xngine.Tools.Commons.Xml;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Xml.AnimationSpritesheet
{
    public abstract class AnimationSpritesheetBase : AAATest
    {
        protected IXmlSerializer serializer;
        protected const string SERIALIZED_XML_ANIMATIONS_SPRITESHEET =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
            "<animations>\r\n" +
            "  <animation name=\"animationName1\" framesPerSecond=\"4\">\r\n" +
            "    <frame number=\"0\" x=\"0\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"50\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"100\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"150\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "  </animation>\r\n" +
            "  <animation name=\"animationName2\" framesPerSecond=\"4\">\r\n" +
            "    <frame number=\"0\" x=\"0\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"50\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"100\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"150\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "  </animation>\r\n" +
            "</animations>";
    }
}
