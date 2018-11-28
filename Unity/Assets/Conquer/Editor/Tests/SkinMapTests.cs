using NUnit.Framework;
using System.Collections.Generic;
using Assets.UI.Windows.Tools.Editor;
using Conquer.Scripts.Info;

[TestFixture]
public class SkinMapTests
{
    private List<CellItemsMapInfo> _mapInfos;
    
    [OneTimeSetUp]
    public void Initialize()
    {
        _mapInfos = AssetEditorTools.GetAssets<CellItemsMapInfo>();
    }

    [Test]
    public void MapExistsTest()
    {
        foreach (var mapInfo in _mapInfos)
        {
            Assert.IsNotNull(mapInfo);
        }
    }
    
    [Test]
    public void ValidateAllSkinsTest([Range(1,6, 1)] int x,[Range(1,6, 1)] int y) 
    {

        foreach (var mapInfo in _mapInfos)
        {
            var skins = mapInfo.SkinNames;
            for (int i = 0; i < skins.Count; i++)
            {
                var skinItem = mapInfo.GetCellInfo(i, x, y);
                Assert.IsNotNull(skinItem);
            }
        }
        
    }


}
