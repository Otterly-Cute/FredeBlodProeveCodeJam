using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ArmMiniGameManager : MonoBehaviour, ITriggerable
{
    public GameObject BandSnapPoint;
    public GameObject SpritSnapPoint;
    public GameObject NeedleSnapPoint;
    
    public GameObject Band;
    public GameObject LooseBand;
    public GameObject BandButton;
    public GameObject TightBand;
    public GameObject BloodVein;
    public GameObject Sprit;
    public GameObject Needle;
    public GameObject Plaster;
    
    public void TriggerEvent(GameObject gameObject)
    {
        switch (gameObject.name) {
                case "Kasse_Band":
                    ArmEventOne();
                    break;
                case "Band_Loose":
                    ArmEventTwo();
                    break;
                case "Sprit":
                    ArmEventThree();
                    break;
                case "Needle":
                    ArmEventFour();
                    break;
        }
    }

    private void ArmEventOne()
    {
        Band.SetActive(false);
        LooseBand.SetActive(true);
        BandButton.SetActive(true);
    }

    private void ArmEventTwo()
    {
        BandButton.SetActive(false);
        LooseBand.SetActive(false);
        TightBand.SetActive(true);
        BloodVein.SetActive(true);
        Sprit.SetActive(true);
        BandSnapPoint.SetActive(false);
        SpritSnapPoint.SetActive(true);
    }

    private void ArmEventThree()
    {
        SpritSnapPoint.SetActive(false);
        NeedleSnapPoint.SetActive(true);
        Needle.SetActive(true);
    }

    private void ArmEventFour()
    {
        Sprit.SetActive(false);
        Plaster.SetActive(true);
    }
}
