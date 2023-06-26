using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activerr : MonoBehaviour
{
    public GameObject myobject;
    public GameObject myobject2;
    // public bool activeteme;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    { 
        
    }
    public void whenButtonClicked()
    {
        if(myobject.activeInHierarchy == true)
        {
            myobject.SetActive(false);
            myobject2.SetActive(true);
        }
        else
        {
            myobject.SetActive(true);
            myobject2.SetActive(false);
        }
    }
    
}
