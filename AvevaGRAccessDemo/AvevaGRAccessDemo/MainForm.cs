//Aveva GRAccess Demo
//By Luis Felipe La Rotta

//This solution requires the .DLL located on C:\Program Files (x86)\Common Files\ArchestrA\ArchestrA.GRAccess.dll
//My program is a demo with no commercial purposes and
//it is based on a code example publicly provided by © 2022 AVEVA Software, LLC. All rights reserved.
//See AVEVA's original code here:
//https://docs.aveva.com/bundle/sp-appserver/page/436618.html

using ArchestrA.GRAccess;
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


        #region UI related stuff region

        enum UI_STATE { LOGGED_INTO_GALAXY, READY_TO_LOGIN }

        UI_STATE currentUiState = UI_STATE.READY_TO_LOGIN;

        private void setNewUiState(UI_STATE argUiState)
        {


            currentUiState = argUiState;
            switch (argUiState)
            {


                case UI_STATE.READY_TO_LOGIN:

                    buttonLoginIntoGalaxy.Text = "Login into Galaxy";
                    comboBoxGalaxiesOnServer.Enabled = true;
                    buttonEnumerateTemplates.Enabled = false;

                    break;

                case UI_STATE.LOGGED_INTO_GALAXY:

                    buttonLoginIntoGalaxy.Text = "Logout from Galaxy";
                    comboBoxGalaxiesOnServer.Enabled = false;
                    buttonEnumerateTemplates.Enabled = true;

                    break;


            }
        }

        #endregion

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
            if (comboBoxGalaxiesOnServer.SelectedIndex < 0)
            {
                MessageBox.Show("Select a Galaxy first");
                return;
            }

            if (currentUiState == UI_STATE.READY_TO_LOGIN)
            {

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
            var result = _galaxyOps.enumerateGalaxyTemplates();

            MessageBox.Show(result.success ? "Templates enumerated successfully!" : $"Error: {result.errorReason}");
        }
    }




}