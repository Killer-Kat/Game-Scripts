using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LanternController : MonoBehaviour
{
    public Transform target;
    private PlayerController Playerman;
    public Light2D lt;
    // Start is called before the first frame update
    void Start()
    {
        Playerman = FindObjectOfType<PlayerController>();
        target = Playerman.transform;
        lt = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
    public void ToggleLantern()
    {
        lt.enabled = !lt.enabled;
    }
}
