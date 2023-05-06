namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class TestPackageDesktop : PluginDynamicCommand
    {
        public TestPackageDesktop()
        : base(displayName: "Test Package Desktop", description: "Test Package Desktop", groupName: "Build")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Build.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(228,193,46));
                    bitmapBuilder.DrawText("Test Package Desktop", color: new BitmapColor(4,0,0));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(4,0,0));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyT, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
