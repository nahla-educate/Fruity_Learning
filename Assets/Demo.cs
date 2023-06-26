using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] Timer time1;
    // Start is called before the first frame update
    private void Start()
    {
        time1.SetDuration(20).Begin();
    }

}
