using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GenericHealthBar
{
    public class IconChange : MonoBehaviour
    {
        [SerializeField] private Image originalImage;
        [SerializeField] private Sprite newSprite;

        public void Start()
        {
            Invoke("ImageChange", 4f);
        }

        public void ImageChange()
        {
            originalImage.sprite = newSprite;
        }
    }
}