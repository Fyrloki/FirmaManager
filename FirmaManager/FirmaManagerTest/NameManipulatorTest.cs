using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirmaManagerTest.Test
{
    /// <summary>
    /// NameManipulator no longer exists in the client. However, it will be reinstalled in the business layer as soon as it is needed again.
    /// </summary>
    [TestClass]
    public class NameManipulatorTest
    {
        [DataTestMethod]
        [DataRow("xxxx", "xxxx")]
        [DataRow("xxxx xxxx", "xxxx xxxx")]
        [DataRow("xxxx   xxxx", "xxxx xxxx")]
        [DataRow("xxxx -xxxx", "xxxx-xxxx")]
        [DataRow("xxxx- xxxx", "xxxx-xxxx")]
        [DataRow("  xxxx  ", "xxxx")]
        [DataRow("xxxx--xxxx", "xxxx--xxxx")]
        [DataRow("-", "-")]
        [DataRow("-xxxx", "-xxxx")]
        [DataRow("xxxx-", "xxxx-")]
        [DataRow("- -xxxx", "--xxxx")]
        [DataRow("xxxx- -", "xxxx--")]
        public void GetCleanedNameTest_Success(string name, string expectedCleanedName)
        {
            //Arrange 
            //INameManipulator nameManipulator = new NameManipulator();

            ////Act
            //string cleanedName = nameManipulator.GetCleanedName(name);

            ////Assert
            //Assert.AreEqual(expectedCleanedName, cleanedName);
        }
    }
}
