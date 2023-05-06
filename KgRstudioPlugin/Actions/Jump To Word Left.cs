namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class JumpToWordLeft : PluginDynamicCommand
    {
        public JumpToWordLeft()
        : base(displayName: "Jump To Word Left", description: "Jump To Word Left", groupName: "Editing (Console and Source)")
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
                    bitmapBuilder.DrawText("Jump To Word Left", color: new BitmapColor(241,228,240));
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
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.ArrowLeft, ModifierKey.Control);
        }
    }
}
