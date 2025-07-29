namespace AvevaGRAccessDemo.Services
{
    //Aveva GRAccess Demo
    //By Luis Felipe La Rotta

    //This solution requires the .DLL located on C:\Program Files (x86)\Common Files\ArchestrA\ArchestrA.GRAccess.dll
    //My program is a demo with no commercial purposes and
    //it is based on a code example publicly provided by © 2022 AVEVA Software, LLC. All rights reserved.
    //See AVEVA's original code here:
    //https://docs.aveva.com/bundle/sp-appserver/page/436618.html

    //TODO: Make this service async, to avoid blocking the UI!

    using ArchestrA.GRAccess;
    using AvevaGRAccessDemo.Interfaces;
    using AvevaGRAccessDemo.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class GalaxyService : IGalaxyOps
    {
        public string nodeName { get; set; } = Environment.MachineName;

        private IGalaxies? _gals = null;

        private IGalaxy? _galaxy = null;

        private ICommandResult? _cmd = null;

        private Boolean _validNodeInfoWasProvided = false;

        private Boolean _currentlyLoggedIntoGalaxy = false;

        private GRAccessApp grAccess = new GRAccessAppClass();

        public (bool success, string errorReason) setInitialConfig(InitialConfig initialConfig)
        {
            if (initialConfig == null)
            {
                return (false, "Please provide a valid initial configuration.");
            }

            if (String.IsNullOrEmpty(initialConfig.nodeName))
            {
                return (false, "The node name is invalid.");
            }

            this.nodeName = initialConfig.nodeName;

            //TODO: Check the node format is valid
            //TODO: Ping the node, or ensure it actually exists

            _validNodeInfoWasProvided = true;

            return (true, "");
        }

        public (bool success, string errorReason, List<IGalaxy> galaxiesOnServer) enumerateGalaxiesOnServer()
        {
            List<IGalaxy> galaxiesList = new List<IGalaxy>();

            try
            {
                if (!_validNodeInfoWasProvided)
                {
                    return (false, "Provide the node info first (i.e. valid initial configuration)", galaxiesList);
                }

                _gals = grAccess.QueryGalaxies(nodeName);

                foreach (IGalaxy galaxy in _gals)
                {
                    galaxiesList.Add(galaxy);
                }

                return (true, "", galaxiesList);
            }
            catch (Exception ex)
            {
                return (false, $"Unable to enumerate Galaxies on server {ex.ToString}", galaxiesList);
            }
        }

        public (bool success, string errorReason, IGalaxy? galaxy) loadExistingGalaxy(string argGalaxyName)
        {
            try
            {
                var resultEnumGals = enumerateGalaxiesOnServer();

                if (!resultEnumGals.success)
                {
                    return (false, resultEnumGals.errorReason, null);
                }

                if (_gals == null)
                {
                    return (false, "There are no Galaxies currently on the server", null);
                }

                if (grAccess.CommandResult.Successful == false)
                {
                    return (false, $"Unable to access the Galaxy {argGalaxyName} ", null);
                }

                _galaxy = _gals[argGalaxyName];

                return (true, $"Success: {grAccess.CommandResult.CustomMessage + grAccess.CommandResult.Text} ", _galaxy);
            }
            catch (Exception ex)
            {
                return (false, $"Unable to load Galaxy {ex.ToString}", null);
            }
        }

        public (bool success, string errorReason) createNewGalaxy(string argGalaxyName)

        {
            //TODO pass proper commands, this is for testing only

            try
            {
                grAccess.CreateGalaxy(

                argGalaxyName,

                nodeName,

                false, // no security

                EAuthenticationMode.galaxyAuthenticationMode,

                "");

                _cmd = grAccess.CommandResult;

                if (!_cmd.Successful)

                {
                    return (false, $"Creating Galaxy with name {argGalaxyName} failed {_cmd.Text + " : " + _cmd.CustomMessage}.");
                }

                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, $"Creating the galaxy with name {argGalaxyName} failed {ex.Message}");
            }
        }

        public (bool success, string errorReason) loginIntoGalaxy(string argGalaxyName, string argUsername = "", string argPassword = "")
        {
            try
            {
                var resultEnumGals = enumerateGalaxiesOnServer();

                if (!resultEnumGals.success || _gals == null)
                {
                    return (false, resultEnumGals.errorReason);
                }

                _galaxy = _gals[argGalaxyName];

                _galaxy.Login(argUsername, argPassword);

                _cmd = _galaxy.CommandResult;

                if (!_cmd.Successful)

                {
                    return (false, $"Login into Galaxy with name {argGalaxyName} failed: {_cmd.Text + " : " + _cmd.CustomMessage}.");
                }

                _currentlyLoggedIntoGalaxy = true;

                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, $"Unable to login into Galaxy {argGalaxyName}: {ex.Message}");
            }
        }

        public (bool success, string errorReason) logoutFromGalaxy()
        {
            try
            {
                if (_galaxy == null)
                {
                    return (true, $"No need to logout. Not logged in yet.");
                }

                _galaxy.Logout();
                _galaxy = null;
                _currentlyLoggedIntoGalaxy = false;

                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, $"Unable to logout from Galaxy: {ex.Message}");
            }
        }

        public (bool success, string errorReason, bool isLogged, string galaxyName) isUserCurrentlyLoggedIntoGalaxy()
        {
            try
            {
                if (_currentlyLoggedIntoGalaxy && _galaxy != null)
                {
                    return (true, "", true, _galaxy.Name);
                }
                else
                {
                    return (true, "", false, "");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Unable to get Login status from Galaxy: {ex.Message}", false, "");
            }
        }

        public (bool success, string errorReason, List<string> templateNames) enumerateGalaxyTemplates()
        {
            var instanceNames = new List<string>();

            try
            {
                if (_galaxy == null || !_currentlyLoggedIntoGalaxy)
                {
                    return (false, "You must login into a Galaxy first.", instanceNames);
                }

                dynamic galaxyDynamic = _galaxy;

                // Integer values for enums:
                // EgObjectIsTemplateOrInstance:
                // 0 = Template
                // 1 = Instance

                // EConditionType:
                // 0 = Name

                // EMatchCondition:
                // 0 = Any match

                dynamic instances = galaxyDynamic.QueryObjects(1, 0, 0);  // 1 = Instances

                foreach (var instance in instances)
                {
                    instanceNames.Add(instance.Name.ToString());
                }

                return (true, "", instanceNames);
            }
            catch (Exception ex)
            {
                return (false, $"Failed to enumerate instances: {ex.Message}", instanceNames);
            }
        }
    }
}

