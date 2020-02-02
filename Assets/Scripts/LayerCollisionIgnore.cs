using UnityEngine;

public class LayerCollisionIgnore : MonoBehaviour
{
    public int layer_curr, layer_ignore;

    private void Update()
    {
        Physics.IgnoreLayerCollision(layer_curr, layer_ignore);
    }
}
