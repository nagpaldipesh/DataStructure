
namespace DataStructurePractice.Stack
{
    public enum AnimalType
    {
        Dog,
        Cat
    }
    public class Animal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AnimalType Type { get; set; }
    }

    public class AnimalShelter
    {
        LinkedList<Animal> animals;

        public AnimalShelter()
        {
            animals = new LinkedList<Animal>();
        }

        //        Animal Shelter: An animal shelter, which holds only dogs and cats, operates on a strictly"first in, first
        //        out" basis. People must adopt either the "oldest" (based on arrival time) of all animals at the shelter,
        //        or they can select whether they would prefer a dog or a cat(and will receive the oldest animal of
        //        that type). They cannot select which specific animal they would like.Create the data structures to
        //        maintain this system and implement operations such as enqueue, dequeueAny, dequeueDog,
        //        and dequeueCat.You may use the built-in Linked list data structure. 

        public void Enqueue(Animal animal)
        {
            animals.AddLast(animal);
        }

        public Animal DequeueAny()
        {
            var animal = animals.First();
            animals.RemoveFirst();
            return animal;
        }

        public Animal DequeueCat()
        {
            return DequeueAnimalByType(AnimalType.Cat);
        }

        public Animal DequeueDog()
        {
            return DequeueAnimalByType(AnimalType.Dog);
        }

        public Animal DequeueAnimalByType(AnimalType type)
        {
            if (animals.Count == 0)
                throw new InvalidOperationException("Linked List is empty!");

            var node = animals.First;

            while (node != null && node.Value.Type != type)
            {
                node = node.Next;
            }
            
            if (node != null && node.Value.Type == type)
            {
                animals.Remove(node);
                return node.Value;
            }

            throw new InvalidOperationException($"Animal {type} is not present in List");
        }
    }
}
