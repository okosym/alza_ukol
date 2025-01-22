using NUnit.Framework;
using AlzaUkol.Application._Shared.Utils;

namespace AlzaUkol.Application.Tests;

[TestFixture]
public class MyFileUtilsTests
{
    [Test]
    public void T01_GetDbFolder_Ok()
    {
        // Arrange
        // Act
        string dbFolder = MyFileUtils.GetDbFolder();

        // Assert
        string dbFileName = Path.Combine(dbFolder, "alza.db");
        Assert.That(File.Exists(dbFileName));
    }
}
