namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class ShowKeyboardShortcutReference : PluginDynamicCommand
    {
        public ShowKeyboardShortcutReference()
        : base(displayName: "Show Keyboard Shortcut Reference", description: "Show Keyboard Shortcut Reference", groupName: "Help")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Help.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(5,44,23));
                    bitmapBuilder.DrawText("Show Keyboard Shortcut Reference", color: new BitmapColor(238,205,225));
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
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyK, ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
