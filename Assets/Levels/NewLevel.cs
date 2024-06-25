using Dreamteck.Forever;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "CustomScript/Level")]
public class NewLevel : ForeverLevel
{
    protected override void OnLoaded()
    {
        base.OnLoaded();

        PlayerController.instance.SetSpeed(2);
        Debug.Log("Player started moving in New Level");
    }
}
