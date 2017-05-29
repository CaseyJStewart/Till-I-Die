using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public int Speed;
    public Rigidbody Bullet;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Bullet == null)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Rigidbody rocketClone = (Rigidbody)Instantiate(Bullet, this.gameObject.transform.GetChild(0).position, transform.rotation);
                rocketClone.velocity = transform.forward * Speed;
            }
        }
    }
}
