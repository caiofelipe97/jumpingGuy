using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        if (player.position.y > -3)
        {
            Vector3 pos = new Vector3(3.35f, player.position.y, -1);
            this.transform.position = pos;
           
        }
    }
}
