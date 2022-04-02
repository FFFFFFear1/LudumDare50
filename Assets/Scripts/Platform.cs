using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformType type;
    private void OnMouseDown()
    {
        if(Input.GetMouseButton(0))
        {
            Destroy(gameObject);
        }
    }
}
