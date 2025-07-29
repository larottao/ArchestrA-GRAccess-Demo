namespace AvevaGRAccessDemo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonEnumerateGalaxies = new Button();
            textBoxNodeName = new TextBox();
            label1 = new Label();
            buttonSetInitialConfig = new Button();
            buttonCreateNewGalaxy = new Button();
            textBoxGalaxyName = new TextBox();
            label2 = new Label();
            buttonInsertObject = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            comboBoxGalaxiesOnServer = new ComboBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            buttonLoginIntoGalaxy = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // buttonEnumerateGalaxies
            // 
            buttonEnumerateGalaxies.Location = new Point(19, 33);
            buttonEnumerateGalaxies.Name = "buttonEnumerateGalaxies";
            buttonEnumerateGalaxies.Size = new Size(144, 33);
            buttonEnumerateGalaxies.TabIndex = 0;
            buttonEnumerateGalaxies.Text = "Enumerate Galaxies";
            buttonEnumerateGalaxies.UseVisualStyleBackColor = true;
            buttonEnumerateGalaxies.Click += buttonEnumerateGalaxies_Click;
            // 
            // textBoxNodeName
            // 
            textBoxNodeName.Location = new Point(19, 46);
            textBoxNodeName.Name = "textBoxNodeName";
            textBoxNodeName.Size = new Size(144, 23);
            textBoxNodeName.TabIndex = 1;
            textBoxNodeName.Text = "127.0.0.1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 28);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 2;
            label1.Text = "Node name";
            // 
            // buttonSetInitialConfig
            // 
            buttonSetInitialConfig.Location = new Point(179, 40);
            buttonSetInitialConfig.Name = "buttonSetInitialConfig";
            buttonSetInitialConfig.Size = new Size(144, 33);
            buttonSetInitialConfig.TabIndex = 3;
            buttonSetInitialConfig.Text = "Set initial configuration";
            buttonSetInitialConfig.UseVisualStyleBackColor = true;
            buttonSetInitialConfig.Click += buttonSetInitialConfig_Click;
            // 
            // buttonCreateNewGalaxy
            // 
            buttonCreateNewGalaxy.Location = new Point(179, 38);
            buttonCreateNewGalaxy.Name = "buttonCreateNewGalaxy";
            buttonCreateNewGalaxy.Size = new Size(144, 33);
            buttonCreateNewGalaxy.TabIndex = 4;
            buttonCreateNewGalaxy.Text = "Create new Galaxy";
            buttonCreateNewGalaxy.UseVisualStyleBackColor = true;
            buttonCreateNewGalaxy.Click += buttonCreateNewGalaxy_Click;
            // 
            // textBoxGalaxyName
            // 
            textBoxGalaxyName.Location = new Point(19, 44);
            textBoxGalaxyName.Name = "textBoxGalaxyName";
            textBoxGalaxyName.Size = new Size(144, 23);
            textBoxGalaxyName.TabIndex = 5;
            textBoxGalaxyName.Text = "MyCSharpGalaxy1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 26);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 6;
            label2.Text = "Galaxy Name";
            // 
            // buttonInsertObject
            // 
            buttonInsertObject.Enabled = false;
            buttonInsertObject.Location = new Point(19, 32);
            buttonInsertObject.Name = "buttonInsertObject";
            buttonInsertObject.Size = new Size(144, 33);
            buttonInsertObject.TabIndex = 7;
            buttonInsertObject.Text = "Insert object into Galaxy";
            buttonInsertObject.UseVisualStyleBackColor = true;
            buttonInsertObject.Click += buttonInsertObject_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxNodeName);
            groupBox1.Controls.Add(buttonSetInitialConfig);
            groupBox1.Location = new Point(23, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(421, 87);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Goal 1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonLoginIntoGalaxy);
            groupBox2.Controls.Add(comboBoxGalaxiesOnServer);
            groupBox2.Controls.Add(buttonEnumerateGalaxies);
            groupBox2.Location = new Point(23, 132);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(421, 132);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Goal 2";
            // 
            // comboBoxGalaxiesOnServer
            // 
            comboBoxGalaxiesOnServer.FormattingEnabled = true;
            comboBoxGalaxiesOnServer.Location = new Point(179, 39);
            comboBoxGalaxiesOnServer.Name = "comboBoxGalaxiesOnServer";
            comboBoxGalaxiesOnServer.Size = new Size(222, 23);
            comboBoxGalaxiesOnServer.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxGalaxyName);
            groupBox3.Controls.Add(buttonCreateNewGalaxy);
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(23, 315);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(421, 87);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Goal 3";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(buttonInsertObject);
            groupBox4.Location = new Point(23, 418);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(421, 87);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Goal 4";
            // 
            // buttonLoginIntoGalaxy
            // 
            buttonLoginIntoGalaxy.Location = new Point(257, 77);
            buttonLoginIntoGalaxy.Name = "buttonLoginIntoGalaxy";
            buttonLoginIntoGalaxy.Size = new Size(144, 33);
            buttonLoginIntoGalaxy.TabIndex = 2;
            buttonLoginIntoGalaxy.Text = "Login into Galaxy";
            buttonLoginIntoGalaxy.UseVisualStyleBackColor = true;
            buttonLoginIntoGalaxy.Click += buttonLoginIntoGalaxy_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 537);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aveva GR Access Demo";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonEnumerateGalaxies;
        private TextBox textBoxNodeName;
        private Label label1;
        private Button buttonSetInitialConfig;
        private Button buttonCreateNewGalaxy;
        private TextBox textBoxGalaxyName;
        private Label label2;
        private Button buttonInsertObject;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private ComboBox comboBoxGalaxiesOnServer;
        private Button buttonLoginIntoGalaxy;
    }
}
