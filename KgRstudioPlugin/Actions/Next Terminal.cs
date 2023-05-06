namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class NextTerminal : PluginDynamicCommand
    {
        public NextTerminal()
        : base(displayName: "Next Terminal", description: "Next Terminal", groupName: "Terminal")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Terminal.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(117,201,216));
                    bitmapBuilder.DrawText("Next Terminal", color: new BitmapColor(37,26,25));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(37,26,25));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.F12, ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
