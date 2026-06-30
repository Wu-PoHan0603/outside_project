using UnityEngine;
using MatchGem.Core;

namespace MatchGem.View
{
    /// <summary>
    /// [MonoBehaviour]單顆寶石的畫面元件(強制綁定SpriteRenderer)
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class GemTile : MonoBehaviour
    {
        #region 基本參數
        [SerializeField]
        private float _tileScale = 0.9f;
        private SpriteRenderer _spriteRenderer;
        /// <summary>
        /// 視覺渲染的延遲讀取
        /// </summary>
        //private SpriteRenderer SpriteRenderer => _spriteRenderer == null ? _spriteRenderer = GetComponent<SpriteRenderer>() : _spriteRenderer; 三元運算子寫法 結構 (? : ;) <?一定要給條件>
        private SpriteRenderer SpriteRenderer
        {
            get
            {
                if (_spriteRenderer == null)
                {
                    _spriteRenderer = GetComponent<SpriteRenderer>();
                }
                return _spriteRenderer;
            }
        }
        /// <summary>
        /// [static(靜態)]共用靜態(Sprite)參數 統一管理
        /// </summary>
        private static Sprite _defualtSprite;
        #endregion 基本參數

        #region 公開功能
        /// <summary>
        /// 依照設定的寶石種類更新視覺
        /// </summary>
        /// <param name="gemType">寶石種類</param>
        public void SetGem(GemType gemType)
        {
            SpriteRenderer.sprite = GetDefaultSprite();
            SpriteRenderer.color = GetColor(gemType);
            transform.localScale = Vector3.one * _tileScale;
        }
        #endregion 公開功能

        #region 私有功能
        /// <summary>
        /// 取得一張預設的Sprite圖片(白色)
        /// </summary>
        /// <returns>Sprite圖片</returns>
        private Sprite GetDefaultSprite()
        {
            if (_defualtSprite == null)
            {
                Texture2D texture = new Texture2D(1, 1); //建立最小單位的貼圖 1*1
                texture.SetPixel(0, 0, Color.white); //設定像素顏色
                texture.Apply();
                //用指定參數格式建立圖片(貼圖,預設矩形定位&尺寸,錨點位置正中,一單位容納像素值)
                _defualtSprite = Sprite.Create(texture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1);
            }
            return _defualtSprite;

        }

        /// <summary>
        /// 取得寶石種類對應的色票
        /// </summary>
        /// <param name="gemType">寶石種類</param>
        /// <returns>對應的色票</returns>
        private Color GetColor(GemType gemType)
        {
            switch (gemType)
            {
                case GemType.Red: return Color.red;
                case GemType.Blue: return Color.blue;
                case GemType.Green: return Color.green;
                case GemType.Yellow: return Color.yellow;
                case GemType.Purple: return new Color(0.5f, 0f, 0.5f);
                case GemType.Pink: return new Color(1f, 0.75f, 0.8f);
            }
            return Color.white;
        }
        #endregion 私有功能


    }
}
