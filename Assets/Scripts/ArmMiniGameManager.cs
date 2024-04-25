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
    public List<GameObject> Plasters;

    public GameObject arrowOne;
    // public GameObject arrowTwo;
    
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
                    MiniEventOne();
                    StartCoroutine(DelayedArmEventThree());
                    break;
                case "Needle":
                    MiniEventTwo();
                    StartCoroutine(DelayedArmEventFour());
                    break;
                default:
                    ArmEventFive(gameObject);
                    break;
        }
    }

    private IEnumerator DelayedArmEventThree()
    {
        yield return new WaitForSeconds(1);
        arrowOne.SetActive(true);
    }

    private void MiniEventOne() => SpritSnapPoint.SetActive(false);
    private void MiniEventTwo() => Needle.tag = "Untagged";

    private IEnumerator DelayedArmEventFour()
    {
        yield return new WaitForSeconds(1);
        arrowOne.SetActive(true); // husk at call eventfour 
    }

    private void ArmEventOne()
    {
        Band.SetActive(false);
        LooseBand.SetActive(true);
        BandButton.SetActive(true);
        Debug.Log("ArmEventOne");
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
        Debug.Log("ArmEventTwo");
    }

    private void ArmEventThree()
    {
        NeedleSnapPoint.SetActive(true);
        Needle.SetActive(true);
        Debug.Log("ArmEventThree");
    }

    private void ArmEventFour()
    {
        NeedleSnapPoint.SetActive(false);
        Sprit.SetActive(false);
        foreach (var plaster in Plasters) {
            plaster.SetActive(true);
        }
        Debug.Log("ArmEventFour");
    }

    private void ArmEventFive(GameObject gameObject)
    {
        Needle.SetActive(false);
        BloodVein.SetActive(false);
        TightBand.SetActive(false);
        foreach (var plaster in Plasters) {
            if (plaster != gameObject) {
                plaster.SetActive(false);
            }
        }
        Debug.Log("ArmEventFive");
        // arrow.SetActive(true);
    }
}
