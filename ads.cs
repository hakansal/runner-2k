using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;


public class ads : MonoBehaviour
{
    private InterstitialAd adInt;
    private BannerView adban;
    private RewardBasedVideoAd adreward;
    public bool isbannerload = false;
      public GameObject pool;
    
    public void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
        this.adreward = RewardBasedVideoAd.Instance;
    }

     void Update()
    {
        if (isbannerload == true) banneradsit();
         
    }

    

    void banneradsit()
    {
        adban.Destroy();
    }
    private void RequestBanner()
    {

         
        string banid = "ca-app-pub-3940256099942544/6300978111";
        this.adban = new BannerView(banid, AdSize.SmartBanner, AdPosition.Bottom);
        

        AdRequest request = new AdRequest.Builder().Build();

        this.adban.LoadAd(request);
         
        
        adInt.OnAdClosed += HandleOnAdClosed;
        
    }
    public void Requestint()
    {
      
        string Intid = "ca-app-pub-3940256099942544/5224354917";
        this.adInt = new InterstitialAd(Intid);
        AdRequest request = new AdRequest.Builder().Build();
        this.adInt.LoadAd(request);
        adInt.Show();
        adInt.OnAdClosed += HandleOnAdClosed;
    }
     

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        this.RequestBanner();
    }

     
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
       
    }

     
}
 

