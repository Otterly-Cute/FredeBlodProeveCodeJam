using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMiniGame : MonoBehaviour, ITriggerable
{
    public GameObject Band;
    public GameObject LooseBand;
    public GameObject TightBand;

    public GameObject BloodVein;
    
    public void TriggerEvent(GameObject gameObject)
    {
        switch (gameObject.name) {
                case "Kasse_Band":
                    BandEvent();
                    break;
                case "Sprit":
                    Debug.Log("Sprit");
                    break;
        }
    }

    private void BandEvent()
    {
        Band.SetActive(false);
        LooseBand.SetActive(true);
        BloodVein.SetActive(true);
    }
}
