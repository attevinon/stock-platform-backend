using System.Collections.Generic;
using Stock.Application.Contracts;
using Stock.Application.Service.Interfaces;
using Stock.Domain.Interfaces;
using Stock.Domain.Entities;
using Stock.Domain.Exceptions;
using Mapster;

namespace Stock.Application.Services
{
    /// <summary>
    /// Представляет логику взаимодействия клиента с контент сущностью Текст
    /// </summary>
    public sealed class TextService : ITextService
    {
        //обеспечивает взаимодейтсвие Application с репозиториями (и => базой данных)
        private readonly IRepositoryManager repositoryManager;

        /// <summary>
        /// Конструктор устанавливает репозиторий для взаимодействия с базой данных
        /// </summary>
        /// <param name="repositoryManager"></param>
        public TextService(IRepositoryManager repositoryManager) => this.repositoryManager = repositoryManager;

        public async Task<IEnumerable<TextDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            //поиск всех контент сущностей Текст в базе данных
            var texts = await repositoryManager.Text.GetAllTextsAsync();

            //конвертация контент сущностей Текст в DTO
            var textsDto = texts.Adapt<IEnumerable<TextDto>>();

            return textsDto;
        }

        public async Task<TextDto> CreateText(TextForCreationDto textForCreationDto, CancellationToken cancellationToken = default)
        {
            //выбрасывает исключение если текст с таким ID уже существует
            if (await repositoryManager.Text.GetTextByIdAsync(textForCreationDto.Id) != null)
            {
                throw new DuplicateKeyValueTextException(textForCreationDto.Id);
            }

            //конвертация DTO в контент сущность Текст
            var text = textForCreationDto.Adapt<Text>();

            //поиск в базе данных авторов с никнеймом, указанным пользователем
            Author author = await repositoryManager.Author.GetAuthorByUsername(textForCreationDto.AuthorUsername);

            //если такого автора нет, то он создаётся
            if (author == null)
            {
                author = new Author
                {
                    Username = textForCreationDto.AuthorUsername,
                    Name = textForCreationDto.AuthorName ?? "Unknown",
                    RegistrationDate = DateTime.Now
                };

                repositoryManager.Author.CreateAuthor(author);

                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            }

            text.Length = text.Content.Length;
            text.ProductAuthor = author;

            repositoryManager.Text.CreateText(text);

            //сохранение изменений, если задача не была отменена
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            //конвертация контент сущности Текст в DTO для последующего вывода
            return text.Adapt<TextDto>();
        }

        public async Task<TextDto> GetById(Guid textId, CancellationToken cancellationToken = default)
        {
            var text = await repositoryManager.Text.GetTextByIdAsync(textId, cancellationToken);

            //в случае отсутсвия такого текста возникает исключение
            if (text == null)
                throw new TextNotFoundException(textId);

            //конвертация контент сущности Текст в DTO
            var textDto = text.Adapt<TextDto>();

            return textDto;
        }
    }
}
