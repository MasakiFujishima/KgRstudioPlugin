namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class InterruptCurrentlyExecutingCommand : PluginDynamicCommand
    {
        public InterruptCurrentlyExecutingCommand()
        : base(displayName: "Interrupt Currently Executing Command", description: "Interrupt Currently Executing Command", groupName: "Console")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Console.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(80,187,165));
                    bitmapBuilder.DrawText("Interrupt Currently Executing Command", color: new BitmapColor(4,0,1));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(4,0,1));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Escape);
        }
    }
}
