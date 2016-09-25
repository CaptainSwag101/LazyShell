using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using LazyShell.Properties;
using LazyShell.EventScripts;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.ThemeVS2013;

namespace LazyShell
{
	public static partial class Do
	{
		#region Form

		public static void AddControl(Control parent, Form child)
		{
			child.TopLevel = false;
			parent.Controls.Add(child);
			//child.WindowState = FormWindowState.Maximized;
			child.Show();
			child.BringToFront();
		}
		public static void RemoveControl(Form child)
		{
			child.WindowState = FormWindowState.Normal;
			child.Parent = null;
			child.TopLevel = true;
			child.Location = new Point(5, 5);
		}

		#endregion

		#region Draw list item

		public static void DrawIcon(
			object sender, DrawItemEventArgs e, Preview preview, int iconIndex,
			Fonts.Glyph[] font, int[] palette, bool shadow, Bitmap bgimage)
		{
			// set the pixels
			var temp = preview.GetPreview(font, palette,
				new char[] { (char)(e.Index + iconIndex) }, shadow, false);
			int[] pixels = new int[256 * 14];
			for (int y = 0, c = 0; y < 14; y++, c++)
			{
				for (int x = 2, a = 0; x < 256; x++, a++)
					pixels[y * 256 + x] = temp[c * 256 + a];
			}
			if (bgimage != null)
			{
				var background = new Rectangle(0, e.Index * 15 % bgimage.Height, bgimage.Width, 15);
				e.Graphics.DrawImage(bgimage, e.Bounds.X, e.Bounds.Y, background, GraphicsUnit.Pixel);
			}
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				e.DrawBackground();
			e.Graphics.DrawImage(Do.PixelsToImage(pixels, 256, 14), new Point(e.Bounds.X, e.Bounds.Y));
		}

