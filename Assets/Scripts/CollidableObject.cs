using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    private Collider2D z_collider;
    [SerializeField]
    private ContactFilter2D z_filter;
    private List<Collider2D> z_collidableObjects = new List<Collider2D>(1); 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        z_collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        z_collider.OverlapCollider(z_filter, z_collidableObjects);
        foreach(var o in z_collidableObjects)
        {
            OnCollided(o.gameObject);
        }
    }

    protected virtual void OnCollided(GameObject collidedObject)
    {
        Debug.Log("Collided with" + collidedObject.name);
    }
}
