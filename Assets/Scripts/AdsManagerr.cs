using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class AdsManagerr : MonoBehaviour
{
    private static string APPS_ADS_ID = "XXXX-XXXX-XXXX-XXXX";
    private static string BANNER_ID = "XXXX-XXXX-XXXX-XXXX";
    //TEST BANNER
    //private static string BANNER_ID = "ca-app-pub-3940256099942544/6300978111";
    private BannerView bannerView;
    // Start is called before the first frame update
    void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        MobileAds.Initialize(APPS_ADS_ID);
#pragma warning restore CS0618 // Type or member is obsolete
        this.RequestBanner();

    }

    public void RequestBanner()
    {
        bannerView = new BannerView(BANNER_ID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);

        this.bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView = new BannerView(BANNER_ID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);

        this.bannerView.Hide();
    }
}
