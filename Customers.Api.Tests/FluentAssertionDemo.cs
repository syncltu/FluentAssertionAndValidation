namespace Customers.Api.Tests;

using FluentAssertions;
using System;
using Services;

public class FluentAssertionDemo
{
    [Fact]
    public void StringTest()
    {
        //Arrange
        var actual = "ABCDEFGHI";

        //Assert
        actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);

        Assert.StartsWith("AB", actual);
        Assert.EndsWith("HI", actual);
        Assert.Contains("EF", actual);
        Assert.Equal(9, actual.Length);
    }

    [Fact]
    public void IntegerTest()
    {
        const int number = 100;
        number.Should().Be(100);
        number.Should().BePositive();
        number.Should().BeGreaterThanOrEqualTo(100);
        number.Should().BeGreaterThan(50);
        number.Should().BeLessThanOrEqualTo(1000);
        number.Should().BeLessThan(500);
        number.Should().BeInRange(1, 100);
    }

    [Fact]
    public void CollectionTest()
    {
        //Arrange
        var numbers = new[] { 1, 2, 3 };

        //Assert
        numbers.Should().OnlyContain(n => n > 0);
        Assert.All(numbers, x => Assert.True(x > 0));

        numbers.Should().HaveCount(4, "because we thought we put four items in the collection");
        Assert.Equal(4, numbers.Length);
    }

    [Fact]
    public void ExceptionThrowTest()
    {
        //Arrange
        var service = new AlwaysFailingService();

        //Act 
        var action = () =>
        {
            service.Execute();
        };

        //Assert

        action.Should().Throw<NotImplementedException>();
        Assert.Throws<NotImplementedException>(action);
    }
}

