using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DirectInput = Microsoft.DirectX.DirectInput;

namespace _3D_slalom_game
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			DX.DrawScreen();
			this.Invalidate();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DX.InitDX();
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
		}
	}

	public static class DX
	{
		private static Device dxDevice;

		private static DirectInput.Device Keyboard;
		private static DirectInput.KeyboardState keyState;

		private static Sprite sprite;

		public static void InitDX()
		{
			PresentParameters present_params = new PresentParameters();
			present_params.Windowed = true;
			present_params.SwapEffect = SwapEffect.Discard;

			dxDevice = new Device(0, DeviceType.Hardware, Program.mainForm, CreateFlags.SoftwareVertexProcessing, present_params);
			Keyboard = new Microsoft.DirectX.DirectInput.Device(DirectInput.SystemGuid.Keyboard);
			Keyboard.Acquire();
			sprite = new Sprite(dxDevice);

		}

		public static void CleanupDX()
		{
			sprite.Dispose();
			Keyboard.Dispose();
			dxDevice.Dispose();
		}

		public static void DrawScreen()
		{
			dxDevice.Clear(ClearFlags.Target, System.Drawing.Color.FromArgb(0, 0, 0).ToArgb(), 1.0f, 0);
			dxDevice.BeginScene();

			dxDevice.EndScene();
			dxDevice.Present();
		}
	}
}
