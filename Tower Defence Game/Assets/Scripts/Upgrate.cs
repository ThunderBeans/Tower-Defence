using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Upgrate : MonoBehaviour
{
    public int Upgrade;
    public GameObject[] upgrades;
    public CurencyScript currencyScript;
    private void Start()
    {
        //currencyScript = GameObject.FindGameObjectWithTag("Mony").GetComponent<CurencyScript>();
        currencyScript = FindObjectOfType<CurencyScript>();
    }
    public void Upgradeing()
    {
        Debug.Log("Fak3");
        Upgrade++;
        if (Upgrade == 2)
        {
            Debug.Log("Fak4");
            if (currencyScript != null)
            {
                if (currencyScript.Money >= 500)
                {
                    currencyScript.Money -= 500; // Decrease money by 500
                    SpawnUpgrade(1);
                }
                else
                {
                    Debug.Log("Insufficient funds for upgrade!");
                }
            }
        }
        else if (Upgrade == 3)
        {
            if (currencyScript != null)
            {
                if (currencyScript.Money >= 500)
                {
                    currencyScript.Money -= 500; // Decrease money by 500
                    SpawnUpgrade(2);
                }
                else
                {
                    Debug.Log("Insufficient funds for upgrade!");
                }
            }
        }
    }

    private void SpawnUpgrade(int upgradeIndex)
    {
        Vector3 spawnPosition = transform.position; // Get the position of the current GameObject
        Quaternion spawnRotation = transform.rotation; // Get the rotation of the current GameObject

        Destroy(gameObject); // Destroy the current GameObject

        if (upgradeIndex < upgrades.Length)
        {
            GameObject upgradePrefab = upgrades[upgradeIndex];
            Instantiate(upgradePrefab, spawnPosition, spawnRotation); // Spawn the upgrade GameObject at the same position and rotation
        }
        else
        {
            Debug.Log("Invalid upgrade index!");
        }
    }
}
