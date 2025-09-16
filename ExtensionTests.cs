using AwesomeAssertions;
using AwesomeAssertions.Specialized;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CsOpdrachten
{
    public class ExtensionTests
    {
        MyLinkedList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new MyLinkedList<int>();
        }

        [Test]
        public void Where_should_return_an_IEnumerable_with_elements_that_match_the_predicate()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            var even = list.MyWhere(n => n % 2 == 0).ToList();

            even[0].Should().Be(2);
            even[1].Should().Be(4);
        }

        [Test]
        public void MyWhere_with_null_source_should_throw_exception_when_trying_to_enumerate_it()
        {
            List<int>? nums = null;

            Action act = () => { var _ = nums!.MyWhere(n => n % 2 == 0).ToList(); };

            act.Should().Throw<ArgumentNullException>();

        }

        [Test]
        public void MyWhere_with_null_predicate_should_throw_exception_when_trying_to_enumerate()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);


            Func<int, bool>? predicate = null;
            Action act = () => list.MyWhere(predicate!).ToList();
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyWhere_should_return_empty_if_nothing_matches_the_predicate()
        {
            list.Add(1);
            list.Add(3);
            list.Add(5);

            var empty = list.MyWhere(x => x % 2 == 0).ToList();

            empty.Should().BeEmpty();
        }

        [Test]
        public void MyWhere_should_return_empty_if_the_list_is_empty()
        {
            var empty = list.MyWhere(x => x > 0).ToList();
            empty.Should().BeEmpty();
        }

        [Test]
        public void Mywhere_enumerator_should_enumerate_properly()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            var toThree = list.MyWhere(x => x < 4).ToList();
            var enumerator = toThree.GetEnumerator();

            enumerator.MoveNext();
            enumerator.Current.Should().Be(1);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(2);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(3);

            enumerator.MoveNext().Should().BeFalse();
        }

        [Test]
        public void MyWhere_with_null_source_should_throw_exception_when_trying_to_enumerate_it_with_index()
        {
            List<int>? nums = null;

            Action act = () => nums!.MyWhere((n, index) => n <= index * 10).ToList();
            act.Should().Throw<ArgumentNullException>();

        }

        [Test]
        public void MyWhere_with_null_predicate_should_throw_exception_when_trying_to_enumerate_with_index()
        {
            Func<int, int, bool>? predicate = null;
            Action act = () => list.MyWhere(predicate!).ToList();
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyWhere_should_return_the_values_where_index_and_element_both_match_predicate()
        {
            list = [1, 2, 31, 4, 60];
            List<int> newList = list.MyWhere((n, index) => n <= index * 10).ToList();
            newList.Should().ContainInOrder(2, 4);
        }

        [Test]
        public void MyWhere_with_index_enumerator_should_enumerate_properly()
        {
            list = [1, 2, 31, 4];
            List<int> newList = list.MyWhere((n, index) => n <= index * 10).ToList();
            var enumerator = newList.GetEnumerator();

            enumerator.MoveNext();
            enumerator.Current.Should().Be(2);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(4);

            enumerator.MoveNext().Should().BeFalse();
        }

        [Test]
        public void MyWhere_with_index_should_return_empty_if_source_is_empty()
        {
            List<int> newList = list.MyWhere((n, index) => true).ToList();
            newList.Should().BeEmpty();
        }

        [Test]
        public void MyWhere_with_index_should_return_empty_if_nothing_matches_the_predicate()
        {
            list.Add(1);
            list.Add(3);
            list.Add(5);

            var empty = list.MyWhere((x, index) => false).ToList();

            empty.Should().BeEmpty();
        }

        [Test]
        public void MySelect_source_if_null_should_throw_exception_when_enumerating()
        {
            List<int>? nums = null;
            Action act = () => { var _ = nums!.MySelect(n => n.ToString()).ToList(); };
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MySelect_selector_if_null_should_throw_exception_when_enumerating()
        {
            Func<int, int>? no = null;
            Action act = () => list.MySelect(no!).ToList();
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MySelect_source_if_null_should_throw_exception_when_enumerating_with_index()
        {
            List<int>? nums = null;

            Action act = () => nums!.MySelect((n, index) => new { index, n }).ToList();
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MySelect_selector_if_null_should_throw_exception_when_enumerating_with_index()
        {
            Func<int, int, int>? no = null;
            Action act = () => list.MySelect(no!).ToList();
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MySelect_should_return_selection_with_index()
        {
            list = [2, 3, 4];
            var newList = list.MySelect((n, index) => n += index).ToList();
            newList.Should().ContainInOrder(2, 4, 6);
        }

        [Test]
        public void MySelect_should_return_empty_if_list_is_empty()
        {
            list.MySelect(n => n.ToString());
            list.Should().BeEmpty();
        }

        [Test]
        public void MySelect_with_index_should_return_empty_if_list_is_empty()
        {
            list.MySelect((n, Index) => true);
            list.Should().BeEmpty();
        }

        [Test]
        public void MySelect_should_return_ints_as_strings()
        {
            string[] stringnums = ["1", "2", "3"];

            List<int> nums = stringnums.MySelect(n => Convert.ToInt32(n)).ToList();
            foreach (var i in nums)
            {
                i.Should().BeOfType(typeof(int));
            }
        }

        [Test]
        public void MySelect_enumerator_should_enumerate_properly()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var toString = list.MySelect(n => n.ToString()).ToList();
            var enumerator = toString.GetEnumerator();

            enumerator.MoveNext();
            enumerator.Current.Should().Be("1");

            enumerator.MoveNext();
            enumerator.Current.Should().Be("2");

            enumerator.MoveNext();
            enumerator.Current.Should().Be("3");

            enumerator.MoveNext().Should().BeFalse();
            toString.Count.Should().Be(3);
        }

        [Test]
        public void MySelect_with_index_enumerator_should_enumerate_properly()
        {
            list.Add(1);
            list.Add(3);
            list.Add(6);

            var toList = list.MySelect((n, index) => new { index, n }).ToList();
            var enumerator = toList.GetEnumerator();

            enumerator.MoveNext();
            enumerator.Current.index.Should().Be(0);
            enumerator.Current.n.Should().Be(1);

            enumerator.MoveNext();
            enumerator.Current.index.Should().Be(1);
            enumerator.Current.n.Should().Be(3);

            enumerator.MoveNext();
            enumerator.Current.index.Should().Be(2);
            enumerator.Current.n.Should().Be(6);

            enumerator.MoveNext().Should().BeFalse();
        }


        [Test]
        public void MyCount_source_if_null_should_throw_exception()
        {
            List<int>? nums = null;
            Action act = () => { var _ = nums!.MyCount(n => n > 0); };
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyCount_predicate_if_null_should_throw_exception()
        {
            Func<int, bool>? no = null;
            Action act = () => list.MyCount(no!);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyCount_source_without_predicacte_if_null_should_throw_exception()
        {
            List<int>? nums = null;
            Action act = () => { var _ = nums!.MyCount(); };
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void If_there_are_no_elements_count_should_be_zero()
        {
            int count = list.MyCount();
            count.Should().Be(0);
        }

        [Test]
        public void MyCount_should_return_count_of_elements()
        {
            list = [1, 2, 3];
            int count = list.MyCount();
            count.Should().Be(3);
        }
        [Test]
        public void MyCount_should_return_count_of_elements_matching_predicate()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            int count = list.MyCount(n => n % 2 == 0);
            count.Should().Be(2);
        }

        [Test]
        public void If_nothing_matches_predicate_count_should_be_zero()
        {
            int matches = list.MyCount(n => n > 0);
            matches.Should().Be(0);
        }


        [Test]
        public void MyAny_source_if_null_should_throw_exception_when_enumerating()
        {
            List<int>? nums = null;
            Action act = () => nums!.MyAny(n => n > 0);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyAny_predicate_if_null_should_throw_exception_when_enumerating()
        {
            Func<int, bool>? no = null;
            Action act = () => list.MyAny(no!);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyAny_should_return_false_if_none_of_the_elements_fit_the_predicate()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            bool containsNegative = list.MyAny(n => n < 0);

            containsNegative.Should().BeFalse();
        }


        [Test]
        public void MyAny_should_return_true_if_any_of_the_elements_fit_the_predicate()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(-1);

            bool containsNegative = list.MyAny(n => n < 0);

            containsNegative.Should().BeTrue();
        }

        [Test]
        public void MyAny_should_return_false_if_the_list_is_empty_with_predicates()
        {
            bool containsNegative = list.MyAny(n => n < 0);
            containsNegative.Should().BeFalse();
        }


        [Test]
        public void MyAny_enumerator()
        {
            list.Add(1);
            list.Add(2);
            list.Add(-1);
            var enumerator = list.GetEnumerator();

            enumerator.MoveNext();
            enumerator.Current.Should().Be(1);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(2);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(-1);

            enumerator.MoveNext().Should().BeFalse();

        }

        [Test]
        public void MyAny_should_return_true_if_source_contains_elements()
        {
            list.Add(1);
            bool notEmpty = list.MyAny();
            notEmpty.Should().BeTrue();
        }

        [Test]
        public void MyAny_should_return_false_if_source_doesnt_contain_elements()
        {
            bool empty = list.MyAny();
            empty.Should().BeFalse();
        }

        [Test]
        public void Short_MyAny_should_throw_exception_if_source_is_null()
        {
            List<int>? nolist = null;
            Action act = () => { var _ = nolist!.MyAny(); };
            act.Should().Throw<ArgumentNullException>();

        }

        [Test]
        public void MyFirstOrDefault_should_throw_exception_if_source_is_null()
        {
            List<int>? nolist = null;
            Action act = () => nolist!.MyFirstOrDefault();
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyFirstOrDefault_should_return_default_if_source_is_empty()
        {

            int value = list.MyFirstOrDefault();
            value.Should().Be(default);
        }

        [Test]
        public void MyFirstOrDefault_with_custom_default_should_throw_exception_if_source_is_null()
        {
            List<int>? nolist = null;
            Action act = () => nolist!.MyFirstOrDefault(3);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyFirstOrDefault_with_custom_default_should_return_default_if_source_is_empty()
        {
            int value = list.MyFirstOrDefault(3);
            value.Should().Be(3);
        }

        [Test]
        public void MyFirstOrDefault_with_custom_default_and_predicate_should_throw_exception_if_source_is_null()
        {
            List<int>? nolist = null;
            Action act = () => nolist!.MyFirstOrDefault(n => n < 0, 3);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyFirstOrDefault_with_custom_default_and_predicate_should_throw_exception_if_predicate_is_null()
        {
            Func<int, bool>? isnull = null!;
            Action act = () => list.MyFirstOrDefault(isnull, 5);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyFirstOrDefault_with__predicate_should_throw_exception_if_source_is_null()
        {
            List<int>? nolist = null;
            Action act = () => nolist!.MyFirstOrDefault(n => n < 0);
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyFirstOrDefault_with_predicate_should_throw_exception_if_predicate_is_null()
        {
            list.Add(1);

            Func<int, bool>? isnull = null!;
            Action act = () => list.MyFirstOrDefault(isnull);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void MyFirstOrDefault_with__predicate_should_return_default_if_source_is_null()
        {
            int value = list.MyFirstOrDefault(n => n < 0);
            value.Should().Be(default);
        }

        [Test]
        public void MyFirstOrDefault_should_return_the_first_value_if_there_is_one()
        {
            list.Add(1);
            int first = list.MyFirstOrDefault();
            first.Should().Be(1);
        }

        [Test]
        public void MyFirstOrDefault_should_return_default_if_theres_no_value()
        {
            int first = list.MyFirstOrDefault();
            first.Should().Be(default);
        }

        [Test]
        public void MyFirstOrDefault_enumerator_should_return_values_in_correct_order()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var enumerator = list.GetEnumerator();

            enumerator.MoveNext();
            enumerator.Current.Should().Be(1);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(2);

            enumerator.MoveNext();
            enumerator.Current.Should().Be(3);

            enumerator.MoveNext().Should().BeFalse();
        }

        [Test]
        public void MyFirstOrDefault_with_custom_default_should_return_the_first_value_if_there_is_one()
        {
            list.Add(1);
            int first = list.MyFirstOrDefault(3);
            first.Should().Be(1);
        }

        [Test]
        public void MyFirstOrDefault_with_custom_default_should_return_the_custom_default_value_if_there_is_one()
        {
            int first = list.MyFirstOrDefault(3);
            first.Should().Be(3);
        }

        [Test]
        public void MyFirstOrDefault_should_return_the_first_value_matching_the_predicate()
        {
            list.Add(1);
            list.Add(2);

            int first = list.MyFirstOrDefault(n => n % 2 == 0);
            first.Should().Be(2);
        }

        [Test]
        public void MyFirstOrDefault_should_return_the_default_value_if_none_match_the_predicate()
        {
            list.Add(1);
            list.Add(2);

            int first = list.MyFirstOrDefault(n => n < 0);
            first.Should().Be(0);
        }

        [Test]
        public void MyFirstOrDefault_should_return_the_default_custom_value_if_none_match_the_predicate()
        {
            list.Add(1);
            list.Add(2);

            int first = list.MyFirstOrDefault(n => n < 0, 4);
            first.Should().Be(4);
        }
        [Test]
        public void MyFirstOrDefault_should_return_the_default_custom_value_if_the_source_is_empty_with_predicate()
        {
            int first = list.MyFirstOrDefault(n => n < 0, 4);
            first.Should().Be(4);
        }

        [Test]
        public void MyFirstOrDefault_with_custom_default_should_return_the_value_that_matches_the_predicate()
        {
            list.Add(1);
            list.Add(2);
            list.Add(-2);

            int first = list.MyFirstOrDefault(n => n < 0, 4);
            first.Should().Be(-2);
        }
    }
}
