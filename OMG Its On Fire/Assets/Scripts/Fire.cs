using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : QuestItem
{
    public int life;
    public int maxLife;
    public Transform healthbar;
    public AllowEntry allowEntry;

    // Start is called before the first frame update
    void Start()
    {
        maxLife = life;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        life--;
        UpdateHealthBar();

        if (life < 0)
        {
            if(QuestManager.Instance != null)
            {
                Complete();
                allowEntry.questItemsCount--;
                allowEntry.CheckQeustItemsCount();
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }           
                  
        }
    }

    private void UpdateHealthBar()
    {
        healthbar.localScale = new Vector3((float)life / maxLife, 1f, 1f);
    }

    public void ResetFire()
    {
        life = maxLife;
        UpdateHealthBar();
        gameObject.SetActive(true);
    }
}
