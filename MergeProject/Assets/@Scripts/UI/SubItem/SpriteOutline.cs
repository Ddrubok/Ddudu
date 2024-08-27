using UnityEngine;

public class SpriteOutline : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color outlineColor { get; set; } = new Color(0.9921875f, 0.98828125f, 0.28125f);
    public float outlineThickness { get; set; } = 0.25f; 

    private GameObject outlineObject; 
    void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        CreateOutline();
    }

    void CreateOutline()
    {
        outlineObject = new GameObject("Outline");

        SpriteRenderer outlineSpriteRenderer = outlineObject.AddComponent<SpriteRenderer>();

        Texture2D outlineTexture = CreateOutlineTexture(spriteRenderer.sprite.texture);
        outlineSpriteRenderer.sprite = Sprite.Create(outlineTexture,
            new Rect(0, 0, outlineTexture.width, outlineTexture.height),
            new Vector2(0.5f, 0.5f));

        outlineSpriteRenderer.color = outlineColor; 
        outlineSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder - 1; 

        outlineObject.transform.localScale = spriteRenderer.transform.localScale * (1.0f+outlineThickness);

        outlineObject.transform.SetParent(spriteRenderer.transform);
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localRotation = Quaternion.identity;

    }

    Texture2D CreateOutlineTexture(Texture2D originalTexture)
    {
        // 원본 텍스처를 복사
        Texture2D copyTexture = new Texture2D(originalTexture.width, originalTexture.height, originalTexture.format, false);
        Graphics.CopyTexture(originalTexture, copyTexture);

        // 픽셀 데이터 가져오기
        Color[] pixels = copyTexture.GetPixels();
        Color[] outlinePixels = new Color[pixels.Length];

        for (int i = 0; i < pixels.Length; i++)
        {
            outlinePixels[i] = pixels[i].a > 0 ? outlineColor : new Color(0, 0, 0, 0); // 알파 값이 있는 경우 아웃라인 색상으로 설정
        }

        // 새로운 텍스처에 픽셀 설정
        Texture2D outlineTexture = new Texture2D(copyTexture.width, copyTexture.height);
        outlineTexture.SetPixels(outlinePixels);
        outlineTexture.Apply();

        return outlineTexture;
    }

    public void OutLineOn()
    {
        outlineObject.SetActive(true);
    }

    public void OutLineOff()
    {
        outlineObject.SetActive(false); 
    }
}
