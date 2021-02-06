using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Arrow;
    int checkObjective;
    objective[] Objectives;
    public Transform ObjectivesParents;

    void Start()
    {
        Objectives = ObjectivesParents.GetComponentsInChildren<objective>();
        Arrow.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        checkObjective = 0;
        for (int i = 0; i < Objectives.Length; i++)
        {
            if (Objectives[i].Check == true)
            {
                checkObjective++;
            }
        }

        if (checkObjective == Objectives.Length)
        {
            Arrow.SetActive(true);
        }
        if (checkObjective != Objectives.Length)
        {
            Arrow.SetActive(false);
        }
    }
}
