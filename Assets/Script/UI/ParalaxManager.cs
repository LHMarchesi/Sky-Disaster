using UnityEngine;

public class ParalaxManager : MonoBehaviour
{
    [SerializeField] private int speed;
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -63)
        {
            this.transform.position = new Vector3(28, transform.position.y, transform.position.z);
        }
    }
}
