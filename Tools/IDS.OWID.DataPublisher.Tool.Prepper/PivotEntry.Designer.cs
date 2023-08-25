namespace IDS.OWID.DataPublisher.Tool.Prepper
{
  partial class PivotEntry
  {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
      txt_label = new Telerik.WinControls.UI.RadTextBox();
      box_x = new Telerik.WinControls.UI.RadAutoCompleteBox();
      box_y = new Telerik.WinControls.UI.RadAutoCompleteBox();
      box_v = new Telerik.WinControls.UI.RadAutoCompleteBox();
      drop_func = new Telerik.WinControls.UI.RadDropDownList();
      ((System.ComponentModel.ISupportInitialize)txt_label).BeginInit();
      ((System.ComponentModel.ISupportInitialize)box_x).BeginInit();
      ((System.ComponentModel.ISupportInitialize)box_y).BeginInit();
      ((System.ComponentModel.ISupportInitialize)box_v).BeginInit();
      ((System.ComponentModel.ISupportInitialize)drop_func).BeginInit();
      SuspendLayout();
      // 
      // txt_label
      // 
      txt_label.Dock = System.Windows.Forms.DockStyle.Top;
      txt_label.Location = new System.Drawing.Point(0, 0);
      txt_label.Name = "txt_label";
      txt_label.NullText = "Bezeichnung eingeben (wird später angezeigt)...";
      txt_label.Size = new System.Drawing.Size(488, 24);
      txt_label.TabIndex = 1;
      // 
      // box_x
      // 
      box_x.Dock = System.Windows.Forms.DockStyle.Top;
      box_x.Location = new System.Drawing.Point(0, 24);
      box_x.Name = "box_x";
      box_x.NullText = "Spalten (X-Achse) eingeben...";
      box_x.Size = new System.Drawing.Size(488, 26);
      box_x.TabIndex = 2;
      // 
      // box_y
      // 
      box_y.Dock = System.Windows.Forms.DockStyle.Top;
      box_y.Location = new System.Drawing.Point(0, 50);
      box_y.Name = "box_y";
      box_y.NullText = "Zeilen (Y-Achse) eingeben...";
      box_y.Size = new System.Drawing.Size(488, 26);
      box_y.TabIndex = 3;
      // 
      // box_v
      // 
      box_v.Dock = System.Windows.Forms.DockStyle.Top;
      box_v.Location = new System.Drawing.Point(0, 76);
      box_v.Name = "box_v";
      box_v.NullText = "Werte eingeben...";
      box_v.Size = new System.Drawing.Size(488, 26);
      box_v.TabIndex = 4;
      // 
      // drop_func
      // 
      drop_func.Dock = System.Windows.Forms.DockStyle.Top;
      drop_func.DropDownAnimationEnabled = true;
      radListDataItem1.Text = "avg";
      radListDataItem2.Text = "count";
      radListDataItem3.Text = "max";
      radListDataItem4.Text = "min";
      radListDataItem5.Text = "sum";
      drop_func.Items.Add(radListDataItem1);
      drop_func.Items.Add(radListDataItem2);
      drop_func.Items.Add(radListDataItem3);
      drop_func.Items.Add(radListDataItem4);
      drop_func.Items.Add(radListDataItem5);
      drop_func.Location = new System.Drawing.Point(0, 102);
      drop_func.Name = "drop_func";
      drop_func.NullText = "Wert aggregation eingeben...";
      drop_func.Size = new System.Drawing.Size(488, 24);
      drop_func.TabIndex = 5;
      // 
      // PivotEntry
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      Controls.Add(drop_func);
      Controls.Add(box_v);
      Controls.Add(box_y);
      Controls.Add(box_x);
      Controls.Add(txt_label);
      Name = "PivotEntry";
      Size = new System.Drawing.Size(488, 128);
      ((System.ComponentModel.ISupportInitialize)txt_label).EndInit();
      ((System.ComponentModel.ISupportInitialize)box_x).EndInit();
      ((System.ComponentModel.ISupportInitialize)box_y).EndInit();
      ((System.ComponentModel.ISupportInitialize)box_v).EndInit();
      ((System.ComponentModel.ISupportInitialize)drop_func).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Telerik.WinControls.UI.RadTextBox txt_label;
    private Telerik.WinControls.UI.RadAutoCompleteBox box_x;
    private Telerik.WinControls.UI.RadAutoCompleteBox box_y;
    private Telerik.WinControls.UI.RadAutoCompleteBox box_v;
    private Telerik.WinControls.UI.RadDropDownList drop_func;
  }
}
