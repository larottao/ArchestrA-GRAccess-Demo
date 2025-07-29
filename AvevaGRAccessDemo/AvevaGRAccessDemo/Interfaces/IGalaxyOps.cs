using ArchestrA.GRAccess;
using AvevaGRAccessDemo.Models;

namespace AvevaGRAccessDemo.Interfaces
{
    public interface IGalaxyOps
    {
        public (bool success, string errorReason) setInitialConfig(InitialConfig initialConfig);

        public (bool success, string errorReason, List<IGalaxy> galaxiesOnServer) enumerateGalaxiesOnServer();

        public (bool success, string errorReason, IGalaxy? galaxy) loadExistingGalaxy(string argGalaxyName);

        public (bool success, string errorReason) createNewGalaxy(string argGalaxyName);

        public (bool success, string errorReason) loginIntoGalaxy(string argGalaxyName, string argUsername, string argPassword);

        public (bool success, string errorReason, bool isLogged, String galaxyName) isUserCurrentlyLoggedIntoGalaxy();

        public (bool success, string errorReason, List<String> objectNameList) enumerateGalaxyObjects();

        public (bool success, string errorReason, List<ObjectAttributeDetail> attributeDetails) getObjectAttributeDetails(String argTagName, String[] requiredAttributes);

        public (bool success, string errorReason) logoutFromGalaxy();
    }
}