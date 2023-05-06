namespace Loupedeck.KgRstudioPlugin
{
    using System;

    public class RunPreviousSweaveRmdCode : PluginDynamicCommand
    {
        public RunPreviousSweaveRmdCode()
        : base(displayName: "Run Previous Sweave Rmd Code", description: "Run Previous Sweave Rmd Code", groupName: "Source")
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
                    bitmapBuilder.DrawText("Run Previous Sweave Rmd Code", color: new BitmapColor(68,13,43));
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
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyP, ModifierKey.Control | ModifierKey.Shift | ModifierKey.Alt);
        }
    }
}
