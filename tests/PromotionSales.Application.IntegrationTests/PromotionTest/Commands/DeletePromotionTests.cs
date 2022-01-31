using PromotionSales.Api.Application.Common.Exceptions;
using PromotionSales.Api.Application.PromotionApplication.Commands.CreatePromotion;
using PromotionSales.Api.Application.PromotionApplication.Commands.DeletePromotion;
using PromotionSales.Api.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using PromotionSales.Application.IntegrationTests;

namespace PromotionSales.Api.Application.IntegrationTests.PromotionTest.Commands;

using static Testing;

public class DeletePromotionTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeletePromotionCommand { Id = Guid.NewGuid() };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreatePromotionCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeletePromotionCommand
        {
            Id = listId.Id
        });

        var list = await FindAsync<Promotion>(listId);

        list.Should().BeNull();
    }
}
