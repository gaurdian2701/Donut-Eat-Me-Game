using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour, IDamageable<float>
{
    public UIManager uim;
    public Animator animator;
    public UnityEngine.UI.Image healthBarImage;
    [SerializeField] private float health = 100;
    private Scene scene;
    [SerializeField] private PlayerSoundManager playerSounds;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        uim = GameObject.Find("Canvas").GetComponent<UIManager>();
        Assert.IsNotNull(healthBarImage);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.health <= 0)
        {
            Debug.Log("player dead");
            OnDied();
            this.enabled = false;
        }
    }

    public void takeDamage(float damage)
    {
        this.health -= damage;
        healthBarImage.fillAmount = this.health / 100;
        playerSounds.PlayHurtSound();
    }

    public void OnDied()
    {
        //SceneManager.LoadScene(scene.name);
        StartCoroutine(WaitForDeath());
        animator.SetTrigger("isDead");
        playerSounds.PlayDeathSound();
        uim.DeathScreen();
    }
    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(3f);
    }
}