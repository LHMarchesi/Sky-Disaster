using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxManager : MonoBehaviour
{
    [SerializeField] private int speed1;
    [SerializeField] private GameObject[] clouds;    
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed1 * Time.deltaTime);

        if(transform.position.x < -63)
        {
            transform.position =new Vector3(28,-3, 2);
        }

        for (int i = 0; i < clouds.Length; i++)
        {
            if (transform.position.x < -12)
            {
                transform.position = new Vector2(15, Random.Range(2,-2.3f));
            }
        }
    }
}
