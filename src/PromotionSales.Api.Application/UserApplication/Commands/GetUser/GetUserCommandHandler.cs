using MediatR;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Application.UserApplication.Commands.GetUser;

namespace PromotionSales.Api.Application.UserApplication.Commands.GetAll;

internal class GetUserCommandHandler : IRequestHandler<GetUserCommand, String>
{
    private readonly IIdentityService identityService;

    public GetUserCommandHandler(IIdentityService _identityService)
    {
        this.identityService = _identityService ?? throw new ArgumentNullException(nameof(_identityService));
    }

    public Task<string> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
