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
        var command = new UpdatePromotionCommand { Id = Guid.NewGuid(), Activo = true };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldRequireUniqueTitle()
    {
        var listId = await SendAsync(new CreatePromotionCommand
        {
            Title = "New List"
        });

        await SendAsync(new CreatePromotionCommand
        {
            Title = "Other List"
        });

        var command = new UpdatePromotionCommand
        {
            Id = listId.Id,
            Activo = true
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
            Title = "New List"
        });

        var command = new UpdatePromotionCommand
        {
            Id = listId.Id,
            Activo = true
        };

        await SendAsync(command);

        var list = await FindAsync<Promotion>(listId);

        list.Should().NotBeNull();
        list!.Activo.Should().Be(command.Activo);
        list.LastModifiedBy.Should().NotBeNull();
        list.LastModifiedBy.Should().Be(userId);
        list.LastModified.Should().NotBeNull();
        list.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
