using UnityEngine;

public class FloatingTextSpawner : MonoBehaviour
{
    public GameObject floatingTextPrefab;

    public void SpawnFloatingText(int damageText)
    {
        GameObject floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        FloatingText floatingTextScript = floatingText.GetComponent<FloatingText>();
        floatingTextScript.SetText("-"+damageText.ToString());
    }
}
