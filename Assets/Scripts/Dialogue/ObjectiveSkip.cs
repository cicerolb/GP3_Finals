using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSkip : MonoBehaviour
{
    public bool nextObjective = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextObjective()
    {
        nextObjective = true;
        nextObjective = false;
    }
}
