namespace Loupedeck.KgTestPlugin
{
    using System;

    public class OriginalAction : PluginDynamicCommand
    {
       // private readonly String[] _names = new[] { "(VirtualKeyCode.KeyR, ModifierKey.Control | ModifierKey.Shift);", "Liam Smith" };

        public OriginalAction()
            : base(displayName: "Create original new R script", description: "Create original new R script", groupName: "Original")
        {
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {

            var ResourcePath = EmbeddedResources.FindFile("Original.png");

            using (var bitmapBuilder = new BitmapBuilder(imageSize))

            {
                if (ResourcePath == null)
                {
                    bitmapBuilder.FillRectangle(0, 0, 80, 80, new BitmapColor(153, 204, 0));
                    bitmapBuilder.DrawText("Create original new R script", color: new BitmapColor(0, 0, 0));
                    return bitmapBuilder.ToImage();
                }
                else
                {
                    bitmapBuilder.SetBackgroundImage(EmbeddedResources.ReadImage(ResourcePath));
                    bitmapBuilder.DrawText("Image", color: new BitmapColor(0, 0, 0));
                    return bitmapBuilder.ToImage();
                }
            }
        }

        protected override void RunCommand(String actionParameter)
        {

            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyN, ModifierKey.Control | ModifierKey.Shift);
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.NumPad1, ModifierKey.Control);
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.F12, ModifierKey.Control);
            this.NativeApi.GetNativeMethods().SendString("#Install the HogeHoge package if it is not already there");
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Return);
            this.NativeApi.GetNativeMethods().SendString("if (!require(\"HogeHoge\", quietly = TRUE)) {");
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Return);
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Return);
            this.NativeApi.GetNativeMethods().SendString("install.packages(\"HogeHoge\");require(\"HogeHoge\")");
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Return);
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.End, ModifierKey.Control);
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Return);
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Return);
            this.NativeApi.GetNativeMethods().SendString("#Loading the library");
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Return);
            this.NativeApi.GetNativeMethods().SendString("library(\"HogeHoge\")");

        }
    }
}