/*

TODO: Understand this

 string[] tagnames = { "$UserDefined" };

IgObjects queryResult = galaxy.QueryObjectsByName(

EgObjectIsTemplateOrInstance.gObjectIsTemplate,

ref tagnames);

cmd = galaxy.CommandResult;

if (!cmd.Successful)

{
    Debug.WriteLine("QueryObjectsByName Failed for $UserDefined Template :" +

            cmd.Text + " : " +

            cmd.CustomMessage);

    return;
}

ITemplate userDefinedTemplate = (ITemplate)queryResult[1];

// create an instance of $UserDefined, named with current time

DateTime now = DateTime.Now;

string instanceName = String.Format("sample_object_{0}_{1}_{2}"

, now.Hour.ToString("00")

, now.Minute.ToString("00")

, now.Second.ToString("00"));

IInstance sampleinst = userDefinedTemplate.CreateInstance(instanceName, true);

//How to edit the object ?

sampleinst.CheckOut();

sampleinst.AddUDA("Names",

MxDataType.MxString,

MxAttributeCategory.MxCategoryWriteable_USC_Lockable,

MxSecurityClassification.MxSecurityOperate,

true,

5);

IAttributes attrs = sampleinst.ConfigurableAttributes;

//Diplay first 5 attribute names from collection

for (int i = 1; i <= 5; i++)

{
    IAttribute attrb = attrs[i];

    Debug.WriteLine(attrb.Name);
}

IAttribute attr1 = attrs["Names"];

MxValue mxv = new MxValueClass();

// we don't need to check that attribute is array type or not

// because we set it as array type when we addUDA.

// I am just showing example, you can do like this.

if (attr1.UpperBoundDim1 > 0)

{
    for (int i = 1; i <= attr1.UpperBoundDim1; i++)

    {
        MxValue mxvelement = new MxValueClass();

        mxvelement.PutString("string element number " + i.ToString());

        mxv.PutElement(i, mxvelement);
    }

    attr1.SetValue(mxv);
}

sampleinst.Save();

sampleinst.CheckIn("Check in after addUDA");

  */