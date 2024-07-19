using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Interfaces;
using MediatR;

namespace BibliotecaBusiness.Query.User
{
    public class GetUserQuery : IRequest<List<UserDto>>
    {
    }
    public class GetUsersHandler : IRequestHandler<GetUserQuery, List<UserDto>>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public GetUsersHandler(
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetListAsync();
            var usersDto = _mapper.Map<List<BibliotecaDomain.Users.User>, List<UserDto>>(users);
            return usersDto;
        }
    }
}
