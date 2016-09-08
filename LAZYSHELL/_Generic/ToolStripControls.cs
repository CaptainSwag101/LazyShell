using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace LazyShell.Controls
{
	[ToolboxItem(true)]
	public class NewToolStripComboBox : ToolStripControlHost
	{
		// Constructor
		public NewToolStripComboBox()
			: base(new NewComboBox())
		{
			this.DropDownControl.FlatStyle = FlatStyle.Popup;
			this.DropDownControl.Margin = new Padding(1, 0, 1, 0);
		}

		#region Properties

		private NewComboBox DropDownControl
		{
			get { return Control as NewComboBox; }
		}
		public DrawMode DrawMode
		{
			get { return DropDownControl.DrawMode; }
			set { DropDownControl.DrawMode = value; }
		}
		public int DropDownHeight
		{
			get { return DropDownControl.DropDownHeight; }
			set { DropDownControl.DropDownHeight = value; }
		}
		public ComboBoxStyle DropDownStyle
		{
			get { return DropDownControl.DropDownStyle; }
			set { DropDownControl.DropDownStyle = value; }
		}
		public int DropDownWidth
		{
			get { return DropDownControl.DropDownWidth; }
			set { DropDownControl.DropDownWidth = value; }
		}
		public int ItemHeight
		{
			get { return DropDownControl.ItemHeight; }
			set { DropDownControl.ItemHeight = value; }
		}
		public ComboBox.ObjectCollection Items
		{
			get { return DropDownControl.Items; }
		}
		public Point Location
		{
			get { return DropDownControl.Location; }
			set { DropDownControl.Location = value; }
		}
		public int SelectedIndex
		{
			get { return DropDownControl.SelectedIndex; }
			set { DropDownControl.SelectedIndex = value; }
		}
		public object SelectedItem
		{
			get { return DropDownControl.SelectedItem; }
			set { DropDownControl.SelectedItem = value; }
		}
		public ContextMenuStrip ContextMenuStrip
		{
			get { return DropDownControl.ContextMenuStrip; }
			set { DropDownControl.ContextMenuStrip = value; }
		}

		#endregion

		#region Custom methods

		public void BeginUpdate()
		{
			DropDownControl.BeginUpdate();
		}
		public void EndUpdate()
		{
			DropDownControl.EndUpdate();
		}

		#endregion

		#region Event Handlers

		// Delegates
		public event EventHandler SelectedIndexChanged;
		public event DrawItemEventHandler DrawItem;

		// Methods
		protected override void OnSubscribeControlEvents(Control c)
		{
			base.OnSubscribeControlEvents(c);
			((ComboBox)c).SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
			((ComboBox)c).DrawItem += new DrawItemEventHandler(OnDrawItem);
		}
		protected override void OnUnsubscribeControlEvents(Control c)
		{
			base.OnUnsubscribeControlEvents(c);
			((ComboBox)c).SelectedIndexChanged -= new EventHandler(OnSelectedIndexChanged);
			((ComboBox)c).DrawItem -= new DrawItemEventHandler(OnDrawItem);
		}
		private void OnSelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedIndexChanged?.Invoke(this, e);
		}
		private void OnDrawItem(object sender, DrawItemEventArgs e)
		{
			DrawItem?.Invoke(this, e);
		}

		#endregion

		public class NewComboBox : ComboBox
		{
			private ComboEditWindow EditBox = new ComboEditWindow(); // the NativeWindow object, used to access and repaint the TextBox.
			protected override void OnHandleCreated(EventArgs e)
			{
				base.OnHandleCreated(e);
				//EditBox.AssignTextBoxHandle(this);
			}
		}

		public sealed class ComboEditWindow : NativeWindow
		{
			#region Windows messages

			// Custom rectangle
			[StructLayout(LayoutKind.Sequential)]
			private struct RECT
			{
				public int left;
				public int top;
				public int right;
				public int bottom;
			}

			// ComboBoxInfo
			[DllImport("user32")]
			private static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref ComboBoxInfo info);
			[StructLayout(LayoutKind.Sequential)]
			private struct ComboBoxInfo
			{
				public int cbSize;
				public RECT rcItem;
				public RECT rcButton;
				public IntPtr stateButton;
				public IntPtr hwndCombo;
				public IntPtr hwndEdit;
				public IntPtr hwndList;
			}

			// SendMessage
			[DllImport("user32", CharSet = CharSet.Auto)]
			private extern static int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

			// Constants
			private const int EC_LEFTMARGIN = 0x1;
			private const int EC_RIGHTMARGIN = 0x2;
			private const int WM_PAINT = 0xF;
			private const int WM_SETCURSOR = 0x20;
			private const int WM_LBUTTONDOWN = 0x201;
			private const int WM_KEYDOWN = 0x100;
			private const int WM_KEYUP = 0x101;
			private const int WM_CHAR = 0x102;
			private const int WM_GETTEXTLENGTH = 0xe;
			private const int WM_GETTEXT = 0xd;
			private const int EM_SETMARGINS = 0xD3;

			// Window process
			protected override void WndProc(ref Message m)
			{
				switch (m.Msg)
				{
					case WM_PAINT:
						base.WndProc(ref m);
						DrawImage();
						break;
					case WM_LBUTTONDOWN:
						base.WndProc(ref m);
						DrawImage();
						break;
					case WM_KEYDOWN:
						base.WndProc(ref m);
						DrawImage();
						break;
					case WM_KEYUP:
						base.WndProc(ref m);
						DrawImage();
						break;
					case WM_CHAR:
						base.WndProc(ref m);
						DrawImage();
						break;
					case WM_GETTEXTLENGTH:
						base.WndProc(ref m);
						DrawImage();
						break;
					case WM_GETTEXT:
						base.WndProc(ref m);
						DrawImage();
						break;
					default:
						base.WndProc(ref m);
						break;
				}
			}

			#endregion

			#region Handles

			// Variables
			private Graphics gfx;
			private NewComboBox Owner = null;
			private ComboBoxInfo cbxinfo = new ComboBoxInfo();

			// Methods
			public void DrawImage()
			{
				if (Owner.BackgroundImage != null)
				{
					// Gets a GDI drawing surface from the textbox.
					gfx = Graphics.FromHwnd(this.Handle);
					gfx.DrawImage(Owner.BackgroundImage, 0, 0);
					gfx.Flush();
					gfx.Dispose();
				}
			}
			public void AssignTextBoxHandle(NewComboBox owner)
			{
				Owner = owner;
				cbxinfo.cbSize = Marshal.SizeOf(cbxinfo);
				GetComboBoxInfo(Owner.Handle, ref cbxinfo);
				if (!this.Handle.Equals(IntPtr.Zero))
				{
					this.ReleaseHandle();
				}
				this.AssignHandle(cbxinfo.hwndEdit);
			}

			#endregion
		}
	}
	[ToolboxItem(true)]
	public class NewToolStripListView : ToolStripControlHost
	{
		// Constructor
		public NewToolStripListView()
			: base(new ListView())
		{
			ListViewControl.GridLines = true;
		}

		#region Properties

		private ListView ListViewControl
		{
			get { return Control as ListView; }
		}
		public ListView.ListViewItemCollection Items
		{
			get { return ListViewControl.Items; }
		}
		public ListView.ColumnHeaderCollection Columns
		{
			get { return ListViewControl.Columns; }
		}
		public View View
		{
			get { return ListViewControl.View; }
			set { ListViewControl.View = value; }
		}

		#endregion

		#region Event Handlers

		protected override void OnSubscribeControlEvents(Control c)
		{
			base.OnSubscribeControlEvents(c);
		}
		protected override void OnUnsubscribeControlEvents(Control c)
		{
			base.OnUnsubscribeControlEvents(c);
		}

		#endregion
	}
	[ToolboxItem(true)]
	public class NewToolStripNumericUpDown : ToolStripControlHost
	{
		// Constructor
		public NewToolStripNumericUpDown()
			: base(new NumericUpDown())
		{ }

		#region Properties

		private NumericUpDown NumericUpDownControl
		{
			get { return Control as NumericUpDown; }
		}
		public bool Hexadecimal
		{
			get { return NumericUpDownControl.Hexadecimal; }
			set { NumericUpDownControl.Hexadecimal = value; }
		}
		public Point Location
		{
			get { return NumericUpDownControl.Location; }
			set { NumericUpDownControl.Location = value; }
		}
		public decimal Maximum
		{
			get { return NumericUpDownControl.Maximum; }
			set { NumericUpDownControl.Maximum = value; }
		}
		public decimal Minimum
		{
			get { return NumericUpDownControl.Minimum; }
			set { NumericUpDownControl.Minimum = value; }
		}
		public new string Name
		{
			get { return NumericUpDownControl.Name; }
			set { NumericUpDownControl.Name = value; }
		}
		public decimal Value
		{
			get { return NumericUpDownControl.Value; }
			set { NumericUpDownControl.Value = value; }
		}
		public decimal Increment
		{
			get { return NumericUpDownControl.Increment; }
			set { NumericUpDownControl.Increment = value; }
		}
		public ContextMenuStrip ContextMenuStrip
		{
			get { return NumericUpDownControl.ContextMenuStrip; }
			set { NumericUpDownControl.ContextMenuStrip = value; }
		}

		#endregion

		#region Event Handlers

		// Delegates
		public event EventHandler ValueChanged;

		// Methods
		protected override void OnSubscribeControlEvents(Control c)
		{
			base.OnSubscribeControlEvents(c);
			((NumericUpDown)c).ValueChanged += new EventHandler(OnValueChanged);
		}
		protected override void OnUnsubscribeControlEvents(Control c)
		{
			base.OnUnsubscribeControlEvents(c);
			((NumericUpDown)c).ValueChanged -= new EventHandler(OnValueChanged);
		}
		private void OnValueChanged(object sender, EventArgs e)
		{
			if (ValueChanged != null)
				ValueChanged(this, e);
		}

		#endregion
	}
	[ToolboxItem(true)]
	public class NewToolStripTextBox : ToolStripControlHost
	{
		// Constructor
		public NewToolStripTextBox()
			: base(new TextBox())
		{
		}

		#region Properties

		private TextBox TextBoxControl
		{
			get { return Control as TextBox; }
		}
		public bool ReadOnly
		{
			get { return TextBoxControl.ReadOnly; }
			set { TextBoxControl.ReadOnly = value; }
		}

		#endregion

		#region Event Handlers

		protected override void OnSubscribeControlEvents(Control c)
		{
			base.OnSubscribeControlEvents(c);
		}
		protected override void OnUnsubscribeControlEvents(Control c)
		{
			base.OnUnsubscribeControlEvents(c);
		}

		#endregion
	}
	[ToolboxItem(true)]
	public class NewToolStripCheckBox : ToolStripControlHost
	{
		// Constructor
		public NewToolStripCheckBox()
			: base(new CheckBox())
		{
			this.BackColor = Color.Transparent;
			this.Padding = new Padding(4, 0, 0, 4);
		}

		#region Properties
		private CheckBox CheckBoxControl
		{
			get { return Control as CheckBox; }
		}
		public bool Checked
		{
			get { return CheckBoxControl.Checked; }
			set { CheckBoxControl.Checked = value; }
		}

		#endregion

		#region Event Handlers

		// Delegates
		public event EventHandler CheckedChanged;

		// Methods
		protected override void OnSubscribeControlEvents(Control c)
		{
			base.OnSubscribeControlEvents(c);
			((CheckBox)c).CheckedChanged += new EventHandler(OnCheckedChanged);
		}
		protected override void OnUnsubscribeControlEvents(Control c)
		{
			base.OnUnsubscribeControlEvents(c);
			((CheckBox)c).CheckedChanged -= new EventHandler(OnCheckedChanged);
		}
		private void OnCheckedChanged(object sender, EventArgs e)
		{
			if (CheckedChanged != null)
				CheckedChanged(this, e);
		}

		#endregion
	}

	public class NewToolStripButton : ToolStripButton
	{
		/// <summary>
		/// The form associated with this button.
		/// </summary>
		public Form Form { get; set; }

		// Event Handlers
		protected override void OnCheckedChanged(EventArgs e)
		{
			if (Form != null)
			{
				if (Form is DockForm)
				{
					if (this.Checked && (Form as DockForm).DockState != DockState.Hidden)
						return;
					if (!this.Checked && (Form as DockForm).DockState == DockState.Hidden)
						return;
					if (this.Checked)
						(Form as DockForm).Show();
					else
						(Form as DockForm).Hide();
				}
				else
					Form.Visible = this.Checked;
			}
		}
	}

}
