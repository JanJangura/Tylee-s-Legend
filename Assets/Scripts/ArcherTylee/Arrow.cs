
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 m_target;
    public float Speed;

    private void Start()
    {
        this.gameObject.tag = "Arrow";        
    }

    void Update()
    {
        float step = Speed * Time.deltaTime;

        if (m_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }
    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if (other.gameObject.tag == "AI" || other.gameObject.tag == "Nightmare")
            {
                Invoke("Destruction", .8f);
            }
        }   
    }

    void Destruction()
    {
        GetComponent<Collider>().enabled = false;
        Destroy(this.gameObject);
    }
}
