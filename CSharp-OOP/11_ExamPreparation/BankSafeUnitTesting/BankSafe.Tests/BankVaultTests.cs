using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("Whos your dadyy", "1");
        }

        [Test]
        public void AddItem_WhenCellExists()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("nqma vault", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void AddItem_WhenCellAlreadyTaken()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
               
                vault.AddItem("A1", item);
                vault.AddItem("A1", new Item("pesho","2"));
            });

            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }

        [Test]
        public void AddItem_WhenItemAlreadyInCell()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {

                vault.AddItem("A1", item);
                vault.AddItem("A2", item);
            });

            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }

        [Test]
        public void AddItem_WhenItemIsAddedSuccesfully()
        {
            string result = vault.AddItem("B2", item);

            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void RemoveItem_WhenCellExists()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("nqma vault", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }


        [Test]
        public void RemoveItem_WhenItemInThatCellDontExist()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A2", item);
            });

            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveItem_WhenItemIsRemovedSuccesfully()
        {
            vault.AddItem("B2", item);
            string result = vault.RemoveItem("B2", item);

            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }
    }
}