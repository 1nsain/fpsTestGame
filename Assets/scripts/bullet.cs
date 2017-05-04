using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    /// <summary>
    /// gameobject takes the object from the game and adds it to a varible 
    /// </summary>
    public GameObject bulletPrefab;
    public float bulletimpulse;
    public GameObject GranadaPrefab;
    public float Granadaimpulse;
    public GameObject Map;
	// Use this for initialization
	void Start () {
		
	}
    
    
	
	/// <summary>
	/// update is called once a frame
	/// </summary>
    /// <sumary>
    /// input get button fire1 = mouse 1
    /// cam takes camera main
    /// thebullet initiates a prefab from gameobject bulletprefab and gives it speed
    /// </sumary>
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            Camera cam = Camera.main;
            GameObject thebullet = (GameObject)Instantiate(bulletPrefab, cam.transform.position, cam.transform.rotation);
            thebullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletimpulse,ForceMode.Impulse);
            
        }

    /// <sumary>
    /// same as bullet but with a swaped prefab to look like a granade
    /// </sumary>
        if (Input.GetButtonDown("Fire2"))
        {
            Camera cam = Camera.main;
            GameObject theGranada = (GameObject)Instantiate(GranadaPrefab, cam.transform.position, cam.transform.rotation);
            theGranada.GetComponent<Rigidbody>().AddForce(cam.transform.forward * Granadaimpulse, ForceMode.Impulse);
            Destroy(theGranada, 5);
        }
        
        
		
	}
    
}
