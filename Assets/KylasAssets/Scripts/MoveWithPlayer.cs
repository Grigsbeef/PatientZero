using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public Transform playerTarget;
    public Transform mirror;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Player = mirror.InverseTransformPoint(playerTarget.position);
        transform.position = mirror.TransformPoint(new Vector3(Player.x, Player.y, -Player.z));
        Vector3 lookatmirror = mirror.TransformPoint(new Vector3(-Player.x, Player.y, Player.z));
        transform.LookAt(lookatmirror);
        
    }
}
