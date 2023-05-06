namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class FocusNextPane : PluginDynamicCommand
    {
        public FocusNextPane()
        : base(displayName: "Focus Next Pane", description: "Focus Next Pane", groupName: "Accessibility")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Accessibility.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(118,181,228));
                    bitmapBuilder.DrawText("Focus Next Pane", color: new BitmapColor(107,62,29));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(107,62,29));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.F6);
        }
    }
}
