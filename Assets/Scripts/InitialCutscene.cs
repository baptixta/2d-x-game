using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InitialCutscene : MonoBehaviour
{
    [SerializeField] GameObject Player;

    void OnEnable() {
        Player.GetComponent<Player>().enabled = false;
    }
}
