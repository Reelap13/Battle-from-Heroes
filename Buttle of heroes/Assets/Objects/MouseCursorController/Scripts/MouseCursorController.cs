using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class MouseCursorController : MonoBehaviour
{
    public UnityEvent<Field> onEnterToField = new UnityEvent<Field>();
    public UnityEvent<Field> onClickToField = new UnityEvent<Field>();
    public UnityEvent<Field> onLeaveFromField = new UnityEvent<Field>();

    [SerializeField] private Sprite _defaultCursor;

    private Field _fieldInQuestion;

    private void Awake()
    {
        SetDefaultCursor();
    }

    public void EnterToField(Field field)
    {
        if (_fieldInQuestion != null)
            LeaveFromFild(_fieldInQuestion);

        _fieldInQuestion = field;
        onEnterToField.Invoke(field);
    }

    public void LeaveFromFild(Field field)
    {
        if (_fieldInQuestion != field)
            return;

        _fieldInQuestion = null;
        onLeaveFromField.Invoke(field);
        SetDefaultCursor();
    }

    public void ClickOnField(Field field)
    {
        if (_fieldInQuestion != field)
            return;

        onClickToField.Invoke(field);
    }

    public void SetDefaultCursor()
    {
        SetCursor(_defaultCursor);
    }

    public void SetCursor(Sprite sprite)
    {
        //ParseSpriteToTexture2D(sprite);
        Cursor.SetCursor(ParseSpriteToTexture2D(sprite), Vector2.zero, CursorMode.ForceSoftware);
    }

    private Texture2D ParseSpriteToTexture2D(Sprite sprite)
    {
        var texture2D = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        var pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                        (int)sprite.textureRect.y,
                                        (int)sprite.textureRect.width,
                                        (int)sprite.textureRect.height);
        texture2D.SetPixels(pixels);
        texture2D.Apply();

        return texture2D;
    }
}
