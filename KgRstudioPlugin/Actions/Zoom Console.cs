namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class ZoomConsole : PluginDynamicCommand
    {
        public ZoomConsole()
        : base(displayName: "Zoom Console", description: "Zoom Console", groupName: "Views")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Views.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(149,85,158));
                    bitmapBuilder.DrawText("Zoom Console", color: new BitmapColor(238,205,225));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(238,205,225));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.NumPad2, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
