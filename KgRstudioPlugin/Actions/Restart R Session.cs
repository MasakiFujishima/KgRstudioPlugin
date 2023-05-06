namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class RestartRSession : PluginDynamicCommand
    {
        public RestartRSession()
        : base(displayName: "Restart R Session", description: "Restart R Session", groupName: "Session")
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
                    bitmapBuilder.DrawText("Restart R Session", color: new BitmapColor(20,8,25));
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
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.F10, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
