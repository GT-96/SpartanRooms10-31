using NUnit.Framework;
using SpartanRoomsData.Models;
namespace TestCases1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RoomTest()
        {
            Room Room = new Room();
            Room.ID = 5;
            var ID = Room.ID;
            Assert.AreEqual(ID, 5);

        }


    }
}