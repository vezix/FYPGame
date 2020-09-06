using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    //public Text HealthText;

    public PlayerController thePlayer;
    public CharacterController charController;
    public Renderer playerRenderer;

    public float invincibilityLength;
    private float invicibilityCounter;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    public GameObject deathEffect;
    public Image blackScreen;
    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    public float fadeSpeed;
    public float waitForFade;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //HealthText.text = "Health: " + (currentHealth);
        //thePlayer = FindObjectOfType<PlayerController>();
        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (invicibilityCounter > 0)
        {
            invicibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }

            if (invicibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }

        if (isFadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }
        if (isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }
    }

    public void respawn()
    {
        //thePlayer.transform.position = respawnPoint;
        //currentHealth = maxHealth;   
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
    }
    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(respawnLength);
        isFadeToBlack = true;
        yield return new WaitForSeconds(waitForFade);
        isFadeFromBlack = true;

        isRespawning = false; 

        thePlayer.gameObject.SetActive(true);
        charController.enabled = false;
        thePlayer.transform.position = respawnPoint;
        charController.enabled = true;
        currentHealth = maxHealth;

        invicibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength;
        //HealthText.text = "Health: " + (currentHealth);
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invicibilityCounter <= 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                respawn();
            }
            else
            {
                thePlayer.Knockback(direction);
                invicibilityCounter = invincibilityLength;
                playerRenderer.enabled = false;
                flashCounter = flashLength;
            }
        }

        //HealthText.text = "Health: " + (currentHealth);
    }
    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
