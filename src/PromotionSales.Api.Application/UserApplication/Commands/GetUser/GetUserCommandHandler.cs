using MediatR;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Application.UserApplication.Commands.GetUser;

namespace PromotionSales.Api.Application.UserApplication.Commands.GetAll;

internal class GetUserCommandHandler : IRequestHandler<GetUserCommand, String>
{
    private readonly IIdentityService identityService;
    private readonly ITokenSignerService tokenSignerService;

    public GetUserCommandHandler(IIdentityService _identityService, ITokenSignerService _tokenSignerService)
    {
        this.identityService = _identityService ?? throw new ArgumentNullException(nameof(_identityService));
        this.tokenSignerService = _tokenSignerService ?? throw new ArgumentNullException(nameof(_tokenSignerService));
    }

    public async Task<string> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = await this.identityService.AuthenticateAsync(request.Email, request.Password);
        var jwtToken = this.tokenSignerService.SignToken(user);
        return jwtToken;
    }
}
