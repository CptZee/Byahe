using System.Collections;
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
    public GameObject boundWarningUI;
    public GameObject connedUI;
    public GameObject touristUI;
    public GameObject conStart;
    public GameObject touristStart;
    public AudioClip successAudio;
    public AudioClip failedAudio;
    private bool checkedLandmark = false;
    private List<float> yLanes = new List<float> { -2.5f, -3f, -3.5f };
    private int yLanePositionIndex = 0;

    void Start()
    {
        if (TutorialManager.instance.tutorialStartFinished)
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Lane ID: " + yLanePositionIndex);
        if (collision.gameObject.CompareTag("Con-Line1"))
        {
            if (yLanePositionIndex != 0)
                return;
            connedUI.SetActive(true);
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = new Vector3(conStart.transform.position.x,
                collision.gameObject.transform.position.y,
                collision.gameObject.transform.position.z);
            StartCoroutine(DeactivateConnedUIAfterDelay(2.0f, collision));
            DataManager.instance.Money -= 0.2f;
        }
        if (collision.gameObject.CompareTag("Con-Line2"))
        {
            if (yLanePositionIndex != 1)
                return;
            connedUI.SetActive(true);
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = new Vector3(conStart.transform.position.x,
                collision.gameObject.transform.position.y,
                collision.gameObject.transform.position.z);
            StartCoroutine(DeactivateConnedUIAfterDelay(2.0f, collision));
            DataManager.instance.Money -= 0.2f;
        }
        if (collision.gameObject.CompareTag("Con-Line3"))
        {
            if (yLanePositionIndex != 2)
                return;
            connedUI.SetActive(true);
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = new Vector3(conStart.transform.position.x,
                collision.gameObject.transform.position.y,
                collision.gameObject.transform.position.z);
            StartCoroutine(DeactivateConnedUIAfterDelay(2.0f, collision));
            DataManager.instance.Money -= 0.2f;
        }
        if (collision.gameObject.CompareTag("Tourist-Line1"))
        {
            if (yLanePositionIndex != 0)
                return;
            touristUI.SetActive(true);
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = new Vector3(touristStart.transform.position.x,
                collision.gameObject.transform.position.y,
                collision.gameObject.transform.position.z);
            StartCoroutine(DeactivateTouristUIAfterDelay(2.0f, collision));
            DataManager.instance.Money += 0.1f;
        }
        if (collision.gameObject.CompareTag("Tourist-Line2"))
        {
            if (yLanePositionIndex != 1)
                return;
            touristUI.SetActive(true);
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = new Vector3(touristStart.transform.position.x,
                collision.gameObject.transform.position.y,
                collision.gameObject.transform.position.z);
            StartCoroutine(DeactivateTouristUIAfterDelay(2.0f, collision));
            DataManager.instance.Money += 0.1f;
        }
        if (collision.gameObject.CompareTag("Tourist-Line3"))
        {
            if (yLanePositionIndex != 2)
                return;
            touristUI.SetActive(true);
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = new Vector3(touristStart.transform.position.x,
                collision.gameObject.transform.position.y,
                collision.gameObject.transform.position.z);
            StartCoroutine(DeactivateTouristUIAfterDelay(2.0f, collision));
            DataManager.instance.Money += 0.1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            boundWarningUI.SetActive(true);
        }
    }
    IEnumerator DeactivateConnedUIAfterDelay(float delay, Collider2D otherCollider)
    {
        yield return new WaitForSeconds(delay);
        connedUI.SetActive(false);
        otherCollider.gameObject.SetActive(true);
    }
    IEnumerator DeactivateTouristUIAfterDelay(float delay, Collider2D otherCollider)
    {
        yield return new WaitForSeconds(delay);
        touristUI.SetActive(false);
        otherCollider.gameObject.SetActive(true);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            boundWarningUI.SetActive(false);
        }
    }

    public void MoveUp()
    {
        switch (yLanePositionIndex)
        {
            case 2:
                yLanePositionIndex = 1;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 19;
                break;
            case 1:
                yLanePositionIndex = 0;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 18;
                break;
        }
        gameObject.transform.position = new Vector3(transform.position.x, yLanes[yLanePositionIndex], 0);
    }

    public void MoveDown()
    {
        switch (yLanePositionIndex)
        {
            case 1:
                yLanePositionIndex = 2;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 20;
                break;
            case 0:
                yLanePositionIndex = 1;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 19;
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
