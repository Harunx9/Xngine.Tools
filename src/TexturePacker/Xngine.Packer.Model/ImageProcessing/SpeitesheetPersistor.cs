using System.IO;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Packer.Model.ImageProcessing
{
    public interface ISpeitesheetPersistor
    {
        void Save(string xml, IImage image, string outputDirectory, string animationName, string imageExt);
    }

    [Dependency]
    internal class SpeitesheetPersistor : ISpeitesheetPersistor
    {
        public void Save(string xml, IImage image, string outputDirectory, string animationName, string imageExt)
        {
            var path = Path.Combine(outputDirectory, animationName);
            File.WriteAllText($"{path}.xml", xml);
            image.Save($"{path}.{imageExt}");
        }
    }
}
