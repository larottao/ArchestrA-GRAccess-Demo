//Aveva GRAccess Demo
//By Luis Felipe La Rotta

//This solution requires the .DLL located on C:\Program Files (x86)\Common Files\ArchestrA\ArchestrA.GRAccess.dll
//My program is a demo with no commercial purposes and
//it is based on a code example publicly provided by © 2022 AVEVA Software, LLC. All rights reserved.
//See AVEVA's original code here:
//https://docs.aveva.com/bundle/sp-appserver/page/436618.html

using ArchestrA.GRAccess;

using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ArchestrA_GRAccess_Demo_.NETFramework_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private IGalaxyOps _galaxyOps = new GalaxyService();

        #region UI related stuff region

        private enum UI_STATE
        { LOGGED_INTO_GALAXY, READY_TO_LOGIN }

        private UI_STATE currentUiState = UI_STATE.READY_TO_LOGIN;

        private void setNewUiState(UI_STATE argUiState)
        {
            currentUiState = argUiState;
            switch (argUiState)
            {
                case UI_STATE.READY_TO_LOGIN:

                    buttonLoginIntoGalaxy.Text = "Login into Galaxy";
                    comboBoxGalaxiesOnServer.Enabled = true;
                    buttonEnumerateTemplates.Enabled = false;
                    comboBoxGalaxyTemplates.Enabled = false;
                    buttonViewAttrib.Enabled = false;

                    break;

                case UI_STATE.LOGGED_INTO_GALAXY:

                    buttonLoginIntoGalaxy.Text = "Logout from Galaxy";
                    comboBoxGalaxiesOnServer.Enabled = false;
                    buttonEnumerateTemplates.Enabled = true;
                    comboBoxGalaxyTemplates.Enabled = true;
                    buttonViewAttrib.Enabled = true;

                    break;
            }
        }

        #endregion UI related stuff region

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxNodeName.Text = Environment.MachineName;
        }

        private void buttonEnumerateGalaxies_Click(object sender, EventArgs e)
        {
            var result = _galaxyOps.enumerateGalaxiesOnServer();

            if (!result.success)
            {
                MessageBox.Show(result.errorReason);
                return;
            }

            comboBoxGalaxiesOnServer.Items.Clear();

            foreach (IGalaxy galaxy in result.galaxiesOnServer)
            {
                comboBoxGalaxiesOnServer.Items.Add(galaxy.Name);
            }

            if (result.galaxiesOnServer.Any())
            {
                comboBoxGalaxiesOnServer.SelectedIndex = 0;
            }

            MessageBox.Show("Galaxies enumerated successfully!");
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

        private void buttonLoginIntoGalaxy_Click(object sender, EventArgs e)
        {
            if (currentUiState == UI_STATE.READY_TO_LOGIN)
            {
                if (comboBoxGalaxiesOnServer.SelectedIndex < 0)
                {
                    MessageBox.Show("Select a Galaxy first");
                    return;
                }

                var loginResult = _galaxyOps.loginIntoGalaxy(comboBoxGalaxiesOnServer.Text, "", "");

                if (loginResult.success)
                {
                    setNewUiState(UI_STATE.LOGGED_INTO_GALAXY);
                }
                else
                {
                    MessageBox.Show(loginResult.errorReason);
                }
            }
            else if (currentUiState == UI_STATE.LOGGED_INTO_GALAXY)
            {
                var logoutResult = _galaxyOps.logoutFromGalaxy();

                if (logoutResult.success)
                {
                    setNewUiState(UI_STATE.READY_TO_LOGIN);
                }
                else
                {
                    MessageBox.Show(logoutResult.errorReason);
                }
            }
        }

        private void buttonEnumerateTemplates_Click(object sender, EventArgs e)
        {
            var result = _galaxyOps.enumerateGalaxyObjects();

            if (!result.success)
            {
                MessageBox.Show(result.errorReason);
                return;
            }

            comboBoxGalaxyTemplates.Items.Clear();

            foreach (String objectName in result.objectNameList)
            {
                comboBoxGalaxyTemplates.Items.Add(objectName);
            }

            if (result.objectNameList.Any())
            {
                comboBoxGalaxyTemplates.SelectedIndex = 0;
            }
        }

        private void comboBoxGalaxyTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonViewAttrib_Click(object sender, EventArgs e)
        {
            //TODO Add a Gui to filter this
            //String[] requiredAttributes = { "PV", "CMD" };

            if (String.IsNullOrEmpty(comboBoxGalaxyTemplates.Text))
            {
                return;
            }

            String[] requiredAttributes = null;

            var result = _galaxyOps.getObjectAttributeDetails(comboBoxGalaxyTemplates.Text, requiredAttributes);

            if (!result.success)
            {
                MessageBox.Show(result.errorReason);
                return;
            }

            ObjectViewer objectViewer = new ObjectViewer();

            string message = string.Join(Environment.NewLine, result.attributeDetails.Select(detail => detail.ToString()));

            objectViewer.Text = comboBoxGalaxyTemplates.Text;

            objectViewer.richTextBox.Text = message;

            objectViewer.Show();
        }
    }
}