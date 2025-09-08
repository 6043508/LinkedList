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
        public void When_trying_to_get_list_item_by_index_it_returns_the_correct_value()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list[0].Should().Be(1);
            list[1].Should().Be(2);
            list[2].Should().Be(3);
        }
        [Test]
        public void Setting_element_at_index_should_change_the_element_at_that_index()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list[0] = 4;
            list[2] = 73;

            list[0].Should().Be(4);
            list[1].Should().Be(2);
            list[2].Should().Be(73);

        }


        [Test]
        public void When_an_element_is_added_list_should_contain_element()
        {
            list.Add(7);
            list[0].Should().Be(7);
        }


        [Test]
        public void When_an_element_is_added_it_should_be_added_at_the_end()
        {
            list.Add(7);
            list.Add(8);
            list[1].Should().Be(8);
        }
        [Test]
        public void List_should_be_empty_after_clearing_it()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Clear();
            list.Count().Should().Be(0);
        }
        [Test]
        public void Count_should_return_the_length_of_list()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(2);
            list.Add(2);

            list.Count().Should().Be(5);
        }

        [Test]
        public void RemoveAt_should_remove_the_element_from_the_list_at_the_specified_index()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveAt(1);
            list[0].Should().Be(1);
            list[1].Should().Be(3);
        }

        [Test]
        public void IndexOf_should_return_position_of_element_in_list()
        {
            list.Add(3);
            list.Add(7);
            list.Add(2);
            list.Add(21);
            list.IndexOf(3).Should().Be(0);
            list.IndexOf(2).Should().Be(2);
            list.IndexOf(7).Should().Be(1);
            list.IndexOf(21).Should().Be(3);
        }

        [Test]
        public void If_IndexOf_cant_find_the_element_it_should_return_negative()
        {
            list.IndexOf(2).Should().Be(-1);
        }

        [Test]
        public void Contains_returns_true_if_the_list_contains_an_element()
        {
            list.Add(4);
            list.Contains(4).Should().BeTrue();
        }

        [Test]
        public void Contains_returns_false_if_list_doesnt_contain_an_element()
        {
            list.Contains(3).Should().BeFalse();
        }

        [Test]
        public void Insert_adds_an_element_at_the_specified_index()
        {
            list.Add(1);
            list.Add(3);
            list.Insert(1, 2);

            list[0].Should().Be(1);
            list[1].Should().Be(2);
            list[2].Should().Be(3);
        }

        [Test]
        public void RemoveAt_removes_the_first_element_found_in_list()
        {
            list.Add(3);
            list.Add(1);
            list.Add(3);

            list.Remove(3);
            list[0].Should().Be(1);
            list[1].Should().Be(3);
        }
    }
}
