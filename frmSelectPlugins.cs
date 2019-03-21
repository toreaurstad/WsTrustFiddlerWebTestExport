using Fiddler.WebTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Fiddler
{
	public class frmSelectPlugins : Form
	{
		private Button btnOk;

		private Button btnCancel;

		private CheckedListBox chkListPlugins;

		private List<PluginClassReference> m_AvailablePlugins;

		private List<PluginClassReference> m_SelectedPlugins;

		internal CheckBox cbAllowAutoComments;

		private System.ComponentModel.Container components;

		internal List<PluginClassReference> SelectedPlugins
		{
			get
			{
				return this.m_SelectedPlugins;
			}
			set
			{
				this.m_SelectedPlugins = value;
			}
		}

		internal frmSelectPlugins(List<PluginClassReference> AvailablePlugins)
		{
			this.InitializeComponent();
			this.m_AvailablePlugins = AvailablePlugins;
			this.PopulateListView();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.m_SelectedPlugins = new List<PluginClassReference>();
			foreach (PluginClassReference pluginRef in this.chkListPlugins.CheckedItems)
			{
				this.m_SelectedPlugins.Add(pluginRef);
			}
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.chkListPlugins = new CheckedListBox();
			this.btnOk = new Button();
			this.btnCancel = new Button();
			this.cbAllowAutoComments = new CheckBox();
			base.SuspendLayout();
			this.chkListPlugins.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.chkListPlugins.CheckOnClick = true;
			this.chkListPlugins.Location = new Point(8, 8);
			this.chkListPlugins.Name = "chkListPlugins";
			this.chkListPlugins.Size = new System.Drawing.Size(424, 169);
			this.chkListPlugins.TabIndex = 0;
			this.btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new Point(276, 183);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new EventHandler(this.btnOk_Click);
			this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new Point(357, 183);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.cbAllowAutoComments.AutoSize = true;
			this.cbAllowAutoComments.Checked = true;
			this.cbAllowAutoComments.CheckState = CheckState.Checked;
			this.cbAllowAutoComments.Location = new Point(8, 187);
			this.cbAllowAutoComments.Name = "cbAllowAutoComments";
			this.cbAllowAutoComments.Size = new System.Drawing.Size(187, 17);
			this.cbAllowAutoComments.TabIndex = 3;
			this.cbAllowAutoComments.Text = "&Include AutoGenerated comments";
			this.cbAllowAutoComments.UseVisualStyleBackColor = true;
			base.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(442, 213);
			base.Controls.Add(this.cbAllowAutoComments);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.chkListPlugins);
			this.MinimumSize = new System.Drawing.Size(300, 200);
			base.Name = "frmSelectPlugins";
			base.ShowIcon = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Select Plugins";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void PopulateListView()
		{
			foreach (PluginClassReference pluginRef in this.m_AvailablePlugins)
			{
				this.chkListPlugins.Items.Add(pluginRef, true);
			}
		}
	}
}