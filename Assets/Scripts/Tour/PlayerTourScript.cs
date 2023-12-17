using System.Collections.Generic;
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
    private List<float> yLanes = new List<float> { -2.5f, -3f, -3.5f };
    private int yLanePositionIndex = 0;

    void Start()
    {
        if(TutorialManager.instance.tutorialStartFinished)
            Time.timeScale = 1;
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;
        gameObject.transform.position = new Vector3(transform.position.x, yLanes[yLanePositionIndex], 0);
        shop1.transform.position = new Vector3(shop1.transform.position.x, shop1.transform.position.y + 10, shop1.transform.position.z);
    }

    void Update()
    {
        DataManager manager = DataManager.instance;
        if (manager.TourActor.Equals("Kalesa"))
        {
            spriteVariation = -1;
        }
        if (manager.TourActor.Equals("Tricycle"))
        {
            spriteVariation = 1;
        }
        animator.SetFloat("SpriteVariation", spriteVariation);
        switch(yLanePositionIndex)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 18;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 19;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 20;
                break;
        }
    }

    public void MoveUp()
    {
        switch(yLanePositionIndex)
        {
            case 2:
                yLanePositionIndex = 1;
                break;
            case 1:
                yLanePositionIndex = 0;
                break;
        }
        gameObject.transform.position = new Vector3(transform.position.x, yLanes[yLanePositionIndex], 0);
    }

    public void MoveDown()
    {
        switch(yLanePositionIndex)
        {
            case 1:
                yLanePositionIndex = 2;
                break;
            case 0:
                yLanePositionIndex = 1;
                break;
        }
        transform.transform.position = new Vector3(transform.position.x, yLanes[yLanePositionIndex], 0);
    }

    public void MoveLeft()
    {
        float moveDirection = -1;
        animator.SetFloat("Vertical", moveDirection);
        animator.SetFloat("Speed", moveSpeed);
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
    }

    public void MoveRight()
    {
        float moveDirection = 1;
        animator.SetFloat("Vertical", moveDirection);
        animator.SetFloat("Speed", moveSpeed);
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
    }

    public void StopMovingRight()
    {
        animator.SetFloat("Vertical", 0.01f);
        animator.SetFloat("Speed", 0);
        rb.velocity = Vector2.zero;
    }


    public void StopMovingLeft()
    {
        animator.SetFloat("Vertical", -0.01f);
        animator.SetFloat("Speed", 0);
        rb.velocity = Vector2.zero;
    }

    public void Interact()
    {
        float distance = Vector3.Distance(transform.position, landmark.transform.position);
        if (distance < 5.0f)
        {
            audioManager.PlayAudio(2);
            checkedLandmark = true;
            showUI(landmarkUI);
        }
        distance = Vector3.Distance(transform.position, terminal.transform.position);
        if (distance < 2.0f)
        {
            audioManager.PlayAudio(0);
            if (DataManager.instance.Gas < 50)
            {
                showUI(cantTravelUI);
                return;
            }
            showUI(destinationUI);
        }
        distance = Vector3.Distance(transform.position, gasStation.transform.position);
        if (distance < 2.0f)
        {
            audioManager.PlayAudio(0);
            showUI(gasStationUI);
        }
        distance = Vector3.Distance(transform.position, modShop.transform.position);
        if (distance < 2.0f)
        {
            audioManager.PlayAudio(0);
            showUI(modShopUI);
        }
        distance = Vector3.Distance(transform.position, shop1.transform.position);
        if (distance < 3.0f && shop1.activeSelf)
        {
            audioManager.PlayAudio(1);
            showUI(shop1UI);
        }
        distance = Vector3.Distance(transform.position, shop2.transform.position);
        if (distance < 3.0f && shop2.activeSelf)
        {
            audioManager.PlayAudio(1);
            showUI(shop2UI);
        }
        distance = Vector3.Distance(transform.position, sign1.transform.position);
        if (distance < 3.0f && !shop1.activeSelf)
        {
            audioManager.PlayAudio(3);
            showUI(sign1UI);
        }
        distance = Vector3.Distance(transform.position, sign2.transform.position);
        if (distance < 3.0f && !shop2.activeSelf)
        {
            audioManager.PlayAudio(4);
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

    public void BuyGas()
    {

        DataManager manager = DataManager.instance;
        if (manager.Money < 10)
        {
            audioSource.clip = failedAudio;
            audioSource.Play();
            return;
        }
        manager.Money -= 10;
        manager.Gas += 7.5f;
        audioSource.clip = successAudio;
        audioSource.Play();
    }

    public void BuyShop1()
    {
        DataManager manager = DataManager.instance;
        if (manager.Money < 15)
        {
            audioSource.clip = failedAudio;
            audioSource.Play();
            return;
        }
        manager.Money -= 15;
        switch (manager.CurrentScene)
        {
            case "Lipa":
                manager.Money += 15; // This is free
                break;
            case "Mabini":
                manager.MabiniShop1 = true;
                break;
            case "Malvar":
                manager.MalvarShop1 = true;
                break;
            case "Bauan":
                manager.BauanShop1 = true;
                break;
            case "SanJose":
                manager.SanJoseShop1 = true;
                break;
            case "Lobo":
                manager.LoboShop1 = true;
                break;
            case "Balayan":
                manager.BalayanShop1 = true;
                break;
        }
        audioSource.clip = successAudio;
        audioSource.Play();
        shop1.SetActive(true);
        shop1.transform.position = new Vector3(shop1.transform.position.x, shop1.transform.position.y - 10, shop1.transform.position.z);
        hideUI(sign1UI);
    }

    public void BuyShop2()
    {
        DataManager manager = DataManager.instance;
        if (manager.Money < 25)
        {
            audioSource.clip = failedAudio;
            audioSource.Play();

            manager.Save();
            return;
        }
        manager.Money = DataManager.instance.Money - 25;
        switch (manager.CurrentScene)
        {
            case "Mabini":
                manager.MabiniShop2 = true;
                break;
            case "Malvar":
                manager.MalvarShop2 = true;
                break;
            case "Bauan":
                manager.BauanShop2 = true;
                break;
            case "SanJose":
                manager.SanJoseShop2 = true;
                break;
            case "Lobo":
                manager.LoboShop2 = true;
                break;
            case "Balayan":
                manager.BalayanShop2 = true;
                break;
        }
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
