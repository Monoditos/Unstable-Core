using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSprite : MonoBehaviour
{

    public Image image;
    public Sprite normal;
    public Sprite clicked;

    public float clickTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void ChangeSprite()
    {
        StartCoroutine(clickSprite());
    }

    public IEnumerator clickSprite()
    {
        image.sprite = clicked;
        yield return new WaitForSeconds(clickTime);
        image.sprite = normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
