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

        [Test]
        public void Removing_an_element_at_index_should_remove_it_and_resize_the_list()
        {
            list.Add(2);
            list.Add(1);
            list.Add(3);
            list.Add(2);

            list.RemoveAt(2);

            list[0].Should().Be(2);
            list[1].Should().Be(1);
            list[2].Should().Be(2);
            list.Count().Should().Be(3);
        }

        [Test]
        public void Removing_the_first_index_with_RemoveAt_should_work_properly()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(0);

            list[0].Should().Be(2);
            list[1].Should().Be(3);
            list.Count().Should().Be(2);
        }

        [Test]
        public void Removing_the_last_element_should_not_cause_problems_either()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(2);

            list[0].Should().Be(1);
            list[1].Should().Be(2);

            Action act = () => { var _ = list[2]; };
            act.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void Inserting_an_element_at_the_front_should_add_it_to_the_front()
        {
            list.Add(2);
            list.Add(3);

            list.Insert(0, 1);

            list[0].Should().Be(1);
            list[1].Should().Be(2);
            list.Count().Should().Be(3);
        }

        [Test]
        public void Inserting_an_element_in_the_center_should_add_it()
        {
            list.Add(1);
            list.Add(3);
            list.Add(4);

            list.Insert(1, 2);

            list[0].Should().Be(1);
            list[1].Should().Be(2);
            list[2].Should().Be(3);
            list.Count().Should().Be(4);
        }

        [Test]
        public void Inserting_an_element_in_the_last_position_should_insert_it_between_the_last_and_one_before_last()
        {
            list.Add(1);
            list.Add(3);

            list.Insert(1, 2);

            list[0].Should().Be(1);
            list[1].Should().Be(2);
            list[2].Should().Be(3);
        }

        [Test]
        public void Insert_should_throw_error_if_argument_goes_out_of_range()
        {
            list.Add(1);
            list.Add(3);

            Action act = () => list.Insert(-1, 3);
            act.Should().Throw<NullReferenceException>();

            act = () => list.Insert(4, 3);
            act.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void Contains_should_return_true_if_element_is_in_list()
        {
            list.Add(1);
            list.Contains(1).Should().BeTrue();
        }

        [Test]
        public void Contains_should_return_false_if_element_is_not_in_list()
        {
            list.Add(1);
            list.Contains(2).Should().BeFalse();
        }

        [Test]
        public void Contains_should_throw_nullreference_if_list_is_empty()
        {
            Action act = () => list.Contains(1);
            act.Should().Throw<NullReferenceException>();
        }

        public void IndexOf_should_return_the_index_of_element_in_list()
        {
            list.Add(1);
            list.Add(3);
            list.Add(4);

            list.IndexOf(1).Should().Be(0);
            list.IndexOf(4).Should().Be(4);
            list.IndexOf(3).Should().Be(1);
        }

        public void IndexOf_should_return_minus_one_if_the_element_is_not_in_list()
        {
            list.IndexOf(2).Should().Be(-1);
        }
    }
}
