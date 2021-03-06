using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public float speed;

    public float dashSpeed;
    
    [Min(0)]public int life;
}
