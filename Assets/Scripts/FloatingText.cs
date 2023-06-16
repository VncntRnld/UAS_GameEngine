using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float destroyTime = 2f;

    private Text text;
    private Vector3 direction;

    private void Awake()
    {
        text = GetComponent<Text>();
        direction = Vector3.up; // Arah gerakan floating text, dapat disesuaikan

        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void SetText(string damageText)
    {
        text.text = damageText;
    }
}
