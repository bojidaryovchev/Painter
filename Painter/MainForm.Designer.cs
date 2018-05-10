namespace Painter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.ComponentModel;

    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
        private Button openButton;
        private Button saveAsButton;
        private Button importButton;
        private Button copyButton;
        private Button pasteButton;
        private Button embedImagesButton;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private FlowLayoutPanel flowLayoutPanel;

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
            this.openButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.importButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            this.embedImagesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(12, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(50, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OnOpenButtonClick);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(68, 12);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 3;
            this.saveAsButton.Text = "Save as";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.OnSaveAsButtonClick);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 41);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(760, 508);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(149, 12);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 5;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.OnImportButtonClick);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(230, 12);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 6;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.OnCopyButtonClick);
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(312, 13);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(75, 23);
            this.pasteButton.TabIndex = 7;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.OnPasteButtonClick);
            // 
            // embedImagesButton
            // 
            this.embedImagesButton.Location = new System.Drawing.Point(393, 13);
            this.embedImagesButton.Name = "embedImagesButton";
            this.embedImagesButton.Size = new System.Drawing.Size(115, 23);
            this.embedImagesButton.TabIndex = 8;
            this.embedImagesButton.Text = "Embed Images";
            this.embedImagesButton.UseVisualStyleBackColor = true;
            this.embedImagesButton.Click += new System.EventHandler(this.OnEmbedImagesButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.embedImagesButton);
            this.Controls.Add(this.pasteButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.openButton);
            this.Name = "MainForm";
            this.Text = "Painter";
            this.Resize += new System.EventHandler(this.OnResize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

