using AwesomeAssertions;

namespace CsOpdrachten
{
    public class Tests
    {
        MyLinkedList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new MyLinkedList<int>();
        }

        [Test]
        public void Adding_an_element_will_add_it_to_the_end_of_list()
        {
            list.Add(1);
            list.Add(2);
            list[0].Should().Be(1);
            list[1].Should().Be(2);
        }

        [Test]
        public void Setting_an_element_will_change_the_value_at_specified_index()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);

            list[3] = 4;

            list[3].Should().Be(4);
        }

        [Test]
        public void Removing_element_should_remove_it_and_the_list_should_resize()
        {
            list.Add(1);
            list.Add(3);
            list.Add(2);
            list.Add(3);

            list.Remove(3);
            list[0].Should().Be(1);
            list[1].Should().Be(2);

            list.Count().Should().Be(3);
        }

        [Test]
        public void Removing_the_first_element_should_only_remove_one_number()
        {
            list.Add(2);
            list.Add(1);
            list.Add(3);
            list.Add(2);

            list.Remove(2);
            list[0].Should().Be(1);
            list[1].Should().Be(3);
            list[2].Should().Be(2);
            list.Count().Should().Be(3);
        }

        [Test]
        public void Clearing_the_list_should_emtpy_the_list()
        {
            list.Add(2);
            list.Add(1);
            list.Add(3);
            list.Clear();
            list.Count().Should().Be(0);
        }
    }
}
