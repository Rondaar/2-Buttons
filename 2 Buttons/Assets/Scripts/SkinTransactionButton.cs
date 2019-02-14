using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinTransactionButton : MonoBehaviour {

    public SkinButton MySkinButton { get; set; }

    public void BuySkin()
    {
        MySkinButton.BuySkin();
    }
}
