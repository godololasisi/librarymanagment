using AutoMapper;
using BibliotecaBusiness.Common.Util;
using BibliotecaBusiness.DTOs;
using BibliotecaBusiness.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBusiness.Command.Book
{
    public class RegisterBookCommand : IRequest<Unit>
    {
        /// <summary>
        /// CountBooks recovered from Book controller api
        /// </summary>
        /// <example></example>
        public int CountBooks { get; set; }

        /// <summary>
        /// NameBook recovered from Book controller api
        /// </summary>
        /// <example></example>
        public string? NameBook { get; set; }

        /// <summary>
        /// IdAuthor recovered from Book controller api
        /// </summary>
        /// <example></example>
        public string? IdAuthor { get; set; }

        /// <summary>
        /// DonatedBy recovered from Book controller api
        /// </summary>
        /// <example></example>
        public string? DonatedBy { get; set; }
    }

    public class RegisterBookHandler : IRequestHandler<RegisterBookCommand, Unit>
    {
        private IBookRepository _bookRepository;
        private IPushNotificationRepository _pushNotificationRepository;
        private readonly IMapper _mapper;
        public RegisterBookHandler(
            IBookRepository bookRepository,
            IPushNotificationRepository pushNotificationRepository,
            IMapper mapper
            )
        {
            _bookRepository = bookRepository;
            _pushNotificationRepository = pushNotificationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(RegisterBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<RegisterBookCommand, RegisterBookDto>(request);

            // Registrar libro en bd
            await _bookRepository.RegisterBookAsync(book);

            // Armar objeto para envio de notificación Push
            var pushDto = Utils.CreateObjectPush(book);

            // Envío de push notification
            //await _pushNotificationRepository.SendPushNotification(pushDto);

            return Unit.Value;

        }
    }
}
