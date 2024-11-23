using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject speedBoostObject;
    public GameObject immunityObject;
    public GameObject extraLifeObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && speedBoostObject.activeSelf)
        {
            speedBoostObject.GetComponent<IPowerUp>().Activate();
            speedBoostObject.SetActive(false);
            UIManager.instance.speedBoost.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && immunityObject.activeSelf)
        {
            immunityObject.GetComponent<IPowerUp>().Activate();
            immunityObject.SetActive(false);
            UIManager.instance.immunity.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R) && extraLifeObject.activeSelf)
        {
            extraLifeObject.GetComponent<IPowerUp>().Activate();
            extraLifeObject.SetActive(false);
            UIManager.instance.extraLife.SetActive(false);
        }
    }
}
