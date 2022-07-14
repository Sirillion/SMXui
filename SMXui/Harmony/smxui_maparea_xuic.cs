using UnityEngine;
public class XUiC_MapAreaSDX : XUiC_MapArea
{

    private EntityPlayer localPlayer;
    private bool bMapInitialized;
    private XUiV_Texture xuiTexture;
    private Texture2D mapTexture;

    public override void Init()
    {
        base.Init();
        initMap();
    }
    private void initMap()
    {
        if (base.xui.playerUI.entityPlayer == null)
        {
            return;
        }
        localPlayer = base.xui.playerUI.entityPlayer;
        this.bMapInitialized = true;
        this.xuiTexture.Material.SetTexture("_MainTex", this.mapTexture);
        this.xuiTexture.Size = new Vector2i(1140, 710);
    }

}