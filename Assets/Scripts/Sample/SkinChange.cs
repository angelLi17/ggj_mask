using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChange : MonoBehaviour
{
    public float armorCheckInterval = 2f;
    public float armorRemoveInterval = 2f;

    private float removeTimer = 0f;
    private List<GameObject> currentArmor = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(ArmorRoutine());
    }

    private IEnumerator ArmorRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(armorCheckInterval);

            // Re-scan armor every 2 seconds
            currentArmor = GetActiveArmorPieces();

            // Track time toward removal
            removeTimer += armorCheckInterval;

            // Remove armor every 5 seconds IF armor exists
            if (removeTimer >= armorRemoveInterval && currentArmor.Count > 0)
            {
                removeTimer = 0f;

                int index = Random.Range(0, currentArmor.Count);
                currentArmor[index].SetActive(false);
            }

            //// Optional: stop completely when no armor exists
            //if (currentArmor.Count == 0)
            //{
            //    removeTimer = 0f;
            //}
        }
    }

    private List<GameObject> GetActiveArmorPieces()
    {
        List<GameObject> armorPieces = new List<GameObject>();

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                armorPieces.Add(child.gameObject);
            }
        }

        return armorPieces;
    }
}
