using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerplayer : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    public Text hitungText;
    public Text winText;
    private int hitung;

    void start()
    {
        rb = GetComponent<Rigidbody>();
        hitung = 0;
        SetHitungText();
        winText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Hori");
        float moveVertical = Input.GetAxis("Ver");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            hitung = hitung + 1;

            SetHitungText();
        }
    }

    void SetHitungText()
    {
        hitungText.text = "Jumlah Kubus: " + hitung.ToString();
        if (hitung >= 12)
        {
            winText.text = "Kamu Menang";
        }
    }

}
