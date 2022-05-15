using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeTimeAnimation : MonoBehaviour
{
    public Text GoldAnimation;
    public Game_controller _gameController;
    private float currentGold;
    public ParticleSystem particle;
    public ParticleSystem mergeParticle;
    public GameObject MergePanel;
    public bool isActive;
    public float timer;
    float step;
    int val;
    void Start()
    {
        particle.Stop();
    }

    void FixedUpdate()
    {
    }
    public  void TurnOnParticle(int value)
    {
        particle.Play();
        _gameController.GoldForSellRessources(value);
    }
    public void test()
    {
        if (isActive)
        {
            timer += Time.fixedDeltaTime;
            particle.Play();
            float tt = currentGold += step;

            GoldAnimation.text = Mathf.RoundToInt(tt).ToString();

            if (timer >= 0.25f)
            {
                _gameController.GoldForSellRessources(val);
                isActive = false;
                timer = 0;
            }
        }
    }
}
