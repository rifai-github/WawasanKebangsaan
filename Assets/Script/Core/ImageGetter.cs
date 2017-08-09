using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGetter : MonoBehaviour
{
    public static ImageGetter GetImage()
    {
        GameObject go = new GameObject("Image");
        go.AddComponent<ImageGetter>();

        ImageGetter image = go.GetComponent<ImageGetter>() as ImageGetter;

        return image;
    }

    public void StartGettingImage(Image image, string url)
    {
        StartCoroutine(GetImageCourotine(image, url));
    }

    private IEnumerator GetImageCourotine(Image image, string url)
    {
        WWW _URLLink = new WWW(url);
        yield return _URLLink;
        
        if (_URLLink.error == null)
        {
            //image.sprite = Sprite.Create(_URLLink.texture, new Rect(0, 0, _URLLink.texture.width, _URLLink.texture.height), new Vector2(0.5f, 0.5f));
            image.sprite = StaticFunction.TextureToSprite(_URLLink.texture);
            Destroy(this.gameObject);
        }
        else
        {
            StaticFunction.WKMessageError(_URLLink.error);
            Destroy(this.gameObject);
        }
    }
}
