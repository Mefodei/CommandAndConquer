using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.UI.Windows.Tools.Editor;
using Conquer.Scripts.Field;
using Conquer.Scripts.Info;
using UniStateMachine.Nodes;
using UnityEditor;
using UnityEngine;

namespace Assets.Conquer.Editor
{
    public class ConquerEditorCommands
    {
        private const string SkinsFolderPath = "SkinInfos";

        [MenuItem(itemName:"Conquer/Update Cell Skins")]
        public static void UpdateCellsSkins()
        {

            var skinsMap = AssetEditorTools.GetAssets<CellItemsMapInfo>().FirstOrDefault();

            var cellSkins = AssetEditorTools.GetComponentAssets<CellItemView>();
            var graphs = AssetEditorTools.GetAssets<UniStatesGraph>();

            var mapPath = AssetDatabase.GetAssetPath(skinsMap);
            var skinPaths = cellSkins.Select(x => AssetDatabase.GetAssetPath(x)).ToList();
            var skinTypes = skinPaths.ToDictionary(x => x,x => Path.GetFileName(Path.GetDirectoryName(x).ToLowerInvariant()));
            var mapFolder = Path.GetDirectoryName(mapPath);
            var skinFolder = mapFolder + "\\" + SkinsFolderPath + "\\";

            skinsMap.Clear();

            if (Directory.Exists(skinFolder))
            {
                Directory.Delete(skinFolder,true);
            }

            if (!Directory.Exists(skinFolder))
            {
                Directory.CreateDirectory(skinFolder);
            }
            
            var skins = new Dictionary<string, CellSkinsInfo>();

            for (var i = 0; i < cellSkins.Count; i++)
            {
                var cellItemView = cellSkins[i];
                var path = skinPaths[i];
                var skinType = skinTypes[path];

                var skinDirectory = skinFolder + skinType;

                if(!skins.TryGetValue(skinType,out var skinInfo))
                {
                    skinInfo = AssetEditorTools.
                        CreateAsset<CellSkinsInfo>("skin_type_" + skinType, skinFolder);

                    skins[skinType] = skinInfo;
                    skinInfo.Name = skinType;
                    skinInfo.CellItemInfos = new List<CellItemInfo>();
                    
                    EditorUtility.SetDirty(skinInfo);
                    
                }

                if (!Directory.Exists(skinDirectory))
                {
                    Directory.CreateDirectory(skinDirectory);
                }

                var skinItemInfo = AssetEditorTools.CreateAsset<CellItemInfo>(skinType+"_skin_"+i, skinDirectory);
                skinInfo.CellItemInfos.Add(skinItemInfo);
                var behaviourName = string.Format($"{skinType}_cell_actor");
                var graph = graphs.FirstOrDefault(x =>
                    string.Equals(behaviourName, x.name, StringComparison.InvariantCultureIgnoreCase));
                skinItemInfo.Initialize(skinType, graph, cellItemView);

                EditorUtility.SetDirty(skinItemInfo);
            }

            foreach (var skin in skins)
            {
                skinsMap.Add(skin.Value);
                EditorUtility.SetDirty(skin.Value);
                foreach (var itemInfo in skin.Value.CellItemInfos)
                {
                    EditorUtility.SetDirty(itemInfo);
                }
            }

            EditorUtility.SetDirty(skinsMap);
            
            AssetDatabase.SaveAssets();

        }

    }
}
