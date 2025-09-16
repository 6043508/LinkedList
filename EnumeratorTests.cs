using AwesomeAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsOpdrachten
{
    public class EnumeratorTests
    {
        MyLinkedList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new MyLinkedList<int>();
        }

        [Test]
        public void Checks_the_enumerator_output()
        {
            var enumerator = list.GetEnumerator();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(1);
            enumerator.MoveNext();
            enumerator.Current.Should().Be(2);
            enumerator.MoveNext();
            enumerator.Current.Should().Be(3);
            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(4);
            enumerator.MoveNext().Should().BeFalse();
        }

        [Test]
        public void Enumerator_move_next_should_be_false_when_list_is_empty()
        {
            var enumerator = list.GetEnumerator();
            enumerator.MoveNext().Should().BeFalse();
        }

        [Test]
        public void Checks_the_output_of_foreach()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            List<int> newList = [];

            foreach (var i in list)
                newList.Add(i);

            newList.Should().ContainInOrder(1, 2, 3, 4);
        }
    }
}
