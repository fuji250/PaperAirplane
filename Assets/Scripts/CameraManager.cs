using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public PlayerController playerController;

    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;

    public bool isForceScrollX = false;
    public float ForceScrollSpeedX = 0.5f;
    public bool isForceScrollY = false;
    public float ForceScrollSpeedY = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //座標更新
        if(player != null)
        {
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;

            //横同期
            if (isForceScrollX)
            {
                x = transform.position.x + (ForceScrollSpeedX * Time.deltaTime); 

                if(x >= rightLimit)
                {
                    playerController.Goal();
                }
            }
            if(x < leftLimit)
            {
                x = leftLimit;
            }
            else if(x > rightLimit)
            {
                x = rightLimit;
            }
            //縦同期
            if(y < bottomLimit)
            {
                y = bottomLimit;
            }
            else if(y > topLimit)
            {
                y = topLimit;
            }
            Vector3 v3 = new Vector3(x,y,z);
            transform.position = v3;

            
        }

        
    }
}
