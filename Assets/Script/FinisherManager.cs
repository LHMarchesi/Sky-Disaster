using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinisherManager : MonoBehaviour
{
    [SerializeField]private GameObject finisher;
    private ScenesManager scenesManager;
    void Start()
    {
        scenesManager = GetComponent<ScenesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finisher.transform.position.x <= 5)
        {
            finisher.transform.position = new Vector2(5, -1);
        }
    }

   
}
