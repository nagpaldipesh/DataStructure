using DataStructurePractice.Stack;
using Shouldly;

namespace DataStructure.Tests.Stack
{

    [TestFixture]
    public class AnimalShelterTests
    {
        private AnimalShelter shelter;

        [SetUp]
        public void SetUp()
        {
            shelter = new AnimalShelter();
        }

        [Test]
        public void Enqueue_ShouldAddAnimalToShelter()
        {
            var animal = new Animal { Name = "Bella", Type = AnimalType.Cat };
            shelter.Enqueue(animal);

            shelter.DequeueAny().ShouldBe(animal);
        }

        [Test]
        public void DequeueAny_ShouldReturnAnimalsInFIFOOrder()
        {
            var cat = new Animal { Name = "Kitty", Type = AnimalType.Cat };
            var dog = new Animal { Name = "Rex", Type = AnimalType.Dog };
            shelter.Enqueue(cat);
            shelter.Enqueue(dog);

            shelter.DequeueAny().ShouldBe(cat);
            shelter.DequeueAny().ShouldBe(dog);
        }

        [Test]
        public void DequeueCat_ShouldReturnOldestCat()
        {
            var cat1 = new Animal { Name = "Mittens", Type = AnimalType.Cat };
            var dog = new Animal { Name = "Buddy", Type = AnimalType.Dog };
            var cat2 = new Animal { Name = "Whiskers", Type = AnimalType.Cat };
            shelter.Enqueue(cat1);
            shelter.Enqueue(dog);
            shelter.Enqueue(cat2);

            shelter.DequeueCat().ShouldBe(cat1);
        }

        [Test]
        public void DequeueDog_ShouldReturnOldestDog()
        {
            var dog1 = new Animal { Name = "Fido", Type = AnimalType.Dog };
            var cat = new Animal { Name = "Luna", Type = AnimalType.Cat };
            var dog2 = new Animal { Name = "Bolt", Type = AnimalType.Dog };
            shelter.Enqueue(dog1);
            shelter.Enqueue(cat);
            shelter.Enqueue(dog2);

            shelter.DequeueDog().ShouldBe(dog1);
            shelter.DequeueAny().ShouldBe(cat);
            shelter.DequeueAny().ShouldBe(dog2);
        }

        [Test]
        public void DequeueAny_ShouldThrowException_WhenNoAnimalsAvailable()
        {
            Should.Throw<InvalidOperationException>(() => shelter.DequeueAny());
        }

        [Test]
        public void DequeueCat_ShouldThrowException_WhenNoCatsAvailable()
        {
            shelter.Enqueue(new Animal { Name = "Buddy", Type = AnimalType.Dog });
            Should.Throw<InvalidOperationException>(() => shelter.DequeueCat());
        }

        [Test]
        public void DequeueDog_ShouldThrowException_WhenNoDogsAvailable()
        {
            shelter.Enqueue(new Animal { Name = "Whiskers", Type = AnimalType.Cat });
            Should.Throw<InvalidOperationException>(() => shelter.DequeueDog());
        }
    }
}
