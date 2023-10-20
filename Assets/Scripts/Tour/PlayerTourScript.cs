using UnityEngine;

public class PlayerTourScript : MonoBehaviour
{
    public AudioSource audioSource;
    public Renderer rend;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public float moveSpeed = 5;
    public Animator animator;
    public AudioManager audioManager;
    private int spriteVariation = 0;

    //This part is really ifty and prolly should be moved to its own later on

    public GameObject uiButtons;
    public GameObject terminal;
    public GameObject sign1;
    public GameObject sign2;
    public GameObject shop1;
    public GameObject shop2;
    public GameObject landmark;
    public GameObject gasStation;
    public GameObject modShop;
    public GameObject gasStationUI;
    public GameObject modShopUI;
    public GameObject landmarkUI;
    public GameObject notForSaleUI;
    public GameObject sign1UI;
    public GameObject sign2UI;
    public GameObject shop1UI;
    public GameObject shop2UI;
    public GameObject cantTravelUI;
    public GameObject destinationUI;
    public AudioClip successAudio;
    public AudioClip failedAudio;
    private bool checkedLandmark = false;

    void Start()
    {
        Time.timeScale = 1; //Resume the game if it is paused
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
    }

    void Update()
    {
        DataManager manager = DataManager.instance;
        Debug.Log("Current Tour Actor: " + manager.TourActor);
        if (manager.TourActor.Equals("Kalesa"))
        {
            spriteVariation = -1;
        }
        if (manager.TourActor.Equals("Tricycle"))
        {
            spriteVariation = 1;
        }
        Debug.Log("Current Sprite Variation " + spriteVariation);
        animator.SetFloat("SpriteVariation", spriteVariation);
        Debug.Log("Current Sprite Variation in animator " + animator.GetFloat("SpriteVariation"));
    }

    public void MoveLeft()
    {
        float moveDirection = -1;
        Debug.Log("Moving Left...");
        animator.SetFloat("Vertical", moveDirection);
        animator.SetFloat("Speed", moveSpeed);
        Debug.Log("Current Velocity: " + rb.velocity);
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
        Debug.Log("New Velocity: " + rb.velocity);
    }

    public void MoveRight()
    {
        float moveDirection = 1;
        Debug.Log("Moving Right...");
        animator.SetFloat("Vertical", moveDirection);
        animator.SetFloat("Speed", moveSpeed);
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
    }

    public void StopMovingRight()
    {
        Debug.Log("Standing...");
        animator.SetFloat("Vertical", 0.01f);
        animator.SetFloat("Speed", 0);
        rb.velocity = Vector2.zero;
    }


    public void StopMovingLeft()
    {
        Debug.Log("Standing...");
        animator.SetFloat("Vertical", -0.01f);
        animator.SetFloat("Speed", 0);
        rb.velocity = Vector2.zero;
    }

    public void Interact()
    {
        Debug.Log("Interacting...");
        float distance = Vector3.Distance(transform.position, landmark.transform.position);
        if (distance < 5.0f)
        {
            Debug.Log("Interacting with The landmark...");
            audioManager.PlayAudio(2);
            checkedLandmark = true;
            showUI(landmarkUI);
        }
        distance = Vector3.Distance(transform.position, terminal.transform.position);
        if (distance < 2.0f)
        {
            audioManager.PlayAudio(0);
            if(DataManager.instance.Gas < 50){
                showUI(cantTravelUI);
                return;
            }
            showUI(destinationUI);
        }
        distance = Vector3.Distance(transform.position, gasStation.transform.position);
        if (distance < 2.0f)
        {
            audioManager.PlayAudio(0);
            Debug.Log("Interacting with the gas station...");
            showUI(gasStationUI);
        }
        distance = Vector3.Distance(transform.position, modShop.transform.position);
        if (distance < 2.0f)
        {
            audioManager.PlayAudio(0);
            Debug.Log("Interacting with the mod shop...");
            showUI(modShopUI);
        }
        distance = Vector3.Distance(transform.position, shop1.transform.position);
        if (distance < 3.0f && shop1.activeSelf)
        {
            audioManager.PlayAudio(1);
            Debug.Log("Interacting with Shop 1...");
            showUI(shop1UI);
        }
        distance = Vector3.Distance(transform.position, shop2.transform.position);
        if (distance < 3.0f && shop2.activeSelf)
        {
            audioManager.PlayAudio(1);
            Debug.Log("Interacting with Shop 2...");
            showUI(shop2UI);
        }
        distance = Vector3.Distance(transform.position, sign1.transform.position);
        if (distance < 3.0f && !shop1.activeSelf)
        {
            audioManager.PlayAudio(3);
            Debug.Log("Interacting with Shop 1 Sign...");
            showUI(sign1UI);
        }
        distance = Vector3.Distance(transform.position, sign2.transform.position);
        if (distance < 3.0f && !shop2.activeSelf)
        {
            audioManager.PlayAudio(4);
            Debug.Log("Interacting with Shop 2 Sign...");
            if (!checkedLandmark)
            {
                showUI(notForSaleUI);
                return;
            }
            showUI(sign2UI);
        }
    }

    public void CloseGasStationUI()
    {
        hideUI(gasStationUI);
    }

    public void CloseModShopUI()
    {
        hideUI(modShopUI);
    }

    public void CloseNotForSaleUI()
    {
        hideUI(notForSaleUI);
    }

    public void CloseShop1UI()
    {
        hideUI(shop1UI);
    }

    public void CloseShop2UI()
    {
        hideUI(shop2UI);
    }

    public void CloseSign1UI()
    {
        hideUI(sign1UI);
    }


    public void CloseSign2UI()
    {
        hideUI(sign2UI);
    }

    public void CloseCantTravel()
    {
        hideUI(cantTravelUI);
    }

    public void CloseDestinationUI()
    {
        hideUI(destinationUI);
    }

    public void BuyShop1()
    {
        DataManager manager = DataManager.instance;
        Debug.Log("Buying Shop 1...");
        if (manager.Money < 15)
        {
            Debug.Log("Not enough money");
            audioSource.clip = failedAudio;
            audioSource.Play();
            return;
        }
        manager.Money -= 15;
        if (manager.CurrentScene.Equals("Mabini"))
            manager.MabiniShop1 = true;
        audioSource.clip = successAudio;
        audioSource.Play();
        shop1.SetActive(true);
        hideUI(sign1UI);
    }

    public void BuyShop2()
    {
        DataManager manager = DataManager.instance;
        Debug.Log("Buying Shop 2...");
        if (manager.Money < 25)
        {
            Debug.Log("Not enough money");
            audioSource.clip = failedAudio;
            audioSource.Play();

            manager.Save();
            return;
        }
        manager.Money = DataManager.instance.Money - 25;
        if (manager.CurrentScene.Equals("Mabini"))
            manager.MabiniShop2 = true;
        audioSource.clip = successAudio;
        audioSource.Play();
        shop2.SetActive(true);
        hideUI(sign2UI);
        manager.Save();
    }


    // Private methods just for modularization
    void showUI(GameObject menu)
    {
        DataManager manager = DataManager.instance;
        menu.SetActive(true);
        uiButtons.SetActive(false);
        Time.timeScale = 0;
        manager.Save();
    }

    void hideUI(GameObject menu)
    {
        DataManager manager = DataManager.instance;
        menu.SetActive(false);
        uiButtons.SetActive(true);
        Time.timeScale = 1;
        manager.Save();
    }
}
