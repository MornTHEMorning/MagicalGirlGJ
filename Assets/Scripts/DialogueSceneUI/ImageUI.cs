using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ImageUI : MonoBehaviour
{
    [Header("Images, Background Images")]
    public Sprite[] images;

    public Image currentImage;

    private int index = 0;

    void Start()
    {
        currentImage = GetComponent<Image>();

        if (images.Length > 0)
        {
            ShowImage(index); // Show the first image
        }
        else
        {
            Debug.Log("ImageUI has been disabled; no bg images");
            this.enabled = false;
        }
    }

    void Update()
    {
       if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            index++;
            if (index >= images.Length) // Check if index is out of bounds
            {
                gameObject.SetActive(false);
                // if you want to load the next scene
                // SceneManager.LoadScene(nextScene);
            }
            else
            {
                ShowImage(index);
            }
        }
    }

    void ShowImage(int index)
    {
        if (currentImage != null && index >= 0 && index < images.Length)
        {
            Debug.Log($"currentImage: {currentImage} || sprite: {currentImage.sprite}");
            currentImage.sprite = images[index];
        }
        else
        {
            Debug.LogError("Invalid index or currentImage is not assigned.");
        }
    }
}
