namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class FocusPreviousPane : PluginDynamicCommand
    {
        public FocusPreviousPane()
        : base(displayName: "Focus Previous Pane", description: "Focus Previous Pane", groupName: "Accessibility")
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
                    bitmapBuilder.DrawText("Focus Previous Pane", color: new BitmapColor(107,62,29));
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
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.F6, ModifierKey.Shift);
        }
    }
}
