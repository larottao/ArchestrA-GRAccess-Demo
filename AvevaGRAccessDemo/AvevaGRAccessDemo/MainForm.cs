//Aveva GRAccess Demo
//By Luis Felipe La Rotta

//This solution requires the .DLL located on C:\Program Files (x86)\Common Files\ArchestrA\ArchestrA.GRAccess.dll
//My program is a demo with no commercial purposes and
//it is based on a code example publicly provided by © 2022 AVEVA Software, LLC. All rights reserved.
//See AVEVA's original code here:
//https://docs.aveva.com/bundle/sp-appserver/page/436618.html

using AvevaGRAccessDemo.Interfaces;
using AvevaGRAccessDemo.Models;
using AvevaGRAccessDemo.Services;

namespace AvevaGRAccessDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private IGalaxyOps _galaxyOps = new GalaxyService();

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxNodeName.Text = Environment.MachineName;
        }

        private void buttonEnumerateGalaxies_Click(object sender, EventArgs e)
        {
            var result = _galaxyOps.enumerateGalaxiesOnServer();

            MessageBox.Show(result.success ? "Galaxy List retrieved successfully!" : $"Error: {result.errorReason}");

            //TODO print each galaxy name
        }

        private void buttonSetInitialConfig_Click(object sender, EventArgs e)
        {
            var config = new InitialConfig
            {
                nodeName = textBoxNodeName.Text
            };

            var result = _galaxyOps.setInitialConfig(config);

            MessageBox.Show(result.success ? "Config set successfully!" : $"Error: {result.errorReason}");
        }

        private void buttonCreateNewGalaxy_Click(object sender, EventArgs e)
        {
            var result = _galaxyOps.createNewGalaxy(textBoxGalaxyName.Text);

            MessageBox.Show(result.success ? "New Galaxy created successfully!" : $"Error: {result.errorReason}");
        }

        private void buttonInsertObject_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}