		/// <summary>
		/// Paints the items in a DDList collection to a list control. 
		/// This should be invoked within a list control's DrawItem event handler.
		/// </summary>
		/// <param name="sender">Passed from the event handler.</param>
		/// <param name="e">Passed from the event handler.</param>
		/// <param name="preview">The preview class that draws the items from a font.</param>
		/// <param name="names">The DDList collection containing the strings to draw.</param>
		/// <param name="font">The font to draw with.</param>
		/// <param name="palette">The font's palette to draw with.</param>
		/// <param name="xOffset">X coord's offset of pixels drawn on item.</param>
		/// <param name="yOffset">Y coord's offset of pixels drawn on item.</param>
		/// <param name="startIndex">The index within the DDlist collection to start at.</param>
		/// <param name="endIndex">The index within the DDlist collection to stop at.</param>
		/// <param name="lastEmpty">Sets whether or not the final index should be displayed as {NOTHING}.</param>
		/// <param name="shadow">If set, a shadow will be drawn around the font characters instead of a border.
		/// This reflects the appearance of font characters in a battle menu.</param>
		public static void DrawName(
			object sender, DrawItemEventArgs e, Preview preview, SortedList names,
			Fonts.Glyph[] font, int[] palette, int xOffset, int yOffset,
			int startIndex, int endIndex, bool lastEmpty, bool shadow, Bitmap bgimage)
		{
			if (e.Index < 0 || e.Index >= names.Names.Length)
				return;
			string name = names.Names[e.Index];
			// set the pixels
			var temp = preview.GetPreview(font, palette, name.ToCharArray(), shadow, false);
			var pixels = new int[256 * 32];
			for (int y = 0, c = yOffset; y < 14; y++, c++)
			{
				for (int x = 2, a = xOffset; x < 256; x++, a++)
					pixels[y * 256 + x] = temp[c * 256 + a];
			}
			if (bgimage != null)
			{
				var background = new Rectangle(0, e.Index * 15 % bgimage.Height, bgimage.Width, 15);
				e.Graphics.DrawImage(bgimage, e.Bounds.X, e.Bounds.Y, background, GraphicsUnit.Pixel);
			}
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				e.DrawBackground();
			if (lastEmpty && names.GetUnsortedIndex(e.Index) == names.Names.Length - 1)
				e.Graphics.DrawString("*** NOTHING ***", new Font("Arial Black", 7F), Brushes.White, e.Bounds.Location);
			else
				e.Graphics.DrawImage(Do.PixelsToImage(pixels, 256, 14), e.Bounds.Location);
		}
		public static void DrawName(
			object sender, DrawItemEventArgs e, Preview preview, SortedList names,
			Fonts.Glyph[] font, int[] palette, int xOffset, int yOffset,
			int startIndex, int endIndex, bool lastEmpty, bool shadow)
		{
			DrawName(sender, e, preview, names, font, palette, xOffset, yOffset, startIndex, endIndex, lastEmpty, shadow, null);
		}
		public static void DrawName(
			object sender, DrawItemEventArgs e, Preview preview, string[] names,
			Fonts.Glyph[] font, int[] palette, int xOffset, int yOffset,
			int startIndex, int endIndex, bool lastEmpty, bool shadow, Bitmap bgimage)
		{
			if (e.Index < 0 || e.Index >= names.Length)
				return;
			string name = names[e.Index];

			// set the pixels
			var temp = preview.GetPreview(font, palette, name.ToCharArray(), shadow, false);
			var pixels = new int[256 * 32];
			for (int y = 0, c = yOffset; y < 14; y++, c++)
			{
				for (int x = 2, a = xOffset; x < 256; x++, a++)
					pixels[y * 256 + x] = temp[c * 256 + a];
			}
			if (bgimage != null)
			{
				var background = new Rectangle(0, e.Index * 16 % bgimage.Height, bgimage.Width, 16);
				e.Graphics.DrawImage(bgimage, e.Bounds.X, e.Bounds.Y, background, GraphicsUnit.Pixel);
			}
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				e.DrawBackground();
			if (lastEmpty && e.Index == names.Length - 1)
				e.Graphics.DrawString("*** NOTHING ***", new Font("Arial Black", 7F), Brushes.White, e.Bounds.Location);
			else
				e.Graphics.DrawImage(Do.PixelsToImage(pixels, 256, 15), e.Bounds.Location);
		}
		public static void DrawName(
			object sender, DrawItemEventArgs e, Preview preview, SortedList names,
			Fonts.Glyph[] font, int[] palette, bool shadow)
		{
			DrawName(sender, e, preview, names, font, palette, 0, 0, 0, names.Names.Length, false, shadow, null);
		}
		public static void DrawName(
			object sender, DrawItemEventArgs e, Preview preview, SortedList names,
			Fonts.Glyph[] font, int[] palette, bool shadow, Bitmap bgimage)
		{
			DrawName(sender, e, preview, names, font, palette, 0, 0, 0, names.Names.Length, false, shadow, bgimage);
		}
		public static void DrawName(
			object sender, DrawItemEventArgs e, Preview preview, string[] names,
			Fonts.Glyph[] font, int[] palette, bool shadow, Bitmap bgimage)
		{
			DrawName(sender, e, preview, names, font, palette, 0, 0, 0, names.Length, false, shadow, bgimage);
		}
		public static void DrawName(
			object sender, DrawItemEventArgs e, Preview preview, SortedList names,
			Fonts.Glyph[] font, int[] palette, bool shadow, bool lastEmpty, Bitmap bgimage)
		{
			DrawName(sender, e, preview, names, font, palette, 0, 0, 0, names.Names.Length, lastEmpty, shadow, bgimage);
		}
		public static void DrawName(
			object sender, DrawItemEventArgs e, Preview preview, SortedList names,
			Fonts.Glyph[] font, int[] palette)
		{
			DrawName(sender, e, preview, names, font, palette, 0, 0, 0, names.Names.Length, false, false, null);
		}

		public static void DrawText(string text, int x, int y, Graphics g, Preview preview, Fonts.Glyph[] font, int[] palette)
		{
			var temp = preview.GetPreview(font, palette, text.ToCharArray(), false, false);
			g.DrawImage(Do.PixelsToImage(temp, 256, 14), x, y);
		}
		public static void DrawText(int[] dst, int dstWidth, char[] text, int x, int y, int rowHeight, Fonts.Glyph[] font, int[] palette)
		{
			int left = x;
			foreach (char letter in text)
			{
				if (letter == '\n' || letter == '\r')
				{
					x = left;
					y += rowHeight;
					continue;
				}
				var character = font[(byte)letter];
				var pixels = character.GetPixels(palette);
				PixelsToPixels(pixels, dst, dstWidth, new Rectangle(x, y, character.Width, character.Height));
				x += character.Width;
			}
		}

