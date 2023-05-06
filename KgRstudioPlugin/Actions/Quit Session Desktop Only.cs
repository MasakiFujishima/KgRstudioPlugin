namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class QuitSessionDesktopOnly : PluginDynamicCommand
    {
        public QuitSessionDesktopOnly()
        : base(displayName: "Quit Session Desktop Only", description: "Quit Session Desktop Only", groupName: "Session")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Session.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(215,224,215));
                    bitmapBuilder.DrawText("Quit Session Desktop Only", color: new BitmapColor(20,8,25));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(20,8,25));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyQ, ModifierKey.Control);
        }
    }
}
