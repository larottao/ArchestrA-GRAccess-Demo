//TODO: Make this service async, to avoid blocking the UI!

using ArchestrA.GRAccess;
using ArchestrA.Visualization.GraphicAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ArchestrA.Visualization.GraphicLibraryPublic.XMLOperations;

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

        public GRAccessApp grAccess = new GRAccessApp();

        public IgObject objectUnderInspection = null;

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

                IgObjects queryResult = null;

                //How to search:

                //string[] tagnames = { "*" }; //Nah, this does not work.
                //string[] tagnames = { "$UserDefined" }; //this works
                //string[] tagnames = { "$AppEngine" }; //this works
                //_galaxy.QueryObjectsByName(EgObjectIsTemplateOrInstance.gObjectIsInstance, tagnames);

                //queryResult = _galaxy.QueryObjects(
                //    EgObjectIsTemplateOrInstance.gObjectIsTemplate,
                //    0,
                //    1);

                //queryResult = _galaxy.QueryObjects(
                //  EgObjectIsTemplateOrInstance.gObjectIsInstance,
                //  0,
                //  0);

                queryResult = _galaxy.QueryObjects(
                    EgObjectIsTemplateOrInstance.gObjectIsInstance,
                    0,
                    0);

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

                templateNameList.OrderBy(name => name.ToString());

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

                if (!_galaxyObjectsDictionary.TryGetValue(argTagName, out IgObject objectFoundInGalaxy))
                {
                    return (false, $"Object '{argTagName}' not found in the Galaxy.", new List<ObjectAttributeDetail>());
                }

                objectUnderInspection = objectFoundInGalaxy as IgObject;

                var attributeDetails = new List<ObjectAttributeDetail>();

                //targetObject.CheckOut(); // This is not needed, as we are only reading attributes.

                _cmdResult = _galaxy.CommandResult;
                if (!_cmdResult.Successful)
                {
                    return (false, $"Failed to check out object '{objectFoundInGalaxy}': {_cmdResult.Text} : {_cmdResult.CustomMessage}", attributeDetails);
                }

                foreach (IAttribute attr in objectFoundInGalaxy.ConfigurableAttributes)
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

        public (bool success, string errorReason) convertAApckIntoXml(String argTargetDirectory)
        {
            try
            {
                if (objectUnderInspection == null)
                {
                    return (false, $"You need to load an object first");
                }

                // Ensure the target directory exists
                if (!Directory.Exists(argTargetDirectory))
                {
                    Directory.CreateDirectory(argTargetDirectory);
                }

                string xmlFilePath = Path.Combine(argTargetDirectory, $"{objectUnderInspection.Tagname}.xml");

                IGraphicAccess4 graphicAccess = new GraphicAccess();

                IGraphicAccessResult graphicAccessResult = graphicAccess.ExportGraphicToXml(_galaxy, objectUnderInspection.Tagname, argTargetDirectory, bExportSubstituteStrings: true);

                StatusCode status = graphicAccessResult.Status;

                if (graphicAccessResult.Successful)
                {
                    return (true, $"Export Complete");
                }

                return (false, $"Export Failed. {graphicAccessResult.CustomMessage}");
            }
            catch (Exception ex)
            {
                return (false, $"Failed to export graphic {objectUnderInspection.Tagname}: {ex.Message}");
            }
        }
    }
}