namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class DiffActiveSourceDocument : PluginDynamicCommand
    {
        public DiffActiveSourceDocument()
        : base(displayName: "Diff Active Source Document", description: "Diff Active Source Document", groupName: "Git/SVN")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Git/SVN.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(205,193,223));
                    bitmapBuilder.DrawText("Diff Active Source Document", color: new BitmapColor(172,56,35));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(172,56,35));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyD, ModifierKey.Control | ModifierKey.Alt);
        }
    }
}
