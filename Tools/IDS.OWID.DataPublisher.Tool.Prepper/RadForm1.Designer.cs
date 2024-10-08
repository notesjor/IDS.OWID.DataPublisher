﻿namespace IDS.OWID.DataPublisher.Tool.Prepper
{
  partial class RadForm1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      btn_open = new Telerik.WinControls.UI.CommandBarButton();
      btn_export = new Telerik.WinControls.UI.CommandBarButton();
      list = new Telerik.WinControls.UI.RadCheckedListBox();
      radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      datakey = new Telerik.WinControls.UI.RadTextBox();
      radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
      chk_readme = new Telerik.WinControls.UI.RadCheckBox();
      chk_licence = new Telerik.WinControls.UI.RadCheckBox();
      btn_add_readme = new Telerik.WinControls.UI.RadButton();
      btn_add_licence = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)radCommandBar1).BeginInit();
      ((System.ComponentModel.ISupportInitialize)list).BeginInit();
      ((System.ComponentModel.ISupportInitialize)radGroupBox1).BeginInit();
      radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)datakey).BeginInit();
      ((System.ComponentModel.ISupportInitialize)radGroupBox2).BeginInit();
      radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)radGroupBox4).BeginInit();
      radGroupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)chk_readme).BeginInit();
      ((System.ComponentModel.ISupportInitialize)chk_licence).BeginInit();
      ((System.ComponentModel.ISupportInitialize)btn_add_readme).BeginInit();
      ((System.ComponentModel.ISupportInitialize)btn_add_licence).BeginInit();
      ((System.ComponentModel.ISupportInitialize)this).BeginInit();
      SuspendLayout();
      // 
      // radCommandBar1
      // 
      radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      radCommandBar1.Location = new System.Drawing.Point(0, 0);
      radCommandBar1.Name = "radCommandBar1";
      radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] { commandBarRowElement1 });
      radCommandBar1.Size = new System.Drawing.Size(587, 31);
      radCommandBar1.TabIndex = 0;
      // 
      // commandBarRowElement1
      // 
      commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      commandBarRowElement1.Name = "commandBarRowElement1";
      commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] { commandBarStripElement1 });
      // 
      // commandBarStripElement1
      // 
      commandBarStripElement1.DisplayName = "commandBarStripElement1";
      commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] { btn_open, btn_export });
      commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_open
      // 
      btn_open.DisplayName = "commandBarButton1";
      btn_open.Image = Properties.Resources.folder_open_24px;
      btn_open.Name = "btn_open";
      btn_open.Text = "JSON-Laden";
      btn_open.Click += btn_open_Click;
      // 
      // btn_export
      // 
      btn_export.AutoEllipsis = true;
      btn_export.DisplayName = "commandBarButton2";
      btn_export.Image = Properties.Resources.save_24px;
      btn_export.Name = "btn_export";
      btn_export.Text = "SPLIT-JSON Erstellen";
      btn_export.Click += btn_export_Click;
      // 
      // list
      // 
      list.Dock = System.Windows.Forms.DockStyle.Fill;
      list.GroupItemSize = new System.Drawing.Size(200, 28);
      list.ItemSize = new System.Drawing.Size(200, 28);
      list.Location = new System.Drawing.Point(2, 18);
      list.Name = "list";
      list.Size = new System.Drawing.Size(583, 288);
      list.TabIndex = 1;
      // 
      // radGroupBox1
      // 
      radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      radGroupBox1.Controls.Add(datakey);
      radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(1);
      radGroupBox1.HeaderText = "1. Data-Key (Vorschlag ggf. ändern)";
      radGroupBox1.Location = new System.Drawing.Point(0, 31);
      radGroupBox1.Name = "radGroupBox1";
      radGroupBox1.Size = new System.Drawing.Size(587, 45);
      radGroupBox1.TabIndex = 2;
      radGroupBox1.Text = "1. Data-Key (Vorschlag ggf. ändern)";
      // 
      // datakey
      // 
      datakey.Dock = System.Windows.Forms.DockStyle.Fill;
      datakey.Location = new System.Drawing.Point(2, 18);
      datakey.Name = "datakey";
      datakey.Size = new System.Drawing.Size(583, 24);
      datakey.TabIndex = 0;
      datakey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // radGroupBox2
      // 
      radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      radGroupBox2.Controls.Add(list);
      radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      radGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(1);
      radGroupBox2.HeaderText = "2. Wählen Sie die Daten aus, die sie schützen möchten:";
      radGroupBox2.Location = new System.Drawing.Point(0, 76);
      radGroupBox2.Name = "radGroupBox2";
      radGroupBox2.Size = new System.Drawing.Size(587, 308);
      radGroupBox2.TabIndex = 3;
      radGroupBox2.Text = "2. Wählen Sie die Daten aus, die sie schützen möchten:";
      // 
      // radGroupBox4
      // 
      radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      radGroupBox4.Controls.Add(chk_readme);
      radGroupBox4.Controls.Add(chk_licence);
      radGroupBox4.Controls.Add(btn_add_readme);
      radGroupBox4.Controls.Add(btn_add_licence);
      radGroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
      radGroupBox4.HeaderMargin = new System.Windows.Forms.Padding(1);
      radGroupBox4.HeaderText = "3. README / LICENCE";
      radGroupBox4.Location = new System.Drawing.Point(0, 384);
      radGroupBox4.Name = "radGroupBox4";
      radGroupBox4.Size = new System.Drawing.Size(587, 45);
      radGroupBox4.TabIndex = 5;
      radGroupBox4.Text = "3. README / LICENCE";
      // 
      // chk_readme
      // 
      chk_readme.Dock = System.Windows.Forms.DockStyle.Right;
      chk_readme.Enabled = false;
      chk_readme.Location = new System.Drawing.Point(457, 18);
      chk_readme.Name = "chk_readme";
      chk_readme.ReadOnly = true;
      chk_readme.Size = new System.Drawing.Size(18, 18);
      chk_readme.TabIndex = 3;
      ((Telerik.WinControls.Primitives.BorderPrimitive)chk_readme.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
      ((Telerik.WinControls.Primitives.BorderPrimitive)chk_readme.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      // 
      // chk_licence
      // 
      chk_licence.Dock = System.Windows.Forms.DockStyle.Left;
      chk_licence.Enabled = false;
      chk_licence.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
      chk_licence.Location = new System.Drawing.Point(112, 18);
      chk_licence.Name = "chk_licence";
      chk_licence.ReadOnly = true;
      // 
      // 
      // 
      chk_licence.RootElement.ShadowColor = System.Drawing.Color.FromArgb(204, 204, 204);
      chk_licence.Size = new System.Drawing.Size(18, 18);
      chk_licence.TabIndex = 2;
      ((Telerik.WinControls.UI.RadCheckBoxElement)chk_licence.GetChildAt(0)).ShadowColor = System.Drawing.Color.FromArgb(204, 204, 204);
      ((Telerik.WinControls.UI.RadCheckBoxElement)chk_licence.GetChildAt(0)).FocusBorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
      ((Telerik.WinControls.UI.RadCheckBoxElement)chk_licence.GetChildAt(0)).ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
      ((Telerik.WinControls.Primitives.BorderPrimitive)chk_licence.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
      ((Telerik.WinControls.Primitives.BorderPrimitive)chk_licence.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1)).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      // 
      // btn_add_readme
      // 
      btn_add_readme.Dock = System.Windows.Forms.DockStyle.Right;
      btn_add_readme.Location = new System.Drawing.Point(475, 18);
      btn_add_readme.Name = "btn_add_readme";
      btn_add_readme.Size = new System.Drawing.Size(110, 25);
      btn_add_readme.TabIndex = 1;
      btn_add_readme.Text = "README";
      btn_add_readme.Click += btn_add_readme_Click;
      // 
      // btn_add_licence
      // 
      btn_add_licence.Dock = System.Windows.Forms.DockStyle.Left;
      btn_add_licence.Location = new System.Drawing.Point(2, 18);
      btn_add_licence.Name = "btn_add_licence";
      btn_add_licence.Size = new System.Drawing.Size(110, 25);
      btn_add_licence.TabIndex = 0;
      btn_add_licence.Text = "LICENCE";
      btn_add_licence.Click += btn_add_licence_Click;
      // 
      // RadForm1
      // 
      AutoScaleBaseSize = new System.Drawing.Size(7, 15);
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(587, 429);
      Controls.Add(radGroupBox2);
      Controls.Add(radGroupBox4);
      Controls.Add(radGroupBox1);
      Controls.Add(radCommandBar1);
      Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      Name = "RadForm1";
      Text = "DataPublisher - Prepper";
      ((System.ComponentModel.ISupportInitialize)radCommandBar1).EndInit();
      ((System.ComponentModel.ISupportInitialize)list).EndInit();
      ((System.ComponentModel.ISupportInitialize)radGroupBox1).EndInit();
      radGroupBox1.ResumeLayout(false);
      radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)datakey).EndInit();
      ((System.ComponentModel.ISupportInitialize)radGroupBox2).EndInit();
      radGroupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)radGroupBox4).EndInit();
      radGroupBox4.ResumeLayout(false);
      radGroupBox4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)chk_readme).EndInit();
      ((System.ComponentModel.ISupportInitialize)chk_licence).EndInit();
      ((System.ComponentModel.ISupportInitialize)btn_add_readme).EndInit();
      ((System.ComponentModel.ISupportInitialize)btn_add_licence).EndInit();
      ((System.ComponentModel.ISupportInitialize)this).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_open;
    private Telerik.WinControls.UI.CommandBarButton btn_export;
    private Telerik.WinControls.UI.RadCheckedListBox list;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadTextBox datakey;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
    private Telerik.WinControls.UI.RadCheckBox chk_readme;
    private Telerik.WinControls.UI.RadCheckBox chk_licence;
    private Telerik.WinControls.UI.RadButton btn_add_readme;
    private Telerik.WinControls.UI.RadButton btn_add_licence;
  }
}