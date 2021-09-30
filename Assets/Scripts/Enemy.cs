using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Attack() {
        Player.ApplyDamage(1);
    }

    
}
