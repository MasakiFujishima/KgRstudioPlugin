namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class SelectPageDown : PluginDynamicCommand
    {
        public SelectPageDown()
        : base(displayName: "Select Page Down", description: "Select Page Down", groupName: "Editing (Console and Source)")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Editing (Console and Source).png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(38,87,45));
                    bitmapBuilder.DrawText("Select Page Down", color: new BitmapColor(241,228,240));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(241,228,240));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.PageDown, ModifierKey.Shift);
        }
    }
}
