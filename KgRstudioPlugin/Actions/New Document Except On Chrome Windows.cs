namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class NewDocumentExceptOnChromeWindows : PluginDynamicCommand
    {
        public NewDocumentExceptOnChromeWindows()
        : base(displayName: "New Document Except On Chrome Windows", description: "New Document Except On Chrome Windows", groupName: "Source")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Source.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(188,223,201));
                    bitmapBuilder.DrawText("New Document Except On Chrome Windows", color: new BitmapColor(68,13,43));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(68,13,43));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyN, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
