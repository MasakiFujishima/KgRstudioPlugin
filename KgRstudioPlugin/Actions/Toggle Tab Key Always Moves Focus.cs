namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class ToggleTabKeyAlwaysMovesFocus : PluginDynamicCommand
    {
        public ToggleTabKeyAlwaysMovesFocus()
        : base(displayName: "Toggle Tab Key Always Moves Focus", description: "Toggle Tab Key Always Moves Focus", groupName: "Accessibility")
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
                    bitmapBuilder.DrawText("Toggle Tab Key Always Moves Focus", color: new BitmapColor(107,62,29));
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
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyT, ModifierKey.Control | ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
