using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //public Sprite healthBar1;
    //public Sprite healthBar2;

    public List<Sprite> healthBar;

    public HealthController healthController;

    int hbNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = healthBar[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (healthController.currentHealth < 100 && healthController.currentHealth >= 90) 
            GetComponent<Image>().sprite = healthBar[0];
        
        else if (healthController.currentHealth < 90 && healthController.currentHealth >= 80) 
            GetComponent<Image>().sprite = healthBar[1];
        
        else if (healthController.currentHealth < 80 && healthController.currentHealth >= 70) 
            GetComponent<Image>().sprite = healthBar[2];
        
        else if (healthController.currentHealth < 70 && healthController.currentHealth >= 60) 
            GetComponent<Image>().sprite = healthBar[3];
        
        else if (healthController.currentHealth < 60 && healthController.currentHealth >= 50) 
            GetComponent<Image>().sprite = healthBar[4];
        
        else if (healthController.currentHealth < 50 && healthController.currentHealth >= 40) 
            GetComponent<Image>().sprite = healthBar[5];
        
        else if (healthController.currentHealth < 40 && healthController.currentHealth >= 30) 
            GetComponent<Image>().sprite = healthBar[6];
        
        else if (healthController.currentHealth < 30 && healthController.currentHealth >= 20) 
            GetComponent<Image>().sprite = healthBar[7];
        
        else if (healthController.currentHealth < 20 && healthController.currentHealth >= 10) 
            GetComponent<Image>().sprite = healthBar[8];
        
        else if (healthController.currentHealth < 10 && healthController.currentHealth >= 0) 
            GetComponent<Image>().sprite = healthBar[9];
        
        else if (healthController.currentHealth < 0) 
            GetComponent<Image>().sprite = healthBar[10];


    }
}
