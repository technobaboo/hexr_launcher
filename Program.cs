using StereoKit;

namespace hexr_launcher;

class Program
{
	static void Main(string[] args)
	{
		// Initialize StereoKit
		SKSettings settings = new()
		{
			appName = "HeXR Launcher",
			assetsFolder = "Assets",
			blendPreference = DisplayBlend.Blend,
			// overlayApp = true,
			// overlayPriority = 1,
			depthMode = DepthMode.D32,
		};
		if (!SK.Initialize(settings))
			return;

		// Create assets used by the app
		Pose windowPose = new(0, 0, -0.5f, Quat.FromAngles(0f, 180.0f, 0f));

		// Material grippableMaterial = Material.Default.Copy();
		// grippableMaterial[MatParamName.ColorTint] = Color.Black;
		// Material gripMaterial = new(Shader.FromFile("grippable"))
		// {
		// 	DepthTest = DepthTest.Equal,
		// 	Transparency = Transparency.Add,
		// };
		// gripMaterial[MatParamName.ColorTint] = Color.Hex(0x007fffff);
		// grippableMaterial.Chain = gripMaterial;
		// Mesh hexagon = Mesh.GenerateCylinder(0.1f, 0.01f, Vec3.Forward, 6);



		// Core application loop
		SK.Run(() =>
		{
			// hexagon.Draw(grippableMaterial, Matrix.T(0f, 0f, -0.25f));

			UI.WindowBegin("Application", ref windowPose);

			if (UI.Button("AR"))
			{
				Device.DisplayBlend = DisplayBlend.Blend;
			}
			UI.SameLine();
			if (UI.Button("VR"))
			{
				Device.DisplayBlend = DisplayBlend.Opaque;
			}



			UI.WindowEnd();
		});
	}
}