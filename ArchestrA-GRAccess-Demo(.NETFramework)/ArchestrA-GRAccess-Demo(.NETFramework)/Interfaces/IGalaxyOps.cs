using System;
using System.Collections.Generic;
using ArchestrA.GRAccess;

namespace ArchestrA_GRAccess_Demo_.NETFramework_
{
    public interface IGalaxyOps
    {
        (bool success, string errorReason) setInitialConfig(InitialConfig initialConfig);

        (bool success, string errorReason, List<IGalaxy> galaxiesOnServer) enumerateGalaxiesOnServer();

        (bool success, string errorReason, IGalaxy galaxy) loadExistingGalaxy(string argGalaxyName);

        (bool success, string errorReason) createNewGalaxy(string argGalaxyName);

        (bool success, string errorReason) loginIntoGalaxy(string argGalaxyName, string argUsername, string argPassword);

        (bool success, string errorReason, bool isLogged, String galaxyName) isUserCurrentlyLoggedIntoGalaxy();

        (bool success, string errorReason, List<String> objectNameList) enumerateGalaxyObjects();

        (bool success, string errorReason, List<ObjectAttributeDetail> attributeDetails) getObjectAttributeDetails(String argTagName, String[] requiredAttributes);

        (bool success, string errorReason) logoutFromGalaxy();
    }
}