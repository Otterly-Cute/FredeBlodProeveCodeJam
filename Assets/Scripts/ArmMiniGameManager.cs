using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMiniGameManager : MonoBehaviour, ITriggerable
{
    public GameObject Band;
    public GameObject LooseBand;
    public GameObject BandButton;
    public GameObject TightBand;

    public GameObject BloodVein;
    
    public void TriggerEvent(GameObject gameObject)
    {
        switch (gameObject.name) {
                case "Kasse_Band":
                    BandEventOne();
                    break;
                case "Band_Loose":
                BandEventTwo();
                    break;
        }
    }

    private void BandEventOne()
    {
        Band.SetActive(false);
        LooseBand.SetActive(true);
        BandButton.SetActive(true);
    }

    private void BandEventTwo()
    {
        LooseBand.SetActive(false);
        BandButton.SetActive(false);
        TightBand.SetActive(true);
        BloodVein.SetActive(true);
        Debug.Log("BandEventTwo has been triggered!");
    }
}
