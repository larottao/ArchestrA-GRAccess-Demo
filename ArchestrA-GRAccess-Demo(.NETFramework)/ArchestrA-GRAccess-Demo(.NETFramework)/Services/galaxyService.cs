//Aveva GRAccess Demo
//By Luis Felipe La Rotta

//This solution requires the .DLL located on C:\Program Files (x86)\Common Files\ArchestrA\ArchestrA.GRAccess.dll
//My program is a demo with no commercial purposes and
//it is based on a code example publicly provided by © 2022 AVEVA Software, LLC. All rights reserved.
//See AVEVA's original code here:
//https://docs.aveva.com/bundle/sp-appserver/page/436618.html

//TODO: Make this service async, to avoid blocking the UI!

using ArchestrA.GRAccess;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchestrA_GRAccess_Demo_.NETFramework_
{
    public class GalaxyService : IGalaxyOps
    {
        public string nodeName { get; set; } = Environment.MachineName;

        private IGalaxies _galaxies = null;

        private IGalaxy _galaxy = null;

        private ICommandResult _cmdResult = null;

        private Boolean _validNodeInfoWasProvided = false;

        private Boolean _currentlyLoggedIntoGalaxy = false;

        private Dictionary<String, IgObject> _galaxyObjectsDictionary = new Dictionary<String, IgObject>();

        private GRAccessApp grAccess = new GRAccessApp();

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

                _galaxies = grAccess.QueryGalaxies(nodeName);

                foreach (IGalaxy galaxy in _galaxies)
                {
                    galaxiesList.Add(galaxy);
                }

                return (true, "", galaxiesList);
            }
            catch (Exception ex)
            {
                return (false, $"Unable to enumerate Galaxies on server {ex.ToString()}", galaxiesList);
            }
        }

        public (bool success, string errorReason, IGalaxy galaxy) loadExistingGalaxy(string argGalaxyName)
        {
            try
            {
                var resultEnumGals = enumerateGalaxiesOnServer();

                if (!resultEnumGals.success)
                {
                    return (false, resultEnumGals.errorReason, null);
                }

                if (_galaxies == null)
                {
                    return (false, "There are no Galaxies currently on the server", null);
                }

                if (grAccess.CommandResult.Successful == false)
                {
                    return (false, $"Unable to access the Galaxy {argGalaxyName} ", null);
                }

                _galaxy = _galaxies[argGalaxyName];

                return (true, $"Success: {grAccess.CommandResult.CustomMessage + grAccess.CommandResult.Text} ", _galaxy);
            }
            catch (Exception ex)
            {
                return (false, $"Unable to load Galaxy {ex.ToString()}", null);
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

                _cmdResult = grAccess.CommandResult;

                if (!_cmdResult.Successful)

                {
                    return (false, $"Creating Galaxy with name {argGalaxyName} failed {_cmdResult.Text + " : " + _cmdResult.CustomMessage}.");
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

                if (!resultEnumGals.success || _galaxies == null)
                {
                    return (false, resultEnumGals.errorReason);
                }

                _galaxy = _galaxies[argGalaxyName];

                _galaxy.Login(argUsername, argPassword);

                _cmdResult = _galaxy.CommandResult;

                if (!_cmdResult.Successful)

                {
                    return (false, $"Login into Galaxy with name {argGalaxyName} failed: {_cmdResult.Text + " : " + _cmdResult.CustomMessage}.");
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

        public (bool success, string errorReason, List<String> objectNameList) enumerateGalaxyObjects()
        {
            List<String> templateNameList = new List<string>();

            try
            {
                if (_galaxy == null || !_currentlyLoggedIntoGalaxy)
                {
                    return (false, "You must login into a Galaxy first.", new List<String>());
                }

                //How to search:

                //string[] tagnames = { "*" }; //Nah, this does not work.
                //string[] tagnames = { "$UserDefined" };
                //string[] tagnames = { "$AppEngine" };

                /*

                EgObjectIsTemplateOrInstance:

                    gObjectIsTemplate
                    gObjectIsInstance

                    EConditionType:

                    0 = gConditionName (or Name in some contexts)
                    1 = gConditionTagname
                    2 = gConditionDerivedFrom

                    EMatchCondition:

                    0 = gMatchAny
                    1 = gMatchExact
                    2 = gMatchWildcard

                */

                IgObjects queryResult = _galaxy.QueryObjects(
                  EgObjectIsTemplateOrInstance.gObjectIsInstance, // Instances
                  0, // Name
                  0); //EMatchCondition

                _cmdResult = _galaxy.CommandResult;

                if (!_cmdResult.Successful)
                {
                    return (false, $"Querying for templates failed: {_cmdResult.Text} : {_cmdResult.CustomMessage}", new List<String>());
                }

                _galaxyObjectsDictionary.Clear();

                foreach (IgObject obj in queryResult)
                {
                    _galaxyObjectsDictionary.Add(obj.Tagname, obj);
                    templateNameList.Add(obj.Tagname);
                }

                return (true, "", templateNameList);
            }
            catch (Exception ex)
            {
                return (false, $"Failed to enumerate templates: {ex.Message}", new List<String>());
            }
        }

        public (bool success, string errorReason, List<ObjectAttributeDetail> attributeDetails) getObjectAttributeDetails(String argTagName, String[] requiredAttributes)
        {
            try
            {
                if (_galaxy == null || !_currentlyLoggedIntoGalaxy)
                {
                    return (false, "You must login into a Galaxy first.", new List<ObjectAttributeDetail>());
                }

                if (!_galaxyObjectsDictionary.TryGetValue(argTagName, out IgObject targetObject))
                {
                    return (false, $"Object '{argTagName}' not found in the Galaxy.", new List<ObjectAttributeDetail>());
                }

                var attributeDetails = new List<ObjectAttributeDetail>();

                //targetObject.CheckOut(); // This is not needed, as we are only reading attributes.

                _cmdResult = _galaxy.CommandResult;
                if (!_cmdResult.Successful)
                {
                    return (false, $"Failed to check out object '{targetObject}': {_cmdResult.Text} : {_cmdResult.CustomMessage}", attributeDetails);
                }

                foreach (IAttribute attr in targetObject.ConfigurableAttributes)
                {
                    if (requiredAttributes != null && !requiredAttributes.Contains(attr.Name))
                    {
                        continue;
                    }

                    attributeDetails.Add(new ObjectAttributeDetail
                    {
                        name = attr.Name,
                        description = attr.Description.ToString(),
                        dataType = attr.DataType.ToString(),
                        category = attr.AttributeCategory.ToString(),
                        value = ParseAttribute.GetAttributeValue(attr)
                    });
                }

                return (true, "", attributeDetails);
            }
            catch (Exception ex)
            {
                return (false, $"Failed to enumerate attributes for '{argTagName}': {ex.Message}", new List<ObjectAttributeDetail>());
            }
        }
    }
}