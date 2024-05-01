using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MoneyPower : ConsumablePower
{
    private ScoreManager sm;
    private SfxPlayer sfx;
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("GenericManagers").GetComponent<ScoreManager>();
        sfx = GameObject.FindGameObjectWithTag("SfxPlayer").GetComponent<SfxPlayer>();
        Invoke("Ding", 1.0f);
        Invoke("CashIn", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ding()
    {
        sfx.PlayDingSfx();
        sfx.RandomCashVoice();

    }

    void CashIn(){
        sm.IncrementScore();
        Destroy(gameObject);
    }
}