		#endregion

		#region TreeView

		public static void SelectAllNodes(TreeNodeCollection nodes, bool selected)
		{
			foreach (TreeNode tn in nodes)
			{
				tn.Checked = selected;
				SelectAllNodes(tn.Nodes, selected);
			}
		}
		public static void SelectAll(Control control, bool selected)
		{
			if (control is CheckBox)
				((CheckBox)control).Checked = selected;
			foreach (Control child in control.Controls)
				SelectAll(child, selected);
		}
		/// <summary>
		/// Enable or disable all or some controls within a parent control, starting at the parent control.
		/// Returns the controls that already have the enable status set.
		/// </summary>
		/// <param name="main">The main parent controls.</param>
		/// <param name="enable">Enable or disable the controls.</param>
		/// <param name="childOnly">If set to true, only controls that contain no child controls will be modified.</param>
		/// <param name="skip">The controls to ignore when changing enabled status.</param>
		public static ArrayList EnableControls(object main, bool enable, bool childOnly, bool firstLoop, params object[] skip)
		{
			if (firstLoop)
				set = new ArrayList();
			if (main is ToolStrip)
				foreach (ToolStripItem item in ((ToolStrip)main).Items)
				{
					if (!Do.Contains(item, skip))
						if (item.Enabled == enable)
							set.Add(item);
						else
							item.Enabled = enable;
				}
			else
				foreach (Control parent in ((Control)main).Controls)
				{
					if (parent.Controls.Count == 0 || !childOnly && !Do.Contains(parent, skip))
						if (parent.Enabled == enable)
							set.Add(parent);
						else
							parent.Enabled = enable;
					EnableControls(parent, enable, childOnly, false, skip);
				}
			return set;
		}
		private static ArrayList set = new ArrayList();
		// Get / set the scrollbar position of the treeview
		[DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern int GetScrollPos(int hWnd, int nBar);
		[DllImport("user32.dll")]
		public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
		private const int SB_HORZ = 0x0;
		private const int SB_VERT = 0x1;
		public static Point GetTreeViewScrollPos(TreeView treeView)
		{
			return new Point(
				GetScrollPos((int)treeView.Handle, SB_HORZ),
				GetScrollPos((int)treeView.Handle, SB_VERT));
		}
		public static void SetTreeViewScrollPos(TreeView treeView, Point scrollPosition)
		{
			SetScrollPos((IntPtr)treeView.Handle, SB_HORZ, scrollPosition.X, true);
			SetScrollPos((IntPtr)treeView.Handle, SB_VERT, scrollPosition.Y, true);
		}

		#endregion

		#region ListView

		/// <summary>
		/// 
		/// </summary>
		/// <param name="listView"></param>
		/// <param name="unsorted">Return the item's original unsorted index</param>
		/// <returns></returns>
		public static int GetSelectedIndex(ListView listView, bool unsorted)
		{
			for (int i = 0; i < listView.Items.Count; i++)
				if (listView.Items[i].Selected)
					return unsorted ? (int)listView.Items[i].Tag : i;
			return -1;
		}
		public static int GetSelectedIndex(ListView listView)
		{
			return GetSelectedIndex(listView, false);
		}
		public static void SortListView(ListView listView, ListViewColumnSorter lvwColumnSorter, int column)
		{
			if (column == lvwColumnSorter.SortColumn)
			{
				// Reverse the current sort direction for this column.
				if (lvwColumnSorter.Order == SortOrder.Ascending)
				{
					lvwColumnSorter.Order = SortOrder.Descending;
				}
				else
				{
					lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}
			// Perform the sort with these new sort options.
			listView.Sort();
		}

		#endregion

		#region ToolStrip

		public static Point GetControlLocation(ToolStripButton toolStripButton)
		{
			var point = new Point(toolStripButton.Bounds.X + toolStripButton.Width, toolStripButton.Bounds.Y);
			return toolStripButton.GetCurrentParent().PointToScreen(point);
		}
		public static void RemoveClickEvent(ToolStripMenuItem b)
		{
			var f1 = typeof(Control).GetField("EventClick",
				BindingFlags.Static | BindingFlags.NonPublic);
			object obj = f1.GetValue(b);
			var pi = b.GetType().GetProperty("Events",
				BindingFlags.NonPublic | BindingFlags.Instance);
			var list = (EventHandlerList)pi.GetValue(b, null);
			list.RemoveHandler(obj, list[obj]);
		}
		public static void ResetToolStripButtons(ToolStrip toolstrip, ToolStripButton skip1, ToolStripButton skip2)
		{
			foreach (ToolStripItem item in toolstrip.Items)
				if (item is ToolStripButton)
					if (item != skip1 && item != skip2)
						((ToolStripButton)item).Checked = false;
		}
		public static void ResetToolStripButtons(ToolStrip toolstrip, ToolStripButton skip1)
		{
			ResetToolStripButtons(toolstrip, skip1, null);
		}
		public static void ResetToolStripButtons(ToolStrip toolstrip)
		{
			ResetToolStripButtons(toolstrip, null, null);
		}
		public static void AlertLabel(ToolStripLabel labelAlert, string message, Color color)
		{
			new Thread(unused => AlertLabelThread(labelAlert, message, color)).Start();
		}
		private static void AlertLabelThread(ToolStripLabel labelAlert, string message, Color color)
		{
			var backcolor = labelAlert.BackColor;
			labelAlert.Visible = true;
			labelAlert.Text = message;
			for (int i = 0; i < 3; i++)
			{
				labelAlert.BackColor = color;
				Thread.Sleep(500);
				labelAlert.BackColor = backcolor;
				Thread.Sleep(500);
			}
			Thread.Sleep(500);
			labelAlert.Text = "";
			labelAlert.Visible = false;
		}

		/// <summary>
		/// Add a shortcut key to a toolstrip.
		/// </summary>
		/// <param name="toolStrip">The toolstrip to add to.</param>
		/// <param name="keys">The shortcut key.</param>
		/// <param name="eventHandler">The event handler to invoke when the shortcut is activated.</param>
		public static void AddShortcut(ToolStrip toolStrip, Keys keys, EventHandler eventHandler)
		{
			var shortcut = new ToolStripMenuItem();
			shortcut.ShortcutKeys = keys;
			shortcut.Visible = false;
			shortcut.Click += eventHandler;
			toolStrip.Items.Add(shortcut);
			//ToolStripMenuItem screencap = new ToolStripMenuItem();
			//screencap.ShortcutKeys = Keys.F3;
			//screencap.Visible = false;
			//screencap.Click += CaptureScreen_Click;
		}
		public static void AddShortcut(ToolStrip toolStrip, Keys keys, ToolStripButton checkable)
		{
			var shortcut = new ToolStripMenuItem();
			shortcut.ShortcutKeys = keys;
			shortcut.Visible = false;
			shortcut.Click += (s, e) => CheckButtonEvent(s, e, checkable);
			toolStrip.Items.Add(shortcut);
		}
		private static void CheckButtonEvent(object sender, EventArgs e, ToolStripButton button)
		{
			button.Checked = !button.Checked;
		}

		#endregion

		#region Window

		private const int SW_SHOWNOACTIVATE = 4;
		private const int HWND_TOPMOST = -1;
		private const uint SWP_NOACTIVATE = 0x0010;
		[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		private static extern bool SetWindowPos(
			 int hWnd,           // window handle
			 int hWndInsertAfter,    // placement-order handle
			 int X,          // horizontal position
			 int Y,          // vertical position
			 int cx,         // width
			 int cy,         // height
			 uint uFlags);       // window positioning flags
		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		public static void ShowInactiveTopmost(Form frm)
		{
			ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
			SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
			frm.Left, frm.Top, frm.Width, frm.Height,
			SWP_NOACTIVATE);
		}
		public static Rectangle GetVisibleBounds(Control control)
		{
			var c = control;
			var r = c.RectangleToScreen(c.ClientRectangle);
			while (c != null)
			{
				r = Rectangle.Intersect(r, c.RectangleToScreen(c.ClientRectangle));
				c = c.Parent;
			}
			r = control.RectangleToClient(r);
			return r;
		}

		#endregion

	}
}
