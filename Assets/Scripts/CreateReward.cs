using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateReward : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Spawnpoint;
    public GameObject Prefab;

    void OnTriggerEnter()
    {
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
    }

}
