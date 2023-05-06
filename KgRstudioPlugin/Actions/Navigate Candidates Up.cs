namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class NavigateCandidatesUp : PluginDynamicCommand
    {
        public NavigateCandidatesUp()
        : base(displayName: "Navigate Candidates Up", description: "Navigate Candidates Up", groupName: "Completions (Console and Source)")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Completions (Console and Source).png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(229,212,232));
                    bitmapBuilder.DrawText("Navigate Candidates Up", color: new BitmapColor(23,42,19));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(23,42,19));
                    return bitmapBuilder.ToImage();
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.ArrowUp);
        }
    }
}
