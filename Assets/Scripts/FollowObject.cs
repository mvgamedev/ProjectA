using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] GameObject objToFollow;
    [SerializeField] float fixedZPos = -10;
    [SerializeField] float fixedYPos = 2;
    [SerializeField] float fixedXPos = 0;

    void Update()
    {
        Vector3 position = new Vector3(objToFollow.transform.position.x + fixedXPos, objToFollow.transform.position.y + fixedYPos, fixedZPos);

        transform.position = position;
    }
}
