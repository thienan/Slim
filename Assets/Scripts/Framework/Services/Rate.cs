using UnityEngine;

public class Rate : MonoBehaviour
{   
    private void OnEnable()
    {
        GlobalEvents<OnBtnRateClick>.Happened += OnBtnRateClick;
    }
    
    private void OnBtnRateClick(OnBtnRateClick obj)
    {
        RateUs();
        GlobalEvents<OnBtnRateClick>.Happened -= OnBtnRateClick;
        DefsGame.RateCounter = 1;
        PlayerPrefs.SetInt("RateCounter", 1);
    }

    public void RateUs()
    {
#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id="+DefsGame.AndroidAppID);
		#elif UNITY_IPHONE
        Application.OpenURL("http://itunes.apple.com/app/" + DefsGame.iOSApp_ID);
#endif
    }

    /*public void RateUs()
    {
        #if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + Defs.AndroidAppID);
        #elif UNITY_IPHONE
        Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
        #endif
    }*/
}