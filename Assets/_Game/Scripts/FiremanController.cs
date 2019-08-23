using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour
{

    public List<Transform> positions = new List<Transform>();

    private void Start()
    {
        transform.position = positions[1].position;
    }


}
