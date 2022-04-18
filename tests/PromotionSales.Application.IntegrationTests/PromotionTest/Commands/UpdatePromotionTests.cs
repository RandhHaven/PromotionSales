using PromotionSales.Api.Application.Common.Exceptions;
using PromotionSales.Api.Application.PromotionApplication.Commands.CreatePromotion;
using PromotionSales.Api.Application.PromotionApplication.Commands.UpdatePromotion;
using PromotionSales.Api.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using PromotionSales.Application.IntegrationTests;

namespace PromotionSales.Api.Application.IntegrationTests.TodoLists.Commands;

using static Testing;

public class UpdatePromotionTests : TestBase
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new UpdatePromotionCommand { Id = Guid.NewGuid(), Active = true };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldRequireUniqueTitle()
    {
        var listId = await SendAsync(new CreatePromotionCommand
        {
            Active = true
        });

        await SendAsync(new CreatePromotionCommand
        {
            Active = true
        });

        var command = new UpdatePromotionCommand
        {
            Id = listId,
            Active = true
        };

        (await FluentActions.Invoking(() =>
            SendAsync(command))
                .Should().ThrowAsync<ValidationException>().Where(ex => ex.Errors.ContainsKey("Title")))
                .And.Errors["Title"].Should().Contain("The specified title already exists.");
    }

    [Test]
    public async Task ShouldUpdateTodoList()
    {
        var userId = await RunAsDefaultUserAsync();

        var listId = await SendAsync(new CreatePromotionCommand
        {
            Active = true
        });

        var command = new UpdatePromotionCommand
        {
            Id = listId,
            Active = true
        };

        await SendAsync(command);

        var list = await FindAsync<Promotion>(listId);

        list.Should().NotBeNull();
        list!.Active.Should().Be(command.Active);
        list.LastModifiedByUserId.Should().NotBeNull();
        list.LastModifiedByUserId.Should().Be(userId);
        list.LastDateModified.Should().NotBeNull();
        list.LastDateModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}