using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousScrap : MonoBehaviour
{
    public GameObject warning;
    public GameObject projectile;
    public float waitTime;
    public float despawnTime;
    private NewPlayerMovement player;
    // Start is called before the first frame update
    
    void Start()
    {
        
        StartCoroutine(WaitBeforeSettingProjectileActive());
        player = PlayerReference.player.GetComponent<NewPlayerMovement>();
        warning.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + player.velocity * Time.deltaTime, 0);
        projectile.transform.position = new Vector3(transform.position.x, projectile.transform.position.y);
    }

    IEnumerator WaitBeforeSettingProjectileActive()
    {
        yield return new WaitForSeconds(waitTime);
        
        projectile.SetActive(true);
        Destroy(warning);
        projectile.transform.position = new Vector3(transform.position.x, player.transform.position.y - 10);
        yield return new WaitForSeconds(despawnTime);
        Destroy(projectile);
        Destroy(gameObject);
    }
}
