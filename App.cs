using Android.App;
using Android.Content;
using Android.Content.PM;
using StereoKit;

namespace hexr_launcher;
public class App
{
    public readonly ApplicationInfo Info;
    public readonly string Label;
    public readonly bool System;

    public App(ApplicationInfo info, PackageManager pm)
    {
        this.Info = info;
        this.Label = this.Info.LoadLabel(pm);
        this.System = (this.Info.Flags & ApplicationInfoFlags.System) != 0;
    }

    public void Draw()
    {
        if (this.Info.Name == null)
        {
            return;
        }
        UI.PushId(this.Info.Name ?? this.Info.PackageName ?? this.Info.StorageUuid?.ToString() ?? "i give up lol");
        UI.Label(this.Label ?? "Unknown App");
        UI.SameLine();
        if (UI.Button("Run"))
        {
            Intent? intent = Application.Context.PackageManager?.GetLaunchIntentForPackage(this.Info.Name!);
            intent?.SetAction(Intent.ActionMain);
            intent?.AddCategory(Intent.CategoryLauncher);
            intent?.SetFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
            // SK.Quit();
        }
        UI.PopId();
    }

}