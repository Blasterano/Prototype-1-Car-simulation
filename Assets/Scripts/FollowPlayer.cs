using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public GameObject player;

    public Vector3 coffset = new Vector3(0, 5, -7), hoffset = new Vector3(0, 2, -14.5f) ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // offset the camera behind the player by adding to the player's position
        //transform.position = player.transform.position + offset;

        if (name == "hood Camera")
        {
            transform.localPosition =  hoffset;
            //transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.localPosition = coffset;
            //transform.localRotation = Quaternion.Euler(roffset);
            // rotating camera with vehicle
            //transform.rotation = new Quaternion(transform.rotation.x, player.transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }
        }
}
