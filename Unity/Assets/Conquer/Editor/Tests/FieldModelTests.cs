using NUnit.Framework;
using System.Collections.Generic;
using Assets.Conquer.Scripts.Models;
using Assets.UI.Windows.Tools.Editor;
using Conquer.Info;
using UnityEngine;

[TestFixture]
public class FieldModelTests
{

    [OneTimeSetUp]
    public void Initialize()
    {
        
    }

    [Test]
    public void GridSizeTest()
    {
        var size = new Vector2Int(10, 16);
        var grid = new ConquerFieldModel(size);
        Assert.IsTrue(size == grid.Size);
    }

    [Test]
    public void EmptyGridTest()
    {
        var size = new Vector2Int(10, 16);
        var grid = new ConquerFieldModel(size);
        for (int row = 0; row < grid.Size.y; row++)
        {
            for (int column = 0; column < grid.Size.x; column++)
            {
                var item = grid[row, column];
                Assert.IsTrue(item.Owner == 0);
                Assert.IsTrue(item.Position.x == column && item.Position.y == row);
            }
        }
    }
    
    [Test]
    public void PutItemGridTest([NUnit.Framework.Range(0,19, 1)] int x,[NUnit.Framework.Range(0,15, 1)] int y)
    {
        var size = new Vector2Int(10, 16);
        var grid = new ConquerFieldModel(size);

        var row = y;
        var column = x;
        var ownerValue = 2;
        
        Assert.IsTrue(grid[row,column].Owner == 0);
        
        grid.SetOwner(row,column,ownerValue);
        
        Assert.IsTrue(grid[row,column].Owner == ownerValue);
    }

    
    [Test]
    public void PutIntoGridTest()
    {
        var grid = new ConquerFieldModel(new Vector2Int());
        
    }



}
