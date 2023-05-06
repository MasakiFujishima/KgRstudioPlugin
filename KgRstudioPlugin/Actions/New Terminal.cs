namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class NewTerminal : PluginDynamicCommand
    {
        public NewTerminal()
        : base(displayName: "New Terminal", description: "New Terminal", groupName: "Terminal")
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
                    bitmapBuilder.DrawText("New Terminal", color: new BitmapColor(37,26,25));
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
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyR, ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
