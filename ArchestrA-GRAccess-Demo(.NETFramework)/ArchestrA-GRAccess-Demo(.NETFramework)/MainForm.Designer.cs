using System.Drawing;
using System.Windows.Forms;

namespace ArchestrA_GRAccess_Demo_.NETFramework_
{
    partial class MainForm
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
            this.buttonEnumerateGalaxies = new System.Windows.Forms.Button();
            this.textBoxNodeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSetInitialConfig = new System.Windows.Forms.Button();
            this.buttonCreateNewGalaxy = new System.Windows.Forms.Button();
            this.textBoxGalaxyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonInsertObject = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonLoginIntoGalaxy = new System.Windows.Forms.Button();
            this.comboBoxGalaxiesOnServer = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxGalaxyTemplates = new System.Windows.Forms.ComboBox();
            this.buttonEnumerateTemplates = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEnumerateGalaxies
            // 
            this.buttonEnumerateGalaxies.Location = new System.Drawing.Point(16, 29);
            this.buttonEnumerateGalaxies.Name = "buttonEnumerateGalaxies";
            this.buttonEnumerateGalaxies.Size = new System.Drawing.Size(162, 29);
            this.buttonEnumerateGalaxies.TabIndex = 0;
            this.buttonEnumerateGalaxies.Text = "Enumerate Galaxies";
            this.buttonEnumerateGalaxies.UseVisualStyleBackColor = true;
            buttonEnumerateGalaxies.Click += buttonEnumerateGalaxies_Click;
            // 
            // textBoxNodeName
            // 
            this.textBoxNodeName.Location = new System.Drawing.Point(16, 40);
            this.textBoxNodeName.Name = "textBoxNodeName";
            this.textBoxNodeName.Size = new System.Drawing.Size(124, 20);
            this.textBoxNodeName.TabIndex = 1;
            this.textBoxNodeName.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Node name";
            // 
            // buttonSetInitialConfig
            // 
            this.buttonSetInitialConfig.Location = new System.Drawing.Point(153, 35);
            this.buttonSetInitialConfig.Name = "buttonSetInitialConfig";
            this.buttonSetInitialConfig.Size = new System.Drawing.Size(162, 29);
            this.buttonSetInitialConfig.TabIndex = 3;
            this.buttonSetInitialConfig.Text = "Set initial configuration";
            this.buttonSetInitialConfig.UseVisualStyleBackColor = true;
            buttonSetInitialConfig.Click += buttonSetInitialConfig_Click;
            // 
            // buttonCreateNewGalaxy
            // 
            this.buttonCreateNewGalaxy.Location = new System.Drawing.Point(153, 33);
            this.buttonCreateNewGalaxy.Name = "buttonCreateNewGalaxy";
            this.buttonCreateNewGalaxy.Size = new System.Drawing.Size(162, 29);
            this.buttonCreateNewGalaxy.TabIndex = 4;
            this.buttonCreateNewGalaxy.Text = "Create new Galaxy";
            this.buttonCreateNewGalaxy.UseVisualStyleBackColor = true;
            buttonCreateNewGalaxy.Click += buttonCreateNewGalaxy_Click;
            // 
            // textBoxGalaxyName
            // 
            this.textBoxGalaxyName.Location = new System.Drawing.Point(16, 38);
            this.textBoxGalaxyName.Name = "textBoxGalaxyName";
            this.textBoxGalaxyName.Size = new System.Drawing.Size(124, 20);
            this.textBoxGalaxyName.TabIndex = 5;
            this.textBoxGalaxyName.Text = "MyCSharpGalaxy1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Galaxy Name";
            // 
            // buttonInsertObject
            // 
            this.buttonInsertObject.Enabled = false;
            this.buttonInsertObject.Location = new System.Drawing.Point(16, 28);
            this.buttonInsertObject.Name = "buttonInsertObject";
            this.buttonInsertObject.Size = new System.Drawing.Size(162, 29);
            this.buttonInsertObject.TabIndex = 7;
            this.buttonInsertObject.Text = "Insert object into Galaxy";
            this.buttonInsertObject.UseVisualStyleBackColor = true;
            buttonInsertObject.Click += buttonInsertObject_Click;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxNodeName);
            this.groupBox1.Controls.Add(this.buttonSetInitialConfig);
            this.groupBox1.Location = new System.Drawing.Point(20, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 75);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Goal 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonLoginIntoGalaxy);
            this.groupBox2.Controls.Add(this.comboBoxGalaxiesOnServer);
            this.groupBox2.Controls.Add(this.buttonEnumerateGalaxies);
            this.groupBox2.Location = new System.Drawing.Point(20, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 114);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Goal 3";
            // 
            // buttonLoginIntoGalaxy
            // 
            this.buttonLoginIntoGalaxy.Location = new System.Drawing.Point(235, 67);
            this.buttonLoginIntoGalaxy.Name = "buttonLoginIntoGalaxy";
            this.buttonLoginIntoGalaxy.Size = new System.Drawing.Size(162, 29);
            this.buttonLoginIntoGalaxy.TabIndex = 2;
            this.buttonLoginIntoGalaxy.Text = "Login into Galaxy";
            this.buttonLoginIntoGalaxy.UseVisualStyleBackColor = true;
            buttonLoginIntoGalaxy.Click += buttonLoginIntoGalaxy_Click;
            // 
            // comboBoxGalaxiesOnServer
            // 
            this.comboBoxGalaxiesOnServer.FormattingEnabled = true;
            this.comboBoxGalaxiesOnServer.Location = new System.Drawing.Point(207, 34);
            this.comboBoxGalaxiesOnServer.Name = "comboBoxGalaxiesOnServer";
            this.comboBoxGalaxiesOnServer.Size = new System.Drawing.Size(191, 21);
            this.comboBoxGalaxiesOnServer.TabIndex = 1;
            comboBoxGalaxyTemplates.SelectedIndexChanged += comboBoxGalaxyTemplates_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxGalaxyName);
            this.groupBox3.Controls.Add(this.buttonCreateNewGalaxy);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(20, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 75);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Goal 2";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonInsertObject);
            this.groupBox4.Location = new System.Drawing.Point(20, 380);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(419, 75);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Goal 5";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxGalaxyTemplates);
            this.groupBox5.Controls.Add(this.buttonEnumerateTemplates);
            this.groupBox5.Location = new System.Drawing.Point(20, 299);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(419, 75);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Goal 4";
            // 
            // comboBoxGalaxyTemplates
            // 
            this.comboBoxGalaxyTemplates.Enabled = false;
            this.comboBoxGalaxyTemplates.FormattingEnabled = true;
            this.comboBoxGalaxyTemplates.Location = new System.Drawing.Point(207, 33);
            this.comboBoxGalaxyTemplates.Name = "comboBoxGalaxyTemplates";
            this.comboBoxGalaxyTemplates.Size = new System.Drawing.Size(191, 21);
            this.comboBoxGalaxyTemplates.TabIndex = 13;
            comboBoxGalaxyTemplates.SelectedIndexChanged += comboBoxGalaxyTemplates_SelectedIndexChanged;
            // 
            // buttonEnumerateTemplates
            // 
            this.buttonEnumerateTemplates.Enabled = false;
            this.buttonEnumerateTemplates.Location = new System.Drawing.Point(16, 28);
            this.buttonEnumerateTemplates.Name = "buttonEnumerateTemplates";
            this.buttonEnumerateTemplates.Size = new System.Drawing.Size(162, 29);
            this.buttonEnumerateTemplates.TabIndex = 7;
            this.buttonEnumerateTemplates.Text = "Enumerate Galaxy Templates";
            this.buttonEnumerateTemplates.UseVisualStyleBackColor = true;
            buttonEnumerateTemplates.Click += buttonEnumerateTemplates_Click;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 470);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aveva GR Access Demo";  
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonEnumerateGalaxies;
        private System.Windows.Forms.TextBox textBoxNodeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSetInitialConfig;
        private System.Windows.Forms.Button buttonCreateNewGalaxy;
        private System.Windows.Forms.TextBox textBoxGalaxyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonInsertObject;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxGalaxiesOnServer;
        private System.Windows.Forms.Button buttonLoginIntoGalaxy;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonEnumerateTemplates;
        private System.Windows.Forms.ComboBox comboBoxGalaxyTemplates;
    }
}

