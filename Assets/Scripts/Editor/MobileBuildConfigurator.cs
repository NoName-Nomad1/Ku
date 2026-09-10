#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace QazaqCity.Editor
{
    public static class MobileBuildConfigurator
    {
        [MenuItem("Qazaq City/Configure Mobile Build")]
        public static void Configure()
        {
            PlayerSettings.companyName = "Qazaq City Studio";
            PlayerSettings.productName = "Qazaq City";
            PlayerSettings.bundleVersion = "0.1.0";
            PlayerSettings.defaultScreenOrientation = ScreenOrientation.LandscapeLeft;

            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "kz.qazaqcity.game");
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, "kz.qazaqcity.game");

            Debug.Log("Qazaq City mobile settings configured for Android + iPhone.");
        }
    }
}
#endif
